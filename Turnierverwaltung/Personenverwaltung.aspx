﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Turnierverwaltung.Personenverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Personenverwaltung</h1>
    <h2 style="font-weight:bold">Hinzufügen oder Bearbeiten von Personen</h2>
    <h1>Auswahl des Personen Typs:</h1>
    <asp:RadioButtonList ID="RadioButtonListPersonenType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListPersonenType_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="Fussballspieler">&nbsp;Fussballspieler</asp:ListItem>
        <asp:ListItem Value="Handballspieler">&nbsp;Handballspieler</asp:ListItem>
        <asp:ListItem Value="Tennisspieler">&nbsp;Tennisspieler</asp:ListItem>
        <asp:ListItem Value="anderer Spielertyp">&nbsp;Anderer Spielertyp(Spieler)</asp:ListItem>
        <asp:ListItem Value="Physiotherapeut">&nbsp;Physiotherapeut</asp:ListItem>
        <asp:ListItem Value="Trainer">&nbsp;Trainer</asp:ListItem>
        <asp:ListItem Value="Person mit anderen Aufgaben">&nbsp;Person mit anderen Aufgaben(Miarbeiter)</asp:ListItem>
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
                <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl1" runat="server" Text="Anzahl Spiele"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Lbl2" runat="server" Text="Geschossene Tore"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Lbl3" runat="server" Text="Spielposition"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt3" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="Sportart" runat="server" Visible="false"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <asp:Label ID="Lbl_Msg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Hinzufügen" OnClick="Button1_Click" />
    <br />
    <asp:Table ID="Tbl" runat="server" BorderStyle="Dotted" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Vorname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Geburtsdatum</asp:TableHeaderCell>
            <asp:TableHeaderCell>Sportart</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Erzielte Tore</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gewonnene Spiele</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Jahre</asp:TableHeaderCell>
            <asp:TableHeaderCell>Anzahl Vereine</asp:TableHeaderCell>
            <asp:TableHeaderCell>Einsatz Bereich</asp:TableHeaderCell>
            <asp:TableHeaderCell>Bearbeiten</asp:TableHeaderCell>
            <asp:TableHeaderCell>Entfernen</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

</asp:Content>
