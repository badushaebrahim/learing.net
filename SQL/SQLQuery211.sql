create PROCEDURE  INVENTORY_CRUD(
@Type AS VARCHAR(MAX),
  @medid As INT = null   
  ,@CustomName as VARCHAR (MAX)= null
      ,  @supid As INT = null  
      ,  @quantity As INT = null  
      ,  @priceperunit As INT = null
	  ,@Itemid As INT NULL)
AS
BEGIN 

IF @Type = 'getinvbyid'

BEGIN
SELECT * FROM dbo.inventory WHERE itemid =@Itemid;
END

IF @Type = 'addtoinv'
BEGIN
INSERT INTO [dbo].[inventory]
           ([medid]
           ,[CustomName]
           ,[supid]
           ,[quantity]
           ,[priceperunit])
     VALUES
           (@medid 
           ,@CustomName
           ,@supid
           ,@quantity
           ,@priceperunit)
END

END;