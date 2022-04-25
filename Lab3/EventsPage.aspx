<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="EventsPage.aspx.cs" Inherits="Lab3.EventsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblEvent" runat="server" Text="Events"></asp:Label>
    <asp:GridView ID="EventTable" runat="server" DataSourceID="sqlsrc" allowsorting="true" AutoGenerateColumns="false" DataKeyNames="EventID" Width="1093px">
            <Columns>
                <asp:BoundField  HeaderText="Event" DataField="EventTitle" SortExpression="EventTitle" />
                <asp:BoundField HeaderText="Date" DataField="EventDate" SortExpression="EventDate" />
                <asp:BoundField HeaderText="Description" DataField="EventDescription" SortExpression="EventDescription" />
                <asp:BoundField HeaderText="Location" DataField="EventLocation" SortExpression="EventLocation" />
        </Columns>
            </asp:GridView>
        <asp:SqlDataSource ID="sqlsrc" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
            SelectCommand="Select * from EVENT">
        </asp:SqlDataSource>

</asp:Content>
