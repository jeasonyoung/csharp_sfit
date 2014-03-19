<%--
//================================================================================
//  FileName: frmSFITGroupEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITGroupEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITGroupEdit" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx id="vsfrmSFITGroupEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <!--数据录入区域-->
    <fieldset class="TableSearch">
        <legend>基本信息</legend>
        <div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbGroupName" runat="server" Style="float:left;" meta:resourcekey="SFIT_GroupName">分组名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtGroupName" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="分组名称不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbUnit" runat="server" Style="float:left;" meta:resourcekey="SFIT_Unit">所属单位：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlUnit" runat="server" Width="198px" ShowUnDefine="true" UnDefineTitle="[教育局]" IsRequired="false" ErrorMessage="所属单位不能为空！" />
		</div>
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="SFIT_Description">描述说明：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="468px" TextMode="MultiLine" Rows="3" />
		</div>
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">排&nbsp;&nbsp;序&nbsp;&nbsp;号：</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="50px" CssClass="NumberTextBoxFlat" Text="1" OnlyNumber="true" />
		</div>
    </fieldset>
    <fieldset class="TableSearch">
        <legend>分组目录管理</legend>
        <div style="float:left; width:100%; height:140px; overflow:auto;">
            <JWC:DataGridView ID="dgGroupCatalog" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true" AllowSorting="true" AllowPaging="false" AllowExport="false"
                MouseoverCssClass="DataGridHighLight" PageSize="10" OnBuildDataSource="dgGroupCatalog_BuildDataSource">
                <PagerSettings Mode="NextPreviousFirstLast" />
                <AlternatingRowStyle CssClass="DataGridAlter" />
                <HeaderStyle CssClass="DataGridHeader" />
                <FooterStyle CssClass="DataGridFooter" />
                <RowStyle CssClass="DataGridItem" />
                <Columns>
                   
                    <JWC:BoundFieldEx DataField="CatalogName" HeaderText="课程目录" SortExpression="CatalogName"  meta:resourcekey="SFIT_DGV_CatalogName">
                        <HeaderStyle Width="40%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>
                    
                     <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属学校单位" SortExpression="UnitName"  meta:resourcekey="SFIT_DGV_UnitName">
                        <HeaderStyle Width="30%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>
                     
                    <JWC:BoundFieldEx DataField="GradeName" HeaderText="所属年级" SortExpression="GradeName"  meta:resourcekey="SFIT_DGV_GradeName">
                        <HeaderStyle Width="20%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>                  
                            
                    <JWC:TemplateFieldEx>
                        <HeaderStyle CssClass="DataGridHeader" Width="10%" HorizontalAlign="Center" />
                        <ItemStyle CssClass="DataGridItem" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            <asp:LinkButton ID="btnAddCatalog" runat="server" Text="[添加]" CausesValidation="false" ToolTip="添加课程目录" OnClientClick="addCatalog()" OnClick="btnAddCatalog_OnClick" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDeleteCatalog" runat="server" Text="[移除]" CausesValidation="false" ToolTip="移除课程目录" OnClick="btnDeleteCatalog_OnClick" />
                        </ItemTemplate>
                    </JWC:TemplateFieldEx>           
                </Columns>
            </JWC:DataGridView>
        </div>
    </fieldset>
    <fieldset class="TableSearch">
        <legend>分组学生管理</legend>
        <div style="float:left; width:100%; height:180px;overflow:auto;">
            <JWC:DataGridView ID="dgGroupStudents" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true" AllowSorting="true" AllowPaging="false" AllowExport="false"
                MouseoverCssClass="DataGridHighLight" PageSize="10" OnBuildDataSource="dgGroupStudents_BuildDataSource">
                <PagerSettings Mode="NextPreviousFirstLast" />
                <AlternatingRowStyle CssClass="DataGridAlter" />
                <HeaderStyle CssClass="DataGridHeader" />
                <FooterStyle CssClass="DataGridFooter" />
                <RowStyle CssClass="DataGridItem" />
                <Columns>
                   
                    <JWC:BoundFieldEx DataField="StudentName" HeaderText="学生名称" SortExpression="StudentName"  meta:resourcekey="SFIT_DGV_StudentName">
                        <HeaderStyle Width="15%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>
                    
                    <JWC:BoundFieldEx DataField="StudentCode" HeaderText="学生代码" SortExpression="StudentCode"  meta:resourcekey="SFIT_DGV_StudentCode">
                        <HeaderStyle Width="25%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>
                    
                     <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属学校单位" SortExpression="UnitName"  meta:resourcekey="SFIT_DGV_UnitName">
                        <HeaderStyle Width="30%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>
                     
                    <JWC:BoundFieldEx DataField="ClassName" HeaderText="所属班级" SortExpression="ClassName"  meta:resourcekey="SFIT_DGV_ClassName">
                        <HeaderStyle Width="20%" />
                        <ItemStyle HorizontalAlign="Left" />
                    </JWC:BoundFieldEx>                  
                            
                    <JWC:TemplateFieldEx>
                        <HeaderStyle CssClass="DataGridHeader" Width="10%" HorizontalAlign="Center" />
                        <ItemStyle CssClass="DataGridItem" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            <asp:LinkButton ID="btnAddStudents" runat="server" Text="[添加]" CausesValidation="false" ToolTip="添加分组学生" OnClientClick="addStudents()" OnClick="btnAddStudents_OnClick" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDeleteStudents" runat="server" Text="[移除]" CausesValidation="false" ToolTip="移除分组学生" OnClick="btnDeleteStudents_OnClick" />
                        </ItemTemplate>
                    </JWC:TemplateFieldEx>           
                </Columns>
            </JWC:DataGridView>
        </div>
    </fieldset>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<asp:HiddenField ID="hiddenCatalogValue" runat="server" OnValueChanged="hiddenCatalogValue_OnValueChanged" />
			<asp:HiddenField ID="hiddenStudentsValue" runat="server" OnValueChanged="hiddenStudentsValue_OnValueChanged" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>

<script language="javascript" type="text/javascript">
    function addCatalog() {
        var sReturn, vTmd = Math.random();
        sReturn = window.showModalDialog('frmSFITCatalogPicker.aspx?IsUnit=<%=this.IsUnit %>&tmd=' + vTmd, window, 'dialogWidth:450px;dialogHeight:440px;help:0');
        if (typeof (sReturn) != "undefined" && sReturn != "") {
            eval("document.all.<%=this.hiddenCatalogValue.ClientID %>.value='" + sReturn + "'");
            return true;
        }
        else {
            return false;
        }
        return true;
    }

    function addStudents() {
        var sReturn, vTmd = Math.random();
        sReturn = window.showModalDialog('frmSFITStudentsPicker.aspx?IsUnit=<%=this.IsUnit %>&tmd=' + vTmd, window, 'dialogWidth:450px;dialogHeight:440px;help:0');
        if (typeof (sReturn) != "undefined" && sReturn != "") {
            eval("document.all.<%=this.hiddenStudentsValue.ClientID %>.value='" + sReturn + "'");
            return true;
        }
        else {
            return false;
        }
        return true;
    }
</script>
</asp:Content>
