<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="Internship.aspx.cs" Inherits="Lab3.Internship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />    
    <asp:Label ID="InName" runat="server" Text="Internship Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="Internlist" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="InternshipTitle" DataValueField="InternshipID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select InternshipID, InternshipTitle from Internship"></asp:SqlDataSource>
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
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
            <asp:TextBox ID="DateStart" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DateStart" Text="Required"></asp:RequiredFieldValidator>
            <br />
            End Date:
            <asp:TextBox ID="DateEnd" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DateEnd" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateIntern" runat="server" Text="Create" OnClick="CreateIntern_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
