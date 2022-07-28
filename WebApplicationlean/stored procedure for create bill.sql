--CREATE TABLE BILL(
--Docid int ,
--patientName VARCHAR(100),
--DOB DATE,
--Gender Varchar(MAX),
--Phonenumber VARCHAR(15),
---Address Varchar(MAX),
--Dateofcreation Date,
--Bid int  IDENTITY  PRIMARY KEY);

--CREATE TABLE [dbo].[BILL] (
--    [Docid]          INT           NULL,
--    [patientName]    VARCHAR (100) NULL,
--    [DOB]            DATE          NULL,
--    [Gender]         VARCHAR (MAX) NULL,
--    [Phonenumber]    VARCHAR (15)  NULL,
--    [Address]        VARCHAR (MAX) NULL,
--    [Dateofcreation] DATE          NULL,
--    [Bid]            INT           IDENTITY (1, 1) NOT NULL,
--    [Amount] INT NULL, 
 --   PRIMARY KEY CLUSTERED ([Bid] ASC)
--);

--select * from BILL

--drop table  dbo.BILL
--hhh
create procedure BILL_CRUD(
@Type AS VARCHAR(MAX)=NULL,
@Docid  as int = null,
@patientname as VARCHAR(MAX)= null,
@DOB as VARCHAR(MAX)= null,
@Gender as VARCHAR(MAX)= null,
@Phonenumber as VARCHAR(MAX)= null,
@address as Varchar (MAX)= null,
@BID as VARCHAR(MAX) = null,
@Amount as int = null
)
AS
BEGIN
if @type = 'addnewbill'
begin
INSERT INTO [dbo].[BILL]
           ([Docid]
           ,[patientName]
           ,[DOB]
           ,[Gender]
           ,[Phonenumber]
           ,[Address]
           ,[Dateofcreation])
     VALUES
           (@Docid
           ,@patientName
           ,@DOB
           ,@Gender
           ,@Phonenumber
           ,@Address
           ,GETDATE())
END
if @type = 'updatebill'
begin
UPDATE [dbo].[BILL]
   SET [patientName] = @patientName
      ,[DOB] = @DOB
      ,[Gender] = @Gender
      ,[Phonenumber] = @Phonenumber
      ,[Address] = @Address

 WHERE Bid= @BID
end



if @type = 'delete bill'
begin
DELETE FROM [dbo].[BILL]
      WHERE Bid =@BID;
END


END;

