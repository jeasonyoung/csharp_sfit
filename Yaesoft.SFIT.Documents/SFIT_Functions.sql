/*
//================================================================================
//  FileName: SFIT_Functions.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/21
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
*/
------------------------------------------------------------------------------------------------
--知识要点中，具有上下级的关系的所有子孙。
if exists(select 0 from sysobjects where xtype = 'tf' and name = 'fnSFITKnowledgePointsGetOffSprings')
begin
	print 'drop function fnSFITKnowledgePointsGetOffSprings'
	drop function fnSFITKnowledgePointsGetOffSprings
end
go
	print 'create function fnSFITKnowledgePointsGetOffSprings'
go
create function fnSFITKnowledgePointsGetOffSprings
(
	@GradeID		GUIDEx,--年级ID。
	@PointID		GUIDEx,--父级要点ID。
	@IncludeSelf	bit = 1--是否包含自己。
)
returns @tableResult table (
								ParentPointID		nvarchar(32),--父知识点ID。
								PointID				nvarchar(32),--知识点ID。
								PointCode			nvarchar(128),--知识代码。
								PointName			nvarchar(256),--知识点名称。
								Description			nvarchar(512),--描述信息。
								OrderNO				int default(0)--排序号。
						   )
as
begin
		declare @v_table table (
									ParentPointID		nvarchar(32),--父知识点ID。
									PointID				nvarchar(32),--知识点ID。
									PointCode			nvarchar(128),--知识代码。
									PointName			nvarchar(256),--知识点名称。
									Description			nvarchar(512),--描述信息。
									OrderNO				int default(0),--排序号。
									LevelNum			int default(0)--层次
							    )
		declare @v_Level int
		set @v_Level = 0
		--插入自己。
		if(isnull(@GradeID,'') <> '')
		begin
		
			insert into @v_table(PointID,PointCode,PointName,Description,OrderNO,LevelNum)
			select PointID,PointCode,PointName,Description,OrderNO,@v_Level
			from tblSFITKnowledgePoints
			where (GradeID = @GradeID and isnull(ParentPointID,'') = '')
			--and ((PointID = @PointID) or (isnull(@PointID,'') = '' and isnull(ParentPointID,'') = ''))
		
		end else begin
		
			insert into @v_table(PointID,PointCode,PointName,Description,OrderNO,LevelNum)
			select PointID,PointCode,PointName,Description,OrderNO,@v_Level
			from tblSFITKnowledgePoints
			where (PointID = @PointID) or (isnull(@PointID,'') = '' and isnull(ParentPointID,'') = '')
			
		end
		--循环插入自己的子孙。
		while(@@rowcount > 0)
		begin
			set @v_Level = @v_Level + 1
			insert into @v_table(ParentPointID,PointID,PointCode,PointName,Description,OrderNO,LevelNum)
			select tmp.PointID,data.PointID,data.PointCode,data.PointName,data.Description,data.OrderNO,@v_Level
			from tblSFITKnowledgePoints data
			inner join @v_table tmp
			on tmp.PointID = data.ParentPointID
			where not exists(select 0
							 from @v_table tmp2
							 where data.PointID = tmp2.PointID)
		end
		--剔除自己。
		if(@IncludeSelf = 0)
			delete from @v_table where (PointID = @PointID) or (isnull(@PointID,'') = '' and isnull(ParentPointID,'') = '')
		--插入结果数据。
		insert into @tableResult(ParentPointID,PointID,PointCode,PointName,Description,OrderNO)
		select ParentPointID,PointID,PointCode,PointName,Description,OrderNO
		from @v_table
		order by LevelNum,OrderNO
		
		return
end
go
------------------------------------------------------------------------------------------------
