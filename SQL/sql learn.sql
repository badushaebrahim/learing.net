use badusha
DROP TABLE dbo.USERS;


CREATE TABLE USERS
(
Name VARCHAR(MAX),
DOB VARCHAR(MAX),
Email VARCHAR(MAX),
Password VARCHAR(MAX),
PhoneNumber VARCHAR(MAX),
Gender VARCHAR(MAX),
PhotoUrl VARCHAR(MAX),
Role VARCHAR(MAX),
ID INT IDENTITY  PRIMARY KEY
)

EXECUTE dbo.getUserdetails

SELECT * FROM dbo.USERS

EXECUTE dbo.inserttoUsers
@Name = 'john22',
@DOB  = '22-02-2002',
@Email = 'jho22@b.com',
@Password = 'pass',
@PhoneNumber = '95441335941',
@Gender ='Male',
@PhotoURL ='jshfokjshfjsadnfjkdsn',
@Role = 'Pharmacist';

EXECUTE dbo.userLogin
@Email = 'jho22@.com',
@Password = 'pass';



EXEC dbo.getUserdetails