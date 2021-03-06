USE [badusha]
GO
/****** Object:  StoredProcedure [dbo].[MEDDETAIL_TABLE_CRUD]    Script Date: 7/19/2022 3:17:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[MEDDETAIL_TABLE_CRUD](
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
--add meds
IF @ACTIONTYPE = 'addnewmeds'
BEGIN
declare @rowcount int =0
--set @rowcount = (select (1) from dbo.medsdetails where Nameofmed= @nameofmed)
--begin try 
--begin tran 
--if(@rowcount =0)
begin
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
--commit tran
--end try 
--begin catch
	 --rollback tran
	 --select ERROR_MESSAGE()
--end catch 


END
--end med
IF @ACTIONTYPE = 'deletemeds'
BEGIN
DELETE FROM dbo.medsdetails WHERE UID = @UID;
END

IF @ACTIONTYPE = 'updatemeds'
BEGIN
declare @rowcount2 int =0
--set @rowcount2 = (select (1) from dbo.medsdetails where Nameofmed= @nameofmed)
--begin try 
--begin tran 
--if(@rowcount =0)
begin
UPDATE [dbo].[medsdetails]  SET[Nameofmed] = @nameofmed ,[Parmasisid] = @paramsid , [dateandtime] = GETDATE() ,[priceperunit] = @price WHERE UID =@uid
END
--commit tran
--end try 
--begin catch
	-- rollback tran
	-- select ERROR_MESSAGE()
--end catch 
END
IF @ACTIONTYPE ='medbyid'
BEGIN 
SELECT * FROM dbo.medsdetails WHERE UID =@UID;
END
END--END