CREATE PROCEDURE USER_TABLE_CRUD(
@TYPE AS VARCHAR(MAX),
@Name AS  VARCHAR(MAX),
@DOB AS VARCHAR(MAX),
@Email AS VARCHAR(MAX),
@Password AS VARCHAR(MAX),
@PhoneNumber AS VARCHAR(MAX),
@Gender AS VARCHAR(MAX),
@PhotoURL AS VARCHAR(MAX),
@Role AS VARCHAR(MAX),
@ID AS INT
)
AS 
BEGIN 
IF @Type = 'addNewsuser'
BEGIN 
INSERT INTO dbo.USERS 
VALUES
(@Name,@DOB,@Email,@Password,@PhoneNumber,@Gender,@PhotoURL,@Role)
END;

IF @Type = 'updateUserdetails'
BEGIN
UPDATE dbo.USERS set "Name"= @Name ,"DOB" = @DOB, "Email"= @Email, "PhoneNumber"=@PhoneNumber, "Gender"=@Gender,"Role" =  @Role where ID = @ID;
END;

IF @Type = 'getUserallDetails'
BEGIN
SELECT * FROM DBO.USERS ORDER BY ID ASC;
END;

IF @Type = 'userLogin'
BEGIN
SELECT * FROM dbo.USERS WHERE Email = @Email AND Password = @Password;
IF @@ROWCOUNT = 0
        PRINT 'No User Found';
ELSE
		print 'User Found';
END;

IF @Type = 'updatePassword'
BEGIN 
UPDATE dbo.USERS SET Password = @Password WHERE ID = @ID;
END;
IF @Type = 'deleteUser'
BEGIN
DELETE FROM dbo.USERS WHERE Name = @Name AND ID = @ID;
END;



END;--final