<%--
//================================================================================
//  FileName: frmSFITCatalogByUnitEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/28
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITCatalogByUnitEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITCatalogByUnitEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx id="vsfrmSFITCatalogByUnitEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <div class="TableSearch">
	    <fieldset style="float:left;width:98%;">
	        <legend>目录信息</legend>
	        <div style="float:left;width:100%;">
	            <div style="float:left;">
	                <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
	                <JWC:DropDownListEx ID="ddlSchool" runat="server" Width="200px" IsRequired="true" ErrorMessage="所属学校不能为空！" ShowUnDefine="true" UnDefineTitle="[全区必修]" />
                </div>    	    
                
                <div style="float:left; margin-left:2px;">
                    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;级：</JWC:LabelEx>
                    <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="年级不能为空！" AutoPostBack="true" 
                         OnSelectedIndexChanged="ddlGrade_OnSelectedIndexChanged" />
                </div>
                
                <div style="float:left;margin-left:10px;">
	                <JWC:LabelEx ID="lbCatalogType" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogType">目录类型：</JWC:LabelEx>
	                <JWC:DropDownListEx ID="ddlCatalogType" runat="server" Width="128px" IsRequired="true" ErrorMessage="目录类型不能为空！" />
                </div>
            </div>
            <div style="float:left;width:100%;">
                <div style="float:left;">
	                <JWC:LabelEx ID="lbCatalogCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogCode">目录代码：</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtCatalogCode" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="目录代码不能为空！"/>
                </div>
                <div style="float:left;margin-left:2px;">
	                <JWC:LabelEx ID="lbCatalogName" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogName">目录名称：</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessag="目录名称不能为空！" />
                </div>
                <div style="float:left;margin-left:8px;">
	                <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="128px" Text="1" CssClass="NumberTextBoxFlat" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="排序号不能为空！" />
                </div>
            </div>
        </fieldset>
    	
    	<fieldset style="float:left;width:98%;">
    	    <legend>知识技能要点</legend>
    	    <div style="float:left; width:100%; height:430px; overflow:auto;">
    	        <JWC:TreeView ID="tvKnowledgePoints" runat="server" ExpandAllLevel="true" CheckType="CheckBox" ShowScrollBar="true" />
    	    </div>
    	</fieldset>
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
