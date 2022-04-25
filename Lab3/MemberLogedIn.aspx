<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="MemberLogedIn.aspx.cs" Inherits="Lab3.MemberLogedIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <br />
                <asp:GridView ID="grdvMemberTable" runat="server" DataSourceID="sqlsrc" allowsorting="true" AutoGenerateColumns="false" DataKeyNames="MemberID" Width="1093px">
            <Columns>
                <asp:BoundField HeaderText="FirstName" DataField="FirstName" SortExpression="FirstName" />
                <asp:BoundField HeaderText="LastName" DataField="LastName" SortExpression="LastName" />
                <asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email" />
                <asp:BoundField HeaderText="PhoneNumber" DataField="PhoneNumber" SortExpression="PhoneNumber" />
                <asp:BoundField HeaderText="GradYear" DataField="GradYear" SortExpression="GradYear" />
                <asp:BoundField HeaderText="Title" DataField="Title" SortExpression="Title" />
        </Columns>
            </asp:GridView>
        <asp:SqlDataSource ID="sqlsrc" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
            SelectCommand="Select * from Member WHERE UserName=@UserNamed">
            <SelectParameters>
                <asp:SessionParameter Name="UserNamed" SessionField="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    <asp:Button ID="EditMemberUser" runat="server" Text="Edit User" OnClick="EditMemberUser_Click" />
    <asp:Label ID="lblStudent" runat="server" Text="Students Mentoring"></asp:Label>
    <asp:GridView ID="StudentGrid" runat="server"></asp:GridView>
    <asp:Button ID="AssignMentor" runat="server" Text="Assign Mentor" OnClick="AssignMentor_Click" />
    <asp:Button ID="AssignScholarship" runat="server" Text="Assign Scholarship" OnClick="AssignScholarship_Click" />
    <asp:Button ID="AssignJob" runat="server" Text="Assign Job" OnClick="AssignJob_Click" />
    <asp:Button ID="AssignInternship" runat="server" Text="Assign Internship" OnClick="AssignInternship_Click" />
    <asp:Button ID="Search" runat="server" Text="Search for Student" OnClick="Search_Click"/>
</asp:Content>
