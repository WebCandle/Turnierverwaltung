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

            if (Session["Personen"] == null)
            {
                Session["Personen"] = new List<Person>();
            }

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
                }
                else if (RadioButtonListPersonenType.SelectedItem.Value == "Trainer")
                {
                    Lbl1.Text = "Anzahl Vereine";
                    Lbl2.Visible = false;
                    Txt2.Visible = false;
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
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonListPersonenType.SelectedItem.Value == "Fussballspieler")
            {
                FussballSpieler fussballSpieler = new FussballSpieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text), Txt3.Text);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Handballspieler")
            {
                HandballSpieler handballSpieler = new HandballSpieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text), Txt3.Text);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Tennisspieler")
            {
                TennisSpieler tennisSpieler = new TennisSpieler(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Convert.ToInt32(Txt2.Text));
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "anderer Spielertyp")
            {
                //Lbl1.Text = "Anzahl Spiele";
                //Lbl2.Text = "Gewonnene Spiele";
                //Lbl2.Visible = true;
                //Txt2.Visible = true;
                //Lbl3.Visible = true;
                //Lbl3.Text = "Sportart";
                //Sportart.Visible = true;
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Physiotherapeut")
            {
                Physiotherapeut physiotherapeut = new Physiotherapeut(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Txt3.Text);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Trainer")
            {
                Trainer trainer = new Trainer(Txt_Name.Text, Txt_Vorname.Text, Convert.ToDateTime(Txt_Datum.Text), Geschlecht.Maenlich, Convert.ToInt32(Txt1.Text), Txt3.Text);
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Person mit anderen Aufgaben")
            {
                //Lbl1.Text = "Aufgaben";
                //Lbl2.Visible = false;
                //Txt2.Visible = false;
                //Lbl3.Visible = true;
                //Lbl3.Text = "Sportart";
                //Sportart.Visible = true;
            }

        }
    }
}