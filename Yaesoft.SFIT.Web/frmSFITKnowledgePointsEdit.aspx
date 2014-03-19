<%--
//================================================================================
// FileName: frmSFITKnowledgePointsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITKnowledgePointsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITKnowledgePointsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITKnowledgePointsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<div class="TableSearch">
	    <asp:Panel ID="panelParentPoint" runat="server" Visible="false" Width="100%">
			<JWC:LabelEx ID="lbParentPointID" runat="server" Style="float:left;" meta:resourcekey="SFIT_ParentPointID">上级要点：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlParentPointID" runat="server" ShowTreeView="true" ShowUnDefine="true" Width="368px" IsRequired="true" ErrorMessage="上级要点不能为空！" />
		</asp:Panel>
		
		<asp:Panel ID="panelGrade" runat="server" Width="100%">
		    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_ParentPointID">所属年级：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="所属年级不能为空！" />
		</asp:Panel>
				
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbPointCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_PointCode">要点代码：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPointCode" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="要点代码不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbPointName" runat="server" Style="float:left;" meta:resourcekey="SFIT_PointName">要点名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPointName" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="要点名称不能为空！" />
		</div>
				
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" CssClass="NumberTextBoxFlat" Text="1" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="排序号不能为空！" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="SFIT_Description">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="368px" TextMode="MultiLine" Rows="3" />
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
