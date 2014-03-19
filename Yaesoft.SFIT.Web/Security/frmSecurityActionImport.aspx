<%--
//================================================================================
//  FileName: frmSecurityActionImport.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/3/31
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSecurityActionImport.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityActionImport" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx id="vsfrmSecurityActionImport" runat="server"  ShowMessageBox="true" ShowSummary="false"/>

<!--查询区域-->
<div class="TableSearch">
    <div style="float:left;">
		<JWC:LabelEx ID="lbFileUpload" runat="server" Style="float:left;" meta:resourcekey="Sec_FileUpload">文件地址：</JWC:LabelEx>
		<asp:FileUpload ID="txtFileUpload" runat="server" Width="450px" />
    </div>

    <div style="float:right;">
	    <JWC:ButtonEx ID="btnUpload" runat="server" CausesValidation="true" onclick="btnUpload_Click" Text="上传"/>
    </div>
</div>
<!--数据显示区域-->
<div style="text-align:center; width:100%; height:350px; overflow:auto;">
<JWC:DataGridView ID="dgfrmSecurityActionImport" runat="server" CssClass="DataGrid" Width="97%" ShowFooter="true"
	AllowSorting="true" AllowPaging="false" AllowExport="false" MouseoverCssClass="DataGridHighLight"
	PageSize="10" onbuilddatasource="dgfrmSecurityActionImport_BuildDataSource">
	<PagerSettings Mode="NextPreviousFirstLast" />
	<AlternatingRowStyle CssClass="DataGridAlter" />
	<HeaderStyle CssClass="DataGridHeader" />
	<FooterStyle CssClass="DataGridFooter" />
	<RowStyle CssClass="DataGridItem" />
	<Columns>
		<JWC:CheckBoxFieldEx DataField="ActionID">
			<HeaderStyle Width="8px" />
		</JWC:CheckBoxFieldEx>
		 
		 <JWC:BoundFieldEx DataField="ActionID" HeaderText="元操作编号" SortExpression="ActionID">
			<HeaderStyle Width="25%" />
			<ItemStyle HorizontalAlign="Center" />
		</JWC:BoundFieldEx>
		 
        <JWC:BoundFieldEx DataField="ActionSign" HeaderText="元操作标识" SortExpression="ActionSign">
	        <HeaderStyle Width="20%" />
	        <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>

        <JWC:BoundFieldEx DataField="ActionName" HeaderText="元操作名称" SortExpression="ActionName">
	        <HeaderStyle Width="25%" />
	        <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>

        <JWC:BoundFieldEx DataField="ActionDescription" HeaderText="描述" SortExpression="ActionDescription">
	        <HeaderStyle Width="30%" />
	        <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
		　
	</Columns>
</JWC:DataGridView>
</div>
<!--数据控制区域-->
<div class="TableControl">
	<div style="margin:0 auto; text-align:center; width:100%;">
        <JWC:ServerAlert ID="errMessage" runat="server" />
		<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" Enabled="false" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
		<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
	</div>
</div>

</asp:Content>
