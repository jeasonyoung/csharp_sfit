<%--
//================================================================================
// FileName: frmSysMgrRegWebPartTemplateEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrRegWebPartTemplateEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrRegWebPartTemplateEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrRegWebPartTemplateEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--数据录入区域-->
	<JWC:TabMultiView ID="tabMultiView" runat="server" EnableServerActive="True" DefaultActiveTabIndex="0" Width="99%" Height="340px">
	    <JWC:TabView ID="tabViewInfo" runat="server" Text="模板信息" Index="0" CssClass="TableSearch" meta:resourcekey="Sys_tabViewInfo">
	        <div style="float:left; width:100%; margin-top:10px;">
		        <JWC:LabelEx ID="lbWebPartTemplateName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartTemplateName">模板名称：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtWebPartTemplateName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessage ="模板名称不能为空！" />
	        </div>
	        <div style="float:left; width:100%;">
		        <JWC:LabelEx ID="lbWebPartTemplatePath" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartTemplatePath">模板地址：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtWebPartTemplatePath" runat="server" Width="418px" TextMode="MultiLine" Rows="2" IsRequired="true" RequiredErrorMessage="模板地址不能为空！" />
	        </div>
	        <div style="float:left; width:100%;">
		        <JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_Description">描&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="3"  />
	        </div>
 	    </JWC:TabView>
	  
	    <JWC:TabView ID="tabViewProperty" runat="server" Text="模板属性" Index="1" CssClass="TableSearch" meta:resourcekey="Sys_tabViewProperty">
	        <fieldset style="float:left; width:96%;">
	            <legend>
	               <JWC:LabelEx ID="lbProperty" runat="server" Style="float:left;" meta:resourcekey="Sys_Property">设置属性</JWC:LabelEx>
	            </legend>
	            <div style="float:left; width:100%;">
	                <div style="float:left;">
			            <JWC:LabelEx ID="lbTemplatePropertyName" runat="server" Style="float:left;" meta:resourcekey="Sys_TemplatePropertyName">属性名：</JWC:LabelEx>
			            <JWC:TextBoxEx ID="txtTemplatePropertyName" runat="server" Width="168px"/>
		            </div>
		            <div style="float:left; margin-left:20px;">
			            <JWC:LabelEx ID="lbTemplateDefaultValue" runat="server" Style="float:left;" meta:resourcekey="Sys_TemplateDefaultValue">默认值：</JWC:LabelEx>
			            <JWC:TextBoxEx ID="txtTemplateDefaultValue" runat="server" Width="168px"/>
		            </div>
	            </div>
	            <div style="float:left; width:100%;">    
                    <div style="float:left;">
		                <JWC:LabelEx ID="lbTemplatePropertyDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_TemplatePropertyDescription">描&nbsp;&nbsp;&nbsp;&nbsp;述：</JWC:LabelEx>
		                <JWC:TextBoxEx ID="txtTemplatePropertyDescription" runat="server" TextMode="MultiLine" Rows="2" Width="298px"/>
	                </div>
                    <div style="float:right; margin-right:10px;">
	                    <span style="float:left;">
		                    <JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" onclick="btnAdd_Click"/>
	                    </span>
	                    <span style="float:left;">|</span>
	                    <span style="float:left;">
		                    <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" onclick="btnDelete_Click" />
	                    </span>
		            </div>
		        </div>
			</fieldset>
			
			<fieldset style="float:left; width:96%;">
			    <legend>
			    	<JWC:LabelEx ID="lbPropertyList" runat="server" Style="float:left;" meta:resourcekey="Sys_PropertyList">属性列表</JWC:LabelEx>
			    </legend>
			    <div style="float:left; width:100%;height:230px;overflow:auto;">
                    <JWC:DataGridView ID="dgfrmSysMgrRegWebPartTemplateEdit" runat="server" CssClass="DataGrid" Width="95%" ShowFooter="false"
	                    AllowSorting="true" MouseoverCssClass="DataGridHighLight" onbuilddatasource="dgfrmSysMgrRegWebPartTemplateEdit_BuildDataSource" 
	                    OnRowSelecting="dgfrmSysMgrRegWebPartTemplateEdit_OnRowSelecting">
	                    <PagerSettings Mode="NextPreviousFirstLast" />
	                    <AlternatingRowStyle CssClass="DataGridAlter" />
	                    <HeaderStyle CssClass="DataGridHeader" />
	                    <RowStyle CssClass="DataGridItem" />
	                    <Columns>
		                    <JWC:CheckBoxFieldEx DataField="TemplatePropertyID">
			                    <HeaderStyle Width="8px" />
		                    </JWC:CheckBoxFieldEx>
                		
		                    <JWC:BoundFieldEx DataField="TemplatePropertyName" HeaderText="属性名称" SortExpression="TemplatePropertyName" 
		                        ShowRowSelectingEvent="true" ToolTipField="Description" ShowToolTip="true" meta:resourcekey="Sys_TemplatePropertyName">
			                    <HeaderStyle Width="40%" />
			                    <ItemStyle HorizontalAlign="Left" />
		                    </JWC:BoundFieldEx>
                			
		                    <JWC:BoundFieldEx DataField="TemplateDefaultValue" HeaderText="默认值" SortExpression="TemplateDefaultValue" meta:resourcekey="Sys_TemplateDefaultValue">
			                    <HeaderStyle Width="60%" />
			                    <ItemStyle HorizontalAlign="Left" />
		                    </JWC:BoundFieldEx>
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
