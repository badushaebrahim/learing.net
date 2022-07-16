--add new user
EXEC USER_TABLE_CRUD @Type='addNewsuser', @Name = 'job2',@Email= 'r@2j.co',@Password='14252',@DOB = '05-07-2001',@PhoneNumber = '9544655941',@Gender = 'male',@PhotoURL='hsbf',@Role ='Manager';
GO
--get all user details
EXEC USER_TABLE_CRUD @Type = 'getUserallDetails'
GO
--login 
EXEC USER_TABLE_CRUD @Type = 'userLogin', @Email ='r@j.co' , @Password = '1425';
GO
--UPDATE DETAILS WITH OUT PASSWORD
EXEC USER_TABLE_CRUD @Type = 'updateUserdetails' @Name = 'job',@Email= 'r@j.co',@DOB = '05-07-2001',@PhoneNumber = '9544655941',@Gender = 'male',@Role ='Manager',@ID = 10;
GO
--update password only
EXEC USER_TABLE_CRUD @Type='updatePassword' ,@Password ='12301' ,@ID = 10;
GO
--delete user
EXEC USER_TABLE_CRUD	@Type='deleteUser' ,  @Name = 'job2', @ID = 12;
GO

