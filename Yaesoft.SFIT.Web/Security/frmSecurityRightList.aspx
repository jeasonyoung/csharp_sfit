<%--
//================================================================================
// FileName: frmSecurityRightList.aspx
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSecurityRightList.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRightList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>

<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSecurityRightEdit.aspx" PickerType="Modal" PickerWidth="360px" PickerHeight="220px" onclick="btnAdd_Click"/>
			</span>
			<span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--��ѯ����-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	    <div style="float:left;">
	        <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">����ϵͳ��</JWC:LabelEx>
	        <JWC:DropDownListEx ID="ddlSystemID" runat="server" Width="168px" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemID_OnSelectedIndexChanged" />
	    </div>
	    
		<div style="float:left;">
		    <JWC:LabelEx ID="lbModuleName" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleName">ģ�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleName" runat="server" Width="168px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	
	<div class="TableArea">
	    <div style="float:left; width:29%; height:475px; overflow:auto;" class="TableControl">
	       <JWC:TreeView ID="tvModule" runat="server" EnabledNodeClickEvent="true" ExpandFirstLevel="true" width="200px" OnNodeClick="tvModule_OnNodeClick" />
	    </div>
	    
	    <div style="float:right; width:70%;">
	        <!--������ʾ����-->
	        <JWC:DataGridView ID="dgfrmSecurityRightList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		        AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		        PageSize="15" onbuilddatasource="dgfrmSecurityRightList_BuildDataSource">
		        <PagerSettings Mode="NextPreviousFirstLast" />
		        <AlternatingRowStyle CssClass="DataGridAlter" />
		        <HeaderStyle CssClass="DataGridHeader" />
		        <FooterStyle CssClass="DataGridFooter" />
		        <RowStyle CssClass="DataGridItem" />
		        <Columns>
			        <JWC:CheckBoxFieldEx DataField="RightID">
				        <HeaderStyle Width="8px" />
			        </JWC:CheckBoxFieldEx>
        			
			        <JWC:BoundFieldEx DataField="ModuleName" HeaderText="ģ������" SortExpression="ModuleName" meta:resourcekey="Sec_ModuleName">
				        <HeaderStyle Width="30%" />
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
        			
			        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="360px" WinHeight="220px"
				        DataNavigateUrlFormatString="frmSecurityRightEdit.aspx?RightID={0}" DataNavigateUrlField="RightID"
				        HeaderText="ģ��Ȩ������" DataField="RightName" SortExpression="RightName" meta:resourcekey="Sec_RightName">
				        <HeaderStyle Width="40%" />
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:MultiQueryStringFieldEx>
        			
			        <JWC:BoundFieldEx DataField="ActionName" HeaderText="Ԫ��������" SortExpression="ActionName" meta:resourcekey="Sec_ActionName">
				        <HeaderStyle Width="30%" />
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
		        </Columns>
	        </JWC:DataGridView>
	    </div>
	</div>
</asp:Content>
