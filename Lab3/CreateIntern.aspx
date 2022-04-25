<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateIntern.aspx.cs" Inherits="Lab3.CreateIntern" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     Internship Title:
            <asp:TextBox ID="TitleIntern" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TitleIntern" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Internship Description:
            <asp:TextBox ID="InternshipDescription" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="InternshipDescription" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Start Date:
            <asp:TextBox ID="DateStart" runat="server" placeholder="00-00-0000"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DateStart" Text="Required"></asp:RequiredFieldValidator>
            <br />
            End Date:
            <asp:TextBox ID="DateEnd" runat="server" placeholder="00-00-0000"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DateEnd" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:DropDownList ID="ContactList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="ContactName" DataValueField="ContactID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select ContactID, ContactName from Contact"></asp:SqlDataSource>
        
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateJobs" runat="server" Text="Create" OnClick="CreateJobs_Click1" CausesValidation="false" />
</asp:Content>
