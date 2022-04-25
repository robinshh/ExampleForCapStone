<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateScholarship.aspx.cs" Inherits="Lab3.CreateScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
  Scholarship Name:
            <asp:TextBox ID="scholarnametxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="scholarnametxt" Text="Required"></asp:RequiredFieldValidator>
            <br />    
    <br />
            Scholarship Year:
            <asp:TextBox ID="yeartxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="yeartxt" Text="Required"></asp:RequiredFieldValidator>
            &nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Out of Range (2022-2026)" ControlToValidate="yeartxt" MinimumValue="2022" MaximumValue="2026" Type="double"></asp:RangeValidator>
            <br />
        <br />
            ScholarshipAmount:
            <asp:TextBox ID="amounttxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="amounttxt" Text="Required"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Out of Range" ControlToValidate="amounttxt" MinimumValue="0" MaximumValue="10000000000000000000000000" Type="double"></asp:RangeValidator>        
    <br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="MemberName"></asp:Label>
    <asp:DropDownList ID="MemberList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="FullName" DataValueField="MemberID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select MemberID, FirstName + ' '+ LastName As FullName from Member"></asp:SqlDataSource>
        
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateJobs" runat="server" Text="Create" OnClick="CreateJobs_Click" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
