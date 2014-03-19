<%--
//================================================================================
// FileName: frmSFITStudentsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITStudentsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITStudentsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">
	     
	    <div style="float:left; width:100%;">
		   <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">����ѧУ��</JWC:LabelEx>
		   <JWC:PickerBase ID="pbSchool" runat="server" Width="370px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="400px" PickerWidth="300px" MultiSelect="false"
			      IsRequired="true" ErrorMessage="ѧУ���Ʋ���Ϊ�գ�" />
	    </div>
				
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">�����꼶��</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_OnSelectedIndexChanged" 
		        IsRequired="true" ErrorMessage="�����꼶����Ϊ�գ�"  />
	    </div>
		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbClass" runat="server" Style="float:left;" meta:resourcekey="SFIT_Class">�����༶��</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlClass" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="�����༶����Ϊ�գ�" />
	    </div>
		 
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbStudentCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentCode">ѧ�����룺</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtStudentCode" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="ѧ�����벻��Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">ѧ�����ƣ�</JWC:LabelEx>			 
			<JWC:TextBoxEx ID="txtStudentName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage="ѧ�����Ʋ���Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGender" runat="server" Style="float:left;" meta:resourcekey="SFIT_Gender">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</JWC:LabelEx>
		     <JWC:DropDownListEx ID="ddlGender" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="�Ա���Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbJoinYear" runat="server" Style="float:left;" meta:resourcekey="SFIT_JoinYear">��ѧ��ݣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtJoinYear" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="��ѧ��ݲ���Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbIDNumber" runat="server" Style="float:left;" meta:resourcekey="SFIT_IDNumber">���֤�ţ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtIDNumber" runat="server" Width="168px" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSyncStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_SyncStatus">ͬ��״̬��</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSyncStatus" runat="server" Width="80px" IsRequired="true" ErrorMessage="ͬ��״̬����Ϊ�գ�" />
		</div>
		
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
