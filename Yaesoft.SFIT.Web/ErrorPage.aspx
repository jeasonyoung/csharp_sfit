<%--
//================================================================================
//  FileName: ErrorPage.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/8
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleIndexMaster.master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Yaesoft.SFIT.Web.ErrorPage" Theme="Index" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="ContentWorkArea" runat="server">
    <div id="MainArea" style="height:600px; background-color:#fff; overflow:auto;">
       <div style="margin:0 auto; width:560px; height:400px; margin-top:80px; overflow:auto; border-bottom:solid 1px #eee; border-left:solid 1px #eee; border-right:solid 1px #eee; ">
            <div style="float:left;width:100%; height:23px; background-color:#eee;">
                <span style="color:Red; font-family:微软雅黑; font-size:12pt; font-weight:bold;margin-top:2px;">系统发生异常</span>
            </div>
            <div style="float:left; width:99%; height:342px; border:solid 0px red; overflow:auto;">
                <span style="float:left; font-family:微软雅黑; font-size:12pt; padding-top:10px; padding-left:10px; color:#555;">
                    <asp:Literal ID="errMessage" runat="server" />
                </span>
            </div>
            <div style="float:left; width:99%; height:27px; padding-top:2px; font-family:微软雅黑; border:solid 0px red;">
                <JWC:ButtonEx ID="btnCallback" runat="server" Text="返 回" BeforeClickScript="window.history.back();return false;" />
            </div>
       </div>
    </div>
</asp:Content>
