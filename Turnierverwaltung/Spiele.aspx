<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spiele.aspx.cs" Inherits="Turnierverwaltung.Spiele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Spiele</h2>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td>Mannschaft</td>
                <td>Punkte</td>
                <td>gegen Mannschaft</td>
                <td>Punkte</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="lstmannschaft" runat="server" Font-Bold="True" EnableViewState="False"></asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="txtPunkte1" TextMode="Number" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="lstgegenmannschaft" runat="server" EnableViewState="False"></asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="txtPunkte2" TextMode="Number" runat="server"></asp:TextBox>

                </td>
            </tr>
        </table>
        <asp:Button ID="btnSichern" runat="server" Text="Sichern" OnClick="btnSichern_Click" />
    </asp:Panel>
    <br /><br />
        <asp:Table ID="Tbl" runat="server" Width="100%" GridLines="Both">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Mannschaft</asp:TableHeaderCell>
            <asp:TableHeaderCell>Punkte</asp:TableHeaderCell>
            <asp:TableHeaderCell>gegen Mannschaft</asp:TableHeaderCell>
            <asp:TableHeaderCell>Punkte</asp:TableHeaderCell>
            <asp:TableHeaderCell>Entfernen</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
