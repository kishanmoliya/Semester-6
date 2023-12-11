/*
=============================================================================
				Schemas
=============================================================================

Table Name :: Department
-----------------------------
DepartmentID		int		--		PK,
DepartmentName		varchar(100)	Not Null	Unique

*************************************************************

Table Name :: Employee
-----------------------------
EmployeeID		int		--		PK,
FirstName		varchar(50)	Not Null,
LastName		varchar(50)	Not Null,
Age				int		Not Null,
DepartmentID	int		Null		FK
*/

-- 1. Create a simple view BasicEmpInfo that displays information of employees including EmployeeID,
--	  FirstName, LastName and Age.
CREATE VIEW BasicEmpInfo
AS
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   e.Age
FROM Employee e

-- 2. Create a complex view that shows the department wise employee count.
CREATE VIEW Department_Wise_Employee_Count
AS
SELECT d.DepartmentID,
	   d.DepartmentName,
	   COUNT(e.EmployeeID) AS Emp_Count
FROM Department d
LEFT JOIN Employee e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID, d.DepartmentName

-- 3. Create a stored procedure that retrieves employee information based on the department name.
CREATE PROCEDURE PR_Employee_SelectByDepartment
	@DepartmentName varchar(100)
AS
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   e.Age
FROM Employee e
INNER JOIN Department d
ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentName = @DepartmentName

-- 4. Create a scalar-valued function that calculates the average age of employees in a specific department.
CREATE FUNCTION FN_Average_Age_By_Department
(
	@DepartmentID int
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @AverageAge FLOAT
	SELECT @AverageAge = AVG(e.Age)
	FROM Employee e
	WHERE e.DepartmentID = @DepartmentID

	RETURN @AverageAge
END

-- 5. Create a table-valued function that retrieves all employees from a specific department.
CREATE FUNCTION FN_Employee_SelectAll
(
	@DepartmentID int
)
RETURNS TABLE
AS
RETURN
(
	SELECT e.EmployeeID,
		   e.FirstName,
		   e.LastName,
		   e.Age
	FROM Employee e
	WHERE e.DepartmentID = @DepartmentID
)

-- 6. Create a complex view that shows the employees information along with their age whose
--    department is IT and age is more than 25.
CREATE VIEW Employee_SelectByDepartmentAndAge
AS
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   e.Age
FROM Employee e
INNER JOIN Department d
ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentName = 'IT' AND e.Age > 25

-- 7. Create a stored procedure that displays information of top 3 employee with their department name.
CREATE PROCEDURE PR_Employee_SelectTopThree
AS
SELECT TOP 3
	   e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   e.Age,
	   d.DepartmentName
FROM Employee e
LEFT JOIN Department d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 8. Create scalar-valued function that counts total number of employees works in IT department.
CREATE FUNCTION FN_Employee_Count_IT()
RETURNS INT
AS
BEGIN
	DECLARE @Count int
	SELECT @Count = COUNT(e.EmployeeID)
	FROM Employee e
	WHERE e.DepartmentID = (SELECT DepartmentID FROM Department WHERE DepartmentName = 'IT')

	RETURN @Count
END

-- 9. Create table-valued function that shows employees whose name start with A to R and department
--    name is HR.
CREATE FUNCTION FN_Employee_Name_Start_AtoR()
RETURNS TABLE
AS
BEGIN
	SELECT e.EmployeeID,
		   e.FirstName,
		   e.LastName,
		   d.DepartmentName
	FROM Employee e
	LEFT JOIN Department d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.DepartmentName = 'HR'
	AND e.FirstName LIKE '[a-r]%'
END



-- 10. Create a complex view that displays employee count having no department.
CREATE VIEW Employees_No_Department
AS
SELECT COUNT(e.EmployeeID) AS Emp_Count
FROM Employee e
WHERE e.DepartmentID IS NULL



-- 11. Create a stored procedure that displays department information having no employees.

CREATE PROCEDURE PR_Departments_No_Employee
AS
SELECT d.DepartmentID, d.DepartmentName
FROM Department d
LEFT JOIN Employee e
ON d.DepartmentID = e.DepartmentID
WHERE e.EmployeeID IS NULL



-- 12. Create a cursor that finds the employee with an age of above 30 and prints their information.
DECLARE @EmployeeID int,
		@FirstName  varchar(50),
		@LastName   varchar(50),
		@Age		int

DECLARE EmployeeCursor CURSOR
FOR	SELECT EmployeeID, FirstName, LastName, Age
	FROM Employee
	WHERE Age > 30	

OPEN EmployeeCursor

FETCH NEXT FROM EmployeeCursor
INTO @EmployeeID, @FirstName, @LastName, @Age

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT 'EmployeeID: ' + CAST(@EmployeeID AS varchar(10)) + ', Name: ' + @FirstName + ' ' + @LastName + ', Age: ' + CAST(@Age AS varchar(10))
	FETCH NEXT FROM EmployeeCursor
	INTO @EmployeeID, @FirstName, @LastName, @Age
END

CLOSE EmployeeCursor

DEALLOCATE EmployeeCursor



-- 13. Create a trigger that automatically assigns a default department when a new employee is inserted
--     with a ‘NULL’ department.


-- 14. Create a cursor that updates the salaries of employees based on their age. For example, increase the
--     salary by 10% for employees aged 30 or below and by 5% for employees aged above 30.
DECLARE @EmployeeID int,
		@Age		int,
		@Salary		float

DECLARE SalaryUpdateCursor CURSOR
FOR	SELECT EmployeeID, Age, Salary
	FROM Employee

OPEN SalaryUpdateCursor

FETCH NEXT FROM SalaryUpdateCursor
INTO @EmployeeID, @Age, @Salary

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @Age <= 30
		SET @Salary = @Salary + (@Salary * 0.10)
	ELSE
		SET @Salary = @Salary + (@Salary * 0.05)

	UPDATE Employee
	SET Salary = @Salary
	WHERE EmployeeID = @EmployeeID

	FETCH NEXT FROM SalaryUpdateCursor
	INTO @EmployeeID, @Age, @Salary
END

CLOSE SalaryUpdateCursor

DEALLOCATE SalaryUpdateCursor



-- 15. Write a Query to throw an exception if duplicate department name inserts in department table.