<%@ Page Title="Activity list" Language="C#" MasterPageFile="~/Master/WebUI.Master" AutoEventWireup="true" CodeBehind="ActivityList.aspx.cs" Inherits="Demos.WebformsMVP.WebUI.Views.ActivityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:Label ID="lblListHeader" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <asp:GridView ID="gvActivityList" runat="server" AutoGenerateColumns="False" 
                    CssClass="table table-bordered table-condensed" 
                    OnRowDeleting="gvActivityList_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="User" InsertVisible="False" SortExpression="UserProfileId">
                            <ItemTemplate>
                                <asp:HiddenField ID="lblUserProfileId" runat="server" Value=<%# Bind("UserProfileId") %>></asp:HiddenField>
                                <asp:Label ID="label1" runat="server" Text='<%# Eval("Performer.Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" InsertVisible="False" SortExpression="ActivityDate">
                            <ItemTemplate>
                                <asp:Label ID="lblActivityDate" runat="server" Text='<%# Bind("ActivityDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activity" InsertVisible="False" SortExpression="ActivityTypeId">
                            <ItemTemplate>
                                <asp:HiddenField ID="lblActivityTypeId" runat="server" Value=<%# Bind("ActivityTypeId") %>></asp:HiddenField>
                                <asp:Label ID="label2" runat="server" Text='<%# Eval("ActivityType.ActivityName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Other" InsertVisible="False" SortExpression="OtherActivity">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("OtherActivity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duration" InsertVisible="False" SortExpression="Duration">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Score" InsertVisible="False" SortExpression="Score">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Score") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Created" InsertVisible="False" SortExpression="Created">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Created") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Updated" SortExpression="Updated" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("Updated") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
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
