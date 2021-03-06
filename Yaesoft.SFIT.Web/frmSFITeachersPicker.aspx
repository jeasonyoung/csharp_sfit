﻿<%--
//================================================================================
//  FileName: frmSFITeachersPicker.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/10/19
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITeachersPicker.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITeachersPicker" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <div class="TableSearch">
         <fieldset>
            <legend>查询条件</legend>
            
            <div style="float:left; width:100%;">
                <JWC:LabelEx ID="lbSchoolID" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
            </div>
            
            <div style="float:left; width:100%;">
                <div style="float:left;">
                    <JWC:LabelEx ID="lbTeacher" runat="server" Style="float:left;" meta:resourcekey="SFIT_TeacherName">教师名称：</JWC:LabelEx>
                    <JWC:TextBoxEx ID="txtTeacherName" runat="server" Width="128px" />
                </div>
                <div style="float:right;">
                    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" OnClick="btnSearch_OnClick" RightSpace="1" />
                </div>
            </div>
        </fieldset>
    </div>

    <div class="TableSearch">
        <asp:ListBox ID="listTeacher" runat="server" Width="100%" Height="280px" />
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
