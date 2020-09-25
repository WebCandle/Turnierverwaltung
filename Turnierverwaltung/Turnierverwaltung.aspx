<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="Turnierverwaltung.Turnierverwaltung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Turnierverwaltung</h2>
    <asp:Panel ID="PnlVerwaltung" runat="server">
        <h3>Hinzufügen von Turnieren</h3>
        <asp:Label ID="Label1" runat="server" Text="Vereinsname"></asp:Label>
        <asp:TextBox ID="txtVereinName" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label6" runat="server" Text="Adresse"></asp:Label>
        <asp:TextBox ID="txtAdresse" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Datumraum"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Von"></asp:Label>
        <asp:TextBox TextMode="Date" ID="txtDatumVon" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Bis"></asp:Label>
        <asp:TextBox TextMode="Date" ID="txtDatumBis" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label5" runat="server" Text="Teilnehmende Mannschaften"></asp:Label><br />
        <asp:CheckBoxList ID="CheckBxLstMannschaften" runat="server"></asp:CheckBoxList><br />

        <asp:Button ID="btnAdd" runat="server" Text="Sichern" OnClick="btnAdd_Click" />
    </asp:Panel>
    <h2>verfügbare Mannschaften:</h2>
    <asp:Table ID="Tbl" runat="server" Width="100%" GridLines="Both">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Verein</asp:TableHeaderCell>
            <asp:TableHeaderCell>Adresse</asp:TableHeaderCell>
            <asp:TableHeaderCell>Mannschaften</asp:TableHeaderCell>
            <asp:TableHeaderCell>Von/Bis</asp:TableHeaderCell>
            <asp:TableHeaderCell>Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Entfernen</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Button ID="Btn_XMLDownload" runat="server" Text="Als XML Herunterladen" OnClick="Btn_XMLDownload_Click" />
</asp:Content>
