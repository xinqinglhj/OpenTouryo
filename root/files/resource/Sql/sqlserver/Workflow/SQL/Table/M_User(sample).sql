USE [Workflow]
GO

/****** Object:  Table [dbo].[M_User]    Script Date: 2014/07/09 13:32:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE [dbo].[M_User]
GO

CREATE TABLE [dbo].[M_User](
	[Id] [decimal](10, 0) NOT NULL,
	[Section] [varchar](10) NULL,
	[Name] [varchar](10) NULL,
	[PositionTitlesId] [decimal](10, 0) NULL,
 CONSTRAINT [PK_M_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

