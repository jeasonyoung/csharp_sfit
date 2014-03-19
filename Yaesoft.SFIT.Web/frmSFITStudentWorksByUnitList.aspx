<%--
//================================================================================
//  FileName: frmSFITStudentWorksByUnitList.aspx
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITStudentWorksByUnitList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentWorksByUnitList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<%@ Register TagPrefix="JWC" TagName="UCStudentWorksList" Src="UCStudentWorksList.ascx" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
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
    <div style="float:left; width:100%;">
    
        <div style="float: left;">
            <JWC:LabelEx ID="lbSchoolName" runat="server" Style="float: left;" meta:resourcekey="SFIT_SchoolName">所属学校：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlSchool" runat="server" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbGrade" runat="server" Style="float: left;" meta:resourcekey="SFIT_Grade">所属年级：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbClassName" runat="server" Style="float: left;" meta:resourcekey="SFIT_ClassName">所属班级：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtClassName" runat="server" Width="168px" />
        </div>
    
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">学生姓名：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="165px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbWorkName" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkName">作品名称：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtWorkName" runat="server" Width="168px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbWorkStatus" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkStatus">作品状态：</JWC:LabelEx>
        <JWC:DropDownListEx ID="ddlWorkStatus" runat="server" ShowUnDefine="true" Width="168px" />
    </div>
    
    <div style="float: right;">
        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
        <JWC:ServerAlert ID="errMessage" runat="server" />
    </div>
</asp:Panel>

<JWC:UCStudentWorksList ID="ucStudentWorksList" runat="server" />
</asp:Content>
