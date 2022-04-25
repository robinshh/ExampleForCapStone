<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AwardWinners.aspx.cs" Inherits="Lab3.AwardWinners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblWinners" runat="server" Text="Winners"></asp:Label>
    <asp:GridView ID="EventTable" runat="server" DataSourceID="sqlsrc" allowsorting="true"  AutoGenerateColumns="false" Width="1093px">
            <Columns>
                <asp:BoundField  HeaderText="Winner" DataField="FullName" SortExpression="FullName" />
                <asp:BoundField HeaderText="Award" DataField="ScholarshipName" SortExpression="ScholarshipName" />
                <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# "/Images/" + Eval("Image")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
        </Columns>
            </asp:GridView>
        <asp:SqlDataSource ID="sqlsrc" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
            SelectCommand="Select Stu.FirstName+' '+Stu.LastName AS FullName,Sco.ScholarshipName,Stu.Image FROM Student Stu, Scholarship Sco, StudentAward Sa WHERE Stu.StudentID=sa.StudentID AND sa.ScholarshipID=Sco.ScholarshipID">
        </asp:SqlDataSource>
</asp:Content>
