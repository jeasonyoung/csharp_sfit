<%--
//================================================================================
// FileName: frmSFITeaReviewStudentEdit.aspx
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

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master"
    CodeBehind="frmSFITeaReviewStudentEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITeaReviewStudentEdit" %>

<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx ID="vsfrmSFITeaReviewStudentEdit" runat="server" ShowMessageBox="true"
        ShowSummary="false" />
    <!--数据录入区域-->
    <div class="TableSearch">
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbWorkID" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkID">作 品 名：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStudentWorks" runat="server" Width="368px" IsRequired="true"
                RequiredErrorMessage="作品名不能为空！" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbEvaluateType" runat="server" Style="float: left;" meta:resourcekey="SFIT_EvaluateType">评价类型：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlEvaluateType" runat="server" Width="168px" ShowUnDefine="false"
                IsRequired="true" ErrorMessage="评价类型不能为空！" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbReviewValue" runat="server" Style="float: left;" meta:resourcekey="SFIT_ReviewValue">客观评价结果：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtReviewValue" runat="server" Width="143px" IsRequired="true"
                RequiredErrorMessage="客观评价结果不能为空！" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbSubjectiveReviews" runat="server" Style="float: left;" meta:resourcekey="SFIT_SubjectiveReviews">主观评语：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtSubjectiveReviews" runat="server" Width="368px" TextMode="MultiLine"
                Rows="3" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbSyncStatus" runat="server" Style="float: left;" meta:resourcekey="SFIT_SyncStatus">同步状态：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlSyncStatus" runat="server" Width="168px" ShowUnDefine="false" />
        </div>
        <div style="float: left; width: 100%;">
            <JWC:LabelEx ID="lbLastSyncTime" runat="server" Style="float: left;" meta:resourcekey="SFIT_LastSyncTime">同步时间：</JWC:LabelEx>
            <JWC:TextBoxCalendar ID="DateLastSyncTime" runat="server" Width="172px" />
        </div>
    </div>
    <!--数据显示区域-->
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
                    HeaderText="作品附件" DataField="AccessoriesName" SortExpression="AccessoriesName"
                    meta:resourcekey="SFIT_AccessoriesName">
                    <HeaderStyle Width="40%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:MultiQueryStringFieldEx>
                <JWC:BoundFieldEx DataField="ContentType" HeaderText="内容类型" SortExpression="ContentType"
                    meta:resourcekey="SFIT_ContentType">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:BoundFieldEx>
                <JWC:BoundFieldEx DataField="AccessoriesSize" HeaderText="附件大小" SortExpression="AccessoriesSize"
                    meta:resourcekey="SFIT_AccessoriesSize">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:BoundFieldEx>
                <JWC:BoundFieldEx DataField="Suffix" HeaderText="附件后缀" SortExpression="Suffix" meta:resourcekey="SFIT_Suffix">
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Left" />
                </JWC:BoundFieldEx>
            </Columns>
        </JWC:DataGridView>
    </div>
    <!--数据控制区域-->
    <div class="TableControl">
        <div style="margin: 0 auto; text-align: center; width: 100%;">
            <JWC:ServerAlert ID="errMessage" runat="server" />
            <JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" OnClick="btnSave_Click"
                CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true" />
            <JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" BeforeClickScript='window.returnValue="";window.close();return false;' />
        </div>
    </div>
</asp:Content>
