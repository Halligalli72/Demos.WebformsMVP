<%@ Page Title="User profile" Language="C#" MasterPageFile="~/Master/WebUI.Master" CodeBehind="UserProfile.aspx.cs" Inherits="Demos.WebformsMVP.WebUI.Views.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div>
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#view">View profile</a></li>
            <li><a data-toggle="tab" href="#edit">Edit profile</a></li>
        </ul>
    </div>
    <div class="tab-content">
        <div id="view" class="tab-pane fade in active">
            <h3>Your user profile</h3>
            <table style="overflow-x:auto;">
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:Label ID="lblUserName" CssClass="form-control" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:Label ID="lblName" CssClass="form-control" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Team name:</td>
                    <td>
                        <asp:Label ID="lblTeamName" CssClass="form-control" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Department:</td>
                    <td>
                        <asp:Label ID="lblDepartmentName" CssClass="form-control" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>My results are public:</td>
                    <td>
                        <asp:Label ID="lblResultsArePublic" CssClass="form-control" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogout" Visible="false" runat="server" Text="Logout" OnClick="btnLogout_Click" /></td>
                </tr>
            </table>
        </div>
        <div id="edit" class="tab-pane fade">
            <h3>Edit user profile</h3>
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
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
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
