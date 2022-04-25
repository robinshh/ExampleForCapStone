<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ApplyJob.aspx.cs" Inherits="Lab3.ApplyJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
            <asp:Label ID="Jobed" runat="server" Text="Job Name:"></asp:Label>
    &nbsp;<asp:DropDownList ID="JobNameList" runat="server" AutoPostBack="True" DataSourceID="Jobs" DataTextField="InternshipDescription" DataValueField="JobID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Jobs" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select JobID, InternshipDescription from Job"></asp:SqlDataSource>
     <br />
        <asp:TextBox ID="Description" runat="server" PlaceHolder="Qualifications"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredText" runat="server" ControlToValidate="Description" Text="Required"></asp:RequiredFieldValidator>
     <br />
    <asp:Button ID="ApplyJobs" runat="server" Text="Apply to Job" OnClick="ApplyJobs_Click"/>
    <asp:Label ID="Results" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
