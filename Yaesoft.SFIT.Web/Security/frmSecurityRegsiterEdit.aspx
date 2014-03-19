<%--
//================================================================================
// FileName: frmSecurityRegsiterEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRegsiterEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRegsiterEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRegsiterEdit" runat="server"  ShowMessageBox="true" ShowSummary="false" />
	<!--数据录入区域-->
	<div class="TableSearch">
	     <div style="float:left;width:100%;">
	            <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">系统编号：</JWC:LabelEx>
	            <JWC:TextBoxEx ID="txtSystemID" runat="server" Width="416px"  MaxLength="32" IsRequired="true" RequiredErrorMessage="系统编号不能为空！" />
            </div>
		
	        <div style="float:left;width:100%;">
			    <JWC:LabelEx ID="lbParentSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentSystemID">上级系统：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlParentSystemID" runat="server" ShowUnDefine="true"  ShowTreeView="true" Width="168px"  />
		    </div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemSign" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemSign">系统标识：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemSign" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="系统标识不能为空！" />
		    </div>
    		
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemName">系统名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemName" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="系统名称不能为空！" />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSystemURL" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemURL">系统URL：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSecurityURL" runat="server" Style="float:left;" meta:resourcekey="Sec_SecurityURL">安全URL：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSecurityURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbPatchURL" runat="server" Style="float:left;" meta:resourcekey="Sec_PatchURL">更新URL：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPatchURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbModuleConfigURL" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleConfigURL">菜单URL：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleConfigURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemType" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemType">类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;型：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlSystemType" runat="server" Width="168px" ShowUnDefine="true" IsRequired="true" ErrorMessage="类型不能为空！" />
		    </div>
		    
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemStatus" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemStatus">状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlSystemStatus" runat="server" Width="168px" ShowUnDefine="true" IsRequired="true" ErrorMessage="状态不能为空！" />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSystemDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemDescription">系统描述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemDescription" runat="server" Width="416px" TextMode="MultiLine" Rows="3"  />
		</div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMsg" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnBatch" runat="server" ButtonType="Batch" Visible="false" LeftSpace="2" OnClick="btnBatch_Click" CausesValidation="true" ConfirmMsg="您确定要初始化模块权限？" ShowConfirmMsg="true" />
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
