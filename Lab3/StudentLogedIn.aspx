<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentLogedIn.aspx.cs" Inherits="Lab3.StudentLogedIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
            

    <asp:Button ID="EditInfo" runat="server" Text="View/Edit Information" OnClick="EditInfo_Click" />
            <br />
    <asp:Label ID="ResumeLabel" runat="server" Text="Resume"></asp:Label>
    <br />
<asp:GridView ID="StudentsView" runat="server"  AllowSorting="true" AllowPaging="true" AutoGenerateColumns="false">
       
        <columns> 
           <asp:TemplateField HeaderText="Resumes">
               <itemTemplate>
                   <asp:HyperLink ID="reumesss" runat="server" NavigateUrl='<%# "/TextFile/" + Eval("Files") %>'>Resume</asp:HyperLink>
               </itemTemplate>

           </asp:TemplateField>

       </columns>

    </asp:GridView>
            <br />
    <asp:Label ID="Mentor" runat="server" Text="Mentor Name:"></asp:Label>
    <asp:GridView ID="MentorGrid" runat="server"></asp:GridView>
            <br />

    <asp:Button ID="ApplyScholar" runat="server" Text="Apply for Scholarship" OnClick="ApplyScholar_Click"/>
    <asp:Button ID="ApplyJob" runat="server" Text="Apply for Job" OnClick="ApplyJob_Click"/>
    <asp:Button ID="ApplyIntern" runat="server" Text="Apply for Internship" OnClick="ApplyIntern_Click"/>
    <asp:Button ID="UploadResume" runat="server" Text="Upload Resume" OnClick="UploadResume_Click"/>

</asp:Content>
