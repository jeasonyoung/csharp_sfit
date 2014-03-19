<%--
//================================================================================
//  FileName: frmSFITStudentWorktsEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/20
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITStudentWorksEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentWorksEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register TagPrefix="JWC" TagName="UCStudentWork" Src="UCStudentWork.ascx" %>
<%@ Register TagPrefix="JWC" TagName="UCStudentAttachment" Src="UCStudentAttachment.ascx" %>
<%@ Register TagPrefix="JWC" TagName="UCReviewStudent" Src="UCReviewStudent.ascx" %>
<%@ Register TagPrefix="JWC" TagName="UCWorksComments" Src="UCWorksComments.ascx" %>
<%--<%@ Register TagPrefix="JWC" TagName="UCWorkThumbnailsList" Src="UCWorkThumbnailsList.ascx" %>--%>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx id="vsfrmSFITStudentWorktsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/> 
    <JWC:TabMultiView ID="tabMutiView" runat="server" Width="100%" Height="456px" DefaultActiveTabIndex="0" EnableServerActive="true">
        <JWC:TabView ID="tabInfoView" Text="作品信息" runat="server" CssClass="TableSearch" TabIndex="0">
             <!--数据录入区域-->
            <div style="float:left; width:98%;">
                <JWC:UCStudentWork ID="ucStudentWork" runat="server" />
            </div>

            <div style="float:left;width:98%;">
                <JWC:UCStudentAttachment id="ucStudentAttachment" runat="server" />
            </div>

            <div style="float:left;width:98%;">
                <JWC:UCReviewStudent ID="ucReviewStudent" runat="server" />
            </div>
             
        </JWC:TabView>
        
        <JWC:TabView ID="tabThumbnails" Text="作品缩略图" runat="server" TabIndex="1">
            <div style="float:left; width:98%; height:450px; overflow:auto;">
                <%--<JWC:UCWorkThumbnailsList ID="ucWorkThumbnailsList" runat="server" />--%>
            </div>
        </JWC:TabView>
        
        <JWC:TabView ID="tabCommentView" Text="作品评论" runat="server" TabIndex="2">
            <div style="float:left;width:98%; height:456px; overflow:auto;">
                <JWC:UCWorksComments ID="ucWorksComments" runat="server" />
            </div>
        </JWC:TabView>
    </JWC:TabMultiView>
   
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
