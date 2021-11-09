USE [WebformsMVPDemo]
GO

/****** Object:  Table [dbo].[UserProfile]    Script Date: 2017-11-16 22:28:43 ******/
DROP TABLE [dbo].[UserProfile]
GO

/****** Object:  Table [dbo].[UserProfile]    Script Date: 2017-11-16 22:28:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserProfile](
	[UserProfileId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Team] [varchar](50) NOT NULL,
	[Department] [varchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



