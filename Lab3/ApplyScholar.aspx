<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ApplyScholar.aspx.cs" Inherits="Lab3.ApplyScholar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Scholard" runat="server" Text="Scholarship Name:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ScholarshipNameList" runat="server" AutoPostBack="True" 
        DataSourceID="Scholarships" DataTextField="ScholarshipName" 
        DataValueField="ScholarshipID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Scholarships" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select ScholarshipID, ScholarshipName FROM Scholarship"></asp:SqlDataSource>
     <br />
        <asp:TextBox ID="Description" runat="server" PlaceHolder="Qualifications"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredText" runat="server" ControlToValidate="Description" Text="Required"></asp:RequiredFieldValidator>
     <br />
    <asp:Button ID="ApplyScholarship" runat="server" Text="Apply to Scholarship" OnClick="ApplyScholarship_Click"/>
    <asp:Label ID="Resulted" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
