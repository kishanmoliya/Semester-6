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
	[dob].[PRJ_Project].[ModifiedDate]
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
	GetDate()
)

-- Delete Project
Exec [dbo].[PR_Delete_Project] 12
CREATE PROCEDURE [dbo].[PR_Delete_Project]
	@ProjectID	int
AS
DELETE FROM [dbo].[PRJ_Project]
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID


-- Select Project By PK
Exec [dbo].[PR_Project_SelectByPK] 20
CREATE PROCEDURE [dbo].[PR_Project_SelectByPK]
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
FROM [dbo].[PRJ_Project]
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID
ORDER BY [dbo].[PRJ_Project].[ProjectTitle]

-- Update Project
Exec  [dbo].[PR_Update_Project] 11, 'k Prj1','k new Project','kishan',50,456425.00,'12-30-2023'
Create Or ALTER PROCEDURE [dbo].[PR_Update_Project]
	@ProjectID			int,
	@ProjectTitle		nVarchar(Max),
	@ProjectDescription	nVarchar(Max),
	@ProjectOwnerName	nVarchar(Max),
	@TotalMembers		int,
	@ProjectCost		Decimal(16,8),
	@DeadLine			DateTime
AS
UPDATE [dbo].[PRJ_Project]	
	SET [dbo].[PRJ_Project].[ProjectTitle] = @ProjectTitle,
		[dbo].[PRJ_Project].[ProjectDescription] = @ProjectDescription,
		[dbo].[PRJ_Project].[ProjectOwnerName] = @ProjectOwnerName,
		[dbo].[PRJ_Project].[TotalMembers] = @TotalMembers,
		[dbo].[PRJ_Project].[ProjectCost] = @ProjectCost,
		[dbo].[PRJ_Project].[DeadLine] = @DeadLine,
		[dbo].[PRJ_Project].[ModifiedDate] = GETDATE()
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID

------------------------------------------------------------------------------
------------------------------------------------------------------------------
--Inert Task
EXEC PR_Task_Insert 'DB2',5,'In This Task All Data base Operation Done Like Table Craetion and procedures etc...',1,'5-5-2024'
Create or ALTER PROCEDURE PR_Task_Insert
    @TaskName			nvarchar(MAX),
    @ProjectID			int,
    @TaskDescription	nvarchar(MAX),
    @MemberID			int = NULL,
	@DeadLine			datetime
AS
BEGIN
    INSERT INTO PRJ_Task
    VALUES (@TaskName, 'Pending', GetDate(), GetDate(), @ProjectID, @TaskDescription, @MemberID, @DeadLine);
END;

--Select All Task
Create or ALter Procedure SelectAllTask
As
Select * From PRJ_Task
ORDER BY [dbo].[PRJ_Task].[CreatedDate]


--Select By PK
Exec [dbo].[PR_Task_SelectByPK] 5
CREATE OR Alter PROCEDURE [dbo].[PR_Task_SelectByPK]
@TaskID int
AS
SELECT * FROM [dbo].[PRJ_Task]
WHERE [dbo].[PRJ_Task].[TaskID] = @TaskID
ORDER BY [dbo].[PRJ_Task].[CreatedDate]

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
------------------------------------------------------------------------------
------------------------------------------------------------------------------
--Inert Member
Select * From PRJ_Member
EXEC InsertMember 'pravin',7899565623,'Pravin322@gmail.com','Manager','Java',26,'40000.00'
CREATE PROCEDURE PR_Member_Insert
    @MemberName nvarchar(MAX),
    @MemberContact nvarchar(MAX),
    @MemberEmail nvarchar(MAX),
    @MemberRole nvarchar(MAX),
    @MemberTechnology nvarchar(MAX),
    @MemberAge int,
    @MemberSalary decimal(18, 2)
AS
BEGIN
    INSERT INTO PRJ_Member (MemberName, MemberContact, MemberEmail, MemberRole, MemberTechnology, MemberAge, MemberSalary)
    VALUES (@MemberName, @MemberContact, @MemberEmail, @MemberRole, @MemberTechnology, @MemberAge, @MemberSalary);
END;

--Select All Members
Create or ALter Procedure SelectAllMember
As
Select * From PRJ_Member