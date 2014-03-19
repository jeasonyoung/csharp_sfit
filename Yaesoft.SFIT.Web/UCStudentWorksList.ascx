<%--
//================================================================================
//  FileName: UCStudentWorksList.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/10
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStudentWorksList.ascx.cs" Inherits="Yaesoft.SFIT.Web.UCStudentWorksList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<!--数据显示区域-->
<JWC:DataGridView ID="dgUCStudentWorksList" runat="server" CssClass="DataGrid"
    Width="98%" ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="false"
    MouseoverCssClass="DataGridHighLight" PageSize="12" OnBuildDataSource="dgUCStudentWorksList_BuildDataSource">
    <PagerSettings Mode="NextPreviousFirstLast" />
    <AlternatingRowStyle CssClass="DataGridAlter" />
    <HeaderStyle CssClass="DataGridHeader" />
    <FooterStyle CssClass="DataGridFooter" />
    <RowStyle CssClass="DataGridItem" />
    <Columns>
        <JWC:CheckBoxFieldEx DataField="WorkID">
			<HeaderStyle Width="8px" />
		</JWC:CheckBoxFieldEx>
		
        <JWC:BoundFieldEx DataField="SchoolName" HeaderText="所属学校" SortExpression="SchoolName"  meta:resourcekey="SFIT_DGV_SchoolName">
            <HeaderStyle Width="15%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="GradeName" HeaderText="所属年级" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
            <HeaderStyle Width="8%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
                    
        <JWC:BoundFieldEx DataField="ClassName" HeaderText="所属班级" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_ClassName">
            <HeaderStyle Width="10%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="640px" WinHeight="560px"
			DataNavigateUrlFormatString="frmSFITStudentWorksEdit.aspx?WorkID={0}" DataNavigateUrlField="WorkID"
			HeaderText="作品名称" DataField="WorkName" SortExpression="WorkName" meta:resourcekey="SFIT_DGV_WorkName">
			<HeaderStyle Width="20%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:MultiQueryStringFieldEx>
        
        <JWC:BoundFieldEx DataField="StudentName" HeaderText="所属学生" SortExpression="StudentName" meta:resourcekey="SFIT_DGV_StudentName">
            <HeaderStyle Width="9%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="ReviewValue" HeaderText="教师评阅" SortExpression="ReviewValue" meta:resourcekey="SFIT_DGV_ReviewValue">
            <HeaderStyle Width="8%" />
            <ItemStyle HorizontalAlign="Right" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="WorkStatusName" HeaderText="作品状态" SortExpression="WorkStatusName" meta:resourcekey="SFIT_DGV_WorkStatusName">
            <HeaderStyle Width="20%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="CreateDateTime" HeaderText="处理时间" SortExpression="CreateDateTime" meta:resourcekey="SFIT_DGV_CreateDateTime"
             DataFormatString="{0:yyyy-MM-dd}">
            <HeaderStyle Width="10%" />
            <ItemStyle HorizontalAlign="Center" />
        </JWC:BoundFieldEx>
    </Columns>
</JWC:DataGridView>