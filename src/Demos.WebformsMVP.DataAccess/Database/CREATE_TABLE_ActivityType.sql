USE WebformsMVPDemo
GO

/****** Object:  Table [dbo].[ActivityType]    Script Date: 2017-11-16 22:27:56 ******/
DROP TABLE [dbo].[ActivityType]
GO

/****** Object:  Table [dbo].[ActivityType]    Script Date: 2017-11-16 22:27:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ActivityType](
	[ActivityTypeId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StepValue] [int] NOT NULL,
	[IsActivated] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED 
(
	[ActivityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


