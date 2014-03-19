<%--
//================================================================================
// FileName: frmSFITStudentsList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITStudentsList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentsList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITStudentsEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="310px" onclick="btnAdd_Click"/>
			</span>
			<span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--查询区域-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	     
	    <div style="float:left; width:100%;">
            <div style="float:left;">
		        <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="128px"/>
	        </div>
        	
            <div style="float:left;">
                 <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">所属年级：</JWC:LabelEx>
                 <JWC:TextBoxEx ID="txtGradeName" runat="server" Width="128px"/>
            </div>	
            
            <div style="float:left;">
                 <JWC:LabelEx ID="lbClass" runat="server" Style="float:left;" meta:resourcekey="SFIT_Class">所属班级：</JWC:LabelEx>
                 <JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
            </div>
        </div>
            
        <div style="float:left;">
		    <JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">学生姓名：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="128px" />
	    </div>
	        
	    <div style="float:right;">
		    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
		    <JWC:ServerAlert ID="errMessage" runat="server" />
	    </div>
	</asp:Panel>
	<!--数据显示区域-->
	 
    <JWC:DataGridView ID="dgfrmSFITStudentsList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
	    AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
	    PageSize="15" onbuilddatasource="dgfrmSFITStudentsList_BuildDataSource">
	    <PagerSettings Mode="NextPreviousFirstLast" />
	    <AlternatingRowStyle CssClass="DataGridAlter" />
	    <HeaderStyle CssClass="DataGridHeader" />
	    <FooterStyle CssClass="DataGridFooter" />
	    <RowStyle CssClass="DataGridItem" />
	    <Columns>
			    <JWC:CheckBoxFieldEx DataField="ClassID,StudentID" DataFormatString="{0}-{1}">
				    <HeaderStyle Width="8px" />
			    </JWC:CheckBoxFieldEx>
    			
			    <JWC:BoundFieldEx DataField="SchoolName" HeaderText="所属学校" SortExpression="SchoolName" meta:resourcekey="SFIT_DGV_SchoolName">
				    <HeaderStyle Width="16%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:BoundFieldEx DataField="GradeName" HeaderText="所属年级" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				    <HeaderStyle Width="12%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:BoundFieldEx DataField="ClassName" HeaderText="所属班级" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_Class">
				    <HeaderStyle Width="13%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    						
			    <JWC:BoundFieldEx DataField="StudentCode" HeaderText="学生代码" SortExpression="StudentCode" meta:resourcekey="SFIT_DGV_StudentCode">
				    <HeaderStyle Width="16%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="310px"
				    DataNavigateUrlFormatString="frmSFITStudentsEdit.aspx?StudentID={0}&ClassID={1}" DataNavigateUrlField="StudentID,ClassID"
				    HeaderText="学生名称" DataField="StudentName" SortExpression="StudentName" meta:resourcekey="SFIT_DGV_StudentName">
				    <HeaderStyle Width="13%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:MultiQueryStringFieldEx>
			    
			    <JWC:BoundFieldEx DataField="GenderName" HeaderText="性别" SortExpression="GenderName" meta:resourcekey="SFIT_DGV_GenderName">
				    <HeaderStyle Width="5%" />
				    <ItemStyle HorizontalAlign="Center" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:BoundFieldEx DataField="SyncStatusName" HeaderText="同步状态" SortExpression="SyncStatusName" meta:resourcekey="SFIT_DGV_SyncStatusName">
				    <HeaderStyle Width="10%" />
				    <ItemStyle HorizontalAlign="Center" />
			    </JWC:BoundFieldEx>
    						
			    <JWC:BoundFieldEx DataField="LastSyncTime" HeaderText="同步时间" SortExpression="LastSyncTime" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" 
			            meta:resourcekey="SFIT_DGV_LastSyncTime">
				    <HeaderStyle Width="15%" />
				    <ItemStyle HorizontalAlign="Center" />
			    </JWC:BoundFieldEx>
		    </Columns>
	</JWC:DataGridView>
</asp:Content>
