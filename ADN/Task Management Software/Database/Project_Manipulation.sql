--Add Project
Exec [dbo].[PR_Add_Project] 'ML','user3Desc','user3','2-5-2024',10,50000,5
Create or Alter Procedure [dbo].[PR_Add_Project]
	@ProjectTitle		nVarchar(Max),
	@ProjectDescription	nVarchar(Max),
	@ProjectOwnerName	nVarchar(Max),
	@DeadLine			DateTime,
	@TotalMembers		int,
	@ProjectCost		Decimal(18,2),
	@UserID				int
As
Insert Into [dbo].[PRJ_Project]
(
	[dbo].[PRJ_Project].[ProjectTitle],
	[dbo].[PRJ_Project].[ProjectDescription],
	[dbo].[PRJ_Project].[ProjectOwnerName],
	[dob].[PRJ_Project].[CreatedDate],
	[dbo].[PRJ_Project].[DeadLine],
	[dbo].[PRJ_Project].[TotalMembers],
	[dbo].[PRJ_Project].[ProjectCost],
	[dbo].[MST_User].[UserID],
	[dob].[PRJ_Project].[ModifiedDate],
	[dob].[PRJ_Project].[ProjectState]
)
Values
(
	@ProjectTitle,		
	@ProjectDescription,
	@ProjectOwnerName,	
	GetDate(),
	@DeadLine,			
	@TotalMembers,		
	@ProjectCost,		
	@UserID,
	GetDate(),
	'Pending'
)

-- Delete Project
Exec [dbo].[PR_Delete_Project] 5
CREATE PROCEDURE [dbo].[PR_Delete_Project]
	@ProjectID	int
AS
DELETE FROM [dbo].[PRJ_Project]
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID


-- Select Project By PK
Exec [dbo].[PR_Project_SelectByPK] 11
CREATE OR ALTER PROCEDURE [dbo].[PR_Project_SelectByPK]
@ProjectID int
AS

SELECT [dbo].[PRJ_Project].[ProjectID]
	  ,[dbo].[PRJ_Project].[ProjectTitle]
      ,[dbo].[PRJ_Project].[ProjectDescription]
	  ,[dbo].[PRJ_Project].[ProjectOwnerName]
	  ,[dbo].[PRJ_Project].[TotalMembers]
	  ,[dbo].[PRJ_Project].[ProjectCost]
	  ,[dbo].[PRJ_Project].[CreatedDate]
	  ,[dbo].[PRJ_Project].[DeadLine]
	  ,[dbo].[PRJ_Project].[ModifiedDate]
	  ,[dbo].[PRJ_Project].[ProjectState]
FROM [dbo].[PRJ_Project]
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID
ORDER BY [dbo].[PRJ_Project].[ProjectTitle]

-- Update Project
Exec  [dbo].[PR_Update_Project] 11, 'k Prj1','k new Project','kishan',50,456425.00,'12-30-2023','In Progress'
Create Or ALTER PROCEDURE [dbo].[PR_Update_Project]
	@ProjectID			int,
	@ProjectTitle		nVarchar(Max),
	@ProjectDescription	nVarchar(Max),
	@ProjectOwnerName	nVarchar(Max),
	@TotalMembers		int,
	@ProjectCost		Decimal(16,8),
	@DeadLine			DateTime,
	@ProjectState		nVarchar(Max)
AS
UPDATE [dbo].[PRJ_Project]	
	SET [dbo].[PRJ_Project].[ProjectTitle] = @ProjectTitle,
		[dbo].[PRJ_Project].[ProjectDescription] = @ProjectDescription,
		[dbo].[PRJ_Project].[ProjectOwnerName] = @ProjectOwnerName,
		[dbo].[PRJ_Project].[TotalMembers] = @TotalMembers,
		[dbo].[PRJ_Project].[ProjectCost] = @ProjectCost,
		[dbo].[PRJ_Project].[DeadLine] = @DeadLine,
		[dbo].[PRJ_Project].[ModifiedDate] = GETDATE(),
		[dbo].[PRJ_Project].[ProjectState] = @ProjectState
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID

------------------------------------------------------------------------------
------------------------------------------------------------------------------
--Inert Task
EXEC PR_Task_Insert 'DB2',5,'In This Task All Data base Operation Done Like Table Craetion and procedures etc...','5-5-2024'
Create or ALTER PROCEDURE PR_Task_Insert
    @TaskName			nvarchar(MAX),
    @ProjectID			int,
    @TaskDescription	nvarchar(MAX),
	@DeadLine			datetime
AS
BEGIN
    INSERT INTO PRJ_Task
    VALUES (@TaskName, 'Pending', GetDate(), GetDate(), @ProjectID, @TaskDescription, @DeadLine, 0);
END;

--Select All Task
Create or ALter Procedure SelectAllTask
As
Select * From PRJ_Task
ORDER BY [dbo].[PRJ_Task].[CreatedDate]


--Select Project Wise Task
Exec [dbo].[PR_ProjectWise_Task] 5
CREATE OR Alter PROCEDURE [dbo].[PR_ProjectWise_Task]
@ProjectID int
AS
SELECT * FROM [dbo].[PRJ_Task]
WHERE [dbo].[PRJ_Task].[ProjectID] = @ProjectID
ORDER BY [dbo].[PRJ_Task].[CreatedDate] DESC
 
