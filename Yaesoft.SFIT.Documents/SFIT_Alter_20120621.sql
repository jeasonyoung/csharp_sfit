--------------------------------------------------------------------------------------------------------------
--数据库更新信息（20120621）
--------------------------------------------------------------------------------------------------------------
--在tblSFITStudentWorks加上Hits字段。
if not exists(select 0 from syscolumns a inner join sysobjects b on b.id = a.id  and b.xtype = 'u' where b.name = 'tblSFITStudentWorks' and a.name = 'Hits')
begin
	print 'tblSFITStudentWorks表中添加Hits字段'
	alter table tblSFITStudentWorks add Hits int default(0)
end
go
--------------------------------------------------------------------------------------------------------------
--获取学校单位。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexTopUnit')
begin
	print 'drop procedure spSFITIndexTopUnit'
	drop procedure spSFITIndexTopUnit
end
go
	print 'create procedure spSFITIndexTopUnit'
go
create procedure spSFITIndexTopUnit
as
begin
	select SchoolID as UnitID,SchoolName as UnitName,OrderNO
	from tblSFITSchools
	where SchoolType < 5
	order by SchoolType desc,OrderNO
end
go
--------------------------------------------------------------------------------------------------------------
--最新作品。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexLastNewsList')
begin
	print 'drop procedure spSFITIndexLastNewsList'
	drop procedure spSFITIndexLastNewsList
end
go
	print 'create procedure spSFITIndexLastNewsList'
go
create procedure spSFITIndexLastNewsList
(
	@UnitID		GUIDEx,--学校单位ID。
	@GradeID	GUIDEx,--年级ID。
	@ClassID	GUIDEx,--班级ID。
	@CatalogID	GUIDEx--科目ID。
)
as
begin
	select a.SchoolName,a.ClassName,b.StudentName,b.StudentCode,a.WorkName,a.WorkID,a.CreateDateTime
	from tblSFITStudentWorks a
	inner join tblSFITStudents b
	on b.StudentID = a.StudentID
	where (a.WorkType = 0) and (cast(a.WorkStatus as int) & 0x10 = 0x10)
	and (a.SchoolID like isnull(@UnitID,'') + '%')
	and (a.GradeID like isnull(@GradeID,'') + '%')
	and (a.ClassID like isnull(@ClassID,'') + '%')
	and (a.CatalogID like isnull(@CatalogID,'') + '%')
	order by a.CreateDateTime desc
end
go
--------------------------------------------------------------------------------------------------------------
--点击率最高作品。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexLastHitsList')
begin
	print 'drop procedure spSFITIndexLastHitsList'
	drop procedure spSFITIndexLastHitsList
end
go
	print 'create procedure spSFITIndexLastHitsList'
go
create procedure spSFITIndexLastHitsList
(
	@UnitID		GUIDEx,--学校单位ID。
	@GradeID	GUIDEx,--年级ID。
	@ClassID	GUIDEx,--班级ID。
	@CatalogID	GUIDEx--科目ID。
)
as
begin
	select a.SchoolName,a.ClassName,b.StudentName,b.StudentCode,a.WorkName,a.WorkID,isnull(a.Hits,0) as Hits
	from tblSFITStudentWorks a
	inner join tblSFITStudents b
	on b.StudentID = a.StudentID
	where (a.WorkType = 0) and (cast(a.WorkStatus as int) & 0x10 = 0x10)
	and (a.SchoolID like isnull(@UnitID,'') + '%')
	and (a.GradeID like isnull(@GradeID,'') + '%')
	and (a.ClassID like isnull(@ClassID,'') + '%')
	and (a.CatalogID like isnull(@CatalogID,'') + '%')
	order by isnull(a.Hits,0) desc
end
go
--------------------------------------------------------------------------------------------------------------
--最优作品。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexLastValueList')
begin
	print 'drop procedure spSFITIndexLastValueList'
	drop procedure spSFITIndexLastValueList
end
go
create procedure spSFITIndexLastValueList
(
	@UnitID		GUIDEx,--学校单位ID。
	@GradeID	GUIDEx,--年级ID。
	@ClassID	GUIDEx,--班级ID。
	@CatalogID	GUIDEx--科目ID。
)
as
begin
	select a.SchoolName,a.ClassName,c.StudentName,c.StudentCode,a.WorkName,a.WorkID,b.ReviewValue
	from tblSFITStudentWorks a
	inner join tblSFITeaReviewStudent b
	on b.WorkID = a.WorkID
	inner join tblSFITStudents c
	on c.StudentID = a.StudentID
	where (a.WorkType = 0) and (cast(a.WorkStatus as int) & 0x10 = 0x10)
	and (isnull(b.ReviewValue,'') <> '')
	and (a.SchoolID like isnull(@UnitID,'') + '%')
	and (a.GradeID like isnull(@GradeID,'') + '%')
	and (a.ClassID like isnull(@ClassID,'') + '%')
	and (a.CatalogID like isnull(@CatalogID,'') + '%')
	order by b.ReviewValue,a.CreateDateTime desc
end
go
--------------------------------------------------------------------------------------------------------------
--检索作品。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexQueryResultList')
begin
	print 'drop procedure spSFITIndexQueryResultList'
	drop procedure spSFITIndexQueryResultList
end
go
	print 'create procedure spSFITIndexQueryResultList'
go
create procedure spSFITIndexQueryResultList
(
	@UnitID		GUIDEx,--学校单位ID。
	@GradeID	GUIDEx,--年级ID。
	@ClassID	GUIDEx,--班级ID。
	@CatalogID	GUIDEx,--科目ID。
	
	@StudentName	nvarchar(50),--学生姓名。
	@WorkName		nvarchar(128)--作品名称。
)
as
begin
	select a.SchoolName,a.ClassName,c.StudentName,c.StudentCode,a.WorkName,a.WorkID,a.CreateDateTime,a.Hits,b.ReviewValue
	from tblSFITStudentWorks a
	inner join tblSFITeaReviewStudent b
	on b.WorkID = a.WorkID
	inner join tblSFITStudents c
	on c.StudentID = a.StudentID
	where (a.WorkType = 0) and (cast(a.WorkStatus as int) & 0x10 = 0x10)
	and (a.SchoolID like isnull(@UnitID,'') + '%')
	and (a.GradeID like isnull(@GradeID,'') + '%')
	and (a.ClassID like isnull(@ClassID,'') + '%')
	and (a.CatalogID like isnull(@CatalogID,'') + '%')
	and (a.WorkName like '%'+@WorkName+'%')
	and (c.StudentName like '%'+@StudentName+'%' or c.StudentCode like '%'+@StudentName+'%')
	
	order by a.CreateDateTime desc,a.Hits desc,b.ReviewValue
end
go
--------------------------------------------------------------------------------------------------------------
