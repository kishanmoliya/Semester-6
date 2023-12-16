Insert into Person values('Kishan','7984186755','kishanmoliya232@gmail.com')
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




Exec API_Person_SelectByID 1
Create Procedure API_Person_SelectByID
	@PersonID	int
As
Select
	Person.PersonID,
	Person.Name,
	Person.Email,
	person.Contact
From Person
	Where PersonID = @PersonID
