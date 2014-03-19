<%--
//================================================================================
//  FileName: IndexDetails.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-21
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
<%@ Page Title="作品明细" Language="C#" MasterPageFile="Share/ModuleIndexMaster.master" AutoEventWireup="true" CodeBehind="IndexDetails.aspx.cs" Inherits="Yaesoft.SFIT.Web.IndexDetails" Theme="Index"%>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="ContentWorkArea" runat="server">
<script src="../lib/indexDetails.js" type="text/javascript"></script>
<div class="container">
    <!--crumb-->
	<div class="crumb">
    	<dl class="clearfix">
        	<dt><a href="#">首页</a> >> <a href="#">学生作品档案</a></dt>
        </dl>
    </div>
    <!--end crumb-->
    <div class="main clearfix">
    	<div class="search_list">
    	    <input type="hidden" id="IndexDetails_WorkID" value="<%=this.WorkID %>" />
    	    <input type="hidden" id="IndexDetails_UserName" value="<%=this.CurrentUserName %>" />
    	    <input type="hidden" id="IndexDetails_ClientIP" value="<%=this.Request.UserHostAddress %>" />
        	<h3 class="file_title">学生作品档案</h3>	
            <div class="archives clearfix">
            	<div class="archives_pic">
                	<p><img src="../Include/ar01.jpg" alt="图" /></p>
                    <h6><%=this.WorkName %></h6>
                </div>
            	<div class="archives_con">
                	<dl class="file_info">
                    	<dd>
                    	    <span class="left">所属学校：<%=this.SchoolName %></span>
                    	    <span class="right">所属班级：<%=this.ClassName %></span>
                    	</dd>
                    	<dd>
                    	    <span class="left">所属课程：<%=this.CatalogName %></span>
                    	</dd>
                    	<dd>
                    	    <span class="left">所属学生：<%=this.StudentName %></span>
                    	    <span class="right">作品状态：<%=this.WorkStatus %></span>
                    	</dd>
                    	<dd>
                    	    <span class="left">作品描述：<%=this.WorkDescription %></span>
                    	</dd>
                    	<dd>
                    	    <span class="left">客观评分：<%=this.WorkValue %></span>
                    	    <span class="right">任课老师：<%=this.WorkTeaName %></span>
                    	</dd>
                    	<dd>
                    	    <span class="left">主观评价：<%=this.WorkSubRev %></span>
                    	</dd>
                    	<dd>
                    	    <span class="left">点击量：<%=this.Hits%></span>
                    	</dd>
                        <dt>
                            <a href="AccessoriesDownload.ashx?FileID=<%=this.WorkID %>"></a>
                            <span style="color:#ccc;">[md5：<%=this.CheckCode%>]</span>
                        </dt>
                    </dl>
                    
                    <div class="comment">
                         <dl>
                            <dt><b>发表评论</b></dt>
                            <dd><textarea class="easyui-validatebox" data-options="required:true" cols="80" rows="7"></textarea></dd>
                            <dd class="reback clearfix">
                                <span>文明上网，理性发言</span>
                                <input type="button" value="发表评论" />
                            </dd>
                        </dl>
                          <ul class="comment_list">
                            
                         </ul>
                     </div>
                    <div class="page"></div>
                </div>
            </div>
            
        </div>
    </div>
</div>
</asp:Content>