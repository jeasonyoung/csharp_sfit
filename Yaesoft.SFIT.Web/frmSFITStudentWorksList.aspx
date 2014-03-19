<%--
//================================================================================
// FileName: frmSFITStudentWorksCollect.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITStudentWorksList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentWorksList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<%@ Register TagPrefix="JWC" TagName="UCStudentWorksList" Src="UCStudentWorksList.ascx" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <!--����-->
    <div class="TitleBar">
        <span class="LabelTitle" style="float: left;">
            <JWC:LabelEx ID="lbTitle" runat="server" />
        </span>
        <div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
    </div>
    <!--��ѯ����-->
    <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
        <div style="float:left; width:100%;">
        
            <div style="float: left;">
                <JWC:LabelEx ID="lbSchoolName" runat="server" Style="float: left;" meta:resourcekey="SFIT_SchoolName">����ѧУ��</JWC:LabelEx>
                <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
            </div>
            
            <div style="float: left;">
                <JWC:LabelEx ID="lbGrade" runat="server" Style="float: left;" meta:resourcekey="SFIT_Grade">�����꼶��</JWC:LabelEx>
                <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" />
            </div>
            
            <div style="float: left;">
                <JWC:LabelEx ID="lbClassName" runat="server" Style="float: left;" meta:resourcekey="SFIT_ClassName">�����༶��</JWC:LabelEx>
                <JWC:TextBoxEx ID="txtClassName" runat="server" Width="168px" />
            </div>
        
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbStudentName" runat="server" Style="float: left;" meta:resourcekey="SFIT_StudentName">ѧ��������</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbWorkName" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkName">��Ʒ���ƣ�</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtWorkName" runat="server" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbWorkStatus" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkStatus">��Ʒ״̬��</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlWorkStatus" runat="server" ShowUnDefine="true" Width="168px" />
        </div>
        
        <div style="float: right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
            <JWC:ServerAlert ID="errMessage" runat="server" />
        </div>
    </asp:Panel>
   
    <JWC:UCStudentWorksList ID="ucStudentWorksList" runat="server" />
</asp:Content>
