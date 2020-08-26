<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Turnierverwaltung.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblMsg" runat="server" Text="Falsches Kennwort oder Benutzer!" Visible="False" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
    <asp:Login ID="LoginMaske" runat="server" OnAuthenticate="Login_Authenticate"></asp:Login>
</asp:Content>
