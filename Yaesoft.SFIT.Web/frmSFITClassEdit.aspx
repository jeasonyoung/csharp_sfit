<%--
//================================================================================
// FileName: frmSFITClassEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITClassEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITClassEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITClassEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<div class="TableSearch">
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
		    <JWC:PickerBase ID="pbSchool" runat="server" Width="370px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="400px" PickerWidth="300px" MultiSelect="false"
			      IsRequired="true" ErrorMessage="学校名称不能为空！" />
		</div>
		
        <div style="float:left;width:100%;">
            <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">所属年级：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="所属年级不能为空！"  />
        </div>
			    
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbClassCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassCode">班级代码：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtClassCode" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="班级代码不能为空！" />
	    </div>
		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbClassName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">班级名称：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtClassName" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="班级名称不能为空！"  />
	    </div>
	    
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbJoinYear" runat="server" Style="float:left;" meta:resourcekey="SFIT_JoinYear">入学年份：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtJoinYear" runat="server" Width="80px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="入学年份不能为空！"  />
	    </div>
	    		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" CssClass="NumberTextBoxFlat" Text="1" IsRequired="true" RequiredErrorMessage="排序号不能为空！"  />
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
