CREATE PROCEDURE deleteuser
(
@Name AS VARCHAR(MAX),
@ID AS INT
)
AS
BEGIN
DELETE FROM dbo.USERS WHERE Name = @Name AND ID = @ID;
END
