<%--
//================================================================================
// FileName: frmSFITEvaluateEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITEvaluateEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITEvaluateEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITEvaluateEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--数据录入区域-->
	<JWC:TabMultiView ID="tabEvaluateEdit" runat="server" TabIndex="0" Width="98%" Height="320px" EnableServerActive="true">
	    <JWC:TabView ID="tabEvaluateInfo" runat="server" Index="0" Text="基本信息" CssClass="TableSearch" meta:resourcekey="SFIT_EvaluateInfo">
	        <div style="float:left; width:100%;">
			    <JWC:LabelEx ID="lbEvaluateName" runat="server" Style="float:left;" meta:resourcekey="SFIT_EvaluateName">评价规则名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtEvaluateName" runat="server" Width="368px" IsRequired="true" RequiredErrorMessage="评价名称不能为空！"  />
		    </div>
    		 
	        <div style="float:left; width:100%;">
		        <JWC:LabelEx ID="lbEvaluateType" runat="server" Style="float:left;" meta:resourcekey="SFIT_EvaluateType">规则类型：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlEvaluateType" runat="server" Width="128px" AutoPostBack="true" OnSelectedIndexChanged="ddlEvaluateType_OnSelectedIndexChanged"
		            ShowUnDefine="true" IsRequired="true" ErrorMessage="规则类型不能为空！" />
	        </div>
    		
	        <div style="float:left;width:100%;">
		        <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" Text="1" IsRequired="true" RequiredErrorMessage="排序号不能为空！" />
	        </div>
    		
		    <asp:Panel ID="panelEvaluate" runat="server" Visible="false" Width="100%" Height="30px">
		        <div style="float:left;">
			        <JWC:LabelEx ID="lbMinValue" runat="server" Style="float:left;" meta:resourcekey="SFIT_MinValue">分数下限：</JWC:LabelEx>
			        <JWC:TextBoxEx ID="txtMinValue" runat="server" Width="80px" OnlyNumber="true" Text="0" />
		        </div>
        		
		        <div style="float:left;">
			        <JWC:LabelEx ID="lbMaxValue" runat="server" Style="float:left;" meta:resourcekey="SFIT_MaxValue">分数上限：</JWC:LabelEx>
			        <JWC:TextBoxEx ID="txtMaxValue" runat="server" Width="80px"  OnlyNumber="true" Text="100"/>
		        </div>
		    </asp:Panel>
	    </JWC:TabView>
	    
	    <JWC:TabView ID="tabEvaluateItems" runat="server" Index="1" Text="等级明细" CssClass="TableSearch" Visible="false"  meta:resourcekey="SFIT_EvaluateItems">
	        <fieldset style="float:left; width:96%;">
	            <legend>
	               <JWC:LabelEx ID="lbEvaluateItems" runat="server" Style="float:left;" meta:resourcekey="SFIT_Items">设置等级</JWC:LabelEx>
	            </legend>
	            <div style="float:left; width:100%;">
	                <div style="float:left;">
			            <JWC:LabelEx ID="lbItemName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ItemName">项目名：</JWC:LabelEx>
			            <JWC:TextBoxEx ID="txtItemName" runat="server" Width="128px" IsRequired="false" RequiredErrorMessage="项目名不能为空！"/>
		            </div>
		            <div style="float:left; margin-left:20px;">
			            <JWC:LabelEx ID="lbItemValue" runat="server" Style="float:left;" meta:resourcekey="SFIT_ItemValue">项目值：</JWC:LabelEx>
			            <JWC:TextBoxEx ID="txtItemValue" runat="server" Width="128px" IsRequired="false" RequiredErrorMessage="项目值不能为空！"/>
		            </div>
	            </div>
	            <div style="float:right; margin-right:10px;">
                    <span style="float:left;">
	                    <JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" CausesValidation="true" onclick="btnAdd_Click"/>
                    </span>
                    <span style="float:left;">
	                    <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" onclick="btnDelete_Click" />
                    </span>
		        </div>
	        </fieldset>
	        <fieldset style="float:left; width:96%;">
			    <legend>
			    	<JWC:LabelEx ID="lbEvaluateItemsList" runat="server" Style="float:left;" meta:resourcekey="SFIT_EvaluateItemsList">项目列表</JWC:LabelEx>
			    </legend>
			    <div style="float:left; width:100%;height:200px;overflow:auto;">
                    <JWC:DataGridView ID="dgfrmSFITEvaluateEdit" runat="server" CssClass="DataGrid" Width="95%" ShowFooter="false"
	                    AllowSorting="true" MouseoverCssClass="DataGridHighLight" onbuilddatasource="dgfrmSFITEvaluateEdit_BuildDataSource" 
	                    OnRowSelecting="dgfrmSFITEvaluateEdit_OnRowSelecting">
	                    <PagerSettings Mode="NextPreviousFirstLast" />
	                    <AlternatingRowStyle CssClass="DataGridAlter" />
	                    <HeaderStyle CssClass="DataGridHeader" />
	                    <RowStyle CssClass="DataGridItem" />
	                    <Columns>
		                    <JWC:CheckBoxFieldEx DataField="ItemID">
			                    <HeaderStyle Width="8px" />
		                    </JWC:CheckBoxFieldEx>
                		
		                    <JWC:BoundFieldEx DataField="ItemName" HeaderText="项目名" SortExpression="ItemName" ShowRowSelectingEvent="true"  meta:resourcekey="SFIT_ItemName">
			                    <HeaderStyle Width="40%" />
			                    <ItemStyle HorizontalAlign="Left" />
		                    </JWC:BoundFieldEx>
                			
		                    <JWC:BoundFieldEx DataField="ItemValue" HeaderText="项目值" SortExpression="ItemValue" meta:resourcekey="SFIT_ItemValue">
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
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
