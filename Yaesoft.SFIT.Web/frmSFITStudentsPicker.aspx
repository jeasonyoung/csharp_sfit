<%--
//================================================================================
//  FileName: frmSFITStudentsPicker.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/23
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITStudentsPicker.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentsPicker" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<div class="TableSearch">
    <fieldset>
        <legend>查询条件</legend>
        <div style="float:left; width:100%;">
            <div style="float:left;">
                <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
	            <JWC:DropDownListEx ID="ddlSchool" runat="server" Width="168px" />
            </div>
            <div style="float:left;">
                <JWC:LabelEx ID="lbClassName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">所属班级：</JWC:LabelEx>
	            <JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
            </div>
        </div>
        <div style="float:left; width:100%;">
            <div style="float:left;">
                <JWC:LabelEx ID="lStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">学生姓名：</JWC:LabelEx>
                <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="168px" />
            </div>
            <div style="float:right;">
                <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" OnClick="btnSearch_OnClick" RightSpace="1" />
            </div>
        </div>
    </fieldset>
</div>
<div class="TableSearch">
    <asp:ListBox ID="listStudents" runat="server" SelectionMode="Multiple" Width="100%" Height="280px" />
</div>
<!--数据控制区域-->
<div class="TableControl">
    <div style="margin:0 auto; text-align:center; width:100%;">
        <JWC:ServerAlert ID="errMsg" runat="server" />
	    <JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" />
	    <JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
    </div>
</div>
</asp:Content>
