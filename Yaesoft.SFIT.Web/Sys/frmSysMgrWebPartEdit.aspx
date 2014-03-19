<%--
//================================================================================
// FileName: frmSysMgrWebPartEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSysMgrWebPartEdit.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSysMgrWebPartEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<JWC:TabMultiView ID="tabMultiView" runat="server" EnableServerActive="True" DefaultActiveTabIndex="0" Width="99%" Height="340px">
	    <JWC:TabView ID="tabViewInfo" runat="server" Text="������Ϣ" Index="0" CssClass="TableSearch" meta:resourcekey="Sys_WebPartBaseName">
	        <div style="float:left; width:100%; margin-top:5px;">
			    <JWC:LabelEx ID="lbWebPartName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartName">��&nbsp;��&nbsp;��&nbsp;&nbsp;�ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtWebPartName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="�������Ʋ���Ϊ�գ�"  />
		    </div>
    	    
		    <div style="float:left;width:100%;">
			    <JWC:LabelEx ID="lbWebPartTemplate" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartTemplate">��&nbsp;��&nbsp;ģ&nbsp;&nbsp;�壺</JWC:LabelEx>
			    <JWC:PickerBase ID="pbWebPartTemplate" runat="server" Width="432px" PickerHeight="420px" PickerWidth="320px" MultiSelect="false" PickerPage="frmSysMgrRegWebPartTemplatePicker.aspx" 
			       OnTextChanged="pbWebPartTemplate_OnTextChanged" AutoPostBack="true"  IsRequired="true" ErrorMessage="�������Ʋ���Ϊ�գ�"/>
		    </div>
    		
		    <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbDataAssemblyName" runat="server" Style="float:left;" meta:resourcekey="Sys_DataAssemblyName">���ݳ��򼯣�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtDataAssemblyName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="���ݳ��򼯲���Ϊ�գ�"  />
		    </div>
    		
		    <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbDataClassName" runat="server" Style="float:left;" meta:resourcekey="Sys_DataClassName">�ӿ������ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtDataClassName" runat="server" Width="418px" IsRequired="true" RequiredErrorMessage="�ӿ������Ʋ���Ϊ�գ�" />
		    </div>
    		
		    <div style="float:right; width:100%;">
			    <JWC:LabelEx ID="lbWebPartStatus" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartStatus">״&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;̬��</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlWebPartStatus" runat="server" Width="80px" ShowUnDefine="false"  />
		    </div>
    		
		    <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="Sys_Description">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtDescription" runat="server" Width="418px" TextMode="MultiLine" Rows="5"  />
		    </div>
	    </JWC:TabView>
	    <JWC:TabView ID="tabViewProperty" runat="server" Text="��������" Index="1" CssClass="TableSearch" meta:resourcekey="Sys_WebPartProperty">
	        <fieldset style="float:left; width:96%; margin-top:5px;">
	            <legend>
	                 <JWC:LabelEx ID="lbWebPartPropertyList" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartPropertyList">�����б�</JWC:LabelEx>
	            </legend>
	            <div style="float:left; width:100%;height:310px;overflow:auto;">
	                <JWC:DataGridView ID="dgfrmSysMgrWebPartEdit" runat="server" CssClass="DataGrid" Width="95%" ShowFooter="false"
                        AllowSorting="true" MouseoverCssClass="DataGridHighLight" onbuilddatasource="dgfrmSysMgrWebPartEdit_BuildDataSource">
                        <PagerSettings Mode="NextPreviousFirstLast" />
                        <AlternatingRowStyle CssClass="DataGridAlter" />
                        <HeaderStyle CssClass="DataGridHeader" />
                        <RowStyle CssClass="DataGridItem" />
                        <Columns>
	                        <JWC:BoundFieldEx DataField="PropertyName" HeaderText="��������" SortExpression="PropertyName"  
	                            ToolTipField="PropertyDescription" ShowToolTip="true" meta:resourcekey="Sys_PropertyName">
		                        <HeaderStyle Width="40%" />
		                        <ItemStyle HorizontalAlign="Left" />
	                        </JWC:BoundFieldEx>
                			
	                        <JWC:TemplateFieldEx>
	                            <HeaderStyle Width="60%" />
		                        <ItemStyle HorizontalAlign="Left" />
	                            <HeaderTemplate>
	                                <JWC:LabelEx ID="lbPropertyValue" runat="server" meta:resourcekey="Sys_PropertyValue">����ֵ</JWC:LabelEx>
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
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</div>
</asp:Content>
