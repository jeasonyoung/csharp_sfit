<%--
//================================================================================
// FileName: frmSFITStudentsEdit.aspx
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITStudentsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITStudentsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<div class="TableSearch">
	     
	    <div style="float:left; width:100%;">
		   <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
		   <JWC:PickerBase ID="pbSchool" runat="server" Width="370px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="400px" PickerWidth="300px" MultiSelect="false"
			      IsRequired="true" ErrorMessage="学校名称不能为空！" />
	    </div>
				
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">所属年级：</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_OnSelectedIndexChanged" 
		        IsRequired="true" ErrorMessage="所属年级不能为空！"  />
	    </div>
		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbClass" runat="server" Style="float:left;" meta:resourcekey="SFIT_Class">所属班级：</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlClass" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="所属班级不能为空！" />
	    </div>
		 
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbStudentCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentCode">学生代码：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtStudentCode" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="学生代码不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">学生名称：</JWC:LabelEx>			 
			<JWC:TextBoxEx ID="txtStudentName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage="学生名称不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGender" runat="server" Style="float:left;" meta:resourcekey="SFIT_Gender">性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</JWC:LabelEx>
		     <JWC:DropDownListEx ID="ddlGender" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="性别不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbJoinYear" runat="server" Style="float:left;" meta:resourcekey="SFIT_JoinYear">入学年份：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtJoinYear" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="入学年份不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbIDNumber" runat="server" Style="float:left;" meta:resourcekey="SFIT_IDNumber">身份证号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtIDNumber" runat="server" Width="168px" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSyncStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_SyncStatus">同步状态：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSyncStatus" runat="server" Width="80px" IsRequired="true" ErrorMessage="同步状态不能为空！" />
		</div>
		
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
