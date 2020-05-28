<%@ Page Title="Personenverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Turnierverwaltung.Personenverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Personenverwaltung</h1>
    <h2 style="font-weight:bold">Hinzufügen oder Bearbeiten von Personen</h2>
    <h1>Auswahl des Personen Typs:</h1>
    <asp:RadioButtonList ID="RadioButtonListPersonenType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="changed">
        <asp:ListItem Selected="True">Fussballspieler</asp:ListItem>
        <asp:ListItem>Handballspieler</asp:ListItem>
        <asp:ListItem>Tennisspieler</asp:ListItem>
        <asp:ListItem Value="anderer Spielertyp">anderer Spielertyp</asp:ListItem>
        <asp:ListItem>Physiotherapeut</asp:ListItem>
        <asp:ListItem>Trainer</asp:ListItem>
        <asp:ListItem>Person mit anderen Aufgaben</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <div>
        <table style="width: 100%;">
            <tr>
                <td><asp:Label ID="Lbl_Vorname" runat="server" Text="Vorname"></asp:Label></td>
                <td><asp:TextBox ID="Txt_Vorname" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="Lbl_Name" runat="server" Text="Name"></asp:Label></td>
                <td><asp:TextBox ID="Txt_Name" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="Lbl_Datum" runat="server" Text="Geburtsdatum"></asp:Label></td>
                <td><asp:TextBox ID="Txt_Datum" runat="server" TextMode="Date"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl_Anzahl_Spiele" runat="server" Text="Anzahl Spiele"></asp:Label>
                    <asp:Label ID="Lbl_Anzahl_Jahre" runat="server" Text="Anzahl Jahre" Visible="False"></asp:Label>
                    <asp:Label ID="Lbl_Anzahl_Vereine" runat="server" Text="Anzahl Vereine" Visible="False"></asp:Label>
                    <asp:Label ID="Lbl_Aufgabe" runat="server" Text="Aufgabe" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt_Anzahl_Spiele" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Txt_Anzahl_Jahre" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="Txt_Anzahl_Vereine" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="Txt_Aufgabe" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Lbl_Geschossene_Tore" runat="server" Text="Geschossene Tore"></asp:Label>
                    <asp:Label ID="Lbl_Geworfene_Tore" runat="server" Text="Geworfene Tore" Visible="False"></asp:Label>
                    <asp:Label ID="Lbl_Gewonnene_Spiele" runat="server" Text="Gewonnene Spiele" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt_Geschossene_Tore" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Txt_Geworfene_Tore" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="Txt_Gewonnene_Spiele" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Lbl_Spielposition" runat="server" Text="Spielposition"></asp:Label>
                    <asp:Label ID="Lbl_Einsatzbereich" runat="server" Text="Einsatzbereich" Visible="False"></asp:Label>
                    <asp:Label ID="Lbl_Sportart" runat="server" Text="Sportart" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt_Spielposition" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Txt_Einsatzbereich" runat="server" Visible="False"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList_Sportart" runat="server" Visible="false"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
