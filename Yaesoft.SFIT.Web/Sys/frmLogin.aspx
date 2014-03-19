<%--
//================================================================================
//  FileName: frmLogin.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/6/16
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmLogin" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx id="vsfrmLogin" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <table border="0" cellpadding="0" cellspacing="0" style="height:99%; width:100%; text-align:center;">
        <tr>
            <td class="LoginOuterTop">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="height:100%; width:100%; text-align:center;">
                    <tr>
                        <td class="LoginMainLeft">&nbsp;</td>
                        <td class="LoginMainWidth" nowrap="nowrap">
                            <table cellpadding="0" cellspacing="0" class="LoginMain">
                                <tr>
                                    <td>
                                        <div style="width:200px; height:80px; margin-left:90px; margin-top:86px; border:solid 0px red;">
                                            <div style="float:left; width:100%; text-align:left;">
                                                 <JWC:TextBoxEx ID="txtLoginSign" runat="server" Width="168px"　IsRequired="true"  RequiredErrorMessage="用户账号不能为空！"/>
                                            </div>
                                            <div style="float:left; width:100%;text-align:left;">
                                                <JWC:TextBoxEx ID="txtLoginPassword" runat="server" TextMode="Password" Width="168px"　IsRequired="true"  RequiredErrorMessage="用户密码不能为空！"/>
                                            </div>
                                            <div style="float:left; width:100%; margin-left:24px; margin-top:5px; text-align:center;">
                                                <JWC:ServerAlert ID="errMsg" runat="server" />
                                                <JWC:ButtonEx ID="btnLogin" runat="server" CausesValidation="true" ButtonType="Login" OnClick="btnLogin_OnClick" />
                                            </div>
                                        </div>
                                        <div style="width:390px; height:26px; text-align:center; margin-top:28px; margin-left:16px; border:solid 0px red;">
                                            <span style="font-size:9pt;"><%=this.CopyRight %></span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="LoginMainRight">&nbsp;</td> 
                    </tr>
               </table>
           </td>
        </tr>
        <tr>
            <td class="LoginOuterBottom">&nbsp;</td>
        </tr>
    </table>
</asp:Content>