--Select TaskByPK
Exec [dbo].[PR_Task_SelectByPK] 5
CREATE OR Alter PROCEDURE [dbo].[PR_Task_SelectByPK]
@TaskID int
AS
SELECT * FROM [dbo].[PRJ_Task]
WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID
ORDER BY [dbo].[PRJ_Task].[TaskName]

-- Change State
Exec [dbo].[PR_State_Change] 5,'InProgress'
Create Or ALTER PROCEDURE [dbo].[PR_State_Change]
	@TaskID		int,
	@TaskState	nvarchar(max)
AS
IF @TaskState = 'Pending'
BEGIN
    UPDATE [dbo].[PRJ_Task]	
	SET [dbo].[PRJ_Task].[TaskState] = 'InProgress'
	WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID;
END
ELSE
BEGIN
    UPDATE [dbo].[PRJ_Task]	
	SET [dbo].[PRJ_Task].[TaskState] = 'Done'
	WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID;
END

--Task Update
ALTER PROCEDURE [dbo].[PR_Update_Task]
	@TaskID				int,
	@TaskName			nVarchar(Max),
	@TaskDescription	nVarchar(Max),
	@DeadLine			DateTime
AS
UPDATE [dbo].[PRJ_Task]	
	SET [dbo].[PRJ_Task].[TaskName] = @TaskName,
		[dbo].[PRJ_Task].[TaskDescription] = @TaskDescription,
		[dbo].[PRJ_Task].[DeadLine] = @DeadLine,
		[dbo].[PRJ_Task].[Modified] = GETDATE()
WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID

--Task Reject and Restore
EXEC [PR_Task_Delete_Restore] 1, 0
Create Procedure [dbo].[PR_Task_Delete_Restore]
	@TaskID			int,
	@IsRejected		bit
AS
IF @IsRejected = 0
BEGIN
    UPDATE [dbo].[PRJ_Task]	
	SET [dbo].[PRJ_Task].[IsRejected] = 1
	WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID;
END
ELSE
BEGIN
    UPDATE [dbo].[PRJ_Task]	
	SET [dbo].[PRJ_Task].[IsRejected] = 0
	WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID;
END

-- Task Delete
Exec [dbo].[PR_Delete_Task] 5
CREATE PROCEDURE [dbo].[PR_Delete_Task]
	@TaskID	int
AS
DELETE FROM [dbo].[PRJ_Task]
WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID
------------------------------------------------------------------------------
------------------------------------------------------------------------------
--Inert Member
Select * From PRJ_Member
EXEC PR_Member_Insert 'pravin2',7899565623,'Pravin322@gmail.com','Manager','Java',26,'40000.00',2
CREATE OR ALTER PROCEDURE PR_Member_Insert
    @MemberName nvarchar(MAX),
    @MemberContact nvarchar(MAX),
    @MemberEmail nvarchar(MAX),
    @MemberRole nvarchar(MAX),
    @MemberTechnology nvarchar(MAX),
    @MemberAge int,
    @MemberSalary decimal(18, 2),
	@TaskID int
AS
BEGIN
    INSERT INTO PRJ_Member 
    VALUES (@MemberName, @MemberContact, @MemberEmail, @MemberRole, @MemberTechnology, @MemberAge, @MemberSalary, @TaskID);
END;

--Select Task Wise Member
Create Procedure PR_TaskWise_Member
@TaskID	int
As
Select * From PRJ_Member Where TaskID = @TaskID


Select * from PRJ_Member

-- Delete Member
Exec [dbo].[PR_Delete_Member] 20
CREATE PROCEDURE [dbo].[PR_Delete_Member]
	@MemberID	int
AS
DELETE FROM [dbo].[PRJ_Member]
WHERE [dbo].[PRJ_Member].[MemberID] = @MemberID

-- Select Member By PK
EXEC PR_Member_SelectByPK 21
Create OR ALTER Procedure [dbo].[PR_Member_SelectByPK] 
	@MemberID int
AS
	Select * From PRJ_Member Where MemberID = @MemberID


--Member Update
EXEC PR_Update_Member 2,'raju',78595484651,'raju23@gmail.com','db','java','22',20000.00
CREATE PROCEDURE [dbo].[PR_Update_Member]
	@MemberID				int,
	@MemberName				nVarchar(Max),
	@MemberContact			nVarchar(Max),
	@MemberEmail			nVarchar(Max),
	@MemberRole				nVarchar(Max),
	@MemberTechnology		nVarchar(Max),
	@MemberAge				int,
	@MemberSalary			Decimal
AS
UPDATE [dbo].[PRJ_Member]	
	SET [dbo].[PRJ_Member].[MemberName] = @MemberName,
		[dbo].[PRJ_Member].[MemberContact] = @MemberContact,
		[dbo].[PRJ_Member].[MemberEmail] = @MemberEmail,
		[dbo].[PRJ_Member].[MemberRole] = @MemberRole,
		[dbo].[PRJ_Member].[MemberTechnology] = @MemberTechnology,
		[dbo].[PRJ_Member].[MemberAge] = @MemberAge,
		[dbo].[PRJ_Member].[MemberSalary] = @MemberSalary
WHERE [dbo].[PRJ_Member].[MemberID] = @MemberID