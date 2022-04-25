<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AssignScholarship.aspx.cs" Inherits="Lab3.AssignScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
        <asp:Label ID="SchoApps" runat="server" Text="Scholarship Applications:"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="JobList" runat="server" AutoGenerateColumns="False" DataSourceID="Schodata">
        <Columns>
            <asp:BoundField DataField="ScholarshipName" HeaderText="ScholarshipName" SortExpression="ScholarshipName" />
            <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
            <asp:BoundField DataField="ScholarshipApplicationDate" HeaderText="ScholarshipApplicationDate" SortExpression="ScholarshipApplicationDate" />
            <asp:BoundField DataField="ScholarshipApplicationDescription" HeaderText="ScholarshipApplicationDescription" SortExpression="ScholarshipApplicationDescription" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Schodata" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT Scho.ScholarshipName, Stu.FirstName + ' '+ Stu.LastName AS FullName, Scap.ScholarshipApplicationDate, Scap.ScholarshipApplicationDescription From Student Stu, Scholarship Scho, ScholarshipApplication Scap WHERE Stu.StudentID=Scap.StudentID AND Scho.ScholarshipID=Scap.ScholarshipID">
        </asp:SqlDataSource>
    <br />
    <asp:Label ID="ScholarshipName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ScholarshipNameList" runat="server" AutoPostBack="True" DataSourceID="Scholar" DataTextField="ScholarshipName" DataValueField="ScholarshipID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Scholar" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select ScholarshipID, ScholarshipName from Scholarship ORDER BY ScholarshipID"></asp:SqlDataSource>
    <br />
     <br />
    <asp:Label ID="StudentName" runat="server" Text="Student Name:"></asp:Label>
    <asp:DropDownList ID="StudentNameList" runat="server" AutoPostBack="True" DataSourceID="StudentNames" DataTextField="FullName" DataValueField="StudentID" >
    </asp:DropDownList>
        <asp:SqlDataSource ID="StudentNames" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT StudentID, [FirstName] +' '+ [LastName] AS FullName FROM [Student]"></asp:SqlDataSource>
     <br />
    <asp:Button ID="AwardScholar" runat="server" Text="Award Student with Scholarship" OnClick="AwardScholar_Click" />
    &nbsp;<asp:Button ID="UpdateScholarship" runat="server" Text="Change Recipient of Scholarship" OnClick="UpdateScholarship_Click"/>
    <br />
    <asp:Label ID="ScholarResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
