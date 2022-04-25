<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="Scholarship.aspx.cs" Inherits="Lab3.Scholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
        <asp:Label ID="JobName" runat="server" Text="Scholarship Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ScholarList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="ScholarshipName" DataValueField="ScholarshipID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select ScholarshipID, ScholarshipName from Scholarship"></asp:SqlDataSource>
        <br />
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
        Scholarship Name:
            <asp:TextBox ID="scholarnametxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="scholarnametxt" Text="Required"></asp:RequiredFieldValidator>
    <br />
            Scholarship Year:
            <asp:TextBox ID="yeartxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="yeartxt" Text="Required"></asp:RequiredFieldValidator>
            &nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Out of Range (2022-2026)" ControlToValidate="yeartxt" MinimumValue="2022" MaximumValue="2026" Type="double"></asp:RangeValidator>
            <br />
            ScholarshipAmount:
            <asp:TextBox ID="amounttxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="amounttxt" Text="Required"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Out of Range" ControlToValidate="amounttxt" MinimumValue="0" MaximumValue="10000000000000000000000000" Type="double"></asp:RangeValidator>        
    <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="CreateScholar" runat="server" Text="Create" OnClick="CreateJob_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />


</asp:Content>


