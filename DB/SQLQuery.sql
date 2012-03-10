USE Master
IF DB_ID('DBEOFFICE') IS NOT NULL
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
CREATE PROC sp_tblDepartment_add 
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
/* create pro delete */
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
CREATE PROC sp_tblGroup_get
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
			SET @DieuKien=@DieuKien+' AND Name='''+@Name+''''
		END
		EXEC('WITH tblRecords AS (SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,* 
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
	@IDModule VARCHAR(200),
	@IDGroup INT,
	@Roles VARCHAR(300)
AS
BEGIN
	UPDATE tblPermission SET Roles=@Roles WHERE IDModule=@IDModule AND IDGroup=@IDGroup
END
GO
/* delete */
IF OBJECT_ID('sp_tblPermission_delete','P') IS NOT NULL
	DROP PROC sp_tblPermission_delete
GO
CREATE PROC sp_tblPermission_delete
	@IDModule VARCHAR(200)=NULL,
	@IDGroup INT=NULL
AS
BEGIN
	IF (@IDModule IS NOT NULL AND @IDModule<>'') OR (@IDGroup IS NOT NULL AND @IDGroup<>'')
	BEGIN
		DECLARE @DieuKien NVARCHAR(500)
		SET @DieuKien=' WHERE (1=1)'
		IF @IDModule IS NOT NULL AND @IDModule<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDMoudule='+cast(@IDModule AS NVARCHAR)
		END
		IF @IDGroup IS NOT NULL AND @IDGroup<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDGroup='+cast(@IDGroup AS NVARCHAR)
		END
	END
END
/* get */
GO
IF OBJECT_ID('sp_tblPermission_get','P') IS NOT NULL
	DROP PROC sp_tblPermission_get
GO
CREATE PROC sp_tblPermission_get	
	@IDGroup INT
AS
BEGIN
	IF @IDGroup IS NOT NULL AND @IDGroup<>0
	BEGIN
		SELECT * FROM tblPermission WHERE IDGroup=@IDGroup
	END
	ELSE
	BEGIN
		SELECT * FROM tblPermission
	END
END
GO
/* table User */	
IF OBJECT_ID('tblUser','U') IS NOT NULL
	DROP TABLE tblUser
GO
CREATE TABLE tblUser
(
	UserID INT IDENTITY(1,1) PRIMARY KEY,
	UserName VARCHAR(200) UNIQUE,
	[Password] VARCHAR(300),
	FullName NVARCHAR(300),
	Email VARCHAR(200),
	PhoneNumber VARCHAR(100),
	Tel VARCHAR(100),
	Gender VARCHAR(20),
	BirthDay DATETIME,
	[Address] NVARCHAR(200),
	Position NVARCHAR(200),
	[Status] VARCHAR(50),
	IDDepartment INT FOREIGN KEY REFERENCES tblDepartment(DepartmentID)	
)
GO
/* add */
IF OBJECT_ID('sp_tblUser_add','P') IS NOT NULL
	DROP PROC sp_tblUser_add
GO
CREATE PROC sp_tblUser_add	
	@UserName VARCHAR(200),
	@Password VARCHAR(300),
	@FullName NVARCHAR(300),
	@Email VARCHAR(200),
	@PhoneNumber VARCHAR(100),
	@Tel VARCHAR(100),
	@Gender VARCHAR(20),
	@BirthDay DATETIME,
	@Address NVARCHAR(200),
	@Position NVARCHAR(200),
	@Status VARCHAR(50),
	@IDDepartment INT	
AS
BEGIN
	INSERT INTO tblUser(UserName,[Password],FullName,Email,PhoneNumber,Tel,Gender,BirthDay,[Address],Position,[Status],IDDepartment)
	 VALUES(@UserName,@Password,@FullName,@Email,@PhoneNumber,@Tel,@Gender,@BirthDay,@Address,@Position,@Status,@IDDepartment)
END
GO
/* update */
IF OBJECT_ID('sp_tblUser_update','P') IS NOT NULL
	DROP PROC sp_tblUser_update
GO
CREATE PROC sp_tblUser_update	
	@UserName VARCHAR(200),
	@Password VARCHAR(300)=NULL,
	@FullName NVARCHAR(300)=NULL,
	@Email VARCHAR(200)=NULL,
	@PhoneNumber VARCHAR(100)=NULL,
	@Tel VARCHAR(100)=NULL,
	@Gender VARCHAR(20)=NULL,
	@BirthDay DATETIME=NULL,
	@Address NVARCHAR(200)=NULL,
	@Position NVARCHAR(200)=NULL,
	@Status VARCHAR(50)=NULL,
	@IDDepartment INT=NULL	
AS
BEGIN
	DECLARE @Update NVARCHAR(500)
	SET @Update=' UserName='''+cast(@UserName AS NVARCHAR)+''''
	IF @Password IS NOT NULL AND @Password<>''
	BEGIN
		SET @Update=@Update+',Password='''+cast(@Password AS NVARCHAR)+''''
	END
	IF @FullName IS NOT NULL AND @FullName<>''
	BEGIN
		SET @Update=@Update+',FullName =N'''+cast(@FullName AS NVARCHAR)+''''
	END
	IF @Email IS NOT NULL AND @Email<>''
	BEGIN
		SET @Update=@Update+',Email ='''+cast(@Email AS NVARCHAR)+''''
	END
	IF @PhoneNumber IS NOT NULL AND @PhoneNumber<>''
	BEGIN
		SET @Update=@Update+',PhoneNumber ='''+cast(@PhoneNumber AS NVARCHAR)+''''
	END
	IF @Tel IS NOT NULL AND @Tel<>''
	BEGIN
		SET @Update=@Update+',Tel ='''+cast(@Tel AS NVARCHAR)+''''
	END
	IF @Gender IS NOT NULL AND @Gender<>''
	BEGIN
		SET @Update=@Update+',Gender='''+cast(@Gender AS VARCHAR)+''''
	END
	IF @BirthDay IS NOT NULL AND @BirthDay<>''
	BEGIN
		SET @Update=@Update+',BirthDay='''+cast(@BirthDay AS VARCHAR)+''''
	END
	IF @Address IS NOT NULL AND @Address<>''
	BEGIN
		SET @Update=@Update+',Address =N'''+cast(@Address AS NVARCHAR)+''''
	END
	IF @Position IS NOT NULL AND @Position<>''
	BEGIN
		SET @Update=@Update+',Position =N'''+cast(@Position AS NVARCHAR)+''''
	END
	IF @Status IS NOT NULL AND @Status<>''
	BEGIN
		SET @Update=@Update+',Status='''+cast(@Status AS NVARCHAR)+''''
	END
	IF @IDDepartment IS NOT NULL AND @IDDepartment<>0
	BEGIN
		SET @Update=@Update+',IDDepartment='+cast(@IDDepartment AS VARCHAR)
	END	
	EXEC('UPDATE tblUser SET'+@Update+' WHERE UserName='''+@UserName+'''')
END
GO
/* delete */
IF OBJECT_ID('sp_tblUser_delete','P') IS NOT NULL
	DROP PROC sp_tblUser_delete
GO
CREATE PROC sp_tblUser_delete
	@UserName VARCHAR(200)
AS
BEGIN
	DELETE tblUser WHERE UserName=@UserName
END	
GO
/* get */
IF OBJECT_ID('sp_tblUser_get','P') IS NOT NULL
	DROP PROC sp_tblUser_get
GO
CREATE PROC sp_tblUser_get
	@UserID INT=NULL,
	@UserName VARCHAR(200)=NULL,	
	@FullName NVARCHAR(300)=NULL,
	@Email VARCHAR(200)=NULL,
	@PhoneNumber VARCHAR(100)=NULL,
	@Tel VARCHAR(100)=NULL,
	@Gender VARCHAR(20)=NULL,
	@BirthDay DATETIME=NULL,
	@Address NVARCHAR(200)=NULL,
	@Position NVARCHAR(200)=NULL,
	@Status VARCHAR(50)=NULL,
	@IDDepartment INT=NULL,	
	@Order VARCHAR(20)='DESC',
	@OrderBy VARCHAR(100)='FullName',
	@PageIndex INT=1,
	@PageSize INT=50,
	@Password VARCHAR(200)=NULL
AS
BEGIN
	IF @UserID IS NOT NULL AND @UserID<>0
	BEGIN
		SELECT * FROM tblUser WHERE UserID=@UserID
	END
	ELSE
	BEGIN
		IF @UserName IS NULL OR @UserName=''
		BEGIN
			DECLARE @Start INT
			DECLARE @End INT
			DECLARE @DieuKien NVARCHAR(500)
			SET @Start=(@PageIndex-1)*@PageSize+1
			SET @End=@PageIndex*@PageSize
			SET @DieuKien=' WHERE (1=1)'
			IF @FullName IS NOT NULL AND @FullName<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND FullName LIKE(N''%'+@FullName+'%'')'
			END
			IF @Email IS NOT NULL AND @Email<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Email LIKE(N''%'+@Email+'%'')'
			END
			IF @PhoneNumber IS NOT NULL AND @PhoneNumber<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND PhoneNumber LIKE(N''%'+@PhoneNumber+'%'')'
			END
			IF @Tel IS NOT NULL AND @Tel<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Tel LIKE(N''%'+@Tel+'%'')'
			END
			IF @Gender IS NOT NULL AND @Gender<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Gender ='''+cast(@Gender AS NVARCHAR)+''''
			END
			IF @BirthDay IS NOT NULL AND @BirthDay<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND BirthDay='''+cast(@BirthDay AS NVARCHAR)+''''
			END
			IF @Address IS NOT NULL AND @Address<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Address LIKE(N''%'+@Address+'%'')'
			END
			IF @Position IS NOT NULL AND @Position<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Position LIKE(N''%'+@Position+'%'')'
			END
			IF @Status IS NOT NULL AND @Status<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Status='''+cast(@Status AS NVARCHAR)+''''
			END
			IF @IDDepartment IS NOT NULL AND @IDDepartment<>0
			BEGIN
				SET @DieuKien=@DieuKien+' AND IDDepartment='+cast(@IDDepartment AS NVARCHAR)
			END			
			EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,*
				FROM tblUser'+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
				SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)
		END
		ELSE
		BEGIN
			SELECT * FROM tblUser WHERE UserName=@UserName AND (Password=@Password OR @Password IS NULL)
		END
	END
END
GO
/* get */
IF OBJECT_ID('sp_tblUser_getcount','P') IS NOT NULL
	DROP PROC sp_tblUser_get
GO
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_tblUser_getcount]
	@UserID INT=NULL,
	@UserName VARCHAR(200)=NULL,	
	@FullName NVARCHAR(300)=NULL,
	@Email VARCHAR(200)=NULL,
	@PhoneNumber VARCHAR(100)=NULL,
	@Tel VARCHAR(100)=NULL,
	@Gender VARCHAR(20)=NULL,
	@BirthDay DATETIME=NULL,
	@Address NVARCHAR(200)=NULL,
	@Position NVARCHAR(200)=NULL,
	@Status VARCHAR(50)=NULL,
	@IDDepartment INT=NULL,	
	@Order VARCHAR(20)='DESC',
	@OrderBy VARCHAR(100)='FullName',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @UserID IS NOT NULL AND @UserID<>0
	BEGIN
		SELECT * FROM tblUser WHERE UserID=@UserID
	END
	ELSE
	BEGIN
		IF @UserName IS NULL OR @UserName=''
		BEGIN
			DECLARE @Start INT
			DECLARE @End INT
			DECLARE @DieuKien NVARCHAR(500)
			SET @Start=(@PageIndex-1)*@PageSize+1
			SET @End=@PageIndex*@PageSize
			SET @DieuKien=' WHERE (1=1)'
			IF @FullName IS NOT NULL AND @FullName<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND FullName LIKE(N''%'+@FullName+'%'')'
			END
			IF @Email IS NOT NULL AND @Email<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Email LIKE(N''%'+@Email+'%'')'
			END
			IF @PhoneNumber IS NOT NULL AND @PhoneNumber<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND PhoneNumber LIKE(N''%'+@PhoneNumber+'%'')'
			END
			IF @Tel IS NOT NULL AND @Tel<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Tel LIKE(N''%'+@Tel+'%'')'
			END
			IF @Gender IS NOT NULL AND @Gender<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Gender ='''+cast(@Gender AS NVARCHAR)+''''
			END
			IF @BirthDay IS NOT NULL AND @BirthDay<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND BirthDay='''+cast(@BirthDay AS NVARCHAR)+''''
			END
			IF @Address IS NOT NULL AND @Address<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Address LIKE(N''%'+@Address+'%'')'
			END
			IF @Position IS NOT NULL AND @Position<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Position LIKE(N''%'+@Position+'%'')'
			END
			IF @Status IS NOT NULL AND @Status<>''
			BEGIN
				SET @DieuKien=@DieuKien+' AND Status='''+cast(@Status AS NVARCHAR)+''''
			END
			IF @IDDepartment IS NOT NULL AND @IDDepartment<>0
			BEGIN
				SET @DieuKien=@DieuKien+' AND IDDepartment='+cast(@IDDepartment AS NVARCHAR)
			END			
			EXEC('SELECT COUNT(UserId)
				FROM tblUser '+@DieuKien)
		END
		ELSE
		BEGIN
			SELECT COUNT(UserId) FROM tblUser WHERE UserName=@UserName
		END
	END
END


GO
/* table User_Group */
IF OBJECT_ID('tblUser_Group','U') IS NOT NULL
	DROP TABLE tblUser_Group
GO
CREATE TABLE tblUser_Group
(
	IDUser INT FOREIGN KEY REFERENCES tblUser(UserID),
	IDGroup INT FOREIGN KEY REFERENCES tblGroup(GroupID),
	PRIMARY KEY(IDUser,IDGroup)
)
GO
/* add */
IF OBJECT_ID('sp_tblUser_Group_add','P') IS NOT NULL
	DROP PROC sp_tblUser_Group_add
GO
CREATE PROC sp_tblUser_Group_add
	@IDUser INT,
	@IDGroup INT
AS
BEGIN
	INSERT INTO tblUser_Group(IDUser,IDGroup) VALUES(@IDUser,@IDGroup)
END
GO
/* update */
IF OBJECT_ID('sp_tblUser_Group_delete','P') IS NOT NULL
	DROP PROC sp_tblUser_Group_delete
GO
CREATE PROC sp_tblUser_Group_delete
	@IDUser INT,
	@IDGroup INT
AS
BEGIN
	DELETE tblUser_Group WHERE IDUser=@IDUser AND IDGroup=@IDGroup
END
/* get */
IF OBJECT_ID('sp_tblUser_Group_get','P') IS NOT NULL
	DROP PROC sp_tblUser_Group_get
GO
CREATE PROC sp_tblUser_Group_get
	@IDUser INT=NULL,
	@IDGroup INT=NULL
AS
BEGIN
	DECLARE @DieuKien NVARCHAR(500)
	SET @DieuKien=' WHERE (1=1)'
	IF @IDUser IS NOT NULL AND @IDUser<>0
	BEGIN
		SET @DieuKien=@DieuKien+' AND IDUser='+cast(@IDUser AS NVARCHAR)
	END
	IF @IDGroup IS NOT NULL AND @IDGroup<>0
	BEGIN
		SET @DieuKien=@DieuKien+' AND IDGroup='+cast(@IDGroup AS NVARCHAR)
	END
	EXEC('SELECT * FROM tblUser_Group'+@DieuKien)
END
/* table DocumentKind */
IF OBJECT_ID('tblDocumentKind','U') IS NOT NULL
	DROP TABLE tblDocumentKind
GO
CREATE TABLE tblDocumentKind
(
	DocumentKindID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(200),
	[Description] NVARCHAR(300),
	DocumentKindParent INT DEFAULT(0)
)
GO
/* add */
IF OBJECT_ID('sp_tblDocumentKind_add','P') IS NOT NULL
	DROP PROC sp_tblDocumentKind_add
GO
CREATE PROC sp_tblDocumentKind_add
	@Name NVARCHAR(200),
	@Description NVARCHAR(300),
	@DocumentKindParent INT=0
AS
BEGIN
	INSERT INTO tblDocumentKind([Name],[Description],DocumentKindParent) VALUES(@Name,@Description,@DocumentKindParent)
END
/* update */
IF OBJECT_ID('sp_tblDocumentKind_update','P') IS NOT NULL
	DROP PROC sp_tblDocumentKind_update
GO
CREATE PROC sp_tblDocumentKind_update
	@DocumentKindID INT,
	@Name NVARCHAR(200),
	@Description NVARCHAR(300),
	@DocumentKindParent INT=0
AS
BEGIN
	UPDATE tblDocumentKind SET [Name]=@Name,[Description]=@Description,DocumentKindParent=@DocumentKindParent 
		WHERE DocumentKindID=@DocumentKindID
END
/* delte */
IF OBJECT_ID('sp_tblDocumentKind_delete','P') IS NOT NULL
	DROP PROC sp_tblDocumentKind_delete
GO
CREATE PROC sp_tblDocumentKind_delete
	@DocumentKindID INT
AS
BEGIN
	DELETE tblDocumentKind WHERE DocumentKindID=@DocumentKindID
END
/* get */
IF OBJECT_ID('sp_tblDocumentKind_get','P') IS NOT NULL
	DROP PROC sp_tblDocumentKind_get
GO
CREATE PROC sp_tblDocumentKind_get
	@DocumentKindID INT=NULL
AS
BEGIN
	IF @DocumentKindID IS NULL OR @DocumentKindID=0
	BEGIN
		SELECT * FROM tblDocumentKind
	END
	ELSE
	BEGIN
		SELECT * FROM tblDocumentKind WHERE DocumentKindID=@DocumentKindID
	END
END
/* table Offical */
GO
IF OBJECT_ID('tblOffical','U') IS NOT NULL
	DROP TABLE tblOffical
GO
CREATE TABLE tblOffical
(
	OfficalID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(300),
	[Description] NVARCHAR(300),
	[Address] NVARCHAR(300),
	Tel VARCHAR(100),
	Fax VARCHAR(100),
	Email VARCHAR(100),
	OfficalParent INT DEFAULT(0)
)
/* add */
IF OBJECT_ID('sp_tblOffical_add','P') IS NOT NULL
	DROP PROC sp_tblOffical_add
GO
CREATE PROC sp_tblOffical_add
	@Name NVARCHAR(300),	
	@Description NVARCHAR(300),
	@Address NVARCHAR(300),
	@Tel VARCHAR(100),
	@Fax VARCHAR(100),
	@Email VARCHAR(100),
	@OfficalParent INT=0
AS
BEGIN
	INSERT INTO tblOffical([Name],[Description],[Address],Tel,Fax,Email,OfficalParent) 
		VALUES(@Name,@Description,@Address,@Tel,@Fax,@Email,@OfficalParent)
END
/* update */
GO
IF OBJECT_ID('sp_tblOffical_update','P') IS NOT NULL
	DROP PROC sp_tblOffical_update
GO
CREATE PROC sp_tblOffical_update	
	@OfficalID INT,
	@Name NVARCHAR(300),
	@Description NVARCHAR(300),
	@Address NVARCHAR(300),
	@Tel VARCHAR(100),
	@Fax VARCHAR(100),
	@Email VARCHAR(100),
	@OfficalParent INT=0
AS
BEGIN
	UPDATE tblOffical SET [Name]=@Name,[Description]=@Description,[Address]=@Address,Tel=@Tel,Fax=@Fax,Email=@Email,OfficalParent=@OfficalParent
END
/* delte */
GO
IF OBJECT_ID('sp_tblOffical_delete','P') IS NOT NULL
	DROP PROC sp_tblOffical_delete
GO
CREATE PROC sp_tblOffical_delete
	@OfficalID INT
AS
BEGIN
	DELETE tblOffical WHERE OfficalID=@OfficalID
END
GO
/* get */
IF OBJECT_ID('sp_tblOffical_get','P') IS NOT NULL
	DROP PROC sp_tblOffical_get
GO
CREATE PROC sp_tblOffical_get
	@OfficalID INT=NULL,
	@Name NVARCHAR(300)=NULL,
	@Address NVARCHAR(300)=NULL,
	@Tel VARCHAR(100)=NULL,
	@Fax VARCHAR(100)=NULL,
	@Email VARCHAR(100)=NULL,
	@OfficalParent INT=NULL,
	@Order VARCHAR(20)='DESC',
	@OrderBy VARCHAR(100)='Name',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @OfficalID IS NULL OR @OfficalID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'
		IF @Name IS NOT NULL AND @Name<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Name LIKE(N''%'+@Name+'%'')'
		END
		IF @Address IS NOT NULL AND @Address<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Address LIKE(N''%'+@Address+'%'')'
		END
		IF @Tel IS NOT NULL AND @Tel<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Tel LIKE(N''%'+@Tel+'%'')'
		END
		IF @Fax IS NOT NULL AND @Fax<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Fax LIKE(N''%'+@Fax+'%'')'
		END
		IF @Email IS NOT NULL AND @Email<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Email LIKE(N''%'+@Email+'%'')'
		END
		IF @OfficalParent IS NOT NULL
		BEGIN
			SET @DieuKien=@DieuKien+' AND OfficalParent='+cast(@OfficalParent AS NVARCHAR)
		END
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,*
			FROM tblOffical'+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)
	END
	ELSE
	BEGIN
		SELECT * FROM tblOffical WHERE OfficalID=@OfficalID
	END
END
GO
/* table attach */
IF OBJECT_ID('tblAttach','U') IS NOT NULL
	DROP TABLE tblAttach
GO
CREATE TABLE tblAttach
(
	AttachID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(300),
	[Description] NVARCHAR(300),
	[Path] NVARCHAR(300)	
)
/* add */
GO
IF OBJECT_ID('sp_tblAttach_add','P') IS NOT NULL
	DROP PROC sp_tblAttach_add
GO
CREATE PROC sp_tblAttach_add
	@Name NVARCHAR(300),
	@Description NVARCHAR(300),
	@Path NVARCHAR(300)
AS
BEGIN
	INSERT INTO tblAttach([Name],[Description],[Path]) VALUES(@Name,@Description,@Path)
END
/* update */
GO
IF OBJECT_ID('sp_tblAttach_update','P') IS NOT NULL
	DROP PROC sp_tblAttach_update
GO
CREATE PROC sp_tblAttach_update
	@AttachID INT,
	@Name NVARCHAR(300),
	@Description NVARCHAR(300),
	@Path NVARCHAR(300)
AS
BEGIN
	UPDATE tblAttach SET [Name]=@Name,[Description]=@Description,[Path]=@Path WHERE AttachID=@AttachID
END
/* delete */
GO
IF OBJECT_ID('sp_tblAttach_delete','P') IS NOT NULL
	DROP PROC sp_tblAttach_delete
GO
CREATE PROC sp_tblAttach_delete
	@AttachID INT
AS
BEGIN
	DELETE tblAttach WHERE AttachID=@AttachID
END
/* get */
GO
IF OBJECT_ID('sp_tblAttach_get','P') IS NOT NULL
	DROP PROC sp_tblAttach_get
GO
CREATE PROC sp_tblAttach_get
	@AttachID INT
AS
BEGIN
	SELECT * FROM tblAttach WHERE AttachID=@AttachID
END
/* get last record */
GO
IF OBJECT_ID('sp_tblAttach_getlast','P') IS NOT NULL
	DROP PROC sp_tblAttach_getlast
GO
CREATE PROC sp_tblAttach_getlast	
AS
BEGIN
	SELECT * FROM tblAttach WHERE AttachID = IDENT_CURRENT('tblAttach')
END
/* table Document */
GO
IF OBJECT_ID('tblDocument','U') IS NOT NULL
	DROP TABLE tblDocument
GO
CREATE TABLE tblDocument
(
	DocumentID VARCHAR(500) PRIMARY KEY,
	DocumentNumber NVARCHAR(200),
	[Name] NVARCHAR(300),
	[Excerpt] NVARCHAR(MAX),
	[Content] NVARCHAR(MAX),	
	PublishDate DATETIME,
	PublishOffical INT FOREIGN KEY REFERENCES tblOffical(OfficalID),
	Attachs VARCHAR(50),
	IDDocumentKind INT FOREIGN KEY REFERENCES tblDocumentKind(DocumentKindID),
	CreateDate DATETIME DEFAULT(GetDate()),
	IDUserCreate INT FOREIGN KEY REFERENCES tblUser(UserID),
	UserProcess VARCHAR(100),
	UserComments VARCHAR(100),
	StartProcess DATETIME DEFAULT(GetDate()),
	EndProcess DATETIME,
	SendDate DATETIME DEFAULT(GetDate()),
	ReceiveDate DATETIME,	
	SendOfficals VARCHAR(100),
	Priority VARCHAR(20),
	[Status] VARCHAR(50)
)
GO
/* add */
IF OBJECT_ID('sp_tblDocument_add','P') IS NOT NULL
	DROP PROC sp_tblDocument_add
GO
CREATE PROC sp_tblDocument_add
	@DocumentID VARCHAR(500)= NULL,
	@DocumentNumber NVARCHAR(200)=NULL,
	@Name NVARCHAR(300),
	@Excerpt NVARCHAR(MAX)=NULL,
	@Content NVARCHAR(MAX)=NULL,	
	@PublishDate DATETIME=NULL,
	@PublishOffical INT,
	@Attachs VARCHAR(50)=NULL,
	@IDDocumentKind INT,
	@CreateDate DATETIME,
	@IDUserCreate INT,
	@UserProcess VARCHAR(100),
	@UserComments VARCHAR(100)=NULL,
	@StartProcess DATETIME,
	@EndProcess DATETIME=NULL,
	@SendDate DATETIME,
	@ReceiveDate DATETIME=NULL,	
	@SendOfficals VARCHAR(100)=NULL,
	@Priority VARCHAR(20),
	@Status VARCHAR(50)
AS
BEGIN
	INSERT INTO tblDocument(DocumentNumber,[Name],Excerpt,[Content],PublishDate,PublishOffical,
				Attachs,IDDocumentKind,CreateDate,IDUserCreate,UserProcess,UserComments,StartProcess,EndProcess,
				SendDate,ReceiveDate,SendOfficals,Priority,[Status]) 
				VALUES(@DocumentNumber,@Name,@Excerpt,@Content,@PublishDate,@PublishOffical,
				@Attachs,@IDDocumentKind,@CreateDate,@IDUserCreate,@UserProcess,@UserComments,@StartProcess,@EndProcess,
				@SendDate,@ReceiveDate,@SendOfficals,@Priority,@Status)
END
GO
/* update */
IF OBJECT_ID('sp_tblDocument_update','P') IS NOT NULL
	DROP PROC sp_tblDocument_update
GO
CREATE PROC sp_tblDocument_update
	@DocumentID VARCHAR(500),
	@DocumentNumber NVARCHAR(200),
	@Name NVARCHAR(300)=NULL,
	@Excerpt NVARCHAR(MAX)=NULL,
	@Content NVARCHAR(MAX)=NULL,	
	@PublishDate DATETIME=NULL,
	@PublishOffical INT =NULL,
	@Attachs VARCHAR(50)=NULL,
	@IDDocumentKind INT =NULL,
	@CreateDate DATETIME=NULL,	
	@UserProcess VARCHAR(100)=NULL,
	@UserComments VARCHAR(100)=NULL,
	@StartProcess DATETIME=NULL,
	@EndProcess DATETIME=NULL,
	@SendDate DATETIME=NULL,
	@ReceiveDate DATETIME=NULL,	
	@SendOfficals VARCHAR(100)=NULL,
	@Priority VARCHAR(20)=NULL,
	@Status VARCHAR(50)=NULL
AS
BEGIN
	DECLARE @Update NVARCHAR(500)
	SET @Update=' DocumentNumber='''+cast(@DocumentNumber AS NVARCHAR)+''''
	IF @Name IS NOT NULL AND @Name<>''
	BEGIN
		SET @Update=@Update+',Name='''+cast(@Name AS NVARCHAR)+''''
	END
	IF @Excerpt IS NOT NULL
	BEGIN
		SET @Update=@Update+',Excerpt='''+cast(@Excerpt AS NVARCHAR)+''''
	END
	IF @Content IS NOT NULL
	BEGIN
		SET @Update=@Update+',Content='''+cast(@Content AS NVARCHAR)+''''
	END
	IF @PublishDate IS NOT NULL AND @PublishDate<>''
	BEGIN
		SET @Update=@Update+',PublishDate='''+@PublishDate+''''
	END
	IF @PublishOffical IS NOT NULL AND @PublishOffical<>0
	BEGIN
		SET @Update=@Update+',PublishOffical='+cast(@PublishOffical AS NVARCHAR)
	END
	IF @Attachs IS NOT NULL
	BEGIN
		SET @Update=@Update+',Attachs='''+cast(@Attachs AS VARCHAR)+''''
	END
	IF @IDDocumentKind IS NOT NULL AND @IDDocumentKind<>0
	BEGIN
		SET @Update=@Update+',IDDocumentKind='+cast(@IDDocumentKind AS NVARCHAR)
	END
	IF @CreateDate IS NOT NULL AND @CreateDate<>''
	BEGIN
		SET @Update=@Update+',CreateDate='''+@CreateDate+''''
	END
	IF @UserProcess IS NOT NULL AND @UserProcess<>''
	BEGIN
		SET @Update=@Update+',UserProcess='''+cast(@UserProcess AS VARCHAR)+''''
	END
	IF @UserComments IS NOT NULL
	BEGIN
		SET @Update=@Update+',UserComments='''+cast(@UserComments AS VARCHAR)+''''
	END
	IF @StartProcess IS NOT NULL AND @StartProcess<>''
	BEGIN
		SET @Update=@Update+',StartProcess='''+@StartProcess+''''
	END
	IF @EndProcess IS NOT NULL
	BEGIN
		SET @Update=@Update+',EndProcess='''+@EndProcess+''''
	END
	IF @SendDate IS NOT NULL AND @SendDate<>''
	BEGIN
		SET @Update=@Update+',SendDate='''+@SendDate+''''
	END
	IF @ReceiveDate IS NOT NULL AND @ReceiveDate<>''
	BEGIN
		SET @Update=@Update+',ReceiveDate='''+@ReceiveDate+''''
	END
	IF @SendOfficals IS NOT NULL
	BEGIN
		SET @Update=@Update+',SendOfficals='''+cast(@SendOfficals AS VARCHAR)+''''
	END
	IF @Priority IS NOT NULL AND @Priority<>''
	BEGIN
		SET @Update=@Update+',Priority='''+cast(@Priority AS NVARCHAR)+''''
	END
	IF @Status IS NOT NULL AND @Status<>''
	BEGIN
		SET @Update=@Update+',Status='''+cast(@Status AS NVARCHAR)+''''
	END
	EXEC('UPDATE tblDocument SET'+@Update+' WHERE DocumentID='+@DocumentID)
END
GO
/* delete */
IF OBJECT_ID('sp_tblDocument_delete','P') IS NOT NULL
	DROP PROC sp_tblDocument_delete
GO
CREATE PROC sp_tblDocument_delete
	@DocumentID VARCHAR(500)
AS
BEGIN
	DELETE tblDocument WHERE DocumentID=@DocumentID
END
/* get */
IF OBJECT_ID('sp_tblDocument_get','P') IS NOT NULL
	DROP PROC sp_tblDocument_get
GO
CREATE PROC sp_tblDocument_get
	@DocumentID VARCHAR(500),
	@DocumentNumber NVARCHAR(200)=NULL,
	@Name NVARCHAR(300)=NULL,
	@Content NVARCHAR(MAX)=NULL,	
	@IDUserCreate INT=NULL,
	@FromPublishDate DATETIME=NULL,
	@ToPublishDate DATETIME=NULL,
	@PublishOffical INT =NULL,
	@IDDocumentKind INT =NULL,
	@FromCreateDate DATETIME=NULL,	
	@ToCreateDate DATETIME=NULL,	
	@UserProcess VARCHAR(100)=NULL,
	@UserComments VARCHAR(100)=NULL,		
	@FromReceiveDate DATETIME=NULL,		
	@ToReceiveDate DATETIME=NULL,
	@Priority VARCHAR(20)=NULL,
	@Status VARCHAR(50)=NULL,
	@Order VARCHAR(30)='DESC',
	@OrderBy VARCHAR(100)='Name',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @DocumentID IS NULL OR @DocumentID=''
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'
		IF @DocumentNumber IS NOT NULL AND @DocumentNumber<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND DocumentNumber ='''+cast(@DocumentNumber AS NVARCHAR)+''''
		END
		IF @Name IS NOT NULL AND @Name<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Name LIKE(N''%'+@Name+'%'')'
		END
		IF @Content IS NOT NULL AND @Content<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Content LIKE(N''%'+@Content+'%'')'
		END
		IF @IDUserCreate IS NOT NULL AND @IDUserCreate<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDUserCreate ='+cast(@IDUserCreate AS NVARCHAR)
		END
		IF @FromPublishDate IS NOT NULL AND @FromPublishDate<>'' AND @ToPublishDate IS NOT NULL AND @ToPublishDate<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND PublishDate BETWEEN '''+@FromPublishDate+''' AND '''+@ToPublishDate+''''
		END
		IF @PublishOffical IS NOT NULL AND @PublishOffical<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND PublishOffical ='+cast(@PublishOffical AS NVARCHAR)
		END
		IF @IDDocumentKind IS NOT NULL AND @IDDocumentKind<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDDocumentKind='+cast(@IDDocumentKind AS NVARCHAR)
		END
		IF @FromCreateDate IS NOT NULL AND @FromCreateDate<>'' AND @ToCreateDate IS NOT NULL AND @ToCreateDate<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND CreateDate BETWEEN '''+@FromCreateDate+''' AND '''+@ToCreateDate+''''
		END
		IF @UserProcess IS NOT NULL AND @UserProcess<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND UserProcess LIKE(''%'+cast(@UserProcess AS NVARCHAR)+'%'')'
		END
		IF @UserComments IS NOT NULL AND @UserComments<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND UserComments LIKE(''%'+cast(@UserComments AS NVARCHAR)+'%'')'
		END
		IF @FromReceiveDate IS NOT NULL AND @FromReceiveDate<>'' AND @ToReceiveDate IS NOT NULL AND @ToReceiveDate<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND ReceiveDate BETWEEN '''+@FromReceiveDate+''' AND '''+@ToReceiveDate+''''
		END
		IF @Priority IS NOT NULL AND @Priority<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Priority='''+cast(@Priority AS NVARCHAR)+''''
		END
		IF @Status IS NOT NULL AND @Status<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Status='''+cast(@Status AS NVARCHAR)+''''
		END		
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,*
			FROM tblDocument'+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)		
	END
	ELSE
	BEGIN
		SELECT * FROM tblDocument WHERE DocumentID=@DocumentID
	END
END
GO
/* table work group */
IF OBJECT_ID('tblWorkGroup','U') IS NOT NULL
	DROP TABLE tblWorkGroup
GO
CREATE TABLE tblWorkGroup
(
	WorkGroupID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(300),
	[Description] NVARCHAR(MAX),
	WorkGroupParent INT DEFAULT(0)	
)
GO
/* add */
IF OBJECT_ID('sp_tblWorkGroup_add','P') IS NOT NULL
	DROP PROC sp_tblWorkGroup_add
GO
CREATE PROC sp_tblWorkGroup_add
	@Name NVARCHAR(300),
	@Description NVARCHAR(MAX),
	@WorkGroupParent INT=0
AS
BEGIN
	INSERT INTO tblWorkGroup([Name],[Description],WorkGroupParent) VALUES(@Name,@Description,@WorkGroupParent)
END
GO
/* update */
IF OBJECT_ID('sp_tblWorkGroup_update','P') IS NOT NULL
	DROP PROC sp_tblWorkGroup_update
GO
CREATE PROC sp_tblWorkGroup_update
	@WorkGroupID INT,
	@Name NVARCHAR(300),
	@Description NVARCHAR(MAX),
	@WorkGroupParent INT
AS
BEGIN
	UPDATE tblWorkGroup SET [Name]=@Name,[Description]=@Description,WorkGroupParent=@WorkGroupParent WHERE WorkGroupID=@WorkGroupID
END
GO
/* delete */
IF OBJECT_ID('sp_tblWorkGroup_delete','P') IS NOT NULL
	DROP PROC sp_tblWorkGroup_delete
GO
CREATE PROC sp_tblWorkGroup_delete
	@WorkGroupID INT
AS
BEGIN
	DELETE tblWorkGroup WHERE WorkGroupID=@WorkGroupID
END
GO
/* get */
IF OBJECT_ID('sp_tblWorkGroup_get','P') IS NOT NULL
	DROP PROC sp_tblWorkGroup_get
GO
CREATE PROC sp_tblWorkGroup_get
	@WorkGroupID INT=NULL,
	@Order VARCHAR(20)='ASC',
	@OrderBy VARCHAR(100)='Name',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @WorkGroupID IS NULL OR @WorkGroupID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,* FROM tblWorkGroup)
		SELECT * FROM tblRecords WHERE RowIndex BETWEEN '+@Start+' AND '+@End)
	END
	ELSE
	BEGIN
		SELECT * FROM tblWorkGroup WHERE WorkGroupID=@WorkGroupID
	END
END
GO
/* table work */
IF OBJECT_ID('tblWork','U') IS NOT NULL
	DROP TABLE tblWork
GO
CREATE TABLE tblWork
(
	WorkID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(300),
	[Description] NVARCHAR(MAX),
	[Content] NVARCHAR(MAX),
	Attachs VARCHAR(50),	
	IDUserCreate INT FOREIGN KEY REFERENCES tblUser(UserID),
	IDUserProcess VARCHAR(100),
	IDWorkGroup INT,
	CreateDate DATETIME DEFAULT(GetDate()),
	StartProcess DATETIME DEFAULT(GetDate()),
	EndProcess DATETIME,
	[Status] VARCHAR(50),
	Priority VARCHAR(500)	
)
GO
/* add */
IF OBJECT_ID('sp_tblWork_add','P') IS NOT NULL
	DROP PROC sp_tblWork_add
GO
CREATE PROC sp_tblWork_add	
	@Name NVARCHAR(300),
	@Description NVARCHAR(MAX),
	@Content NVARCHAR(MAX),
	@Attachs VARCHAR(50),	
	@IDUserCreate INT,
	@IDUserProcess VARCHAR(100),
	@IDWorkGroup INT,
	@CreateDate DATETIME=NULL,
	@StartProcess DATETIME=NULL,
	@EndProcess DATETIME,
	@Status VARCHAR(50),
	@Priority VARCHAR(500)
AS
BEGIN
	INSERT INTO tblWork([Name],[Description],[Content],Attachs,IDUserCreate,IDUserProcess,IDWorkGroup,CreateDate,
		StartProcess,EndProcess,[Status],Priority)
		VALUES(@Name,@Description,@Content,@Attachs,@IDUserCreate,@IDUserProcess,@IDWorkGroup,@CreateDate,
		@StartProcess,@EndProcess,@Status,@Priority)
END
/* update */
GO
IF OBJECT_ID('sp_tblWork_update','P') IS NOT NULL
	DROP PROC sp_tblWork_update
GO
CREATE PROC sp_tblWork_update
	@WorkID INT,
	@Name NVARCHAR(300)=NULL,
	@Description NVARCHAR(MAX)=NULL,
	@Content NVARCHAR(MAX)=NULL,
	@Attachs VARCHAR(50)=NULL,	
	@IDUserCreate INT,
	@IDUserProcess VARCHAR(100)=NULL,
	@IDWorkGroup INT=NULL,
	@CreateDate DATETIME=NULL,
	@StartProcess DATETIME=NULL,
	@EndProcess DATETIME=NULL,
	@Status VARCHAR(50)=NULL,
	@Priority VARCHAR(500)=NULL
AS
BEGIN
	DECLARE @Update NVARCHAR(500)
	SET @Update=' IDUserCreate='+cast(@IDUserCreate AS NVARCHAR)
	IF @Name IS NOT NULL AND @Name<>''
	BEGIN
		SET @Update=@Update+',Name='''+cast(@Name AS NVARCHAR)+''''
	END
	IF @Description IS NOT NULL
	BEGIN
		SET @Update=@Update+',Description='''+cast(@Description AS NVARCHAR)+''''
	END
	IF @Content IS NOT NULL
	BEGIN
		SET @Update=@Update+',Content='''+cast(@Content AS NVARCHAR)+''''
	END
	IF @Attachs IS NOT NULL
	BEGIN
		SET @Update=@Update+',Attachs='''+cast(@Attachs AS VARCHAR)+''''
	END
	IF @IDUserProcess IS NOT NULL AND @IDUserProcess<>''
	BEGIN
		SET @Update=@Update+',IDUserProcess='''+cast(@IDUserProcess AS VARCHAR(100))+''''
	END
	IF @IDWorkGroup IS NOT NULL AND @IDWorkGroup<>0
	BEGIN
		SET @Update=@Update+',IDWorkGroup='+cast(@IDWorkGroup AS NVARCHAR)
	END	
	IF @CreateDate IS NOT NULL AND @CreateDate<>''
	BEGIN
		SET @Update=@Update+',CreateDate='''+cast(@CreateDate AS NVARCHAR(100))+''''
	END
	IF @StartProcess IS NOT NULL AND @StartProcess<>''
	BEGIN
		SET @Update=@Update+',StartProcess='''+cast(@StartProcess AS NVARCHAR(100))+''''
	END
	IF @EndProcess IS NOT NULL
	BEGIN
		SET @Update=@Update+',EndProcess='''+cast(@EndProcess AS NVARCHAR(100))+''''
	END
	IF @Status IS NOT NULL AND @Status<>''
	BEGIN
		SET @Update=@Update+',Status='''+cast(@Status AS NVARCHAR)+''''
	END
	IF @Priority IS NOT NULL AND @Priority<>''
	BEGIN
		SET @Update=@Update+',Priority='''+cast(@Priority AS NVARCHAR)+''''
	END	
	EXEC('UPDATE tblWork SET'+@Update+' WHERE WorkID='+@WorkID)
END


GO
/* delete */
IF OBJECT_ID('sp_tblWork_delete','P') IS NOT NULL
	DROP PROC sp_tblWork_delete
GO
CREATE PROC sp_tblWork_delete
	@WorkID INT
AS
BEGIN
	DELETE tblWork WHERE WorkID=@WorkID
END
GO
/* get */
IF OBJECT_ID('sp_tblWork_get','P') IS NOT NULL
	DROP PROC sp_tblWork_get
GO
CREATE PROC sp_tblWork_get
	@WorkID INT=NULL,	
	@Name NVARCHAR(300)=NULL,
	@Content NVARCHAR(MAX)=NULL,
	@IDUserCreate INT=NULL,
	@IDUserProcess VARCHAR(100)=NULL,
	@IDWorkGroup INT=NULL,
	@FromCreateDate DATETIME=NULL,
	@ToCreateDate DATETIME=NULL,
	@StartProcess DATETIME=NULL,	
	@EndProcess DATETIME=NULL,
	@Status VARCHAR(50)=NULL,
	@Priority VARCHAR(500)=NULL,
	@Order VARCHAR(30)='DESC',
	@OrderBy VARCHAR(100)='Name',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @WorkID IS NULL OR @WorkID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'		
		IF @Name IS NOT NULL AND @Name<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Name LIKE(N''%'+@Name+'%'')'
		END
		IF @Content IS NOT NULL AND @Content<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Content LIKE(N''%'+@Content+'%'')'
		END
		IF @IDUserCreate IS NOT NULL AND @IDUserCreate<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDUserCreate ='+cast(@IDUserCreate AS NVARCHAR)
		END
		IF @IDUserProcess IS NOT NULL AND @IDUserProcess<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDUserProcess LIKE(''%'+cast(@IDUserProcess AS NVARCHAR)+'%'')'
		END
		IF @IDWorkGroup IS NOT NULL AND @IDWorkGroup<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDWorkGroup='+cast(@IDWorkGroup AS NVARCHAR)
		END
		IF @FromCreateDate IS NOT NULL AND @FromCreateDate<>'' AND @ToCreateDate IS NOT NULL AND @ToCreateDate<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND CreateDate BETWEEN '''+@FromCreateDate+''' AND '''+@ToCreateDate+''''
		END			
		IF @StartProcess IS NOT NULL AND @StartProcess<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND StartProcess>='''+cast(@StartProcess AS NVARCHAR)+''''
		END						
		IF @Priority IS NOT NULL AND @Priority<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Priority='''+cast(@Priority AS NVARCHAR)+''''
		END		
		IF @Status IS NOT NULL AND @Status<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Status='''+cast(@Status AS NVARCHAR)+''''
		END						
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,*
			FROM tblWork'+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)		
	END
	ELSE
	BEGIN
		SELECT * FROM tblWork WHERE WorkID=@WorkID
	END
END
GO
/* get id last record*/
IF OBJECT_ID('sp_tblWork_getidlastrecord','P') IS NOT NULL
	DROP PROC sp_tblWork_getidlastrecord
GO
CREATE PROC sp_tblWork_getidlastrecord
	@IDUserCreate INT
AS
BEGIN
	SELECT WorkID FROM tblWork WHERE WorkID = IDENT_CURRENT('tblWork') AND IDUserCreate=@IDUserCreate
END
GO
/* table comment */
IF OBJECT_ID('tblComment','U') IS NOT NULL
	DROP TABLE tblComment
GO
CREATE TABLE tblComment
(
	CommentID VARCHAR(500) PRIMARY KEY,
	Title NVARCHAR(MAX),
	[Content] NVARCHAR(MAX),
	IDUserCreate VARCHAR(50),
	IDDocument VARCHAR(500),
	IDWork INT,
	Attachs VARCHAR(50),
	CreateDate DATETIME DEFAULT(GetDate()),		
)
GO
/* add */
IF OBJECT_ID('sp_tblComment_add','P') IS NOT NULL
	DROP PROC sp_tblComment_add
GO
CREATE PROC sp_tblComment_add
	@CommentID VARCHAR(500),
	@Title NVARCHAR(MAX),
	@Content NVARCHAR(MAX),
	@IDUserCreate VARCHAR(50),
	@IDDocument VARCHAR(500)=NULL,
	@IDWork INT=NULL,
	@Attachs VARCHAR(50)=NULL,
	@CreateDate DATETIME=NULL
AS
BEGIN
	INSERT INTO tblComment(CommentID,Title,[Content],IDUserCreate,IDDocument,IDWork,Attachs,CreateDate)
			VALUES(@CommentID,@Title,@Content,@IDUserCreate,@IDDocument,@IDWork,@Attachs,@CreateDate)
END
GO
/* update */
IF OBJECT_ID('sp_tblComment_update','P') IS NOT NULL
	DROP PROC sp_tblComment_update
GO
CREATE PROC sp_tblComment_update
	@CommentID VARCHAR(500),
	@Title NVARCHAR(MAX)=NULL,
	@Content NVARCHAR(MAX)=NULL,	
	@IDUserCreate VARCHAR(50),
	@IDDocument VARCHAR(500)=NULL,
	@IDWork INT=NULL,
	@Attachs VARCHAR(50)=NULL,
	@CreateDate DATETIME=NULL
AS
BEGIN
	DECLARE @Update NVARCHAR(500)
	SET @Update=' IDUserCreate='''+cast(@IDUserCreate AS NVARCHAR)+''''
	IF @Title IS NOT NULL AND @Title<>''
	BEGIN
		SET @Update=@Update+',Title='''+cast(@Title AS NVARCHAR)+''''
	END
	IF @Content IS NOT NULL AND @Content<>''
	BEGIN
		SET @Update=@Update+',Content='''+cast(@Content AS NVARCHAR)+''''
	END		
	IF @IDDocument IS NOT NULL
	BEGIN
		SET @Update=@Update+',IDDocument='''+cast(@IDDocument AS NVARCHAR)+''''
	END	
	IF @IDWork IS NOT NULL
	BEGIN
		SET @Update=@Update+',IDWork='+cast(@IDWork AS NVARCHAR)
	END	
	IF @Attachs IS NOT NULL
	BEGIN
		SET @Update=@Update+',Attachs='''+cast(@Attachs AS NVARCHAR)+''''
	END
	EXEC('UPDATE tblComment SET'+@Update+' WHERE Comment='+@CommentID)	
END
GO
/* delete */
IF OBJECT_ID('sp_tblComment_delete','P') IS NOT NULL
	DROP PROC sp_tblComment_delete
GO
CREATE PROC sp_tblComment_delete
	@CommentID VARCHAR(500)
AS
BEGIN
	DELETE tblComment WHERE CommentID=@CommentID
END
/* get */
IF OBJECT_ID('sp_tblComment_get','P') IS NOT NULL
	DROP PROC sp_tblComment_get
GO
CREATE PROC sp_tblComment_get
	@CommentID VARCHAR(500)=NULL,
	@Title NVARCHAR(MAX)=NULL,
	@IDUserCreate VARCHAR(50)=NULL,
	@IDDocument VARCHAR(500)=NULL,
	@IDWork INT=NULL	
AS
BEGIN
	IF @CommentID IS NULL OR @CommentID=''
	BEGIN	
		DECLARE @DieuKien NVARCHAR(500)	
		SET @DieuKien=' WHERE (1=1)'
		IF @Title IS NOT NULL AND @Title<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Title LIKE(N''%'+@Title+'%'')'
		END
		IF @IDUserCreate IS NOT NULL AND @IDUserCreate<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDUserCreate='''+cast(@IDUserCreate AS VARCHAR)+''''
		END
		IF @IDDocument IS NOT NULL AND @IDDocument<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDDocument='''+cast(@IDDocument AS NVARCHAR)+''''
		END
		IF @IDWork IS NOT NULL AND @IDWork<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDWork='+cast(@IDWork AS NVARCHAR)
		END
		EXEC('SELECT * FROM tblComment'+@DieuKien+'ORDER BY CreateDate DESC')
	END
	ELSE
	BEGIN
		SELECT * FROM tblComment WHERE CommentID=@CommentID
	END
END
GO
/* table Calendar */
IF OBJECT_ID('tblCalendar','U') IS NOT NULL
	DROP TABLE tblCalendar
GO
CREATE TABLE tblCalendar
(
	CalendarID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(500),
	[Content] NVARCHAR(MAX),
	StartDate DATETIME,
	EndDate DATETIME,
	UserJoin VARCHAR(200),
	[Address] NVARCHAR(300),
	UserCreate VARCHAR(200)
)
GO
/* add */
IF OBJECT_ID('sp_tblCalendar_add','P') IS NOT NULL
	DROP PROC sp_tblCalendar_add
GO
CREATE PROC sp_tblCalendar_add
	@Name NVARCHAR(500),
	@Content NVARCHAR(MAX),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@UserJoin VARCHAR(200),
	@Address NVARCHAR(300),
	@UserCreate VARCHAR(200)
AS
BEGIN
	INSERT INTO tblCalendar([Name],[Content],StartDate,EndDate,UserJoin,[Address],UserCreate) 
				VALUES(@Name,@Content,@StartDate,@EndDate,@UserJoin,@Address,@UserCreate)
END
GO
/* update */
IF OBJECT_ID('sp_tblCalendar_update','P') IS NOT NULL
	DROP PROC sp_tblCalendar_update
GO
CREATE PROC sp_tblCalendar_update
	@CalendarID INT,
	@Name NVARCHAR(500),
	@Content NVARCHAR(MAX),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@UserJoin VARCHAR(200),
	@Address NVARCHAR(300)
AS
BEGIN
	UPDATE tblCalendar SET [Name]=@Name,[Content]=@Content,StartDate=@StartDate,
			EndDate=@EndDate,UserJoin=@UserJoin,[Address]=@Address WHERE CalendarID=@CalendarID
END
GO
/* delete */
IF OBJECT_ID('sp_tblCalendar_delete','P') IS NOT NULL
	DROP PROC sp_tblCalendar_delete
GO
CREATE PROC sp_tblCalendar_delete
	@CalendarID INT
AS
BEGIN
	DELETE tblCalendar WHERE CalendarID=@CalendarID
END
GO
/* get */
IF OBJECT_ID('sp_tblCalendar_get','P') IS NOT NULL
	DROP PROC sp_tblCalendar_get
GO
CREATE PROC sp_tblCalendar_get
	@CalendarID INT=NULL,
	@UserJoin VARCHAR(200)=NULL,
	@UserCreate VARCHAR(200)=NULL
AS
BEGIN
	IF @CalendarID IS NULL OR @CalendarID=0
	BEGIN
		DECLARE @DieuKien NVARCHAR(MAX)
		SET @DieuKien='WHERE (1=1)'
		IF @UserJoin IS NOT NULL AND @UserJoin<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND UserJoin LIKE(''%'+cast(@UserJoin AS VARCHAR)+'%'')'
		END
		IF @UserCreate IS NOT NULL AND @UserCreate<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND UserCreate='''+cast(@UserCreate AS VARCHAR)+''''
		END
		EXEC('SELECT * FROM tblCalendar '+@DieuKien)		
	END
	ELSE
	BEGIN
		SELECT * FROM tblCalendar WHERE CalendarID=@CalendarID
	END
END
GO
/* tbl ContactGroup */
IF OBJECT_ID('tblContactGroup','U') IS NOT NULL
	DROP TABLE tblContactGroup
GO
CREATE TABLE tblContactGroup
(
	ContactGroupID INT IDENTITY(1,1) PRIMARY KEY,
	GroupName NVARCHAR(200),
	[Description] NVARCHAR(200),
	IDUser INT FOREIGN KEY REFERENCES tblUser(UserID)		
)
GO
/* add */
IF OBJECT_ID('sp_tblContactGroup_add','P') IS NOT NULL
	DROP PROC sp_tblContactGroup_add
GO
CREATE PROC sp_tblContactGroup_add
	@GroupName NVARCHAR(200),
	@Description NVARCHAR(200),
	@IDUser INT
AS
BEGIN
	INSERT INTO tblContactGroup(GroupName,[Description],IDUser) VALUES(@GroupName,@Description,@IDUser)
END
GO
/* update */
IF OBJECT_ID('sp_tblContactGroup_update','P') IS NOT NULL
	DROP PROC sp_tblContactGroup_update
GO
CREATE PROC sp_tblContactGroup_update
	@ContactGroupID INT,
	@GroupName NVARCHAR(200),
	@Description NVARCHAR(200)
AS
BEGIN
	UPDATE tblContactGroup SET GroupName=@GroupName,[Description]=@Description WHERE ContactGroupID=@ContactGroupID
END
GO
/* delete */
IF OBJECT_ID('sp_tblContactGroup_delete','P') IS NOT NULL
	DROP PROC sp_tblContactGroup_delete
GO
CREATE PROC sp_tblContactGroup_delete
	@ContactGroupID INT
AS
BEGIN
	DELETE tblContactGroup WHERE ContactGroupID=@ContactGroupID
END
GO
/* get */
IF OBJECT_ID('sp_tblContactGroup_get','P') IS NOT NULL
	DROP PROC sp_tblContactGroup_get
GO
CREATE PROC sp_tblContactGroup_get
	@ContactGroupID INT=NULL,
	@IDUser INT=NULL	
AS
BEGIN
	IF @ContactGroupID IS NOT NULL AND @ContactGroupID <> 0
	BEGIN
		SELECT * FROM tblContactGroup WHERE ContactGroupID=@ContactGroupID
	END
	ELSE
	BEGIN
		IF @IDUser IS NOT NULL AND @IDUser<>0
		BEGIN
			SELECT * FROM tblContactGroup WHERE IDUser=@IDUser 
		END		
	END
END
GO
/* tbl contact */
IF OBJECT_ID('tblContact','U') IS NOT NULL
	DROP TABLE tblContact
GO
CREATE TABLE tblContact
(
	ContactID INT IDENTITY(1,1) PRIMARY KEY,
	ContactName NVARCHAR(200),
	TitleName NVARCHAR(30),
	FullName NVARCHAR(200),
	Phone VARCHAR(20),
	Tel VARCHAR(20),
	Email VARCHAR(50),	
	BirthDay DATETIME,
	Gender NVARCHAR(20),
	Job NVARCHAR(200),
	[Address] NVARCHAR(200),
	Other NVARCHAR(200),
	IDContactGroup INT FOREIGN KEY REFERENCES tblContactGroup(ContactGroupID),
	IDUser INT FOREIGN KEY REFERENCES tblUser(UserID)
)
GO
/* add */
IF OBJECT_ID('sp_tblContact_add','P') IS NOT NULL
	DROP PROC sp_tblContact_add
GO
CREATE PROC sp_tblContact_add
	@ContactName NVARCHAR(200),
	@TitleName NVARCHAR(30),
	@FullName NVARCHAR(200),
	@Phone VARCHAR(20),
	@Tel VARCHAR(20),
	@Email VARCHAR(50),
	@BirthDay DATETIME,
	@Gender NVARCHAR(20),
	@Job NVARCHAR(200),
	@Address NVARCHAR(200),
	@Other NVARCHAR(200),
	@IDContactGroup INT,
	@IDUser INT	
AS
BEGIN
	INSERT INTO tblContact(ContactName,TitleName,FullName,Phone,Tel,Email,BirthDay,Gender,Job,[Address],Other,IDContactGroup,IDUser)
						VALUES(@ContactName,@TitleName,@FullName,@Phone,@Tel,@Email,@BirthDay,@Gender,@Job,@Address,@Other,@IDContactGroup,@IDUser) 
END
GO
/* update */
IF OBJECT_ID('sp_tblContact_update','P') IS NOT NULL
	DROP PROC sp_tblContact_update
GO
CREATE PROC sp_tblContact_update
	@ContactID INT,
	@ContactName NVARCHAR(200)=NULL,
	@TitleName NVARCHAR(30)=NULL,
	@FullName NVARCHAR(200)=NULL,
	@Phone VARCHAR(20)=NULL,
	@Tel VARCHAR(20)=NULL,
	@Email VARCHAR(50)=NULL,
	@BirthDay DATETIME=NULL,
	@Gender NVARCHAR(20)=NULL,
	@Job NVARCHAR(200)=NULL,
	@Address NVARCHAR(200)=NULL,
	@Other NVARCHAR(200)=NULL,
	@IDContactGroup INT=NULL,
	@IDUser INT
AS
BEGIN
	DECLARE @Update NVARCHAR(500)
	SET @Update=' IDUser='+cast(@IDUser AS VARCHAR)
	IF @ContactName IS NOT NULL AND @ContactName <>''
	BEGIN
		SET @Update=@Update+',ContactName=N'''+cast(@ContactName AS NVARCHAR)+''''
	END
	IF @TitleName IS NOT NULL AND @TitleName <>''
	BEGIN
		SET @Update=@Update+',TitleName=N'''+cast(@TitleName AS NVARCHAR)+''''
	END
	IF @FullName IS NOT NULL AND @FullName <>''
	BEGIN
		SET @Update=@Update+',FullName=N'''+cast(@FullName AS NVARCHAR)+''''
	END
	IF @Phone IS NOT NULL AND @Phone <>''
	BEGIN
		SET @Update=@Update+',Phone='''+cast(@Phone AS VARCHAR)+''''
	END
	IF @Tel IS NOT NULL
	BEGIN
		SET @Update=@Update+',Tel='''+cast(@Tel AS VARCHAR)+''''
	END
	IF @Email IS NOT NULL
	BEGIN
		SET @Update=@Update+',Email='''+cast(@Email AS VARCHAR)+''''
	END
	IF @BirthDay IS NOT NULL
	BEGIN
		SET @Update=@Update+',BirthDay='''+cast(@BirthDay AS NVARCHAR)+''''
	END
	IF @Gender IS NOT NULL AND @Gender <>''
	BEGIN
		SET @Update=@Update+',Gender='''+cast(@Gender AS NVARCHAR)+''''
	END
	IF @Job IS NOT NULL
	BEGIN
		SET @Update=@Update+',Job=N'''+cast(@Job AS NVARCHAR)+''''
	END
	IF @Address IS NOT NULL
	BEGIN
		SET @Update=@Update+',Address=N'''+cast(@Address AS NVARCHAR)+''''
	END
	IF @Other IS NOT NULL
	BEGIN
		SET @Update=@Update+',Other=N'''+cast(@Other AS NVARCHAR)+''''
	END
	IF @IDContactGroup IS NOT NULL AND @IDContactGroup<>0
	BEGIN
		SET @Update=@Update+',IDContactGroup='+cast(@IDContactGroup AS VARCHAR)
	END
	EXEC('UPDATE tblContact SET'+@Update+' WHERE ContactID='+@ContactID)	
END
GO
/* delete */
IF OBJECT_ID('sp_tblContact_delete','P') IS NOT NULL
	DROP PROC sp_tblContact_delete
GO
CREATE PROC sp_tblContact_delete
	@ContactID INT
AS
BEGIN
	DELETE tblContact WHERE ContactID=@ContactID
END
GO
/* get */
IF OBJECT_ID('sp_tblContact_get','P') IS NOT NULL
	DROP PROC sp_tblContact_get
GO
CREATE PROC sp_tblContact_get
	@ContactID INT,
	@ContactName NVARCHAR(200)=NULL,
	@TitleName NVARCHAR(30)=NULL,
	@FullName NVARCHAR(200)=NULL,
	@Phone VARCHAR(20)=NULL,
	@Tel VARCHAR(20)=NULL,
	@Email VARCHAR(50)=NULL,
	@Gender NVARCHAR(20)=NULL,
	@Job NVARCHAR(200)=NULL,
	@Address NVARCHAR(200)=NULL,
	@IDContactGroup INT=NULL,
	@IDUser INT,
	@Order VARCHAR(10)='ASC',
	@OrderBy VARCHAR(20)='ContactName',
	@PageIndex INT=1,
	@PageSize INT=50
AS
BEGIN
	IF @ContactID IS NULL OR @ContactID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'		
		IF @ContactName IS NOT NULL AND @ContactName<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND ContactName LIKE(N''%'+cast(@ContactName AS NVARCHAR)+'%'')'
		END
		IF @TitleName IS NOT NULL AND @TitleName<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND TitleName LIKE(N''%'+cast(@TitleName AS NVARCHAR)+'%'')'
		END
		IF @FullName IS NOT NULL AND @FullName<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND FullName LIKE(N''%'+cast(@FullName AS NVARCHAR)+'%'')'
		END
		IF @Phone IS NOT NULL AND @Phone<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Phone LIKE(N''%'+cast(@Phone AS NVARCHAR)+'%'')'
		END
		IF @Tel IS NOT NULL AND @Tel<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Tel LIKE(''%'+cast(@Tel AS NVARCHAR)+'%'')'
		END
		IF @Email IS NOT NULL AND @Email<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Email LIKE(''%'+cast(@Email AS NVARCHAR)+'%'')'
		END
		IF @Gender IS NOT NULL AND @Gender<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Gender='''+cast(@Gender AS NVARCHAR)+''''
		END
		IF @Job IS NOT NULL AND @Job<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Job LIKE(''%'+cast(@Job AS NVARCHAR)+'%'')'
		END			
		IF @Address IS NOT NULL AND @Address<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Address LIKE(''%'+cast(@Address AS NVARCHAR)+'%'')'
		END						
		IF @IDContactGroup IS NOT NULL AND @IDContactGroup<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND IDContactGroup='+cast(@IDContactGroup AS NVARCHAR)
		END
		IF @IDUser<>0
		BEGIN		
			SET @DieuKien=@DieuKien+' AND IDUser='+cast(@IDUser AS VARCHAR)
		END
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY '+@OrderBy+' '+@Order+') AS RowIndex,*
			FROM tblContact'+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)		
	END
	ELSE
	BEGIN
		SELECT * FROM tblContact WHERE ContactID=@ContactID
	END
END


GO
/* table tblDepartment */
/* create table */
IF OBJECT_ID('tblPermisionDefinition','U') IS NOT NULL
	DROP TABLE tblPermisionDefinition
GO


CREATE TABLE tblPermisionDefinition
(
ID   INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Code  NVARCHAR(150)  NOT NULL,
[Name]  NVARCHAR(500)
)
GO
/* get */
IF OBJECT_ID('sp_tblPermisionDefinition_get','P') IS NOT NULL
	DROP PROC sp_tblPermisionDefinition_get
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblPermisionDefinition_get]
	@ID INT=0,
	@Code NVARCHAR(150)=NULL,
	@Name NVARCHAR(500)=NULL,
	@PageIndex INT=1,
	@PageSize INT=500
AS
BEGIN
	IF @ID IS NULL OR @ID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'		
		IF @Code IS NOT NULL AND @Code<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND Code = N'''+cast(@Code AS NVARCHAR)+''''
		END
		IF @Name IS NOT NULL AND @Name<>''
		BEGIN
			SET @DieuKien=@DieuKien+' AND [Name] LIKE(N''%'+cast(@Name AS NVARCHAR)+'%'')'
		END
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY ID) AS RowIndex,*
			FROM tblPermisionDefinition'+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)		
	END
	ELSE
	BEGIN
		SELECT * FROM tblPermisionDefinition WHERE ID=@ID
	END
END


GO
/* get */
IF OBJECT_ID('sp_tblPermisionDefinition_delete','P') IS NOT NULL
	DROP PROC sp_tblPermisionDefinition_delete
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblPermisionDefinition_delete]
	@ID INT=0
AS
BEGIN
	BEGIN
			DELETE 	FROM tblPermisionDefinition WHERE ID=@ID
	END

END


GO
/* get */
IF OBJECT_ID('sp_tblPermisionDefinition_update','P') IS NOT NULL
	DROP PROC sp_tblPermisionDefinition_update
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblPermisionDefinition_update]
	@ID INT=0,
	@Code NVARCHAR(150)=NULL,
	@Name NVARCHAR(500)=NULL
AS
BEGIN
	BEGIN
			UPDATE tblPermisionDefinition SET Code=@Code,[Name]=@Name WHERE ID=@ID
	END

END


GO
/* get */
IF OBJECT_ID('sp_tblPermisionDefinition_add','P') IS NOT NULL
	DROP PROC sp_tblPermisionDefinition_add
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblPermisionDefinition_add]
	@Code NVARCHAR(150)=NULL,
	@Name NVARCHAR(500)=NULL
AS
BEGIN
	BEGIN
			INSERT INTO   tblPermisionDefinition(Code,[Name]) VALUES(@Code,@Name)
	END

END

GO
/* table tblDepartment */
/* create table */
IF OBJECT_ID('tblGroupPermission','U') IS NOT NULL
	DROP TABLE tblGroupPermission
GO

CREATE TABLE tblGroupPermission
(
ID   INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
GroupId  INT  NOT NULL,
PermissionDefinitionId  INT  NOT NULL,
)
GO
/* get */
IF OBJECT_ID('sp_tblGroupPermission_get','P') IS NOT NULL
	DROP PROC sp_tblGroupPermission_get
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblGroupPermission_get]
	@ID INT=0,
	@GroupId INT=0,
	@PermissionDefinitionId INT=0,
	@PageIndex INT=1,
	@PageSize INT=500
AS
BEGIN
	IF @ID IS NULL OR @ID=0
	BEGIN
		DECLARE @Start INT
		DECLARE @End INT
		DECLARE @DieuKien NVARCHAR(500)
		SET @Start=(@PageIndex-1)*@PageSize+1
		SET @End=@PageIndex*@PageSize
		SET @DieuKien=' WHERE (1=1)'		
		IF @GroupId IS NOT NULL AND @GroupId<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND GroupId = '+cast(@GroupId AS NVARCHAR)
		END
		IF @PermissionDefinitionId IS NOT NULL AND @PermissionDefinitionId<>0
		BEGIN
			SET @DieuKien=@DieuKien+' AND PermissionDefinitionId = '+cast(@PermissionDefinitionId AS NVARCHAR)
		END
		EXEC('WITH tblRecords AS(SELECT ROW_NUMBER() OVER (ORDER BY ID) AS RowIndex,*
			FROM tblGroupPermission '+@DieuKien+'),tblTotalResult AS(SELECT MAX(RowIndex) AS TotalResult FROM tblRecords)
			SELECT * FROM tblRecords,tblTotalResult WHERE RowIndex BETWEEN '+@Start+' AND '+@End)		
	END
	ELSE
	BEGIN
		SELECT * FROM tblGroupPermission WHERE ID=@ID
	END
END



GO
/* get */
IF OBJECT_ID('sp_tblGroupPermission_add','P') IS NOT NULL
	DROP PROC sp_tblGroupPermission_add
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblGroupPermission_add]
	@GroupId INT,
	@PermissionDefinitionId INT
AS
BEGIN
	BEGIN
			INSERT INTO   tblGroupPermission(GroupId,PermissionDefinitionId) VALUES(@GroupId,@PermissionDefinitionId)
	END
END





GO
/* get */
IF OBJECT_ID('sp_tblGroupPermission_delete','P') IS NOT NULL
	DROP PROC sp_tblGroupPermission_delete
GO 

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROC [dbo].[sp_tblGroupPermission_delete]
	@ID INT=0,
	@GroupId INT=0,
	@PermissionDefinitionId INT=0
AS
BEGIN
	BEGIN
			DELETE 	FROM tblGroupPermission WHERE (ID=@ID OR @ID=0) AND  (PermissionDefinitionId=@PermissionDefinitionId OR @PermissionDefinitionId=0) AND (GroupId=@GroupId OR @GroupId=0)
	END

END




