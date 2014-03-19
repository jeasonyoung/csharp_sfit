<%--
//================================================================================
//  FileName: UCWorksComments.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWorksComments.ascx.cs" Inherits="Yaesoft.SFIT.Web.UCWorksComments" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<!--标题-->
<asp:Panel ID="panelControl" runat="server" CssClass="TitleBar">
    <div style="float:right; margin-top:2px;">
        <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
    </div>
</asp:Panel>
<!--数据显示区域-->
<JWC:DataGridView ID="dgUCWorksComments" runat="server" Visible="false" CssClass="DataGrid" Width="98%" ShowFooter="true"
	AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	PageSize="15" onbuilddatasource="dgUCWorksComments_BuildDataSource">
	<PagerSettings Mode="NextPreviousFirstLast" />
	<AlternatingRowStyle CssClass="DataGridAlter" />
	<HeaderStyle CssClass="DataGridHeader" HorizontalAlign="Center" />
	<FooterStyle CssClass="DataGridFooter" />
	<RowStyle CssClass="DataGridItem" />
	<Columns>
		<JWC:CheckBoxFieldEx DataField="CommentID">
			<HeaderStyle Width="8px" />
		</JWC:CheckBoxFieldEx>
		
		<JWC:BoundFieldEx DataField="CreateDateTime" HeaderText="时间" SortExpression="CreateDateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="SFIT_DGV_CreateDateTime">
			<HeaderStyle Width="20%" />
			<ItemStyle HorizontalAlign="Center" />
		</JWC:BoundFieldEx>
		
		<JWC:BoundFieldEx DataField="Comment" HeaderText="评论" SortExpression="Comment" CharCount="100" ToolTipField="Comment" ShowToolTip="true" meta:resourcekey="SFIT_DGV_Comment">
			<HeaderStyle Width="60%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:BoundFieldEx>
		
		<JWC:BoundFieldEx DataField="StatusName" HeaderText="状态" SortExpression="StatusName" meta:resourcekey="SFIT_DGV_StatusName">
			<HeaderStyle Width="8%" />
			<ItemStyle HorizontalAlign="Center" />
		</JWC:BoundFieldEx>
					
		<JWC:BoundFieldEx DataField="UserName" HeaderText="用户名称" SortExpression="UserName" ToolTipField="ClientIP" ShowToolTip="true" meta:resourcekey="SFIT_DGV_UserName">
			<HeaderStyle Width="12%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:BoundFieldEx>
	</Columns>
</JWC:DataGridView>

<JWC:DataGridView ID="dgUCWorksCommentsDetail" runat="server" Visible="false" CssClass="DataGrid" Width="98%" ShowFooter="true"
	AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	PageSize="15" onbuilddatasource="dgUCWorksCommentsDetail_BuildDataSource">
	<PagerSettings Mode="NextPreviousFirstLast" />
	<AlternatingRowStyle CssClass="DataGridAlter" />
	<HeaderStyle CssClass="DataGridHeader" HorizontalAlign="Center" />
	<FooterStyle CssClass="DataGridFooter" />
	<RowStyle CssClass="DataGridItem" />
	<Columns>
		<JWC:CheckBoxFieldEx DataField="CommentID">
			<HeaderStyle Width="8px" />
		</JWC:CheckBoxFieldEx>
		
		<JWC:BoundFieldEx DataField="CreateDateTime" HeaderText="时间" SortExpression="CreateDateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="SFIT_DGV_CreateDateTime">
			<HeaderStyle Width="20%" />
			<ItemStyle HorizontalAlign="Center" />
		</JWC:BoundFieldEx>
		
		<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="400px" WinHeight="300px"
		    DataNavigateUrlFormatString="frmSFITWorksCommentsEdit.aspx?CommentID={0}" DataNavigateUrlField="CommentID"
		    HeaderText="评论" DataField="Comment" SortExpression="Comment" ShowToolTip="true" ToolTipField="Comment" CharCount="100"  meta:resourcekey="SFIT_DGV_Comment">
		    <HeaderStyle Width="60%" />
		    <ItemStyle HorizontalAlign="Left" />
	    </JWC:MultiQueryStringFieldEx>
		
		<JWC:BoundFieldEx DataField="StatusName" HeaderText="状态" SortExpression="StatusName" meta:resourcekey="SFIT_DGV_StatusName">
			<HeaderStyle Width="8%" />
			<ItemStyle HorizontalAlign="Center" />
		</JWC:BoundFieldEx>
					
		<JWC:BoundFieldEx DataField="UserName" HeaderText="用户名称" SortExpression="UserName" ToolTipField="ClientIP" ShowToolTip="true" meta:resourcekey="SFIT_DGV_UserName">
			<HeaderStyle Width="12%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:BoundFieldEx>
	</Columns>
</JWC:DataGridView>