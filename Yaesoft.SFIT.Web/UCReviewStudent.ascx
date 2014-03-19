<%--
//================================================================================
//  FileName: UCReviewStudent.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/29
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCReviewStudent.ascx.cs" Inherits="Yaesoft.SFIT.Web.UCReviewStudent" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<fieldset style="margin-top:2px;">
    <legend>作品评阅</legend>
    <div style="float:left; width:100%;">
        <JWC:LabelEx ID="lbReviewValue" runat="server">客观评分：</JWC:LabelEx>         
        <JWC:TextBoxEx ID="txtReviewValue" runat="server" Width="168px" ValidationExpression="([\d|,]+)(\.(\d+))?" RegularErrorMessage="客观评分应为数字！" IsRequired="true" RequiredErrorMessage="客观评分不为空！"/>
        <JWC:DropDownListEx ID="ddlReviewValue" runat="server" Width="168px" ShowUnDefine="true" Visible="false" IsRequired="false" ErrorMessage="请选择客观评分！" />
    </div>
    <div style="float:left; width:100%;">
        <JWC:LabelEx ID="lbSubjectiveReviews" runat="server">主观评价：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtSubjectiveReviews" runat="server" Width="470px" TextMode="MultiLine" Rows="3" />
    </div>
    <div style="float:left; width:100%;">
        <JWC:LabelEx ID="lbTeacharName" runat="server">评价教师：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtTeacharName" runat="server" Width="168px"/>
    </div>
    <div style="float:left; width:100%;">
        <div style="float:left;">
           <JWC:LabelEx ID="lbCreateEmployeeName" runat="server">最后修改：</JWC:LabelEx>
           <JWC:TextBoxEx ID="txtCreateEmployeeName" runat="server" Width="168px" Enabled="false"/>
        </div>
        <div style="float:left;">
           <JWC:LabelEx ID="lbCreateDateTime" runat="server">最后时间：</JWC:LabelEx>
           <JWC:TextBoxEx ID="txtCreateDateTime" runat="server" Width="128px" Enabled="false"/>
        </div>
    </div>
</fieldset>