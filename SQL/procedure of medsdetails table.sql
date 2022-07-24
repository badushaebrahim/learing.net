CREATE PROCEDURE MEDDETAIL_TABLE_CRUD(
@ACTIONTYPE AS VARCHAR(MAX),
 @nameofmed AS VARCHAR(MAX)=NULL,
 @paramsid AS INT =NULL,
 @price AS INT = NULL,
 @UID AS INT = NULL)
 AS 
 BEGIN

IF @ACTIONTYPE ='getallmeds'
BEGIN 
SELECT * FROM dbo.medsdetails  ORDER BY Nameofmed ASC;
END

IF @ACTIONTYPE = 'joinedallmeds'
BEGIN
select dbo.USERS.Name AS Name_of_pharamasist, dbo.medsdetails.* from dbo.medsdetails INNER JOIN dbo.USERS ON dbo.medsdetails.Parmasisid  =  dbo.USERS.ID;
END

IF @ACTIONTYPE = 'addnewmeds'
BEGIN
INSERT INTO [dbo].[medsdetails]
           ([Nameofmed]
           ,[Parmasisid]
           ,[dateandtime]
           ,[priceperunit])
     VALUES
           (@nameofmed
           ,@paramsid
           ,GETDATE()
           ,@price)
END
IF @ACTIONTYPE = 'deletemeds'
BEGIN
DELETE FROM dbo.medsdetails WHERE UID = @UID;
END

IF @ACTIONTYPE = 'updatemeds'
BEGIN
UPDATE [dbo].[medsdetails]  SET[Nameofmed] = @nameofmed ,[Parmasisid] = @paramsid  ,  [priceperunit] = @price WHERE UID =@uid
END


END--END

EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='joinedallmeds'

EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='deletemeds' ,  @UID = 5;
EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='updatemeds' ,@nameofmed = 'ALBENTAZOL2',@paramsid=10,@price=5,  @UID = 6;


EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='addnewmeds' ,@nameofmed = 'ALBENTAZOL2',@paramsid=10,@price=5;