--Add Project
Exec [dbo].[PR_Add_Project] 'user3','user3Desc','user3','2-5-2024',10,50000,15
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
	[dbo].[MST_User].[UserID]
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
	@UserID				
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
		[dbo].[PRJ_Project].[DeadLine] = @DeadLine
WHERE [dbo].[PRJ_Project].[ProjectID] = @ProjectID