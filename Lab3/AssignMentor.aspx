<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AssignMentor.aspx.cs" Inherits="Lab3.AssignMentor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <br />
    <asp:Label ID="MentorName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="MentorNameList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="FullName" DataValueField="MemberID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select MemberID, FirstName + ' '+ LastName as FullName from Member"></asp:SqlDataSource>
    <br />
     <br />
    <asp:Label ID="StudentName" runat="server" Text="Student Name:"></asp:Label>
    <asp:DropDownList ID="StudentNameList" runat="server" AutoPostBack="True" DataSourceID="StudentNames" DataTextField="FullName" DataValueField="StudentID" >
    </asp:DropDownList>
        <asp:SqlDataSource ID="StudentNames" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT StudentID, [FirstName] +' '+ [LastName] AS FullName FROM [Student]"></asp:SqlDataSource>
     <br />
    <asp:Button ID="AssignMentors" runat="server" Text="Assign Student to Mentor" OnClick="AssignMentor_Click" />
    <br />
    <asp:Label ID="MentorResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
