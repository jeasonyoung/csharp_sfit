<%--
//================================================================================
//  FileName: UCStudentWork.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/10
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStudentWork.ascx.cs" Inherits="Yaesoft.SFIT.Web.UCStudentWork" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<fieldset>
    <legend>基本信息</legend>
    <div style="float:left;width:100%;">
        <div style="float:left;">
	        <JWC:LabelEx ID="lbWorkName" runat="server" Style="float:left;" meta:resourcekey="SFIT_WorkName">作品名称：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtWorkName" runat="server" Width="268px" IsRequired="true" RequiredErrorMessage="作品名称不能为空！" />
        </div>
        <div style="float:left;">
	        <JWC:LabelEx ID="lbWorkType" runat="server" Style="float:left;" meta:resourcekey="SFIT_WorkType">作品类型：</JWC:LabelEx>
	        <JWC:DropDownListEx ID="ddlWorkType" runat="server" Width="128px"  IsRequired="true" ErrorMessage="作品类型不能为空！" />
        </div>
    </div>
    
    <div style="float:left;width:100%;">
        <JWC:LabelEx ID="lbWorkStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_WorkStatus">作品状态：</JWC:LabelEx>
        <JWC:CheckBoxListEx ID="chkWorkStatus" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="作品状态不能为空！" />
    </div>
    
     
    <asp:Panel ID="panelCheckCode" runat="server" Width="100%">
        <JWC:LabelEx ID="lbCheckCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_CheckCode">校&nbsp;&nbsp;验&nbsp;&nbsp;码：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtCheckCode" runat="server" Width="472px" ReadOnly="true"/>
    </asp:Panel>
    
    
    <div style="float:left;width:100%;">
         <div style="float:left;">
	        <JWC:LabelEx ID="lbWorkDescription" runat="server" Style="float:left;" meta:resourcekey="SFIT_WorkDescription">作品描述：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtWorkDescription" runat="server" Width="472px" TextMode="MultiLine" Rows="3" />
        </div>
    </div>
</fieldset>
<fieldset style="margin-top:2px;">
    <legend>作品属性</legend>
    <div style="float:left;width:100%;">
        <div style="float:left;">
	        <JWC:LabelEx ID="lbSchoolName" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">所属学校：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="268px" Enabled="false" />
        </div>
        <div style="float:left; margin-left:11px;">
	        <JWC:LabelEx ID="lbGradeName" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">所属年级：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtGradeName" runat="server" Width="128px" Enabled="false" />
        </div>
    </div>
    <div style="float:left;width:100%;">
        <div style="float:left;">
	        <JWC:LabelEx ID="lbClassName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">所属班级：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtClassName" runat="server" Width="268px" Enabled="false" />
        </div>
        
        <div style="float:left; margin-left:11px;">
	        <JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">所属学生：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="128px" Enabled="false" />
        </div>
    </div>
    <div style="float:left;width:100%;">
        <div style="float:left;">
	        <JWC:LabelEx ID="lbCatalogName" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogName">所属目录：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="268px" Enabled="false" />
        </div>
    </div>
</fieldset>
