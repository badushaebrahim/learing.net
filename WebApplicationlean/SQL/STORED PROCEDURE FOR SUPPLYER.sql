create procedure SUPPLYERID_TABLE_CRUD
(
@TYPE AS VARCHAR(MAX),
@Supplyername As VARCHAR(MAX) = NULL
           ,@Companyname As VARCHAR(MAX) = NULL
           ,@SupplyerAddress As VARCHAR(MAX) = NULL
           ,@Email As VARCHAR(MAX) = NULL
           ,@Phonenumber As VARCHAR(MAX) = NULL
           ,@adddate As VARCHAR(MAX) = NULL,
           @SID as INT =null
)
AS 
BEGIN

if @TYPE = 'getsupplyerfull'
BEGIN
SELECT * FROM dbo.supplyerid;
END

if @TYPE = 'getsupplyerbyid'
BEGIN
SELECT * FROM dbo.supplyerid where SID= @SID;
END

if @TYPE = 'addsupplyer'
BEGIN

INSERT INTO [dbo].[supplyerid]
           ([Supplyername]
           ,[Companyname]
           ,[SupplyerAddress]
           ,[Email]
           ,[Phonenumber]
           ,[adddate])
     VALUES
           (@Supplyername
           ,@Companyname
           ,@SupplyerAddress
           ,@Email
           ,@Phonenumber
           ,GETDATE())
END

if @TYPE = 'updatesupplyerbyid'
BEGIN
UPDATE [dbo].[supplyerid]
   SET [Supplyername] = @Supplyername
      ,[Companyname] = @Companyname
      ,[SupplyerAddress] = @SupplyerAddress
      ,[Email] = @Email
      ,[Phonenumber] = @Phonenumber
 WHERE SID= @SID;
END

if @TYPE = 'deletesupplyerbyid'
BEGIN
DELETE  FROM dbo.supplyerid where SID= @SID;
END


END;

EXEC SUPPLYERID_TABLE_CRUD @Type='getsupplyerbyid', @SID=2