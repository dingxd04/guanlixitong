USE [PS_DB]
GO

/****** Object:  Table [dbo].[spotcheck_info]    Script Date: 2017/11/13 19:15:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[spotcheck_info](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[base_id] [bigint] NULL,
	[position] [varchar](250) NULL,
	[recorder] [varchar](50) NULL,
	[date_time] [datetime] NULL,
	[status] [varchar](50) NULL,
	[status_detail] [nvarchar](500) NULL,
	[starndard1] [varchar](500) NULL,
	[record1_name] [varchar](50) NULL,
	[record1_value] [decimal](8, 4) NULL,
	[starndard2] [varchar](500) NULL,
	[record2_name] [varchar](50) NULL,
	[record2_value] [decimal](8, 4) NULL,
	[starndard3] [varchar](500) NULL,
	[record3_name] [varchar](50) NULL,
	[record3_value] [decimal](8, 4) NULL,
	[remark] [nvarchar](500) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  CONSTRAINT [DF_items_base_position]  DEFAULT ('') FOR [position]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  CONSTRAINT [DF_items_recorder]  DEFAULT ('') FOR [recorder]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  CONSTRAINT [DF_items_base_date_time]  DEFAULT (getdate()) FOR [date_time]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('') FOR [status]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('') FOR [status_detail]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('') FOR [starndard1]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('default') FOR [record1_name]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ((0)) FOR [record1_value]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('') FOR [starndard2]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('default') FOR [record2_name]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ((0)) FOR [record2_value]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('') FOR [starndard3]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('default') FOR [record3_name]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ((0)) FOR [record3_value]
GO

ALTER TABLE [dbo].[spotcheck_info] ADD  DEFAULT ('') FOR [remark]
GO


