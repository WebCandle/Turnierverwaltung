<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="Turnierverwaltung.AddPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Timer ID="Timer1" runat="server"></asp:Timer>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label runat="server" Text="Name" ></asp:Label><br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label1" runat="server" Text="Alt"></asp:Label><br />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox><br />
        <asp:Button ID="btnAdd" runat="server" Text="Hinzufügen" />
    </asp:Panel>
</asp:Content>
