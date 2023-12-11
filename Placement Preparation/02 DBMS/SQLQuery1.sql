-- 1. Write a Query to retrieve all the databases in SQL Server.
SELECT Name
FROM Sys.Databases

-- 2. Write a Query to Display Text of a Stored Procedure, Trigger, or View in SQL Server.
EXEC sp_helptext 'PR_City_SelectAll' -- Procedure Name or Trigger Name or View Name

-- 3. Write a Query to find size of Database Table in SQL Server
SELECT 
    t.NAME AS TableName,
    s.Name AS SchemaName,
    p.rows AS RowCounts,
    SUM(a.total_pages) * 8 AS TotalSpaceKB,
    SUM(a.used_pages) * 8 AS UsedSpaceKB,
    (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS UnusedSpaceKB
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
LEFT OUTER JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
WHERE 
    t.NAME = 'LOC_City' -- Replace 'YourTableName' with the name of your table
GROUP BY 
    t.Name, s.Name, p.Rows


-- 4. Write a Query to list Primary Key and Foreign Key for a particular table in SQL Server.

/*==================================================================
		Display for all PK & FK in the particular table 
==================================================================*/

SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
--WHERE TABLE_NAME = '[LOC_City].[INFORMATION_SCHEMA_TABLES]'


/*==================================================================
		Display for all PK in the particular table 
==================================================================*/

SELECT KCU.CONSTRAINT_NAME AS PKConstraintName,
	   KCU.COLUMN_NAME AS PKColumnName
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU 
ON TC.CONSTRAINT_NAME = KCU.CONSTRAINT_NAME
WHERE TC.TABLE_NAME = 'LOC_City'
AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY'


/*==================================================================
		Display for all FK in the particular table 
==================================================================*/

SELECT FK.name AS FKConstraintName,
	   COL_NAME(FKC.parent_object_id, FKC.parent_column_id) AS ForeignKeyColumn,
	   OBJECT_NAME(FKC.referenced_object_id) AS ReferencedTableName,
	   COL_NAME(FKC.referenced_object_id, FKC.referenced_column_id) AS ReferencedColumn
FROM sys.foreign_keys AS FK
INNER JOIN sys.foreign_key_columns AS FKC 
ON FK.object_id = FKC.constraint_object_id
WHERE OBJECT_NAME(FKC.parent_object_id) = 'LOC_City'

-- 5. Write a Query to Get the version name of SQL Server.
SELECT @@VERSION AS SQLServerVersion

-- 6. Write a Query to Get current Language of SQL Server.
SELECT @@LANGUAGE AS CurrentLanguage

-- 7. Write a Query to Return Server Name of SQL Server.
SELECT @@SERVERNAME AS ServerName

-- 8. Write a Query to disable and enable All Trigger of a table in SQL Server.
DISABLE TRIGGER ALL ON 'Table Name'
ENABLE TRIGGER ALL ON 'Table Name'

-- 9. Write a Query to get all the table that don’t have Primary Key.
SELECT t.name AS TableName
FROM sys.tables t
LEFT JOIN sys.indexes i 
ON t.object_id = i.object_id
WHERE i.index_id IS NULL
OR i.is_primary_key = 0


-- 10. Write a Query to get First Date of Current Month.
SELECT DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AS FirstDateOfCurrentMonth

