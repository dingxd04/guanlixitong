USE [PS_DB]
GO

/****** Object:  Trigger [dbo].[items_status_update]    Script Date: 2017/11/13 19:17:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[items_status_update] ON [dbo].[items_maintain] 
FOR INSERT 
AS 
BEGIN 
	DECLARE @items_id bigint
	DECLARE @is_using int
	DECLARE @status_detail varchar(100)	
	declare @temp_total int
	declare @items_using_num int
	declare @items_well_num int
	declare @items_repair_num int
	declare @items_bad_num int
	declare @last_test_time Datetime

	SELECT  @items_id =base_id, @last_test_time = date_time,@is_using=is_using FROM INSERTED
	SELECT  @items_well_num=COUNT(status) from items_maintain WHERE base_id=@items_id and status=1  ;  
	SELECT  @items_repair_num=COUNT(status) from items_maintain WHERE base_id=@items_id and status=2  ;  
	SELECT  @items_bad_num=COUNT(status) from items_maintain WHERE base_id=@items_id and status=3   ;  
	SELECT  @items_using_num=COUNT(is_using) from items_maintain WHERE base_id=@items_id  +@is_using ;  
	select  @status_detail='当前可用备件为：'+LTRIM(@items_well_num-@items_using_num) ;

	if ( @items_id <>0 )
	BEGIN
		UPDATE  items_base SET 		
		last_test_time=@last_test_time,
		status_detail=@status_detail,
		items_well_num=@items_well_num,
		items_repair_num=@items_repair_num,
		items_bad_num=@items_bad_num,
		items_using_num=@items_using_num WHERE id=@items_id
	END	
	
END

GO


