<%--
//================================================================================
// FileName: frmSecurityModuleEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityModuleEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityModuleEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityModuleEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
        <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">所属系统：</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlSystemID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="168px" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemID_OnSelectedIndexChanged"
		     IsRequired="true" ErrorMessage="所属系统不能为空！" />
	    </div>
	
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbModuleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleID">模块编号：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtModuleID" runat="server" Width="418px"  MaxLength="32" IsRequired="true" RequiredErrorMessage="模块编号不能为空！" />
	    </div>
 		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbModuleName" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleName">模块名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtModuleName" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="模块名称不能为空！" />
		    </div>
		    
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbParentModuleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentModuleID">上级模块：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlParentModuleID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="168px"  />
		    </div>	
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbModuleStatus" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleStatus">状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlModuleStatus" runat="server" Width="168px" ShowUnDefine="true" IsRequired="true" ErrorMessage="状态不能为空！" />
		    </div>
    		
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sec_OrderNo">排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="168px" OnlyNumber="true" Text="0" />
		    </div>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbModuleDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleDescription">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleDescription" runat="server" TextMode="MultiLine" Rows="3" Width="418px"  />
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
