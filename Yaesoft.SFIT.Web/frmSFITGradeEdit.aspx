<%--
//================================================================================
// FileName: frmSFITGradeEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITGradeEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITGradeEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITGradeEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<div class="TableSearch">
	     	
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbGradeCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeCode">年级代码：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtGradeCode" runat="server" Width="368px"  IsRequired="true" RequiredErrorMessage="年级代码不能为空！" />
	    </div>
		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGradeName" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">年级名称：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtGradeName" runat="server" Width="368px" IsRequired="true" RequiredErrorMessage="年级名称不能为空！" />
	    </div>		    
	     
	    <div style="float:left; width:100%;">
            <JWC:LabelEx ID="lbGradeValue" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeValue">年&nbsp;&nbsp;级&nbsp;&nbsp;值：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtGradeValue" runat="server" Width="80px" CssClass="NumberTextBoxFlat" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="年级值不能为空！" />
        </div>
	    
        <div style="float:left; width:100%;">
             <JWC:LabelEx ID="lbLearnLevelName" runat="server" Style="float:left;" meta:resourcekey="SFIT_LearnLevelName">学习阶段：</JWC:LabelEx>
             <JWC:DropDownListEx ID="ddlLearnLevel" runat="server" Width="128px" ShowUnDefine="true" IsRequired="true" ErrorMessage="学习阶段不能为空！" />
        </div>
        
        <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" CssClass="NumberTextBoxFlat" OnlyNumber="true" Text="1" IsRequired="true" RequiredErrorMessage="排序号不能为空！" />
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
