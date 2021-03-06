USE [badusha]
GO
/****** Object:  StoredProcedure [dbo].[INVENTORY_CRUD]    Script Date: 7/24/2022 10:25:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[INVENTORY_CRUD](
@Type AS VARCHAR(MAX),
  @medid As INT = null   
  ,@CustomName as VARCHAR (MAX)= null
      ,  @supid As INT = null  
      ,  @quantity As INT = null  
      ,  @priceperunit As INT = null
	  ,@Itemid As INT=null)
AS
BEGIN 

IF @Type = 'getinvbyid'

BEGIN
SELECT
 dbo.inventory.*,
  dbo.medsdetails.Nameofmed,
  dbo.supplyerid.Supplyername
FROM dbo.inventory
JOIN dbo.medsdetails
  ON medsdetails.UID = medid 
JOIN dbo.supplyerid
  ON dbo.inventory.supid = dbo.supplyerid.SID where itemid =@Itemid;
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
if @Type = 'getallinv'
BEGIN
SELECT
 dbo.inventory.*,
  dbo.medsdetails.Nameofmed,
  dbo.supplyerid.Supplyername
FROM dbo.inventory
JOIN dbo.medsdetails
  ON medsdetails.UID = medid 
JOIN dbo.supplyerid
  ON dbo.inventory.supid = dbo.supplyerid.SID;
END
if @Type = 'updateinv'
Begin
UPDATE [dbo].[inventory]
   SET 
    [CustomName] = @CustomName
      ,[quantity] = @quantity
      ,[priceperunit] = @priceperunit
 WHERE itemid = @Itemid

END
if @Type = 'deleteinventory'
BEGIN
DELETE FROM dbo.inventory where itemid = @Itemid;
END

END;