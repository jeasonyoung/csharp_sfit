<%--
//================================================================================
//  FileName: frmSFITTeaClassByUnitEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITTeaClassByUnitEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITTeaClassByUnitEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx id="vsfrmSFITTeaClassByUnitEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSchool" runat="server" Width="268px" ShowUnDefine="true" AutoPostBack="true" OnSelectedIndexChanged="ddlSchool_OnSelectedIndexChanged" 
			    IsRequired="true" ErrorMessage="学校名称不能为空！" />
		</div>
		
        <div style="float:left;width:100%;">
            <JWC:LabelEx ID="lbTeacher" runat="server" Style="float:left;" meta:resourcekey="SFIT_TeacherName">教师名称：</JWC:LabelEx>
            <JWC:PickerBase ID="pbTeacher" runat="server" Width="268px" PickerPage="frmSFITeachersPicker.aspx" MultiSelect="false" PickerHeight="450px" PickerWidth="300px" IsRequired="true" ErrorMessage="教师名称不能为空！" />
        </div>
	</div>
	<!--班级数据-->
	<div class="TableControl" style="height:390px; vertical-align:top; overflow:auto;">
	    <JWC:TreeView ID="tvStudents" runat="server"  CheckType="CheckBox" width="100%" />
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
