<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITStudentWorksUpload.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentWorksUpload" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx id="vsfrmSFITStudentWorksUpload" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <!--数据录入区域-->
	<div class="TableSearch">
	    
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