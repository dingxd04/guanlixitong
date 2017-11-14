USE [PS_DB]
GO

/****** Object:  Table [dbo].[items_maintain]    Script Date: 2017/11/13 19:15:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[items_maintain](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[base_id] [bigint] NULL DEFAULT ((0)),
	[position] [varchar](250) NULL DEFAULT (''),
	[recorder] [varchar](50) NULL DEFAULT (''),
	[date_time] [datetime] NULL DEFAULT (getdate()),
	[status] [int] NULL DEFAULT ((0)),
	[details] [nvarchar](500) NULL DEFAULT (''),
	[is_using] [int] NULL DEFAULT ((0)),
	[remark] [nvarchar](500) NULL DEFAULT ('')
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


