<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnierTabelle.aspx.cs" Inherits="Turnierverwaltung.TurnierTabelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Turnier-Tabelle</h1>
    <asp:Table ID="Tbl" runat="server" Width="100%" GridLines="Both">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Platz</asp:TableHeaderCell>
            <asp:TableHeaderCell>Mannschaft</asp:TableHeaderCell>
            <asp:TableHeaderCell>Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Siege</asp:TableHeaderCell>
            <asp:TableHeaderCell>Unentschieden</asp:TableHeaderCell>
            <asp:TableHeaderCell>Niederlage</asp:TableHeaderCell>
            <asp:TableHeaderCell>Tore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gegentore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Tordifferenz</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
