<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="Yaesoft.SFIT.Web.Controls.MainMenu" %>
<table cellSpacing="0" cellPadding="0" style="float:left;" border="0">
    <tr>
        <asp:Repeater ID="repeaterMainMenu" runat="server">
            <ItemTemplate>
                <td class="<%#(this.CurrentSystemID == Eval("ModuleID").ToString()) ? "MainMenuOver":"MainMenuOut" %>" 
                    <%# (this.CurrentSystemID == Eval("ModuleID").ToString()) ? "":"onmouseover=\"this.className='MainMenuOver';\" onmouseout=\"this.className='MainMenuOut';\">" %>
                   <a target="_self" href='<%# DataBinder.Eval(Container.DataItem,"ModuleUri") %>'><%# DataBinder.Eval(Container.DataItem, "ModuleName")%></a>
                </td>
            </ItemTemplate>
        </asp:Repeater>
    </tr>
</table>