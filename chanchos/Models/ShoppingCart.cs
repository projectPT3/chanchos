using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chanchos.Models
{
    public partial class ShoppingCart
    {
        databaseChanchosEntities storeDB = new databaseChanchosEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Product album)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.carts.SingleOrDefault(
                c => c.cartId == ShoppingCartId
                && c.productId == album.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new cart
                {
                    productId = album.Id,
                    cartId = ShoppingCartId,
                    count = 1,
                    date = DateTime.Now
                };
                storeDB.carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.count++;
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.carts.Single(
                cart => cart.cartId == ShoppingCartId
                && cart.recordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.count > 1)
                {
                    cartItem.count--;
                    itemCount = cartItem.count;
                }
                else
                {
                    storeDB.carts.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = storeDB.carts.Where(
                cart => cart.cartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public List<cart> GetCartItems()
        {
            return storeDB.carts.Where(
                cart => cart.cartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.carts
                          where cartItems.cartId == ShoppingCartId
                          select (int?)cartItems.count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in storeDB.carts
                              where cartItems.cartId == ShoppingCartId
                              select (int?)cartItems.count *
                              cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.productId,
                    OrderId = order.orderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.count * item.Product.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.total = orderTotal;

            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.orderId;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.carts.Where(
                c => c.cartId == ShoppingCartId);

            foreach (cart item in shoppingCart)
            {
                item.cartId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}