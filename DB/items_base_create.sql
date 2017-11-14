USE [PS_DB]
GO

/****** Object:  Table [dbo].[items_base]    Script Date: 2017/11/13 19:14:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[items_base](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[items_department_id] [int] NULL CONSTRAINT [DF_items_base_items_department_id]  DEFAULT ((0)),
	[items_name] [varchar](200) NULL CONSTRAINT [DF_items_base_items_name]  DEFAULT (''),
	[items_url] [varchar](250) NULL CONSTRAINT [DF_items_base_items_url]  DEFAULT (''),
	[items_type] [varchar](100) NULL CONSTRAINT [DF_items_base_items_type]  DEFAULT (''),
	[manufacturer] [varchar](100) NULL CONSTRAINT [DF_items_base_manufacturer]  DEFAULT (''),
	[sub_department] [varchar](50) NULL CONSTRAINT [DF_items_base_sub_department]  DEFAULT (''),
	[position] [varchar](250) NULL DEFAULT (''),
	[keeper] [varchar](50) NULL CONSTRAINT [DF_items_base_user]  DEFAULT (''),
	[remark] [nvarchar](500) NULL CONSTRAINT [DF_items_base_remark]  DEFAULT (''),
	[last_test_time] [datetime] NULL CONSTRAINT [DF_items_base_last_test_time]  DEFAULT (getdate()),
	[test_interval] [int] NULL CONSTRAINT [DF_items_base_test_interval]  DEFAULT ((0)),
	[status_detail] [varchar](100) NULL CONSTRAINT [DF_items_base_status]  DEFAULT (''),
	[items_total] [int] NULL CONSTRAINT [DF_items_base_items_total]  DEFAULT ((0)),
	[items_using_num] [int] NULL CONSTRAINT [DF_items_base_items_using_num]  DEFAULT ((0)),
	[items_well_num] [int] NULL CONSTRAINT [DF_items_base_items_well_num]  DEFAULT ((0)),
	[items_repair_num] [int] NULL CONSTRAINT [DF_items_base_items_repair_num]  DEFAULT ((0)),
	[items_bad_num] [int] NULL CONSTRAINT [DF_items_base_items_bad_num]  DEFAULT ((0)),
	[is_xs] [int] NULL CONSTRAINT [DF_items_base_is_xs]  DEFAULT ((0))
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在库信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'items_department_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'items_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'items_url'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'items_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产厂商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'manufacturer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属子系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'sub_department'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存放位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'position'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保管人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'keeper'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次维护时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'last_test_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护周期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'test_interval'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'items_total'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'items_base', @level2type=N'COLUMN',@level2name=N'is_xs'
GO


