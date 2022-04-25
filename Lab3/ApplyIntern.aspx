<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ApplyIntern.aspx.cs" Inherits="Lab3.ApplyIntern" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Interned" runat="server" Text="Internship Name:"></asp:Label>
    &nbsp;<asp:DropDownList ID="InternshipNameList" runat="server" AutoPostBack="True" DataSourceID="Internds" DataTextField="InternshipTitle" DataValueField="InternshipID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Internds" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select InternshipID, InternshipTitle FROM Internship"></asp:SqlDataSource>
     <br />
        <asp:TextBox ID="Description" runat="server" PlaceHolder="Qualifications"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredText" runat="server" ControlToValidate="Description" Text="Required"></asp:RequiredFieldValidator>
     <br />
    <asp:Button ID="ApplyInterns" runat="server" Text="Apply to Internship" OnClick="ApplyIntern_Click"/>

    <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
