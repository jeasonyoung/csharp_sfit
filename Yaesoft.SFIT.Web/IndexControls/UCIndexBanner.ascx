<%--
//================================================================================
//  FileName: UCIndexBanner.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/18
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIndexBanner.ascx.cs" Inherits="Yaesoft.SFIT.Web.IndexControls.UCIndexBanner" %>
<div class="header">
    <div class="header_con">
		<div class="top clearfix trans">
            <h5><asp:Label ID="lbUsername" runat="server" ForeColor="#cacaca" Font-Bold="true" Font-Names="'雅黑'" /> 您好，芙蓉区教育局欢迎您！</h5>
            <dl id="LoginPanel" runat="server" class="clearfix">                 
                <dd>
                    <span>学生/教师账号：</span>
                    <input type="text" name="name" class="easyui-validatebox" data-options="required:true,missingMessage:'账号不能为空！'" value="请输入城域网账号" onfocus="if (value =='请输入城域网账号'){value =''}" onblur="if (value ==''){value='请输入城域网账号'}"/>
                </dd>
                <dd>
                    <span>密码：</span>
                    <input type="password" name="password" class="easyui-validatebox" data-options="required:true,missingMessage:'密码不能为空！'"/>
                </dd>
                <dt>
                    <input type="button" value="登陆" />
                </dt>
                <script language="javascript" type="text/javascript">
                    $(function() {
                        //$("#ctl00_ucIndexBanner_LoginPanel input[name=name]").focus();
                        $("#ctl00_ucIndexBanner_LoginPanel").on("keyup", function(event) {
                            if (event.keyCode == 13) {
                                console.info(event);
                            }
                        });
                        $("#ctl00_ucIndexBanner_LoginPanel input[type=button]").on("click", function() {
                            var bname = $("#ctl00_ucIndexBanner_LoginPanel input[name=name]").validatebox("isValid");
                            var bpwd = $("#ctl00_ucIndexBanner_LoginPanel input[name=password]").validatebox("isValid");
                            if (bname && bpwd) {
                                $.messager.progress();
                                $.ajax({
                                    type: "POST",
                                    url: "LoginHandler.ashx",
                                    data:{
                                        username:$("#ctl00_ucIndexBanner_LoginPanel input[name=name]").val(),
                                        password:$("#ctl00_ucIndexBanner_LoginPanel input[name=password]").val()
                                    },
                                    dataType: "json",
                                    success: function(data) {
                                        $.messager.show({
                                            title: "登录提示",
                                            msg: data.err
                                        });
                                        $.messager.progress("close");
                                        //$(".datagrid-mask,.datagrid-mask-msg").remove();
                                        if (data.result == 0) {
                                            <%=this.Page.ClientScript.GetPostBackEventReference(this, this.ClientID)%>;
                                        }
                                    }
                                });

                            }
                        });
                    });
                </script>
            </dl>
            <dl id="MCenterPanel" runat="server" class="clearfix">
                <dd><span><a href="/DesktopCenter.aspx" target="_self" style="cursor:pointer;">[进入管理中心]</a></span></dd>
            </dl>
        </div>
		<div class="banner clearfix">
            <p class="logo"><img src="../Include/logo.png" alt="logo" class="trans" /></p>
            <p class="logo_right"><img src="../Include/header02.png" alt="header" class="trans" /></p>
        </div>
    </div>
</div>