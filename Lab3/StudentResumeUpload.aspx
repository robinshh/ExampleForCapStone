<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentResumeUpload.aspx.cs" Inherits="Lab3.StudentResumeUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Choose Text File to Upload"></asp:Label>
    <asp:FileUpload Id="fileUploadText" runat="server"></asp:FileUpload>
    <asp:Button ID="bttnUploadFile" runat="server" Text="Upload File" OnClick="bttnUpload_Click"  />
    <asp:Label ID="txtDisplay" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
