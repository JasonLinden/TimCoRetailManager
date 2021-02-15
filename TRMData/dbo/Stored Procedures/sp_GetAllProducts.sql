CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
  SET NOCOUNT ON;
  SELECT 
    [Id] 
    ,[ProductName] 
    ,[Description] 
    ,[QuantityInStock] 
    ,[RetailPrice]
  FROM 
    dbo.[Product]
  ORDER BY 
    [ProductName]
END