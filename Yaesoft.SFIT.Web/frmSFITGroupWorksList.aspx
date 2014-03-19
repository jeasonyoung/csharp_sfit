<%--
//================================================================================
//  FileName: frmSFITGroupList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/24
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITGroupWorksList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITGroupWorksList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
<!--标题-->
<div class="TitleBar">
    <span class="LabelTitle" style="float: left;">
        <JWC:LabelEx ID="lbTitle" runat="server" />
    </span>
    <div style="float:right;">
		<span style="float:left;">
			<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
		</span>
	</div>
</div>
<!--查询区域-->
<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
 <div style="float: left; width:100%;">
    <div style="float: left;">
        <JWC:LabelEx ID="lbSchoolName" runat="server" Style="float: left;" meta:resourcekey="SFIT_SchoolName">所属学校：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbGroupName" runat="server" Style="float: left;" meta:resourcekey="SFIT_GroupName">分组名称：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtGroupName" runat="server" Width="168px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbCatalogName" runat="server" Style="float: left;" meta:resourcekey="SFIT_CatalogName">课程科目：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="168px" />
    </div>
 </div>
 <div style="float: left; width:100%;"> 
     <div style="float: left;">
        <JWC:LabelEx ID="lbStudentName" runat="server" Style="float: left;" meta:resourcekey="SFIT_StudentName">学生名称：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="168px" />
    </div>
 
    <div style="float: right;">
        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
        <JWC:ServerAlert ID="errMessage" runat="server" />
    </div>
 </div>
</asp:Panel>

<!--数据显示区域-->
<JWC:DataGridView ID="dgfrmSFITGroupWorksList" runat="server" CssClass="DataGrid"
    Width="98%" ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="false"
    MouseoverCssClass="DataGridHighLight" PageSize="12" OnBuildDataSource="dgfrmSFITGroupWorksList_BuildDataSource">
    <PagerSettings Mode="NextPreviousFirstLast" />
    <AlternatingRowStyle CssClass="DataGridAlter" />
    <HeaderStyle CssClass="DataGridHeader" />
    <FooterStyle CssClass="DataGridFooter" />
    <RowStyle CssClass="DataGridItem" />
    <Columns>
        <JWC:CheckBoxFieldEx DataField="WorkID">
			<HeaderStyle Width="8px" />
		</JWC:CheckBoxFieldEx>
		
		<JWC:BoundFieldEx DataField="GroupName" HeaderText="所属分组" SortExpression="GroupName"  meta:resourcekey="SFIT_DGV_GroupName">
            <HeaderStyle Width="12%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
		
        <JWC:BoundFieldEx DataField="SchoolName" HeaderText="所属学校" SortExpression="SchoolName"  meta:resourcekey="SFIT_DGV_SchoolName">
            <HeaderStyle Width="15%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
                                  
        <JWC:BoundFieldEx DataField="ClassName" HeaderText="所属班级" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_ClassName">
            <HeaderStyle Width="8%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="640px" WinHeight="560px"
			DataNavigateUrlFormatString="frmSFITStudentWorksEdit.aspx?WorkID={0}" DataNavigateUrlField="WorkID"
			HeaderText="作品名称" DataField="WorkName" SortExpression="WorkName" meta:resourcekey="SFIT_DGV_WorkName">
			<HeaderStyle Width="18%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:MultiQueryStringFieldEx>
        
        <JWC:BoundFieldEx DataField="StudentName" HeaderText="所属学生" SortExpression="StudentName" meta:resourcekey="SFIT_DGV_StudentName">
            <HeaderStyle Width="9%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="ReviewValue" HeaderText="评阅" SortExpression="ReviewValue" meta:resourcekey="SFIT_DGV_ReviewValue">
            <HeaderStyle Width="6%" />
            <ItemStyle HorizontalAlign="Right" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="WorkStatusName" HeaderText="作品状态" SortExpression="WorkStatusName" meta:resourcekey="SFIT_DGV_WorkStatusName">
            <HeaderStyle Width="22%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="CreateDateTime" HeaderText="处理时间" SortExpression="CreateDateTime" meta:resourcekey="SFIT_DGV_CreateDateTime"
             DataFormatString="{0:yyyy-MM-dd}">
            <HeaderStyle Width="10%" />
            <ItemStyle HorizontalAlign="Center" />
        </JWC:BoundFieldEx>
    </Columns>
</JWC:DataGridView>
</asp:Content>
