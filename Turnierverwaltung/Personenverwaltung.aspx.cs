using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung
{
    public partial class Personenverwaltung : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Sportart.Items.Clear();
            Sportart.Items.Add("Fussball");
            Sportart.Items.Add("Handball");
            Sportart.Items.Add("Tennis");

            Lbl_Msg.Visible = false;
            
            Render();


        }
        protected void RadioButtonListPersonenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListPersonenType.SelectedItem.Value == "Fussballspieler")
            {
                Lbl1.Text = "Anzahl Spiele";
                Lbl2.Text = "Geschossene Tore";
                Lbl2.Visible = true;
                Txt2.Visible = true;
                Lbl3.Visible = true;
                Txt3.Visible = true;
                Lbl3.Text = "Spielposition";
                Sportart.Visible = false;
            }
            else
            {

                if (RadioButtonListPersonenType.SelectedItem.Value == "Handballspieler")
                {
                    Lbl1.Text = "Anzahl Spiele";
                    Lbl2.Text = "	Geworfene Tore";
                    Lbl3.Text = "Einsatzbereich";
                    Lbl2.Visible = true;
                    Txt2.Visible = true;
                    Lbl3.Visible = true;
                    Txt3.Visible = true;
                }
                else if (RadioButtonListPersonenType.SelectedItem.Value == "Tennisspieler")
                {
                    Lbl1.Text = "Anzahl Spiele";
                    Lbl2.Text = "	Gewonnene Spiele";
                    Lbl2.Visible = true;
                    Txt2.Visible = true;
                    Lbl3.Visible = false;
                    Txt3.Visible = false;
                    Sportart.Visible = false;
                }
                else if (RadioButtonListPersonenType.SelectedItem.Value == "anderer Spielertyp")
                {
                    Lbl1.Text = "Anzahl Spiele";
                    Lbl2.Text = "Gewonnene Spiele";
                    Lbl2.Visible = true;
                    Txt2.Visible = true;
                    Lbl3.Visible = true;
                    Lbl3.Text = "Sportart";
                    Txt3.Visible = false;
                    Sportart.Visible = true;
                }
                else if (RadioButtonListPersonenType.SelectedItem.Value == "Physiotherapeut")
                {
                    Lbl1.Text = "Anzahl Jahre";
                    Lbl2.Visible = false;
                    Txt2.Visible = false;
                    Lbl3.Visible = true;
                    Sportart.Visible = true;
                    Lbl3.Text = "Sportart";
                    Txt3.Visible = false;
                }
                else if (RadioButtonListPersonenType.SelectedItem.Value == "Trainer")
                {
                    Lbl1.Text = "Anzahl Vereine";
                    Lbl2.Visible = false;
                    Txt2.Visible = false;
                    Txt3.Visible = false;
                    Lbl3.Text = "Sportart";
                    Lbl3.Visible = true;
                    Sportart.Visible = true;
                }
                else if (RadioButtonListPersonenType.SelectedItem.Value == "Person mit anderen Aufgaben")
                {
                    Lbl1.Text = "Aufgaben";
                    Lbl2.Visible = false;
                    Txt2.Visible = false;
                    Lbl3.Visible = true;
                    Lbl3.Text = "Sportart";
                    Sportart.Visible = true;
                    Txt3.Visible = false;
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonListPersonenType.SelectedItem.Value == "Fussballspieler")
            {
                FussballSpieler fussballSpieler = new FussballSpieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text), Txt3.Text);
                Lbl_Msg.Visible = true;
                Lbl_Msg.Text = "FussballSpieler wurde erfolgreich hinzugefügt!";
                Global.Personen.Add(fussballSpieler);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Handballspieler")
            {
                HandballSpieler handballSpieler = new HandballSpieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text), Txt3.Text);
                Global.Personen.Add(handballSpieler);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Tennisspieler")
            {
                TennisSpieler tennisSpieler = new TennisSpieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text));
                Global.Personen.Add(tennisSpieler);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "anderer Spielertyp")
            {
                Spieler spieler = new Spieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text), Sportart.Text);
                Global.Personen.Add(spieler);

            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Physiotherapeut")
            {
                Physiotherapeut physiotherapeut = new Physiotherapeut(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Sportart.Text);
                Global.Personen.Add(physiotherapeut);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Trainer")
            {
                Trainer trainer = new Trainer(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Sportart.Text);
                Global.Personen.Add(trainer);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Person mit anderen Aufgaben")
            {
                Mitarbeiter mitarbeiter = new Mitarbeiter(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Txt1.Text, Sportart.Text);
                Global.Personen.Add(mitarbeiter);
            }
            Txt_Name.Text = "";
            Txt_Vorname.Text = "";
            Txt1.Text = "";
            Txt2.Text = "";
            Txt3.Text = "";
            Render();
        }
        private void Render()
        {
            Tbl.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();

            TableHeaderCell h1 = new TableHeaderCell();
            h1.Text = "ID";
            header.Cells.Add(h1);
            TableHeaderCell h2 = new TableHeaderCell();
            h2.Text = "Name";
            header.Cells.Add(h2);
            TableHeaderCell h3 = new TableHeaderCell();
            h3.Text = "Vorname";
            header.Cells.Add(h3);
            TableHeaderCell h4 = new TableHeaderCell();
            h4.Text = "Geburtsdatum";
            header.Cells.Add(h4);
            TableHeaderCell h5 = new TableHeaderCell();
            h5.Text = "Sportart";
            header.Cells.Add(h5);
            TableHeaderCell h6 = new TableHeaderCell();
            h6.Text = "Anzahl Spiele";
            header.Cells.Add(h6);
            TableHeaderCell h7 = new TableHeaderCell();
            h7.Text = "Erzielte Tore";
            header.Cells.Add(h7);
            TableHeaderCell h8 = new TableHeaderCell();
            h8.Text = "Gewonnene Spiele";
            header.Cells.Add(h8);
            TableHeaderCell h9 = new TableHeaderCell();
            h9.Text = "Anzahl Jahre";
            header.Cells.Add(h9);
            TableHeaderCell h10 = new TableHeaderCell();
            h10.Text = "Anzahl Vereine";
            header.Cells.Add(h10);
            TableHeaderCell h11 = new TableHeaderCell();
            h11.Text = "Einsatz Bereich";
            header.Cells.Add(h11);
            TableHeaderCell h12 = new TableHeaderCell();
            h12.Text = "Bearbeiten";
            header.Cells.Add(h12);
            TableHeaderCell h13 = new TableHeaderCell();
            h13.Text = "Entfernen";
            header.Cells.Add(h13);

            Tbl.Rows.Add(header);

            int k = 0;
            foreach (Person p in Global.Personen)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = k.ToString(); k++;
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = p.Name;
                row.Cells.Add(cell2);
                TableCell cell3 = new TableCell();
                cell3.Text = p.Vorname;
                row.Cells.Add(cell3);
                TableCell cell4 = new TableCell();
                cell4.Text = p.Geburtsdatum.ToShortDateString();
                row.Cells.Add(cell4);

                if (p is FussballSpieler)
                {
                    TableCell cell5 = new TableCell();
                    cell5.Text = "FussballSpieler";
                    row.Cells.Add(cell5);
                    FussballSpieler f = p as FussballSpieler;
                    TableCell cell6 = new TableCell();
                    cell6.Text = f.Spiele.ToString();
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = "";
                    row.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Text = f.Tore.ToString();
                    row.Cells.Add(cell8);
                    TableCell cell9 = new TableCell();
                    cell9.Text = "";
                    row.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Text = "";
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Text = f.Position;
                    row.Cells.Add(cell11);
                }
                else if (p is HandballSpieler)
                {
                    TableCell cell5 = new TableCell();
                    cell5.Text = "HandballSpieler";
                    row.Cells.Add(cell5);
                    HandballSpieler h = p as HandballSpieler;
                    TableCell cell6 = new TableCell();
                    cell6.Text = h.Spiele.ToString();
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = h.Tore.ToString();
                    row.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Text = "";
                    row.Cells.Add(cell8);
                    TableCell cell9 = new TableCell();
                    cell9.Text = "";
                    row.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Text = "";
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Text = h.Position;
                    row.Cells.Add(cell11);
                }
                else if (p is TennisSpieler)
                {
                    TableCell cell5 = new TableCell();
                    cell5.Text = "TennisSpieler";
                    row.Cells.Add(cell5);
                    Spieler t = p as Spieler;
                    TableCell cell6 = new TableCell();
                    cell6.Text = t.Spiele.ToString();
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = "";
                    row.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Text = t.Tore.ToString();
                    row.Cells.Add(cell8);
                    TableCell cell9 = new TableCell();
                    cell9.Text = "";
                    row.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Text = "";
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Text = "";
                    row.Cells.Add(cell11);
                }
                else if (p is Physiotherapeut)
                {
                    Physiotherapeut ph = p as Physiotherapeut;
                    TableCell cell5 = new TableCell();
                    cell5.Text = ph.Sportart;
                    row.Cells.Add(cell5);
                    TableCell cell6 = new TableCell();
                    cell6.Text = "";
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = "";
                    row.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Text = "";
                    row.Cells.Add(cell8);
                    TableCell cell9 = new TableCell();
                    cell9.Text = "";
                    row.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Text = "";
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Text = "";
                    row.Cells.Add(cell11);
                }
                else if (p is Trainer)
                {
                    Trainer t = p as Trainer;
                    TableCell cell5 = new TableCell();
                    cell5.Text = t.Sportart;
                    row.Cells.Add(cell5);
                    TableCell cell6 = new TableCell();
                    cell6.Text = "";
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = "";
                    row.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Text = "";
                    row.Cells.Add(cell8);
                    TableCell cell9 = new TableCell();
                    cell9.Text = "";
                    row.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Text = "";
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Text = "";
                    row.Cells.Add(cell11);
                }
                else
                {
                    TableCell cell5 = new TableCell();
                    if (p is Spieler)
                        cell5.Text = "Spieler";
                    else if( p is Mitarbeiter)
                        cell5.Text = "Mitarbeiter";
                    row.Cells.Add(cell5);
                    TableCell cell6 = new TableCell();
                    cell6.Text = "";
                    row.Cells.Add(cell6);
                    TableCell cell7 = new TableCell();
                    cell7.Text = "";
                    row.Cells.Add(cell7);
                    TableCell cell8 = new TableCell();
                    cell8.Text = "";
                    row.Cells.Add(cell8);
                    TableCell cell9 = new TableCell();
                    cell9.Text = "";
                    row.Cells.Add(cell9);
                    TableCell cell10 = new TableCell();
                    cell10.Text = "";
                    row.Cells.Add(cell10);
                    TableCell cell11 = new TableCell();
                    cell11.Text = "";
                    row.Cells.Add(cell11);
                }

                TableCell cell12 = new TableCell();
                row.Cells.Add(cell12);

                TableCell cell13 = new TableCell();
                row.Cells.Add(cell13);

                Tbl.Rows.Add(row);
            }
        }
    }
}