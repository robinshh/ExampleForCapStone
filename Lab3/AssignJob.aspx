<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AssignJob.aspx.cs" Inherits="Lab3.AssignJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
    <asp:Label ID="JobApps" runat="server" Text="Job Applications:"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="JobList" runat="server" AutoGenerateColumns="False" DataSourceID="JobAppd">
        <Columns>
            <asp:BoundField DataField="InternshipDescription" HeaderText="InternshipDescription" SortExpression="InternshipDescription" />
            <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
            <asp:BoundField DataField="JobApplicationDescription" HeaderText="JobApplicationDescription" SortExpression="JobApplicationDescription" />
            <asp:BoundField DataField="JobApplicationDueDate" HeaderText="JobApplicationDueDate" SortExpression="JobApplicationDueDate" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="JobAppd" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT Jo.InternshipDescription, Stu.FirstName + ' '+ Stu.LastName AS FullName, Ja.JobApplicationDescription, Ja.JobApplicationDueDate From Student Stu, Job Jo, JobApplication Ja WHERE Stu.StudentID=Ja.StudentID AND Jo.JobID=Ja.JobID">
        </asp:SqlDataSource>



    <br />
    <asp:Label ID="JobName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="JobNameList" runat="server" AutoPostBack="True" DataSourceID="Jobs" DataTextField="JobName" DataValueField="JobID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Jobs" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select JobID, InternshipDescription AS JobName from Job"></asp:SqlDataSource>
    <br />
     <br />
    <asp:Label ID="StudentName" runat="server" Text="Student Name:"></asp:Label>
    <asp:DropDownList ID="StudentNamedList" runat="server" AutoPostBack="True" DataSourceID="StudentNames" DataTextField="FullName" DataValueField="StudentID" >
    </asp:DropDownList>
        <asp:SqlDataSource ID="StudentNames" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT StudentID, [FirstName] +' '+ [LastName] AS FullName FROM [Student]"></asp:SqlDataSource>
     <br />
    <asp:Button ID="AwardJob" runat="server" Text="Award Student with Job" OnClick="AwardJob_Click" />
    &nbsp;<asp:Button ID="ChangeJob" runat="server" Text="Change Job Recipient" OnClick="ChangeJob_Click"/>
            <br />
    <asp:Label ID="JobResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
