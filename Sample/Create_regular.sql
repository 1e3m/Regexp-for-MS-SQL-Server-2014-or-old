CREATE ASSEMBLY Regular
FROM 'path to dll file'; -- 'C:\Regexp.dll'
GO

IF OBJECT_ID(N'dbo.Regexp', N'P') IS NOT NULL
	DROP FUNCTION dbo.Regexp;
GO

CREATE FUNCTION dbo.Regexp(@cExpr nvarchar(max), @cPattern nvarchar(max))
RETURNS  TABLE (
	nId int NULL,
	cStr nvarchar(MAX) NULL
) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME Regular.Regexp.Run
GO