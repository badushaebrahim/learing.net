use badusha
CREATE TABLE medsdetails
(Nameofmed VARCHAR(70),
Parmasisid int,
dateandtime VARCHAR(60),
priceperunit int,
UID int IDENTITY PRIMARY KEY);

--SQL TO SELECT MNEDS DETAISL TABLE
select * from medsdetails;

--ALTER TABLE DROP COLUMN
--ALTER TABLE dbo.medsdetails drop column unitsleft;

--ALTER TABLE ADD COLUMN
--ALTER TABLE dbo.medsdetails ADD column Details VARCHAR(1000);


use badusha
--UPDATE MEDDETAILS
--UPDATE  dbo.medsdetails SET parmasisid = 9 where UID = 2

--SQL QUERY TO JION USERS AND MEDDETAILS TABLES
select dbo.USERS.Name AS Name_of_pharamasist, dbo.medsdetails.* from dbo.medsdetails INNER JOIN dbo.USERS ON dbo.medsdetails.Parmasisid  =  dbo.USERS.ID
GO

EXEC SP_HELP medsdetails;

--STORED PROCEDURE TO GET ALL DETAILS IN USERS TABLE
EXEC dbo.getUserdetails

SELECT * FROM medsdetails;

--stored procedure to insert data into users table
EXEC dbo.inserttoUsers @Name='arun',@DOB='06-08-2001',@Email='b@q.co',@Password ='1452',@PhoneNumber='9544655941',
@Gender='Male',
@PhotoURL='jsdsds',
@Role='Pharmacist';
go
--stored procedure to elete user
EXEC dbo.deleteuser @Name = 'arun',@ID =11;

--STORED PROCEDURE TO UPDATE PASSWORD
use badusha
EXEC dbo.updatepassword @Password ='1230' ,@ID = 10

--strode prodedure to update user details
EXEC dbo.updateUserdetails @Name = 'job',@Email= 'r@j.co',@DOB = '05-07-2001',@Phoneno = '9544655941',@Gender = 'male',@Role ='Manager',@ID = 10;
go
--stored procedure for login logic
EXEC dbo.userLogin @Email='r@j.co', @Password='1230'


--created a view 
create view userdetails AS
SELECT Name,DOB,Email,PhoneNumber,Gender,Role from dbo.USERS;
go

--select the view
select * from userdetails

--

