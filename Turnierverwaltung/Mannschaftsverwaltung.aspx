<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Turnierverwaltung.Mannschaftsverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Mannschaftsverwaltung</h2>
    <h3>Hinzufügen oder Bearbeiten einer Turnier Mannschaft</h3>
    <asp:Label ID="Label1" runat="server" Text="Eine Sportart für die Mannschaft auswählen"></asp:Label>
    <br />
    <asp:DropDownList ID="Sportart" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Mannschaftsname:"></asp:Label>
    <br />
    <asp:TextBox ID="Txt_Name" runat="server"></asp:TextBox>
    <table style="width: 100%;" ID="personentbl" runat="server">
        <tr>
            <td style="width: 40%;">
                <asp:Label ID="Label3" runat="server" Text="Mitglieder der Mannschaft:"></asp:Label>
                <br />
                <asp:ListBox ID="LstBxM" runat="server" Width="100%" SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td style="width: 10%; text-align:center;">
                <asp:Button ID="Btn2" runat="server" Text=">" OnClick="Btn2_Click" />
            </td>
            <td style="width: 10%; text-align:center;">
                <asp:Button ID="Button1" runat="server" Text="<" OnClick="Button1_Click" />
            </td>
            <td style="width: 40%;">
                <asp:Label ID="Label4" runat="server" Text="verfügbare Personen:"></asp:Label>
                <br />
                <asp:ListBox ID="LstBxP" runat="server" Width="100%" SelectionMode="Multiple"></asp:ListBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="Btn_Add" runat="server" Text="Manschaft Hinzufügen" OnClick="Btn_add" />&nbsp;&nbsp;
    <asp:Button ID="Btn_Sichern" runat="server" Text="Sichern" Visible="false" OnClick="Btn_Sichern_Click" />&nbsp;&nbsp;
    <asp:Button ID="Btn_Abbrechen" runat="server" Text="Abbrechen" Visible="false" OnClick="Btn_Abbrechen_Click"/>
    <h2>verfügbare Mannschaften:</h2>
    <asp:Table ID="Tbl" runat="server" Width="100%" GridLines="Both">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Sportart</asp:TableHeaderCell>
            <asp:TableHeaderCell>Mitglieder</asp:TableHeaderCell>
            <asp:TableHeaderCell>Bearbeiten</asp:TableHeaderCell>
            <asp:TableHeaderCell>Entfernen</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
        <br />
    <asp:Button ID="Btn_XMLDownload" runat="server" Text="Als XML Herunterladen" OnClick="Btn_XMLDownload_Click"  />
</asp:Content>
