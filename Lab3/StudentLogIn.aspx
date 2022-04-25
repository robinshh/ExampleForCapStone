<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentLogIn.aspx.cs" Inherits="Lab3.StudentLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="LoginType" runat="server" Text="Log In"></asp:Label>
    <br />
<asp:Label ID="StudentUserName" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="StudentPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnStudentLogin" runat="server" Text="Login ->" OnClick="btnStudentLogin_Click" />
            <br />
    <br />
    
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="buttnCreateStudent" runat="server" Text="Create Student Account" OnClick="buttnCreateStudent_Click" />
    <asp:Button ID="buttnCreateMember" runat="server" Text="Create Member Account" OnClick="buttnCreateMember_Click" />
</asp:Content>
