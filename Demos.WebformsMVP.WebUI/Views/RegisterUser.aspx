<%@ Page Title="Register user" Language="C#" MasterPageFile="~/Master/WebUI.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Demos.WebformsMVP.WebUI.Views.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Register new user</div>
        <div class="panel-body">
            <table style="overflow-x:auto;">
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Team name:</td>
                    <td>
                        <div><asp:DropDownList ID="drpAvailableTeams" CssClass="form-control" runat="server"></asp:DropDownList></div>
                        <div><asp:TextBox ID="txtTeam" CssClass="form-control" runat="server"></asp:TextBox></div>
                    </td>
                </tr>
                <tr>
                    <td>Department:</td>
                    <td>
                        <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>My results are public:</td>
                    <td>
                        <asp:CheckBox ID="chkPublicResults" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegisterUser" runat="server" Text="Save" OnClick="btnRegisterUser_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Panel ID="pnlMessage" runat="server" Visible="false">
        <div>
            <asp:TextBox ID="txtMessage" ReadOnly="true" TextMode="MultiLine" Rows="5" Width="100%" runat="server"></asp:TextBox>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
