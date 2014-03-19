<%@ Page Title="作业搜索" Language="C#" MasterPageFile="Share/ModuleIndexMaster.master" AutoEventWireup="true" CodeBehind="IndexSearch.aspx.cs" Inherits="Yaesoft.SFIT.Web.IndexSearch" Theme="Index" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="ContentWorkArea" runat="server">
<script src="../lib/indexSearch.js" type="text/javascript"></script>
<div class="container">
    <!--crumb-->
	<div class="crumb">
    	<dl class="clearfix">
        	<dt><a href="/">首页</a> >> 学生作品检索</dt>
        </dl>
    </div>
    <!--end crumb-->
    
    <!--传递值-->
    <div id="indexSearch_queryVal" style="display:none;">
        <input type="hidden" name="uname" value="<%=this.SchoolName %>" />
        <input type="hidden" name="cname" value="<%=this.ClassName %>" />
        <input type="hidden" name="sname" value="<%=this.CatalogName %>" />
        <input type="hidden" name="st" value="<%=this.WorkTime %>" />
    </div>
        
    <div class="main clearfix">
        <div class="search_list">
            <h3>学生作品检索</h3>
            <!--查询条件-->
            <dl class="searchbar clearfix">
                <dd>
                	<span>学校名称：</span>
                    <input name="txtUnitName" type="text" class="easyui-validatebox" data-options="validType:'length[0,50]'" style="width:168px;" />
                </dd>
                <dd>
                	<span>班级名称：</span>
                    <input name="txtClassName" type="text" class="easyui-validatebox" data-options="validType:'length[0,32]'" style="width:128px;" />
                </dd>
            	<dd>
                	<span>课程名称：</span>
                    <input name="txtCatalogName" type="text" class="easyui-validatebox" data-options="validType:'length[0,256]'" style="width:198px;" />
                </dd>
                <dd>
                	<span>学生姓名：</span>
					<input name="txtStudentName" type="text" class="easyui-validatebox" data-options="validType:'length[0,32]'" />
                </dd>
                
            	<dd style="margin-top:8px;">
                	<span>作品名称：</span>
					<input name="txtWorkName" type="text" class="easyui-validatebox" data-options="validType:'length[0,256]'" style="width:198px;" />
                </dd>
            	
            	<dd style="margin-top:8px;">
                	<span>作业上传时间段：</span>
					<input id="txtStartDate" type="text" class="easyui-datebox easyui-validatebox" validType="regex[/^\d{4}-\d{2}-\d{2}$/,'日期格式不符合（yyyy-MM-dd）规则']" style="width:128px;" />
					<span>-</span>
					<input id="txtEndDate" type="text" class="easyui-datebox easyui-validatebox" validType="regex[/^\d{4}-\d{2}-\d{2}$/,'日期格式不符合（yyyy-MM-dd）规则']" style="width:128px;" />
                </dd>
                
                <dd style="margin-top:8px;">
                    <input id="indexSearch_Submit" type="button" value="检索" />
                </dd>
            </dl>
            
            <!--查询结果-->
            <div id="indexSearch_resultList" class="hot_works">
                <ul class="clearfix"></ul>
                <!--分页-->
                <div class="page"></div>
            </div>
        </div>
    </div>
</div>
</asp:Content>