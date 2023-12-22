-- Person Select ALL
Insert into Person values('Uttam','7984186755','kishanmoliya232@gmail.com')
exec API_Person_SelectAll
Create Procedure API_Person_SelectAll
As
Select 
	Person.PersonID,
	Person.Name,
	Person.Email,
	person.Contact
From Person
Order by
	Person.Name,
	Person.Email



--Person SelectBy ID
Exec API_Person_SelectByID 3
Create or Alter Procedure API_Person_SelectByID
	@PersonID	int
As
Select
	Person.PersonID,
	Person.Name,
	Person.Email,
	person.Contact
From Person
	Where PersonID = @PersonID


--Person Delete
Exec API_Person_Delete 3
Create Procedure API_Person_Delete
	@PersonID int
AS
Delete From Person
Where PersonID = @PersonID

-- Person Insert
Exec API_Person_Insert 'Kishan','kishanmoliya232@gmail.com',798456315
Create Procedure API_Person_Insert
	@Name		Varchar(50),
	@Email		Varchar(50),
	@Contact	Varchar(50)
As
	Insert Into Person
	Values
	(
		@Name, 
		@Email,
		@Contact
	)

-- Person Update
Create or Alter Procedure API_Person_Update
	@PersonID	int,
	@Name		Varchar(50),
	@Email		Varchar(50),
	@Contact	Varchar(50)
As
	Update Person
	Set
		Name	= @Name,
		Contact = @Contact,
		Email	= @Email
	Where 
		PersonID = @PersonID
