<%--
//================================================================================
// FileName: frmSFITeaReviewStudentEdit.aspx
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

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master"
    CodeBehind="frmSFITeaReviewStudentEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITeaReviewStudentEdit" %>

<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx ID="vsfrmSFITeaReviewStudentEdit" runat="server" ShowMessageBox="true"
        ShowSummary="false" />
    <!--����¼������-->
    <div class="TableSearch">
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbWorkID" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkID">�� Ʒ ����</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStudentWorks" runat="server" Width="368px" IsRequired="true"
                RequiredErrorMessage="��Ʒ������Ϊ�գ�" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbEvaluateType" runat="server" Style="float: left;" meta:resourcekey="SFIT_EvaluateType">�������ͣ�</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlEvaluateType" runat="server" Width="168px" ShowUnDefine="false"
                IsRequired="true" ErrorMessage="�������Ͳ���Ϊ�գ�" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbReviewValue" runat="server" Style="float: left;" meta:resourcekey="SFIT_ReviewValue">�͹����۽����</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtReviewValue" runat="server" Width="143px" IsRequired="true"
                RequiredErrorMessage="�͹����۽������Ϊ�գ�" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbSubjectiveReviews" runat="server" Style="float: left;" meta:resourcekey="SFIT_SubjectiveReviews">�������</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtSubjectiveReviews" runat="server" Width="368px" TextMode="MultiLine"
                Rows="3" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbSyncStatus" runat="server" Style="float: left;" meta:resourcekey="SFIT_SyncStatus">ͬ��״̬��</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlSyncStatus" runat="server" Width="168px" ShowUnDefine="false" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbLastSyncTime" runat="server" Style="float: left;" meta:resourcekey="SFIT_LastSyncTime">ͬ��ʱ�䣺</JWC:LabelEx>
            <JWC:TextBoxCalendar ID="DateLastSyncTime" runat="server" Width="172px" />
        </div>
    </div>
    <!--������ʾ����-->
    <div class="TableControl" style="height: 450px; overflow: auto;">
        <JWC:DataGridView ID="dgfrmSFITeaReviewStudentEdit" runat="server" CssClass="DataGrid"
            Width="98%" ShowFooter="true" AllowSorting="true" AllowPaging="false" AllowExport="false"
            MouseoverCssClass="DataGridHighLight" PageSize="15" OnBuildDataSource="dgfrmSFITeaReviewStudentEdit_BuildDataSource">
            <PagerSettings Mode="NextPreviousFirstLast" />
            <AlternatingRowStyle CssClass="DataGridAlter" />
            <HeaderStyle CssClass="DataGridHeader" />
            <FooterStyle CssClass="DataGridFooter" />
            <RowStyle CssClass="DataGridItem" />
            <Columns>
                <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
                    DataNavigateUrlFormatString="AccessoriesDownload.ashx?FileID={0}" DataNavigateUrlField="AccessoriesID"
                    HeaderText="��Ʒ����" DataField="AccessoriesName" SortExpression="AccessoriesName"
                    meta:resourcekey="SFIT_AccessoriesName">
                    <HeaderStyle Width="40%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:MultiQueryStringFieldEx>
                <JWC:BoundFieldEx DataField="ContentType" HeaderText="��������" SortExpression="ContentType"
                    meta:resourcekey="SFIT_ContentType">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:BoundFieldEx>
                <JWC:BoundFieldEx DataField="AccessoriesSize" HeaderText="������С" SortExpression="AccessoriesSize"
                    meta:resourcekey="SFIT_AccessoriesSize">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:BoundFieldEx>
                <JWC:BoundFieldEx DataField="Suffix" HeaderText="������׺" SortExpression="Suffix" meta:resourcekey="SFIT_Suffix">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:BoundFieldEx>
            </Columns>
        </JWC:DataGridView>
    </div>
    <!--���ݿ�������-->
    <div class="TableControl">
        <div style="margin: 0 auto; text-align: center; width: 100%;">
            <JWC:ServerAlert ID="errMessage" runat="server" />
            <JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" OnClick="btnSave_Click"
                CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true" />
            <JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" BeforeClickScript='window.returnValue="";window.close();return false;' />
        </div>
    </div>
</asp:Content>
