CREATE PROCEDURE [dbo].[sp_GetUser]
	@userId nvarchar(128)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT 
    Id,
    FirstName,
	LastName,
	EmailAddress,
    CreatedDate
  FROM 
    dbo.[User] 
  WHERE 
    Id = @userId
END