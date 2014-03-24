<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITStudentWorksUpload.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentWorksUpload" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.Upload" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx id="vsfrmSFITStudentWorksUpload" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <!--数据录入区域-->
	<div class="TableSearch">
	    <div style="float:left; width:98%;">
            <JWC:LabelEx ID="lbSchoolName" runat="server">所属学校：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="328px" ReadOnly="true" IsRequired="true" RequiredErrorMessage="所属学校不能为空！"/>
	    </div>
	    <div style="float:left; width:98%;">
	        <JWC:LabelEx ID="lbClassName" runat="server">所属班级：</JWC:LabelEx>
	        <JWC:TextBoxEx ID="txtClassName" runat="server" Width="328px" ReadOnly="true" IsRequired="true" RequiredErrorMessage="所属班级不能为空！"/>
	    </div>
	    <div style="float:left; width:98%;">
            <JWC:LabelEx ID="lbStudentName" runat="server">学生姓名：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStudentName" runat="server" Width="328px" ReadOnly="true" IsRequired="true" RequiredErrorMessage="学生姓名不能为空！"/>
	    </div>
	    <div style="float:left; width:98%;">
	         <JWC:LabelEx ID="lbCatalog" runat="server">课程科目：</JWC:LabelEx>
	         <JWC:DropDownListEx ID="ddlCatalog" runat="server" Width="328px" ShowUnDefine="true" IsRequired="true" ErrorMessage="课程科目不能为空！" />
	    </div>
	    <div style="float:left; width:98%;">
            <JWC:LabelEx ID="lbWorkName" runat="server">作业名称：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtWorkName" runat="server" Width="328px" ReadOnly="true" IsRequired="true" RequiredErrorMessage="学生姓名不能为空！"/>
	    </div>
	    <div style="float:left; width:98%;">
	         <JWC:LabelEx ID="lbWorkType" runat="server">作品类型：</JWC:LabelEx>
	         <JWC:RadioButtonListEx ID="ddlWorkType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="作品类型不能为空！" />
	    </div>
	    <div style="float:left; width:98%;">
	         <JWC:LabelEx ID="lbWorkDescription" runat="server">作业描述：</JWC:LabelEx>
	         <JWC:TextBoxEx ID="txtWorkDescription" runat="server" Width="528px" TextMode="MultiLine" Rows="4"/>
	    </div>
	    <fieldset style="float:left; margin-top:8px; width:98%;">
	        <legend>上传作业附件：</legend>
	        <div style="float:left; width:98%; height:90px; overflow:auto;">
	            <JWC:UploadView ID="uploadAttachments" runat="server" Width="95%" MaxUploadSize="20" MaxUploadCount="1" DownloadBaseURI="AccessoriesDownload.ashx?FileID=" AllowOfficeOnlineEdit="false" OnUploadViewExceptionEvent="uploadAttachments_OnUploadViewExceptionEvent" />
	        </div>
	    </fieldset>
	</div>
	<!--数据控制区域-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>