USE [PTO_Dev]
GO

/****** Object:  Table [dbo].[Log]    Script Date: 04/13/2014 16:20:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
	[MachineName] [varchar](50) NULL,
	[Identity] [varchar](100) NULL,
	[LoggerName] [varchar](200) NULL,
	[LogLevel] [varchar](20) NULL,
	[Message] [varchar](max) NULL,
	[ExceptionSource] [varchar](200) NULL,
	[ExceptionClass] [varchar](200) NULL,
	[ExceptionMethod] [varchar](200) NULL,
	[ExceptionError] [varchar](1000) NULL,
	[ExceptionStackTrace] [varchar](max) NULL,
	[ExceptionInnerMessage] [varchar](1000) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


