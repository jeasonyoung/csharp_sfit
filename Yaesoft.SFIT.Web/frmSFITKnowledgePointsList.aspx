<%--
//================================================================================
// FileName: frmSFITKnowledgePointsList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITKnowledgePointsList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITKnowledgePointsList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>

<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITKnowledgePointsEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="260px" onclick="btnAdd_Click"/>
			</span>
			<span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--查询区域-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	    <div style="float:left;">
			<JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">所属年级：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlGrade" runat="server" Width="168px" ShowUnDefine="true" />
		</div>
	
		<div style="float:left;">
			<JWC:LabelEx ID="lbPointName" runat="server" Style="float:left;" meta:resourcekey="SFIT_PointName">要点名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPointName" runat="server" Width="168px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSFITopKnowledgePointsList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" Visible="false" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITopKnowledgePointsList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="PointID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="GradeName" HeaderText="所属年级" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
				DataNavigateUrlFormatString="frmSFITKnowledgePointsEdit.aspx?PointID={0}" DataNavigateUrlField="PointID"
				HeaderText="要点代码" DataField="PointCode" SortExpression="PointCode" meta:resourcekey="SFIT_DGV_PointCode">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
						
			<JWC:BoundFieldEx DataField="PointName" HeaderText="要点名称" SortExpression="PointName" meta:resourcekey="SFIT_DGV_PointName">
				<HeaderStyle Width="40%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="Description" HeaderText="描述" SortExpression="Description" meta:resourcekey="SFIT_DGV_Description">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:TemplateFieldEx>
			    <HeaderStyle Width="10%" />
			    <HeaderTemplate>详细</HeaderTemplate>
			    <ItemStyle HorizontalAlign="Center" />
			    <ItemTemplate>
			        <a target="_self" href='frmSFITKnowledgePointsList.aspx?TopPointID=<%#Eval("PointID")%>'>详细</a>
			    </ItemTemplate>
			</JWC:TemplateFieldEx>
		</Columns>
	</JWC:DataGridView>
	<!--显示树结构-->
	<JWC:TreeView ID="tvKnowledgePoints" runat="server" Visible="false" ExpandAllLevel="true" CheckType="CheckBox" Width="99%" />
	
	<script language="javascript" type="text/javascript">
	<!--//
	    function tvKnowledgePointsOpenEdit(PointID) {
	        var sReturn, vTmd = Math.random();
	        sReturn = window.showModalDialog("frmSFITKnowledgePointsEdit.aspx?PointID=" + PointID + "&tmd=" + vTmd, window, "dialogWidth:540px;dialogHeight:260px;help:0");
	        if(typeof(sReturn)!="undefined" && sReturn!="")
            {
	            <%=this.ClientScript.GetPostBackEventReference(this.btnAdd, this.btnAdd.ClientID)%>
	        }
	    }
    //-->
	</script>
</asp:Content>
