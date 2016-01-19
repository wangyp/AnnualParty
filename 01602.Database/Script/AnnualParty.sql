USE [AnnualParty]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Employee_CheckIn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF_Employee_CheckIn]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Employee_Award]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF_Employee_Award]
END

GO

USE [AnnualParty]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 02/17/2011 15:11:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO

/****** Object:  Table [dbo].[Photo]    Script Date: 02/17/2011 15:11:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Photo]') AND type in (N'U'))
DROP TABLE [dbo].[Photo]
GO

USE [AnnualParty]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 02/17/2011 15:11:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeNumber] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Dept] [char](2) NOT NULL,
	[Alias] [varchar](100) NULL,
	[PinyinFull] [varchar](100) NULL,
	[PinyinShort] [varchar](5) NULL,
	[CheckIn] [bit] NOT NULL,
	[CheckinTime] [datetime] NULL,
	[Award] [int] NOT NULL,
	[AwardTime] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [AnnualParty]
GO

/****** Object:  Table [dbo].[Photo]    Script Date: 02/17/2011 15:11:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Photo](
	[EmployeeNumber] [varchar](10) NOT NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_CheckIn]  DEFAULT ((0)) FOR [CheckIn]
GO

ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Award]  DEFAULT ((-1)) FOR [Award]
GO


USE [AnnualParty]
GO

/****** Object:  StoredProcedure [dbo].[SearchEmployee]    Script Date: 02/28/2011 17:24:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchEmployee]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SearchEmployee]
GO

USE [AnnualParty]
GO

/****** Object:  StoredProcedure [dbo].[SearchEmployee]    Script Date: 02/28/2011 17:24:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchEmployee]
(
@name nvarchar(50)
)
as
select *
from Employee
where Alias like @name+'%' or PinyinFull like @name+'%' or PinyinShort = @name

GO
