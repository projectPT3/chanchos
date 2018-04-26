
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/25/2018 20:08:38
-- Generated from EDMX file: C:\Users\Nazihah Jamal\source\repos\chanchos\chanchos\Models\databaseChanchos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__cart__productId__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[carts] DROP CONSTRAINT [FK__cart__productId__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__Order__userId__5AEE82B9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK__Order__userId__5AEE82B9];
GO
IF OBJECT_ID(N'[dbo].[FK__OrderDeta__Order__5EBF139D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Order__5EBF139D];
GO
IF OBJECT_ID(N'[dbo].[FK__OrderDeta__Produ__5FB337D6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Produ__5FB337D6];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[carts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[carts];
GO
IF OBJECT_ID(N'[dbo].[ChanchosUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChanchosUsers];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OrderDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetails];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'carts'
CREATE TABLE [dbo].[carts] (
    [recordId] int  NOT NULL,
    [cartId] varchar(50)  NULL,
    [productId] int  NULL,
    [date] datetime  NULL,
    [count] int  NULL
);
GO

-- Creating table 'ChanchosUsers'
CREATE TABLE [dbo].[ChanchosUsers] (
    [userId] int IDENTITY(1,1) NOT NULL,
    [name] varchar(50)  NULL,
    [passwords] varchar(6)  NULL,
    [age] int  NULL,
    [address] varchar(30)  NULL,
    [phoneNo] varchar(50)  NULL,
    [roles] varchar(50)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [orderId] int IDENTITY(1,1) NOT NULL,
    [userId] int  NOT NULL,
    [Total] decimal(18,0)  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailId] int  NOT NULL,
    [OrderId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductName] varchar(50)  NULL,
    [Price] decimal(18,0)  NULL,
    [status] varchar(10)  NULL,
    [ProductImage] varchar(max)  NULL,
    [quantity] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [recordId] in table 'carts'
ALTER TABLE [dbo].[carts]
ADD CONSTRAINT [PK_carts]
    PRIMARY KEY CLUSTERED ([recordId] ASC);
GO

-- Creating primary key on [userId] in table 'ChanchosUsers'
ALTER TABLE [dbo].[ChanchosUsers]
ADD CONSTRAINT [PK_ChanchosUsers]
    PRIMARY KEY CLUSTERED ([userId] ASC);
GO

-- Creating primary key on [orderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([orderId] ASC);
GO

-- Creating primary key on [OrderDetailId] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([OrderDetailId] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [productId] in table 'carts'
ALTER TABLE [dbo].[carts]
ADD CONSTRAINT [FK__cart__productId__49C3F6B7]
    FOREIGN KEY ([productId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__cart__productId__49C3F6B7'
CREATE INDEX [IX_FK__cart__productId__49C3F6B7]
ON [dbo].[carts]
    ([productId]);
GO

-- Creating foreign key on [userId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__userId__5AEE82B9]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[ChanchosUsers]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__userId__5AEE82B9'
CREATE INDEX [IX_FK__Order__userId__5AEE82B9]
ON [dbo].[Orders]
    ([userId]);
GO

-- Creating foreign key on [OrderId] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK__OrderDeta__Order__5EBF139D]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([orderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderDeta__Order__5EBF139D'
CREATE INDEX [IX_FK__OrderDeta__Order__5EBF139D]
ON [dbo].[OrderDetails]
    ([OrderId]);
GO

-- Creating foreign key on [ProductId] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK__OrderDeta__Produ__5FB337D6]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderDeta__Produ__5FB337D6'
CREATE INDEX [IX_FK__OrderDeta__Produ__5FB337D6]
ON [dbo].[OrderDetails]
    ([ProductId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------