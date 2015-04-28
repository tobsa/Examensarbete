DROP TABLE Cart;

-- Save our precious 
--INSERT INTO SavedOrderDetail SELECT * FROM OrderDetail;
DROP TABLE OrderDetail;

-- Save our precious 
--INSERT INTO SavedOrder SELECT * FROM [Order];
DROP TABLE [Order];

DROP TABLE Product;
DROP TABLE Category;
DROP TABLE [User];
DROP TABLE RecommendationResult;
DROP TABLE __MigrationHistory;


-- Save our precious 
INSERT INTO SavedOrderDetail SELECT * FROM OrderDetail;


-- Save our precious 
INSERT INTO SavedOrder SELECT * FROM [Order];


CREATE TABLE [dbo].[SavedOrder] (
    [OrderId]    INT             NOT NULL,
    [Username]   NVARCHAR (MAX)  NULL,
    [Age]        INT             NOT NULL,
    [Sex]        BIT             NOT NULL,
    [Total]      DECIMAL (18, 2) NOT NULL,
    [OrderDate]  DATETIME        NOT NULL,
    [IsWebOrder] BIT             NOT NULL,
    [IpAddress]  NVARCHAR (MAX)  NULL,
);


CREATE TABLE [dbo].[SavedOrderDetail] (
    [OrderDetailId] INT             NOT NULL,
    [OrderId]       INT             NOT NULL,
    [ProductId]     INT             NOT NULL,
    [Quantity]      INT             NOT NULL,
    [UnitPrice]     DECIMAL (18, 2) NOT NULL
);