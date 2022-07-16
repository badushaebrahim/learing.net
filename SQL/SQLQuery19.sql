
EXEC DBO.getUserdetails

EXEC dbo.deleteuser @Name = 'joel' , @ID = 5;

EXEC dbo.updatedetails @Colname = 'Name', @Value ='DON' , @ID =8;

UPDATE dbo.USERS SET "Name" = 'DON' WHERE ID = 6;