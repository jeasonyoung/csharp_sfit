<%--
//================================================================================
//  FileName: IndexClasses.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-16
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
<%@ Page Title="班级主页" Language="C#" MasterPageFile="Share/ModuleIndexMaster.master" AutoEventWireup="true" CodeBehind="IndexClasses.aspx.cs" Inherits="Yaesoft.SFIT.Web.IndexClasses" Theme="Index" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="ContentWorkArea" runat="server">
<script src="../lib/indexClasses.js" type="text/javascript"></script>
<div class="container">
    <!--crumb-->
	<div id="index_typeView" class="crumb">
	    <input type="hidden" name="UID" value="<%=this.SchoolID %>" />
	    <input type="hidden" name="GID" value="<%=this.GradeID %>" />
	    <input type="hidden" name="CID" value="<%=this.ClassID %>" />
	    <input type="hidden" name="SID" value="<%=this.CatalogID %>" />
    	<dl class="clearfix">
        	<dd><a id="index_typeView_catalog" href="javascript:void(0)" class="currrent">按册次</a></dd>
        	<dd><a id="index_typeView_time" href="javascript:void(0)">按时间</a></dd>
        	<dt><a href="/">首页</a></dt>
        </dl>
    </div>
    <!--end crumb-->
    <div class="main clearfix">
        <!--left menu start-->
    	<div id="index_leftMenu" class="sidebar">
            <h5 class="trans"><%=this.SchoolName %></h5>
        	<dl class="sidebar_list">
                
            </dl>
            <div class="sidebar_page">
            	<dl class="clearfix">
                	<dd class="previewpage"></dd>
                	<dt>1/3</dt>
                	<dd class="nextpage"><a href="#"></a></dd>
                </dl>
            </div>
        </div>
        <!--left menu end-->
        <!--work view start-->
       <div id="index_workContant" class="contant">
            <div class="part_title"><%=this.ClassName %>学生作品集</div>
            <dl class="tab_title clearfix">
            	<dd class="current" id="allWorkTitle">最新作品</dd>
            	<dd id="hotWorkTitle">点击率最高作品</dd>
            	<dd id="bestWorkTitle">最优作品</dd>
                <dt><a href="IndexSearch.aspx?CID=<%=this.ClassID %>" target="_blank">更多>></a></dt>
            </dl>
            <!--最新作品-->
            <div id="allWork" class="new_works">
                <ul class="clearfix"></ul>
                <div class="page"></div>
            </div>
            <!--点击率最高作品-->
            <div id="hotWork" class="hot_works">
                <ul class="clearfix"></ul>
                <div class="page"></div>
            </div>
            <!--最优作品-->
            <div id="bestWork" class="hot_works">
                <ul class="clearfix"></ul>
                <div class="page"></div>
            </div>
        </div>
        <!--work view end-->
    </div>
</div>
</asp:Content>