/*
//================================================================================
//  FileName: SFIT_Tables.sql
//  Desc:学生信息技术档案管理系统表结构。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/5
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
---------------------------------------------------------------------------------------------
--删除表。
---------------------------------------------------------------------------------------------
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITTeaClass')
begin
	print 'drop table tblSFITTeaClass'
	drop table tblSFITTeaClass
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITeaReviewStudent')
begin
	print 'drop table tblSFITeaReviewStudent'
	drop table tblSFITeaReviewStudent
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITeachers')
begin
	print 'drop table tblSFITeachers'
	drop table tblSFITeachers
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITStudentAttachment')
begin
	print 'drop table tblSFITStudentAttachment'
	drop table tblSFITStudentAttachment
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITWorksComments')
begin
	print 'drop table tblSFITWorksComments'
	drop table tblSFITWorksComments
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITStudentWorks')
begin
	print 'drop table tblSFITStudentWorks'
	drop table tblSFITStudentWorks
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITClassStudents')
begin
	print 'drop table tblSFITClassStudents'
	drop table tblSFITClassStudents
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITClass')
begin
	print 'drop table tblSFITClass'
	drop table tblSFITClass
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITSchoolSetCatalog')
begin
	print 'drop table tblSFITSchoolSetCatalog'
	drop table tblSFITSchoolSetCatalog
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITCatalogKnowledgePoints')
begin
	print 'drop table tblSFITCatalogKnowledgePoints'
	drop table tblSFITCatalogKnowledgePoints
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITCatalog')
begin
	print 'drop table tblSFITCatalog'
	drop table tblSFITCatalog
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITEvaluateItems')
begin
	print 'drop table tblSFITEvaluateItems'
	drop table tblSFITEvaluateItems
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITEvaluateSet')
begin
	print 'drop table tblSFITEvaluateSet'
	drop table tblSFITEvaluateSet
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITCenterAccess')
begin
	print 'drop table tblSFITCenterAccess'
	drop table tblSFITCenterAccess
end
go
---------------------------------------------------------------------------------------------
--学校信息表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITSchools')
begin
	print 'drop table tblSFITSchools'
	drop table tblSFITSchools
end
go
	print 'create table tblSFITSchools'
go
create table tblSFITSchools
(
	SchoolID		GUIDEx,--学校ID。
	SchoolCode		nvarchar(128),--学校代码。
	SchoolName		nvarchar(256),--学校名称。
	SchoolType		int	default(1),--学校类型。
	
	OrderNO			int default(0),--排序号。
	
	SyncStatus		int default(0),--同步状态。
	LastSyncTime	datetime default(null),--同步时间。
	
	constraint PK_tblSFITSchools primary key(SchoolID),--主键约束。
	constraint UK_tblSFITSchools_SchoolCode unique(SchoolCode)--唯一约束。
)
go
---------------------------------------------------------------------------------------------
--教师信息表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITeachers')
begin
	print 'drop table tblSFITeachers'
	drop table tblSFITeachers
end
go
	print 'create table tblSFITeachers'
go
create table tblSFITeachers
(
	TeacherID		GUIDEx,--教师ID。
	TeacherCode		nvarchar(128),--教师代码。
	TeacherName		nvarchar(256),--教师名称。
	
	SchoolID		GUIDEx,--所属学校ID。
	
	SyncStatus		int default(0),--同步状态。
	LastSyncTime	datetime default(null),--同步时间。
	
	constraint PK_tblSFITeachers primary key(TeacherID),--主键约束。
	constraint UK_tblSFITeachers_TeacherCode unique(TeacherCode),--唯一约束。
	constraint FK_tblSFITeachers_tblSFITSchools_SchoolID foreign key(SchoolID) references tblSFITSchools(SchoolID) --外键约束。
)
go
---------------------------------------------------------------------------------------------
--年级信息表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITGrade')
begin
	print 'drop table tblSFITGrade'
	drop table tblSFITGrade
end
go
	print 'create table tblSFITGrade'
go
create table tblSFITGrade
(
	GradeID		GUIDEx,--年级ID。
	GradeCode	nvarchar(128),--年级代码。
	GradeName	nvarchar(256),--年级名称。
	GradeValue	int null,--年级值。
	LearnLevel	int null,--学习阶段。
		
	OrderNO		int default(0),--排序号。		
	
	constraint PK_tblSFITGrade primary key(GradeID),--主键约束。
	constraint UK_tblSFITGrade_GradeCode unique(GradeCode)--唯一约束。
	--constraint UK_tblSFITGrade_GradeValue_LearnLevel unique(GradeValue,LearnLevel)--唯一约束。
)
go
---------------------------------------------------------------------------------------------
--班级信息。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITClass')
begin
	print 'drop table tblSFITClass'
	drop table tblSFITClass
end
go
	print 'create table tblSFITClass'
go
create table tblSFITClass
(
	ClassID			GUIDEx,--班级ID。
	ClassCode		nvarchar(128),--班级代码。
	ClassName		nvarchar(256),--班级名称。
	OrderNO			int default(0),--排序号。
	
	SchoolID		GUIDEx,--所属学校ID。
	JoinYear		int null,--入学年份。
	GradeValue		int null,--当前年级。
	LearnLevel		int default(0),--学习阶段[枚举]。
	
	SyncStatus		int default(0),--同步状态。
	LastSyncTime	datetime default(null),--同步时间。
	
	constraint PK_tblSFITClass primary key(ClassID),--主键约束。
	constraint UK_tblSFITClass_ClassCode unique(ClassCode), --唯一约束。
	constraint FK_tblSFITClass_tblSFITSchools_SchoolID foreign key(SchoolID) references tblSFITSchools(SchoolID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
--学生信息。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITStudents')
begin
	print 'drop table tblSFITStudents'
	drop table tblSFITStudents
end
go
	print 'create table tblSFITStudents'
go
create table tblSFITStudents
(
	StudentID		GUIDEx,--学生ID。
	StudentCode		nvarchar(128),--学生学号（学号）
	StudentName		nvarchar(256),--姓名。
	
	Gender			int default(0),--性别（1-男，2-女，0-未知）
	JoinYear		int,--入学年份。
	IDNumber		nvarchar(32),--身份证号码。
			
	SyncStatus		int default(0),--同步状态。
	LastSyncTime	datetime default(null),--同步时间。
	
	constraint PK_tblSFITStudents primary key(StudentID),--主键约束。
	constraint UK_tblSFITStudents_StudentCode unique(StudentCode)--唯一约束。
)
go
---------------------------------------------------------------------------------------------
--学生班级对应关系表。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITClassStudents')
begin
	print 'drop table tblSFITClassStudents'
	drop table tblSFITClassStudents
end
go
	print 'create table tblSFITClassStudents'
go
create table tblSFITClassStudents
(
	StudentID		GUIDEx,--学生ID。
	ClassID			GUIDEx,--班级ID。
	
	LastSyncTime	datetime default(null),--同步时间。
	
	constraint PK_tblSFITClassStudents primary key(StudentID,ClassID),--主键约束。
	constraint FK_tblSFITClassStudents_tblSFITStudents_StudentID foreign key(StudentID) references tblSFITStudents(StudentID),--外键约束。
	constraint FK_tblSFITClassStudents_tblSFITClass_ClassID foreign key(ClassID) references tblSFITClass(ClassID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--任课教师/班级对应。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITTeaClass')
begin
	print 'drop table tblSFITTeaClass'
	drop table tblSFITTeaClass
end
go
	print 'create table tblSFITTeaClass'
go
create table tblSFITTeaClass
(
	TeacherID		GUIDEx,--教师ID。
	ClassID			GUIDEx,--班级ID。
	
	CreateEmployeeID	GUIDEx null,--创建者ID。
	CreateEmployeeName	nvarchar(50),--创建者名称。
	LastModifyTime		datetime default(getdate()),--创建时间。
	
	constraint PK_tblSFITTeaClass primary key(TeacherID,ClassID),--主键约束。
	constraint FK_tblSFITTeaClass_tblSFITeachers_TeacherID foreign key(TeacherID) references tblSFITeachers(TeacherID),--外键约束。
	constraint FK_tblSFITTeaClass_tblSFITClass_ClassID foreign key(ClassID) references tblSFITClass(ClassID)--外键约束。
)
go
---------------------------------------------------------------------------------------------


---------------------------------------------------------------------------------------------
--接入管理（区中心）。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITCenterAccess')
begin
	print 'drop table tblSFITCenterAccess'
	drop table tblSFITCenterAccess
end
go
	print 'drop table tblSFITCenterAccess'
go
create table tblSFITCenterAccess
(
	AccessID		GUIDEx, --接入ID。
	AccessAccount	nvarchar(32),--接入账号。
	AccessPassword	nvarchar(32),--接入密码。
	
	AccessStatus	int default(0),--访问状态。
	
	SchoolID		GUIDEx,--所属学校ID。
	SchoolName		nvarchar(256),--所属学校名称。

	Description		nvarchar(512),--描述信息。
	
	CreateEmployeeID	GUIDEx null,--创建者ID。
	CreateEmployeeName	nvarchar(50),--创建者名称。
	CreateDateTime		datetime default(getdate()),--创建时间。
	
	constraint PK_tblSFITCenterAccess primary key(AccessID),--主键约束。
	constraint UK_tblSFITCenterAccess_AccessAccount unique(AccessAccount), --唯一约束。
	constraint UK_tblSFITCenterAccess_SchoolID unique(SchoolID),--唯一约束（一个学校一个账号）。
	constraint FK_tblSFITCenterAccess_tblSFITSchools_SchoolID foreign key(SchoolID) references tblSFITSchools(SchoolID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--课程目录设置
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITCatalog')
begin
	print 'drop table tblSFITCatalog'
	drop table tblSFITCatalog
end
go
	print 'create table tblSFITCatalog'
go
create table tblSFITCatalog
(
	CatalogID		GUIDEx,--目录ID。
	CatalogCode		nvarchar(128),--目录代码。
	CatalogName		nvarchar(256),--目录名称。
	GradeID			GUIDEx,--所属年级ID。
	
	CatalogType		int default(0),--目录类型，0-区设必修，1-学校自增。
	SchoolID		GUIDEx	null,--学校ID(为空即为区设置)。
	OrderNO			int default(0),--排序号。
	
	CreateEmployeeID	GUIDEx null,--创建用户ID。
	CreateEmployeeName	nvarchar(64),--创建用户名称。
	LastModifyTime		datetime default(getdate()),--创建时间。
	
	constraint PK_tblSFITCatalog primary key(CatalogID),--主键约束。
	constraint UK_tblSFITCatalog_CatalogCode unique(CatalogCode),--唯一约束。
	constraint FK_tblSFITCatalog_tblSFITGrade_GradeID foreign key(GradeID) references tblSFITGrade(GradeID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--知识要点。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITKnowledgePoints')
begin
	print 'drop table tblSFITKnowledgePoints'
	drop table tblSFITKnowledgePoints
end
go
	print 'create table tblSFITKnowledgePoints'
go
create table tblSFITKnowledgePoints
(
	ParentPointID		GUIDEx	null,--父知识点ID。
	GradeID				GUIDEx	null,--所属年级ID。
	PointID				GUIDEx,--知识点ID。
	PointCode			nvarchar(128),--知识代码。
	PointName			nvarchar(256),--知识点名称。
	Description			nvarchar(512),--描述信息。
	OrderNO				int default(0),--排序号。
	
	constraint PK_tblSFITKnowledgePoints primary key(PointID)--主键约束。
)
go
---------------------------------------------------------------------------------------------
--课程目录下的知识要点。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITCatalogKnowledgePoints')
begin
	print 'drop table tblSFITCatalogKnowledgePoints'
	drop table tblSFITCatalogKnowledgePoints
end
go
	print 'create table tblSFITCatalogKnowledgePoints'
go
create table tblSFITCatalogKnowledgePoints
(
	CatalogID		GUIDEx,--目录ID。
	PointID			GUIDEx,--知识点ID。
	
	constraint PK_tblSFITCatalogKnowledgePoints primary key(CatalogID,PointID),--主键约束。
	constraint FK_tblSFITCatalogKnowledgePoints_tblSFITCatalog foreign key(CatalogID) references tblSFITCatalog(CatalogID),--外键约束。
	constraint FK_tblSFITCatalogKnowledgePoints_tblSFITKnowledgePoints foreign key(PointID) references tblSFITKnowledgePoints(PointID) --外键约束。
)
go
---------------------------------------------------------------------------------------------
--客观评价。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITEvaluate')
begin
	print 'drop table tblSFITEvaluate'
	drop table tblSFITEvaluate
end
go
	print 'create table tblSFITEvaluate'
go
create table tblSFITEvaluate
(
	EvaluateID			GUIDEx,--评价ID。
	EvaluateName		nvarchar(128),--评价名称。
	EvaluateType		int default(1),--评价类型(0-等级制，1-分数制)。
	OrderNO				int default(0),--排序号。
	
	MinValue			int default(0),--分数下限（分数制可用）。
	MaxValue			int default(100),--分数上限（分数制可用）。
	
	constraint PK_tblSFITEvaluate primary key(EvaluateID),--主键约束。
	constraint UK_tblSFITEvaluate_EvaluateName unique(EvaluateName)--唯一约束。
)
go
---------------------------------------------------------------------------------------------
--客观评价项目（等级制时使用）。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITEvaluateItems')
begin
	print 'drop table tblSFITEvaluateItems'
	drop table tblSFITEvaluateItems
end
go
	print 'create table tblSFITEvaluateItems'
go
create table tblSFITEvaluateItems
(
	ItemID				GUIDEx,--项目ID。
	ItemName			nvarchar(64),--项目名称。
	ItemValue			nvarchar(64),--项目值。
	
	EvaluateID			GUIDEx,--评价ID。
	
	constraint PK_tblSFITEvaluateItems primary key(ItemID),--主键约束。
	constraint UK_tblSFITEvaluateItems_ItemName_EvaluateID unique(EvaluateID,ItemName),--唯一约束。
	constraint FK_tblSFITEvaluateItems_tblSFITEvaluate_EvaluateID foreign key(EvaluateID) references tblSFITEvaluate(EvaluateID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--客观评价设置。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITEvaluateSet')
begin
	print 'drop table tblSFITEvaluateSet'
	drop table tblSFITEvaluateSet
end
go
	print 'create table tblSFITEvaluateSet'
go
create table tblSFITEvaluateSet
(
	EvaluateID		GUIDEx,--评价ID。
	GradeID			GUIDEx,--所属年级ID。
	ModifyTime		datetime default(getdate()),--设置时间。
	
	constraint PK_tblSFITEvaluateSet primary key(EvaluateID,GradeID),--主键约束。
	constraint FK_tblSFITEvaluateSet_tblSFITEvaluate_EvaluateID foreign key(EvaluateID) references tblSFITEvaluate(EvaluateID),--外键约束。
	constraint FK_tblSFITEvaluateSet_tblSFITGrade_GradeID foreign key(GradeID) references tblSFITGrade(GradeID)
)
go
---------------------------------------------------------------------------------------------
--学校课程目录作品提交时间段设置
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITSchoolSetCatalog')
begin
	print 'drop table tblSFITSchoolSetCatalog'
	drop table tblSFITSchoolSetCatalog
end
go
	print 'create table tblSFITSchoolSetCatalog'
go
create table tblSFITSchoolSetCatalog
(
	SchoolID		GUIDEx,--所属学校ID。
	CatalogID		GUIDEx,--目录ID。
	
	StartTime		datetime default(null),--开始时间。
	EndTime			datetime default(null),--结束时间。
	
	constraint PK_tblSFITSchoolSetCatalog primary key(SchoolID,CatalogID),--主键约束。
	constraint FK_tblSFITSchoolSetCatalog_tblSFITSchools_SchoolID foreign key(SchoolID) references tblSFITSchools(SchoolID),--外键约束。
	constraint FK_tblSFITSchoolSetCatalog_tblSFITCatalog_CatalogID foreign key(CatalogID) references tblSFITCatalog(CatalogID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--学生作品
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITStudentWorks')
begin
	print 'drop table tblSFITStudentWorks'
	drop table tblSFITStudentWorks
end
go
	print 'create table tblSFITStudentWorks'
go
create table tblSFITStudentWorks
(
	WorkID				GUIDEx,--作品ID。
	WorkName			nvarchar(256),--作品名称。
	WorkStatus			int default(0),--作品状态（0-提交，1-批阅，2-上传，3-发布）。
	WorkType			int default(0),--作品类型（0-公开，1-不公开）。
	
	CheckCode			nvarchar(32),--校验码。
	
	SchoolID			GUIDEx,--学校ID。
	SchoolName			nvarchar(128),--学校名称。
	
	GradeID				GUIDEx,--年级ID。
	GradeName			nvarchar(64),--年级名称。
	
	ClassID				GUIDEx,--班级ID。
	ClassName			nvarchar(64),--班级名称。
	
	StudentID			GUIDEx,--学生ID。
	
	CatalogID			GUIDEx,--目录ID。
	CatalogName			nvarchar(128),--目录名称。
	
	CreateEmployeeID	GUIDEx null,--创建用户ID。
	CreateEmployeeName	nvarchar(64),--创建用户名称。
	CreateDateTime		datetime default(getdate()),--创建时间。
	
	WorkDescription		nvarchar(512),--作品描述。
	
	constraint PK_tblSFITStudentWorks primary key(WorkID),--主键约束。
	constraint FK_tblSFITStudentWorks_tblSFITSchools_SchoolID foreign key(SchoolID) references tblSFITSchools(SchoolID),--学校ID外键约束。
	constraint FK_tblSFITStudentWorks_tblSFITGrade_GradeID foreign key(GradeID) references tblSFITGrade(GradeID),--年级ID外键约束。
	constraint FK_tblSFITStudentWorks_tblSFITCatalog_CatalogID foreign key(CatalogID) references tblSFITCatalog(CatalogID),--目录ID外键约束。
	constraint FK_tblSFITStudentWorks_tblSFITClass_ClassID foreign key(ClassID) references tblSFITClass(ClassID),--班级ID外键约束。
	constraint FK_tblSFITStudentWorks_tblSFITStudents_StudentID foreign key(StudentID) references tblSFITStudents(StudentID)--学生ID外键约束。
)
go
---------------------------------------------------------------------------------------------
--附件管理。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITAccessories')
begin
	print 'drop table tblSFITAccessories'
	drop table tblSFITAccessories
end
go
	print 'create table tblSFITAccessories'
go
create table tblSFITAccessories
(
	AccessoriesID		GUIDEx,--附件ID。
	AccessoriesName		nvarchar(128),--附件名称。
	ContentType			nvarchar(128),--MIME 内容类型。
	AccessoriesSize		float default(0),--附件大小。
	Suffix				nvarchar(10),--附件后缀名。
	CheckCode			nvarchar(64),--校验码。
	LastModify			datetime default(getdate()),--最近修改时间。
	
	constraint PK_tblSFITAccessories primary key(AccessoriesID) --主键约束。
)
go
---------------------------------------------------------------------------------------------
--学生作品附件。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITStudentAttachment')
begin
	print 'drop table tblSFITStudentAttachment'
	drop table tblSFITStudentAttachment
end
go
	print 'create table tblSFITStudentAttachment'
go
create table tblSFITStudentAttachment
(
	WorkID				GUIDEx,--作品ID。
	AccessoriesID		GUIDEx,--附件ID。
	
	CreateEmployeeID	GUIDEx null,--创建用户ID。
	CreateEmployeeName	nvarchar(64),--创建约束名称。
	CreateDateTime		datetime default(getdate()),--创建时间。
	
	constraint PK_tblSFITStudentAttachment primary key(WorkID,AccessoriesID),--主键约束。
	constraint FK_tblSFITStudentAttachment_tblSFITStudentWorks_WorkID foreign key(WorkID) references tblSFITStudentWorks(WorkID),--外键约束。
	constraint FK_tblSFITStudentAttachment_tblSFITAccessories_AccessoriesID foreign key(AccessoriesID) references tblSFITAccessories(AccessoriesID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--任课老师评阅。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITeaReviewStudent')
begin
	print 'drop table tblSFITeaReviewStudent'
	drop table tblSFITeaReviewStudent
end
go
	print 'create table tblSFITeaReviewStudent'
go
create table tblSFITeaReviewStudent
(
	WorkID			GUIDEx,--作品ID。
	TeacherID		GUIDEx,--教师ID。
	TeacharName		nvarchar(64),--教师名称。
	
	EvaluateType		int default(1),--评价类型(0-等级制，1-分数制)。
	ReviewValue			nvarchar(32),--客观评价结果。
	SubjectiveReviews	nvarchar(1024),--主观评语。
	
	CreateEmployeeID	GUIDEx null,--创建用户ID。
	CreateEmployeeName	nvarchar(64),--创建用户名称。
	CreateDateTime		datetime default(getdate()),--创建时间。
	
	constraint PK_tblSFITeaReviewStudent primary key(WorkID),--主键约束。
	constraint FK_tblSFITeaReviewStudent_tblSFITStudentWorks_WorkID foreign key(WorkID) references tblSFITStudentWorks(WorkID),--外键约束。
	constraint FK_tblSFITeaReviewStudent_tblSFITeachers_TeacherID foreign key(TeacherID) references tblSFITeachers(TeacherID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
--匿名评论。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITWorksComments')
begin
	print 'drop table tblSFITWorksComments'
	drop table tblSFITWorksComments
end
go
	print 'create table tblSFITWorksComments'
go
create table tblSFITWorksComments
(
	CommentID	GUIDEx,--评论ID。
	WorkID		GUIDEx,--作品ID。
	Status		int default(0),--状态（0-展示，1-隐藏）。
	Comment		nvarchar(1024),--评论。
	
	UserName	nvarchar(128),--用户名称。
	ClientIP	nvarchar(64),--IP地址。
	CreateDateTime	datetime default(getdate()),--创建时间。
	
	constraint PK_tblSFITWorksComments primary key(CommentID),--主键约束。
	constraint FK_tblSFITWorksComments_tblSFITStudentWorks_WorkID foreign key(WorkID) references tblSFITStudentWorks(WorkID)--外键约束。
)
go
---------------------------------------------------------------------------------------------
