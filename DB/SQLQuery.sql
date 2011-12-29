IF OBJECT_ID('DBEOFFICE','U') IS NOT NULL
	DROP DATABASE DBEOFFICE
GO
CREATE DATABASE DBEOFFICE
GO
USE DBEOFFICE
GO
/* table tblDepartment */
/* create table */
IF OBJECT_ID('tblDepartment','U') IS NOT NULL
	DROP TABLE tblDepartment
GO
CREATE TABLE tblDepartment
(
	DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(200),
	DepartmentParent INT DEFAULT(0),
	[Description] NVARCHAR(MAX)
)
GO
/* creapte pro add */
IF OBJECT_ID('sp_tblDepartment_add','P') IS NOT NULL
	DROP PROC sp_tblDeparment_add
GO
CREATE PROC sp_tblDepartment 
	@Name NVARCHAR,
	@DepartmentParent INT,
	@Description NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO tblDepartment([Name],DepartmentParent,[Description]) VALUES(@Name,@DepartmentParent,@Description)
END
GO
/* creapte pro update */
IF OBJECT_ID('sp_tblDepartment_update','P') IS NOT NULL
	DROP PROC sp_tblDepartment_update
GO
CREATE PROC sp_tblDepartment_update
	@DepartmentID INT,
	@Name NVARCHAR(200),
	@DepartmentParent INT,
	@Description NVARCHAR(MAX)
AS
BEGIN
	UPDATE tblDepartment SET [Name]=@Name,DepartmentParent=@DepartmentParent,[Description]=@Description WHERE DepartmentID=@DepartmentID
END
GO
/* creapte pro delete */
IF OBJECT_ID('sp_tblDepartment_delete','P') IS NOT NULL
	DROP PROC sp_tblDepartment_delete
GO
CREATE PROC sp_tblDepartment_delete
	@DepartmentID INT
AS
BEGIN
	DELETE tblDepartment WHERE DepartmentID=@DepartmentID
END
GO
/* creapte pro get */
IF OBJECT_ID('sp_tblDepartment_get','P') IS NOT NULL
	DROP PROC sp_tblDepartment_get
GO
CREATE PROC sp_tblDepartment_get
	@DepartmentID INT=NULL,
	@Name NVARCHAR(200)=NULL,
	@DepartmentParent INT=NULL,
	@Order VARCHAR(20)='DESC',
	@OrderBy VARCHAR(100)='Name',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @DepartmentID IS NULL OR @DepartmentID = 0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(300)
		SET @Start=((@PageIndex-1)*@PageSize+1)
		SET @End=(@PageSize*@PageIndex)
		SET @DieuKien=' WHERE (1=1)'		
		IF @Name IS NOT NULL AND @Name<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Name LIKE(N''%'+ @Name +'%'')'
		END
		IF @DepartmentParent IS NOT NULL AND @DepartmentParent<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND DepartmentParent='+cast(@DepartmentParent AS NVARCHAR)
		END				
		EXEC('WITH tblRecords AS (SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,* 
			FROM tblDepartment'+@DieuKien+'),tblTotalResult AS (SELECT MAX(RowIndex) AS TotalResult 
			FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)
	END
	ELSE
	BEGIN
		SELECT * FROM tblDepartment WHERE DepartmentID=@DepartmentID
	END	
END
GO
/* table Group */
/* create tblGroup */
IF OBJECT_ID('tblGroup','U') IS NOT NULL
	DROP TABLE tblGroup
GO
CREATE TABLE tblGroup
(
	GroupID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(300),
	[Description] NVARCHAR(MAX)		
)
GO
/* create proc add */
IF OBJECT_ID('sp_tblGroup_add','P') IS NOT NULL
	DROP PROC sp_tblGroup_add
GO
CREATE PROC sp_tblGroup_add	
	@Name NVARCHAR(300),
	@Description NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO tblGroup([Name],[Description]) VALUES(@Name,@Description)
END
GO
/* create proc update */
IF OBJECT_ID('sp_tblGroup_update','P') IS NOT NULL
	DROP PROC sp_tblGroup_update
GO
CREATE PROC sp_tblGroup_update
	@GroupID INT,
	@Name NVARCHAR(300),
	@Description NVARCHAR(MAX)
AS
BEGIN
	UPDATE tblGroup SET [Name]=@Name,[Description]=@Description WHERE GroupID=@GroupID
END
/* create proc delete */
GO
IF OBJECT_ID('sp_tblGroup_delete','P') IS NOT NULL
	DROP PROC sp_tblGroup_delete
GO
CREATE PROC sp_tblGroup_delete
	@GroupID INT
AS
BEGIN
	DELETE tblGroup WHERE GroupID=@GroupID
END
GO
/* create proc get */
IF OBJECT_ID('sp_tblGroup_get','P') IS NOT NULL
	DROP PROC sp_tblGroup_get
GO
CREATE PROC sp_tbleGroup_get
	@GroupID INT=NULL,
	@Name NVARCHAR(300)=NULL,
	@Order VARCHAR(20)='DESC',
	@OrderBy VARCHAR(100)='Name',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @GroupID IS NULL OR @GroupID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start = (@PageIndex-1)*@PageSize+1
		SET @End = @PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'
		IF @Name IS NOT NULL AND @Name<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Name LIKE(N''%'+@Name+'%'')'
		END
		EXEC('WITH tblRecords AS (SELECT ROW_NUMBER() OVER (ODERY BY '+@OrderBy+' '+@Order+') AS RowIndex,* 
			FROM tblGroup'+@DieuKien+'),tblTotalResult AS (SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)
	END
	ELSE
	BEGIN
		SELECT * FROM tblGroup WHERE GroupID=@GroupID
	END
END
GO
/* table Permission */
/* create tblPermission */
IF OBJECT_ID('tblPermission','U') IS NOT NULL
	DROP TABLE tblPermission
GO
CREATE TABLE tblPermission
(
	PermissionID INT IDENTITY(1,1) PRIMARY KEY,
	IDModule VARCHAR(200),
	IDGroup INT FOREIGN KEY REFERENCES tblGroup(GroupID),
	Roles VARCHAR(300)
)
GO
/* create proc add */
IF OBJECT_ID('sp_tblPermission_add','P') IS NOT NULL
	DROP PROC sp_tblPermission_add
GO
CREATE PROC sp_tblPermission_add
	@IDModule VARCHAR(200),
	@IDGroup INT,
	@Roles VARCHAR(300)
AS
BEGIN
	INSERT INTO tblPermission(IDModule,IDGroup,Roles) VALUES(@IDModule,@IDGroup,@Roles)
END
/* create proc update */
IF OBJECT_ID('sp_tblPermission_update','P') IS NOT NULL
	DROP PROC sp_tblPermission_update
GO
CREATE PROC sp_tblPermission_update
	@PermissionID INT,
	@IDModule