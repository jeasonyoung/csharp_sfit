<%--
//================================================================================
//  FileName: IndexRpt.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-22
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
<%@ Page Title="统计报表" Language="C#" MasterPageFile="Share/ModuleIndexMaster.master" AutoEventWireup="true" CodeBehind="IndexRpt.aspx.cs" Inherits="Yaesoft.SFIT.Web.IndexRpt" Theme="Index" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="ContentWorkArea" runat="server">
<script src="../lib/indexRpt.js" type="text/javascript"></script>
<div class="container">
    <!--crumb-->
	<div class="crumb">
	    <dl class="clearfix">
	        <dt><a href="/">首页</a></dt>
	    </dl>
	</div>
	<!--end crumb-->
	<div class="main clearfix">
	    <div>
	        <input type="hidden" id="IndexRpt_type" value="<%=this.RptType %>" />
            <input type="hidden" id="IndexRpt_UID" value="<%=this.UnitID %>" />
            <input type="hidden" id="IndexRpt_UnitName" value="<%=this.UnitName %>" />
            <input type="hidden" id="IndexRpt_CID" value="<%=this.ClassID %>" />
            <input type="hidden" id="IndexRpt_ClassName" value="<%=this.ClassName %>" />
            <input type="hidden" id="IndexRpt_SID" value="<%=this.CatalogID %>" />
            <input type="hidden" id="IndexRpt_StudentID" value="<%=this.StudentID %>" />
            <input type="hidden" id="IndexRpt_StudentName" value="<%=this.StudentName %>" />
            <input type="hidden" id="IndexRpt_CatalogName" value="<%=this.CatalogName %>" />
            <input type="hidden" id="IndexRpt_Time" value="<%=this.Time %>" />
	    </div>
	
	    
	    <div class="contant" style="float:none; margin:0px auto 0px auto;">
	        <div class="part_title">报表统计</div>	         
	         <table id="IndexRpt_Rpt"></table>
            <div id="IndexRpt_Rpt_Query" style="display:none;">  
	            <span style="margin-left:10px;">作品上传时间段：</span>
	            <input id="IndexRpt_txtStartDate" type="text" class="easyui-datebox easyui-validatebox" validType="regex[/^\d{4}-\d{2}-\d{2}$/,'日期格式不符合（yyyy-MM-dd）规则']" style="width:128px;" />
	            <span>-</span>
	            <input id="IndexRpt_txtEndDate" type="text" class="easyui-datebox easyui-validatebox" validType="regex[/^\d{4}-\d{2}-\d{2}$/,'日期格式不符合（yyyy-MM-dd）规则']" style="width:128px;" />
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true" onclick="SearchLoadData()">检索</a>
            </div>
	    </div>
	     
	</div>
</div>
</asp:Content>