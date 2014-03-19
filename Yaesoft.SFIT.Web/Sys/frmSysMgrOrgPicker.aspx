<%--
//================================================================================
//  FileName: frmSysMgrOrgPicker.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/6/1
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSysMgrOrgPicker.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrOrgPicker" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWork" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx id="vsfrmSysMgrOrgPicker" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
 
	<div class="TableSearch">
         <fieldset style=" float:left; width:92%;">
            <legend>查询条件</legend>
            <div style="float:left; width:100%;">
                  <div style="float:left;">
                      <JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_EmployeeName">用户名称：</JWC:LabelEx>
                      <JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="128px" />
                  </div>
                  <div style="float:right;">
                       <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
                  </div>
            </div>
        </fieldset>
        <!--多选-->
         <asp:Panel ID="EmployeePanelMultiSelect" runat="server" Visible="false" ScrollBars="Auto" CssClass="TableSearch" Height="280px">
            <table cellpadding="1" cellspacing="1" border="0" style="width:100%; height:280px;">
                <tr>
                    <td valign="top" width="40%">
                        <asp:ListBox ID="lbEmployeeMulti" runat="server" Width="100%" Height="270px" SelectionMode="Multiple" />
                    </td>
                    <td width="20%">
                        <p align="center">
                            <JWC:ButtonEx ID="btnEmployeeSelectAll" runat="server" OnClick="btnEmployeeSelectAll_OnClick" CausesValidation="false" Text="&gt;&gt;" />
                        </p>
                        <p align="center">
                            <JWC:ButtonEx ID="btnEmployeeSelect" runat="server" OnClick="btnEmployeeSelect_OnClick" CausesValidation="false" Text="&gt;" />
                        </p>
                        <p align="center">
                            <JWC:ButtonEx ID="btnEmployeeRemove" runat="server" OnClick="btnEmployeeRemove_OnClick" CausesValidation="false" Text="&lt;" />
                        </p>
                        <p align="center">
                            <JWC:ButtonEx ID="btnEmployeeRemoveAll" runat="server" OnClick="btnEmployeeRemoveAll_OnClick" CausesValidation="false" Text="&lt;&lt;" />
                        </p>
                    </td>
                    <td valign="top" width="40%">
                        <asp:ListBox ID="lbEmployeeSelect" runat="server" Width="100%" Height="270px" SelectionMode="Multiple" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <!--单选-->
         <asp:Panel ID="EmployeePanelSelect" runat="server" Visible="false" ScrollBars="Auto" CssClass="TableSearch" Height="280px">
            <asp:ListBox ID="lbEmployeeSingleSelect" runat="server" Width="100%" Height="270px" SelectionMode="Single" />
        </asp:Panel>
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
