Create Database Task_Management_Software

-- User Login
Insert into MST_User values('K','k','k',0,1,12-21-2023,12-21-2023)
Exec PR_GetUser_Log 'user3@gmail.com', 'user3'
Create or Alter Procedure PR_GetUser_Log
	@Email		nvarchar(MAX),
	@Password	nvarchar(MAX)
As
Select
	UserID,
	UserName,
	Email,
	IsAdmin,
	IsActive,
	CreatedDate,
	ModifiedDate
From MST_User
	Where Email = @Email and Password = @Password

-- User Register
select * From MST_User
Exec [dbo].[PR_User_Insert] 'k','k','k',0,1
Create or Alter Procedure [dbo].[PR_User_Insert]
	@UserName	nvarchar(Max),
	@Email		nvarchar(Max),
	@Password	nvarchar(Max),
	@IsAdmin	Bit = 0,
	@IsActive	Bit = 1
As
SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM MST_User WHERE UserName = @UserName)
        THROW 51001, 'User Name Already Exists', 1;
    Else IF EXISTS (SELECT 1 FROM MST_User WHERE Email = @Email)
        THROW 51000, 'Email Already Exists', 1;
	Else
		Insert Into [dbo].[MST_User]
		(
			[dbo].[MST_User].[UserName],
			[dbo].[MST_User].[Email],
			[dbo].[MST_User].[Password],
			[dbo].[MST_User].[IsAdmin],
			[dbo].[MST_User].[IsActive],
			[dbo].[MST_User].[CreatedDate],
			[dbo].[MST_User].[ModifiedDate]
		)
		Values
		(
			@UserName,
			@Email,	
			@Password,
			@IsAdmin,
			@IsActive,
			GETDATE(),
			GETDATE()
		)



-- Login User
Select * From PRJ_Project
Insert Into PRJ_Project Values('Civil_Quntity_Estimator','Many Calculators','Kishan Moliya',18-12-2023,20-12-2023,30,56235600,1)
Insert Into PRJ_Project Values('Task_Management_Software','You can Manage youre task','Kishan Moliya',18-12-2023,20-12-2023,35,4632456,1)
Insert Into PRJ_Project Values('RTO_Driving_Test','Hear you can show the various MCQs','Karan Khunt',18-12-2023,20-12-2023,20,1000000,2)
Insert Into PRJ_Project Values('Architecture_Admission','Find the collage','Uttam Nagvadiya',18-12-2023,20-12-2023,56,6565600,3)
	
-- Get Login User
Exec PR_UserWise_Project 5
Create or Alter Procedure PR_UserWise_Project
	@UserID			int,
	@ProjectState	nvarchar(Max) = NULL
As
Select 
	PRJ_Project.UserID,
	PRJ_Project.ProjectID,
	PRJ_Project.ProjectTitle,
	PRJ_Project.ProjectDescription,
	PRJ_Project.ProjectOwnerName,
	PRJ_Project.CreatedDate,
	PRJ_Project.DeadLine,
	PRJ_Project.TotalMembers,
	PRJ_Project.ProjectCost,
	PRJ_Project.ModifiedDate,
	PRJ_Project.ProjectState
From PRJ_Project
Inner Join MST_User on PRJ_Project.UserID = MST_User.UserID
Where PRJ_Project.UserID = @UserID AND (@ProjectState IS NULL OR PRJ_Project.ProjectState = @ProjectState)
ORDER BY [dbo].[PRJ_Project].[CreatedDate] DESC



--Get ALL Data
Create or ALter Procedure GetData
As
Select
	UserID,
	UserName,
	Email,
	IsAdmin,
	IsActive,
	CreatedDate,
	ModifiedDate
From MST_User
 

-- Dashbord Data
Exec DashbordCount 24
Alter Procedure DashbordCount
	@UserID	int
AS
Declare @Temp Table
(
	sumOfMember		int,
	sumOfProject	int,
	sumOfBudget		decimal(18,2),
	sumOfCustomers	int	
)
Insert Into @Temp 
Select sumOfMember = ISNULL(SUM(TotalMembers), 0), sumOfProject = Count(ProjectID), sumOfBudget = ISNULL(SUM(ProjectCost), 0), sumOfCustomers = Count(Distinct ProjectOwnerName)
FROM PRJ_Project Where UserID = @UserID

Select * From @Temp

