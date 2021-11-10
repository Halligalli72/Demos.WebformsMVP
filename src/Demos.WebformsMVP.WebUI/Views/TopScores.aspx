<%@ Page Title="Top scores" Language="C#" MasterPageFile="~/Master/WebUI.Master" AutoEventWireup="true" CodeBehind="TopScores.aspx.cs" Inherits="Demos.WebformsMVP.WebUI.Views.TopScores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <asp:Panel ID="pnlMessage" runat="server" Visible="false">
        <div>
            <asp:TextBox ID="txtMessage" ReadOnly="true" TextMode="MultiLine" Rows="5" Width="230" runat="server"></asp:TextBox>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
