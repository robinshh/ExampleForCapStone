<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AccountApplications.aspx.cs" Inherits="Lab3.AccountApplications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:DropDownList ID="StudentListDrop" runat="server" AutoPostBack="true" DataSourceID="StudentAppls" DataTextField="FullName" DataValueField="StudentAccAppID"></asp:DropDownList>
    <asp:SqlDataSource ID="StudentAppls" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select StudentAccAppID, FirstName + ' '+ LastName as FullName from StudentAccountApplication"></asp:SqlDataSource>
    <br />
    <asp:Button ID="ViewStudentAcc" runat="server" Text="View Student Account Info" OnClick="ViewStudentAcc_Click" />
    <br />
    <asp:GridView ID="StudentAccGrid" runat="server"></asp:GridView>
    <br />
    <asp:Button ID="AcceptStudentAcc" runat="server" Text="Accept Student Application" OnClick="AcceptStudentAcc_Click" />
    <br />
    <asp:Label ID="AcceptStudentResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:DropDownList ID="MemberListDrop" runat="server" AutoPostBack="true"  DataSourceID="MemberAppls" DataTextField="FullName" DataValueField="MemberAccAppID"></asp:DropDownList>
    <asp:SqlDataSource ID="MemberAppls" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select MemberAccAppID, FirstName + ' '+ LastName as FullName from MemberAccountApplication"></asp:SqlDataSource>
    <br />
    <asp:Button ID="ViewMemberAcc" runat="server" Text="View Member Account Info" OnClick="ViewMemberAcc_Click" />
    <br />
    <asp:GridView ID="MemberAccGrid" runat="server"></asp:GridView>
    <br />
    <asp:Label ID="MemberType" runat="server" Text="Select Member Type"></asp:Label>
    <asp:DropDownList ID="TypeList" runat="server">
        <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
        <asp:ListItem Text="Leader" Value="Leader"></asp:ListItem>
        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
    </asp:DropDownList>


    <asp:Button ID="AcceptMemberAcc" runat="server" Text="Accept Member Application" OnClick="AcceptMemberAcc_Click" />
    <br />
    <asp:Label ID="AcceptMemberResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
