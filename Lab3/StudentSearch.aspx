<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentSearch.aspx.cs" Inherits="Lab3.StudentSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Searchlbl" runat="server" Text="Search Student"></asp:Label>
    <asp:TextBox ID="Searchtxt" runat="server" placeholder="Student Name"></asp:TextBox>
    <asp:Button ID="Search4Student" runat="server" Text="Search" OnClick="Search4Student_Click" />
    <asp:GridView ID="StudentsView" runat="server"  AllowSorting="true" AllowPaging="true" AutoGenerateColumns="false">
       
        <columns> 
           <asp:BoundField ReadOnly="True" HeaderText="FirstName" Datafield="FirstName" SortExpression="FirstName" />
           <asp:BoundField ReadOnly="True" HeaderText="LastName" Datafield="LastName" SortExpression="LastName" />
           <asp:BoundField ReadOnly="True" HeaderText="Email" Datafield="Email" SortExpression="Email" />
           <asp:BoundField ReadOnly="True" HeaderText="PhoneNumber" Datafield="PhoneNumber" SortExpression="PhoneNumber" />
           <asp:BoundField ReadOnly="True" HeaderText="UniversityYear" Datafield="UniversityYear" SortExpression="UniversityYear" />
           <asp:BoundField ReadOnly="True" HeaderText="Major" Datafield="Major" SortExpression="Major" />
           <asp:BoundField ReadOnly="True" HeaderText="GradYear" Datafield="GradYear" SortExpression="GradYear" />
           <asp:BoundField ReadOnly="True" HeaderText="UserName" Datafield="UserName" SortExpression="UserName" />
           <asp:TemplateField HeaderText="Resumes">
               <itemTemplate>
                   <asp:HyperLink ID="reumesss" runat="server" NavigateUrl='<%# "/TextFile/" + Eval("Files") %>'>HyperLink</asp:HyperLink>
               </itemTemplate>

           </asp:TemplateField>

       </columns>

    </asp:GridView>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />

</asp:Content>
