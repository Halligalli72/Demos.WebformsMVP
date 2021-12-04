<%@ Page Title="Register activity" Language="C#" MasterPageFile="~/Master/WebUI.Master" AutoEventWireup="true" CodeBehind="RegisterActivity.aspx.cs" Inherits="Demos.WebformsMVP.WebUI.Views.RegisterActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Register new activity</div>
        <div class="panel-body">
            <table style="overflow-x:auto;">
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:Label ID="lblUsername" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Date:</td>
                    <td>
                        <div class="input-group date" id="mydatetimepicker">
                            <asp:TextBox ID="txtActivityDate" CssClass="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Activity:</td>
                    <td>
                        <div><asp:DropDownList ID="drpActivityTypes" CssClass="form-control" runat="server"></asp:DropDownList></div>
                        <div><asp:TextBox ID="txtOtherActivity" CssClass="form-control" runat="server"></asp:TextBox></div>
                
                    </td>
                </tr>
                <tr>
                    <td>Duration:</td>
                    <td>
                        <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
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
    <script type="text/javascript">
        $(document).ready(function () {
            console.log('ready');
            $('#mydatetimepicker').datepicker({
                locale: 'sv',
                format: 'yyyy-mm-dd'
            });
        });
    </script>
</asp:Content>
