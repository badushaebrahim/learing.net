create table doctors(Docname VARCHAR(75),Dept VARCHAR(100),DocContact VarChar(15),DID INT IDENTITY PRIMARY KEY);


insert into dbo.doctors Values ('john','general','9544655984');
insert into dbo.doctors Values ('jack','Ent','9544655983');

select * from dbo.doctors

