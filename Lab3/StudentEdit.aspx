<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="Lab3.StudentEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
        <asp:Label ID="JobName" runat="server" Text="Student Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="StudentList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="FullName" DataValueField="StudentID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select StudentID, FirstName + ' ' + LastName AS FullName from Student"></asp:SqlDataSource>
        <br />
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
        First Name:
            <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirst" Text="Required"></asp:RequiredFieldValidator>
    <br />
        Last Name:
            <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLast" Text="Required"></asp:RequiredFieldValidator>
    <br />
        Email:
            <asp:TextBox ID="txtEm" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEm" Text="Required"></asp:RequiredFieldValidator>
    <br />
        Phone Number:
            <asp:TextBox ID="txtPho" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPho" Text="Required"></asp:RequiredFieldValidator>
    <br />
        University Year:
            <asp:TextBox ID="txtUni" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUni" Text="Required"></asp:RequiredFieldValidator>
    <br />
        Major:
            <asp:TextBox ID="txtMaj" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMaj" Text="Required"></asp:RequiredFieldValidator>
    <br />
        Graduation Year:
            <asp:TextBox ID="txtGrad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGrad" Text="Required"></asp:RequiredFieldValidator>
    &nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Out of Range (2022-2028)" ControlToValidate="txtGrad" MinimumValue="2022" MaximumValue="2028" Type="double"></asp:RangeValidator>
    <br />
        UserName:
            <asp:Label ID="labelUsername" runat="server"></asp:Label>
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />

</asp:Content>
