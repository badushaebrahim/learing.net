
CREATE PROCEDURE updatedetails
(
@Colname AS VARCHAR(MAX),
@VALUE AS VARCHAR(MAX),
@ID AS INT 
)
AS
BEGIN 
UPDATE dbo.USERS SET @Colname = @VALUE WHERE ID = @ID;
END