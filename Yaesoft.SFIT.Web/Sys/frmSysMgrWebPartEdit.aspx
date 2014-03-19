<%--
//================================================================================
// FileName: frmSysMgrWebPartEdit.aspx
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrWebPartEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrWebPartEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<JWC:TabMultiView ID="tabMultiView" runat="server" EnableServerActive="True" DefaultActiveTabIndex="0" Width="99%" Height="340px">
	    <JWC:TabView ID="tabViewInfo" runat="server" Text="基本信息" Index="0" CssClass="TableSearch" meta:resourcekey="Sys_WebPartBaseName">
	        <div style="float:left; width:100%; margin-top:5px;">
			    <JWC:LabelEx ID="lbWebPartName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartName">部&nbsp;件&nbsp;名&nbsp;&nbsp;称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtWebPartName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="部件名称不能为空！"  />
		    </div>
    	    
		    <div style="float:left;width:100%;">
			    <JWC:LabelEx ID="lbWebPartTemplate" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartTemplate">所&nbsp;属&nbsp;模&nbsp;&nbsp;板：</JWC:LabelEx>
			    <JWC:PickerBase ID="pbWebPartTemplate" runat="server" Width="432px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrRegWebPartTemplatePicker.aspx" 
			       OnTextChanged="pbWebPartTemplate_OnTextChanged" AutoPostBack="true"  IsRequired="true" ErrorMessage="部件名称不能为空！"/>
		    </div>
    		
		    <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbDataAssemblyName" runat="server" Style="float:left;" meta:resourcekey="Sys_DataAssemblyName">数据程序集：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtDataAssemblyName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="数据程序集不能为空！"  />
		    </div>
    		
		    <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbDataClassName" runat="server" Style="float:left;" meta:resourcekey="Sys_DataClassName">接口类名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtDataClassName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="接口类名称不能为空！" />
		    </div>
    		
		    <div style="float:right; width:100%;">
			    <JWC:LabelEx ID="lbWebPartStatus" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartStatus">状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlWebPartStatus" runat="server" Width="80px" ShowUnDefine="false"  />
		    </div>
    		
		    <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_Description">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="5"  />
		    </div>
	    </JWC:TabView>
	    <JWC:TabView ID="tabViewProperty" runat="server" Text="部件属性" Index="1" CssClass="TableSearch" meta:resourcekey="Sys_WebPartProperty">
	        <fieldset style="float:left; width:96%; margin-top:5px;">
	            <legend>
	                 <JWC:LabelEx ID="lbWebPartPropertyList" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartPropertyList">属性列表</JWC:LabelEx>
	            </legend>
	            <div style="float:left; width:100%;height:310px;overflow:auto;">
	                <JWC:DataGridView ID="dgfrmSysMgrWebPartEdit" runat="server" CssClass="DataGrid" Width="95%" ShowFooter="false"
                        AllowSorting="true" MouseoverCssClass="DataGridHighLight" onbuilddatasource="dgfrmSysMgrWebPartEdit_BuildDataSource">
                        <PagerSettings Mode="NextPreviousFirstLast" />
                        <AlternatingRowStyle CssClass="DataGridAlter" />
                        <HeaderStyle CssClass="DataGridHeader" />
                        <RowStyle CssClass="DataGridItem" />
                        <Columns>
	                        <JWC:BoundFieldEx DataField="PropertyName" HeaderText="属性名称" SortExpression="PropertyName"  
	                            ToolTipField="PropertyDescription" ShowToolTip="true" meta:resourcekey="Sys_PropertyName">
		                        <HeaderStyle Width="40%" />
		                        <ItemStyle HorizontalAlign="Left" />
	                        </JWC:BoundFieldEx>
                			
	                        <JWC:TemplateFieldEx>
	                            <HeaderStyle Width="60%" />
		                        <ItemStyle HorizontalAlign="Left" />
	                            <HeaderTemplate>
	                                <JWC:LabelEx ID="lbPropertyValue" runat="server" meta:resourcekey="Sys_PropertyValue">属性值</JWC:LabelEx>
	                            </HeaderTemplate>
	                            <ItemTemplate>
	                                <JWC:TextBoxEx ID="txtPropertyValue" runat="server" Width="168px" Text='<%# Eval("PropertyValue") %>' AutoPostBack="true" OnTextChanged="txtPropertyValue_OnTextChanged"/>
	                            </ItemTemplate>
	                        </JWC:TemplateFieldEx>
                        </Columns>
                    </JWC:DataGridView>
                </div>
	        </fieldset>
	    </JWC:TabView>
	</JWC:TabMultiView>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</div>
</asp:Content>
