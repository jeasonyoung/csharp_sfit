<%--
//================================================================================
// FileName: frmSFITWorksCommentsList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITWorksCommentsList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITWorksCommentsList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <!--����-->
    <div class="TitleBar">
        <span class="LabelTitle" style="float: left;">
            <JWC:LabelEx ID="lbTitle" runat="server" />
        </span>
        <div style="float: right;">
            <span style="float: left;">
                <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" OnClick="btnDelete_Click" />
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
            <JWC:LabelEx ID="lbCatalogName" runat="server" Style="float: left;" meta:resourcekey="SFIT_CatalogName">����Ŀ¼��</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbStudentName" runat="server" Style="float: left;" meta:resourcekey="SFIT_StudentName">ѧ��������</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="166px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbWorkName" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkName">��Ʒ���ƣ�</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtWorkName" runat="server" Width="168px" />
        </div>
                
        <div style="float: right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
            <JWC:ServerAlert ID="errMessage" runat="server" />
        </div>
    </asp:Panel>
    <!--������ʾ����-->
    <JWC:DataGridView ID="dgfrmSFITWorksCommentsList" runat="server" CssClass="DataGrid"
        Width="98%" ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="false"
        MouseoverCssClass="DataGridHighLight" PageSize="15" OnBuildDataSource="dgfrmSFITWorksCommentsList_BuildDataSource">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
            <JWC:CheckBoxFieldEx DataField="CommentID">
                <HeaderStyle Width="8px" />
            </JWC:CheckBoxFieldEx>
            
            <JWC:BoundFieldEx DataField="SchoolName" HeaderText="����ѧУ" SortExpression="SchoolName"  meta:resourcekey="SFIT_DGV_SchoolName">
                <HeaderStyle Width="15%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="GradeName" HeaderText="�����꼶" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
                <HeaderStyle Width="8%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
                        
            <JWC:BoundFieldEx DataField="ClassName" HeaderText="�����༶" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_ClassName">
                <HeaderStyle Width="10%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="WorkName" HeaderText="��Ʒ����" SortExpression="WorkName" meta:resourcekey="SFIT_DGV_WorkName">
                <HeaderStyle Width="15%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="StatusName" HeaderText="����״̬" SortExpression="StatusName" meta:resourcekey="SFIT_DGV_StatusName">
                <HeaderStyle Width="8%" />
                <ItemStyle HorizontalAlign="Center" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="StudentName" HeaderText="����ѧ��" SortExpression="StudentName" meta:resourcekey="SFIT_DGV_StudentName">
                <HeaderStyle Width="8%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="ClientIP" HeaderText="IP��ַ" SortExpression="ClientIP" meta:resourcekey="SFIT_DGV_ClientIP">
                <HeaderStyle Width="10%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="CreateDateTime" HeaderText="����ʱ��" SortExpression="CreateDateTime" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="SFIT_DGV_CreateDateTime">
                <HeaderStyle Width="10%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="400px" WinHeight="300px"
			    DataNavigateUrlFormatString="frmSFITWorksCommentsEdit.aspx?CommentID={0}" DataNavigateUrlField="CommentID"
			    HeaderText="����" DataField="Comment" SortExpression="Comment" ShowToolTip="true" ToolTipField="Comment" CharCount="20"  meta:resourcekey="SFIT_DGV_Comment">
			    <HeaderStyle Width="16%" />
			    <ItemStyle HorizontalAlign="Left" />
		    </JWC:MultiQueryStringFieldEx>
          
        </Columns>
    </JWC:DataGridView>
</asp:Content>
