<%--
//================================================================================
// FileName: frmSysMgrEmployeeAuthorizationEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrEmployeeAuthorizationEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrEmployeeAuthorizationEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrEmployeeAuthorizationEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<div class="TableSearch">
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbEmployee" runat="server" Style="float:left;" meta:resourcekey="Sys_Employee">用户姓名：</JWC:LabelEx>
			<JWC:PickerBase ID="pbEmployee" runat="server" Width="268px" PickerHeight="450px" PickerWidth="340px" MultiSelect="false" PickerPage="frmSysMgrOrgPicker.aspx?IsLocal=false"
			   AutoPostBack="true" OnTextChanged="pbEmployee_OnTextChanged" IsRequired="true" ErrorMessage="用户姓名不能为空！"  />
		</div>
		<div style="float:left; margin-top:10px; width:100%;">
		    <table cellpadding="1" cellspacing="1" border="0" style="width:100%; height:320px;">
                <tr>
                    <td valign="top">
                        <fieldset>
                            <legend>
                                <JWC:LabelEx ID="lbAppAuthMulti" runat="server" Style="float:left;" meta:resourcekey="Sys_AppAuthMulti">未授权系统</JWC:LabelEx>
                            </legend>
                            <asp:ListBox ID="lbAllAppAuthMulti" runat="server" Width="100%" Height="320px" SelectionMode="Multiple" />
                        </fieldset>
                    </td>
                    <td width="15px">
                        <p align="center">
                            <JWC:ButtonEx ID="btnSelectAll" runat="server" OnClick="btnSelectAll_OnClick" CausesValidation="false" Text="&gt;&gt;" />
                        </p>
                        <p align="center">
                            <JWC:ButtonEx ID="btnSelect" runat="server" OnClick="btnSelect_OnClick" CausesValidation="false" Text="&gt;" />
                        </p>
                        <p align="center">
                            <JWC:ButtonEx ID="btnRemove" runat="server" OnClick="btnRemove_OnClick" CausesValidation="false" Text="&lt;" />
                        </p>
                        <p align="center">
                            <JWC:ButtonEx ID="btnRemoveAll" runat="server" OnClick="btnRemoveAll_OnClick" CausesValidation="false" Text="&lt;&lt;" />
                        </p>
                    </td>
                    <td valign="top">
                        <fieldset>
                            <legend>
                                <JWC:LabelEx ID="lbSelectAuthMulti" runat="server" Style="float:left;" meta:resourcekey="Sys_SelectAuthMulti">授权的系统</JWC:LabelEx>
                            </legend>
                            <asp:ListBox ID="lbSelectAppAuthMulti" runat="server" Width="100%" Height="320px" SelectionMode="Multiple" />
                        </fieldset>
                    </td>
                </tr>
            </table>
         </div>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMsg" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
