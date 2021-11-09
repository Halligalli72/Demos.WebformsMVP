<%@ Page Title="Login" MasterPageFile="~/Master/WebUI.Master" Language="C#" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="Demos.WebformsMVP.WebUI.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Login</div>
        <div class="panel-body">
            <table>
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Panel ID="pnlMessage" runat="server" Visible="false">
        <div>
            <asp:TextBox ID="txtMessage" ReadOnly="true" TextMode="MultiLine" Rows="5" Width="230" runat="server"></asp:TextBox>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
