<%--
//================================================================================
// FileName: frmSFITStudentsList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITStudentsList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentsList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
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
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--��ѯ����-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	     
	    <div style="float:left; width:100%;">
            <div style="float:left;">
		        <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">����ѧУ��</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="128px"/>
	        </div>
        	
            <div style="float:left;">
                 <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">�����꼶��</JWC:LabelEx>
                 <JWC:TextBoxEx ID="txtGradeName" runat="server" Width="128px"/>
            </div>	
            
            <div style="float:left;">
                 <JWC:LabelEx ID="lbClass" runat="server" Style="float:left;" meta:resourcekey="SFIT_Class">�����༶��</JWC:LabelEx>
                 <JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
            </div>
        </div>
            
        <div style="float:left;">
		    <JWC:LabelEx ID="lbStudentName" runat="server" Style="float:left;" meta:resourcekey="SFIT_StudentName">ѧ��������</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="128px" />
	    </div>
	        
	    <div style="float:right;">
		    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
		    <JWC:ServerAlert ID="errMessage" runat="server" />
	    </div>
	</asp:Panel>
	<!--������ʾ����-->
	 
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
    			
			    <JWC:BoundFieldEx DataField="SchoolName" HeaderText="����ѧУ" SortExpression="SchoolName" meta:resourcekey="SFIT_DGV_SchoolName">
				    <HeaderStyle Width="16%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:BoundFieldEx DataField="GradeName" HeaderText="�����꼶" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				    <HeaderStyle Width="12%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:BoundFieldEx DataField="ClassName" HeaderText="�����༶" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_Class">
				    <HeaderStyle Width="13%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    						
			    <JWC:BoundFieldEx DataField="StudentCode" HeaderText="ѧ������" SortExpression="StudentCode" meta:resourcekey="SFIT_DGV_StudentCode">
				    <HeaderStyle Width="16%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="310px"
				    DataNavigateUrlFormatString="frmSFITStudentsEdit.aspx?StudentID={0}&ClassID={1}" DataNavigateUrlField="StudentID,ClassID"
				    HeaderText="ѧ������" DataField="StudentName" SortExpression="StudentName" meta:resourcekey="SFIT_DGV_StudentName">
				    <HeaderStyle Width="13%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:MultiQueryStringFieldEx>
			    
			    <JWC:BoundFieldEx DataField="GenderName" HeaderText="�Ա�" SortExpression="GenderName" meta:resourcekey="SFIT_DGV_GenderName">
				    <HeaderStyle Width="5%" />
				    <ItemStyle HorizontalAlign="Center" />
			    </JWC:BoundFieldEx>
    			
			    <JWC:BoundFieldEx DataField="SyncStatusName" HeaderText="ͬ��״̬" SortExpression="SyncStatusName" meta:resourcekey="SFIT_DGV_SyncStatusName">
				    <HeaderStyle Width="10%" />
				    <ItemStyle HorizontalAlign="Center" />
			    </JWC:BoundFieldEx>
    						
			    <JWC:BoundFieldEx DataField="LastSyncTime" HeaderText="ͬ��ʱ��" SortExpression="LastSyncTime" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" 
			            meta:resourcekey="SFIT_DGV_LastSyncTime">
				    <HeaderStyle Width="15%" />
				    <ItemStyle HorizontalAlign="Center" />
			    </JWC:BoundFieldEx>
		    </Columns>
	</JWC:DataGridView>
</asp:Content>
