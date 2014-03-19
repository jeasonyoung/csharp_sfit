<%--
//================================================================================
//  FileName: UCWriteComments.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/21
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWriteComments.ascx.cs" Inherits="Yaesoft.SFIT.Web.UCWriteComments" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<fieldset style="float:left; width:100%;">
    <legend>用户评论</legend>
    <div style="float:left; width:100%;">
        <span>用户名：</span>
        <JWC:TextBoxEx ID="txtUsername" runat="server" Width="128px" />
    </div>
    <div style="float:left; width:100%;">
        <JWC:TextBoxEx ID="txtComments" runat="server" Width="96%" TextMode="MultiLine" Rows="3" IsRequired="true"  RequiredErrorMessage="评论内容不能为空！" />
    </div>
    <div style="float:left; width:100%;">
        <div style="float:right; margin-right:10px;">
            <JWC:ServerAlert ID="errMsg" runat="server" />
            <JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存？" ShowConfirmMsg="true"/>
        </div>
    </div>
</fieldset>
