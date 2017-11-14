USE [PS_DB]
GO

/****** Object:  Table [dbo].[spotcheck_base]    Script Date: 2017/11/13 19:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[spotcheck_base](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[spotcheck_department_id] [int] NULL,
	[spotcheck_name] [varchar](200) NULL,
	[spotcheck_url] [varchar](250) NULL,
	[spotcheck_type] [varchar](100) NULL,
	[sub_department] [varchar](50) NULL,
	[position] [varchar](250) NULL,
	[checker] [varchar](50) NULL,
	[last_check_time] [datetime] NULL,
	[check_interval] [int] NULL,
	[status] [varchar](50) NULL,
	[status_detail] [nvarchar](500) NULL,
	[remark] [nvarchar](500) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_spotcheck_department_id]  DEFAULT ((0)) FOR [spotcheck_department_id]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_spotcheck_name]  DEFAULT ('') FOR [spotcheck_name]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_spotcheck_url]  DEFAULT ('') FOR [spotcheck_url]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_spotcheck_type]  DEFAULT ('') FOR [spotcheck_type]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_sub_department]  DEFAULT ('') FOR [sub_department]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_position]  DEFAULT ('') FOR [position]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_user]  DEFAULT ('') FOR [checker]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_last_check_time]  DEFAULT (getdate()) FOR [last_check_time]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  CONSTRAINT [DF_spotcheck_base_check_interval]  DEFAULT ((0)) FOR [check_interval]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  DEFAULT ('') FOR [status]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  DEFAULT ('') FOR [status_detail]
GO

ALTER TABLE [dbo].[spotcheck_base] ADD  DEFAULT ('') FOR [remark]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点检点序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'spotcheck_department_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点检点名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'spotcheck_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点检部位图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'spotcheck_url'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点检点类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'spotcheck_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属子系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'sub_department'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'position'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'checker'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次检查时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'last_check_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点检间隔周期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'check_interval'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点检状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'spotcheck_base', @level2type=N'COLUMN',@level2name=N'remark'
GO


