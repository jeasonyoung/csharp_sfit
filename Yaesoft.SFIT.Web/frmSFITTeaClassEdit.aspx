<%--
//================================================================================
// FileName: frmSFITTeaClassEdit.aspx
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITTeaClassEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITTeaClassEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITTeaClassEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">����ѧУ��</JWC:LabelEx>
			<JWC:PickerBase ID="pbSchool" runat="server" Width="268px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="420px" PickerWidth="330px" MultiSelect="false"
			      IsRequired="true" ErrorMessage="ѧУ���Ʋ���Ϊ�գ�" AutoPostBack="true" OnTextChanged="pbSchool_OnTextChanged" />
		</div>
		
        <div style="float:left;width:100%;">
            <JWC:LabelEx ID="lbTeacher" runat="server" Style="float:left;" meta:resourcekey="SFIT_TeacherName">��ʦ���ƣ�</JWC:LabelEx>
            <JWC:PickerBase ID="pbTeacher" runat="server" Width="268px" PickerPage="frmSFITeachersPicker.aspx" MultiSelect="false" PickerHeight="450px" PickerWidth="300px" IsRequired="true" ErrorMessage="��ʦ���Ʋ���Ϊ�գ�" />
        </div>
	</div>
	<!--�༶����-->
	<div class="TableControl" style="height:390px; vertical-align:top; overflow:auto;">
	    <JWC:TreeView ID="tvStudents" runat="server"  CheckType="CheckBox" width="100%" />
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
