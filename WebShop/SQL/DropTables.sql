DROP TABLE Cart;

-- Save our precious 
INSERT INTO SavedOrderDetail SELECT * FROM OrderDetail;
DROP TABLE OrderDetail;

-- Save our precious 
INSERT INTO SavedOrder SELECT * FROM [Order];
DROP TABLE [Order];

DROP TABLE Product;
DROP TABLE Category;
DROP TABLE __MigrationHistory;