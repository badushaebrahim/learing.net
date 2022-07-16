USE [badusha]
GO

INSERT INTO [dbo].[medsdetails]
           ([Nameofmed]
           ,[Parmasisid]
           ,[dateandtime]
           ,[priceperunit])
     VALUES
           ('ALBENTAZOL22'
           ,10
           ,GETDATE()
           ,5)
GO


