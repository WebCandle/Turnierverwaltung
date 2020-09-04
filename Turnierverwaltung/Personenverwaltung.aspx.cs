using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace Turnierverwaltung
{
    public partial class Personenverwaltung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth"] == null || !(bool)Session["auth"])
            {
                Session["redirect"] = "~/Personenverwaltung.aspx";
                Response.Redirect("~/Login.aspx", true);
            }
            else
            {
                if(Has_Permission("admin"))
                {
                    PnlVerwaltung.Visible = true;
                    if (Page.IsCallback == false)
                    {
                        if (Request.QueryString["do"] == "entfernen")
                        {
                            int item = Convert.ToInt32(Request.QueryString["item"]);
                            Global.Personen.RemoveAt(item);
                            Response.Redirect("~/Personenverwaltung.aspx");
                        }
                        else if (Request.QueryString["do"] == "bearbeiten")
                        {
                            RadioButtonListPersonenType.Visible = false;
                            lblTitle.Visible = false;
                            Btn_Add.Visible = false;
                            Btn_Bearbeiten.Visible = true;
                            Btn_Cancel.Visible = true;
                            int item = Convert.ToInt32(Request.QueryString["item"]);
                            Person person = Global.Personen.ElementAt(item);
                            if (person is FussballSpieler)
                            {
                                RenderFussballForm();
                                FussballSpieler s = person as FussballSpieler;
                                Txt1.Text = s.Spiele.ToString();
                                Txt2.Text = s.Tore.ToString();
                                Txt3.Text = s.Position;
                            }
                            else if (person is HandballSpieler)
                            {
                                RenderHandballForm();
                                HandballSpieler s = person as HandballSpieler;
                                Txt1.Text = s.Spiele.ToString();
                                Txt2.Text = s.Tore.ToString();
                                Txt3.Text = s.Position;
                            }
                            else if (person is TennisSpieler)
                            {
                                RenderTennisForm();
                                TennisSpieler s = person as TennisSpieler;
                                Txt1.Text = s.Spiele.ToString();
                                Txt2.Text = s.Tore.ToString();
                            }
                            else if (person is Spieler)
                            {
                                RenderSpielerForm();
                                Spieler s = person as Spieler;
                                Txt1.Text = s.Spiele.ToString();
                                Txt2.Text = s.Tore.ToString();
                                Sportart.Text = s.Sportart;
                            }
                            else if (person is Mitarbeiter)
                            {
                                RenderMitarbeiterForm();
                                Mitarbeiter m = person as Mitarbeiter;
                                Txt1.Text = m.Aufgabe;
                                Sportart.Text = m.Sportart;
                            }
                            else if (person is Physiotherapeut)
                            {
                                RenderPhysiotherapeutForm();
                                Physiotherapeut ph = person as Physiotherapeut;
                                Txt1.Text = ph.Jahre.ToString();
                                Sportart.Text = ph.Sportart;
                            }
                            else if (person is Trainer)
                            {
                                RenderTrainerForm();
                                Trainer t = person as Trainer;
                                Txt1.Text = t.Vereine.ToString();
                                Sportart.Text = t.Sportart;
                            }
                            Txt_Name.Text = person.Name;
                            Txt_Vorname.Text = person.Vorname;
                            Txt_Datum.Text = person.Geburtsdatum.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            RadioButtonListPersonenType.Visible = true;
                            lblTitle.Visible = true;
                            Btn_Add.Visible = true;
                            Btn_Bearbeiten.Visible = false;
                            Btn_Cancel.Visible = false;
                        }

                        Sportart.Items.Clear();
                        Sportart.Items.Add("Fussball");
                        Sportart.Items.Add("Handball");
                        Sportart.Items.Add("Tennis");
                        Txt_Datum.Text = DateTime.Now.ToString("yyyy-MM-dd"); ;
                    }
                }
                else
                {
                    PnlVerwaltung.Visible = false;
                }
    
                Lbl_Msg.Visible = false;

                Render();
            }
        }
        protected void RenderFussballForm()
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
        protected void RenderHandballForm()
        {
            Lbl1.Text = "Anzahl Spiele";
            Lbl2.Text = "	Geworfene Tore";
            Lbl3.Text = "Einsatzbereich";
            Lbl2.Visible = true;
            Txt2.Visible = true;
            Lbl3.Visible = true;
            Txt3.Visible = true;
        }
        protected void RenderTennisForm()
        {
            Lbl1.Text = "Anzahl Spiele";
            Lbl2.Text = "	Gewonnene Spiele";
            Lbl2.Visible = true;
            Txt2.Visible = true;
            Lbl3.Visible = false;
            Txt3.Visible = false;
            Sportart.Visible = false;
        }
        protected void RenderSpielerForm()
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
        protected void RenderPhysiotherapeutForm()
        {
            Lbl1.Text = "Anzahl Jahre";
            Lbl2.Visible = false;
            Txt2.Visible = false;
            Lbl3.Visible = true;
            Sportart.Visible = true;
            Lbl3.Text = "Sportart";
            Txt3.Visible = false;
        }
        protected void RenderTrainerForm()
        {
            Lbl1.Text = "Anzahl Vereine";
            Lbl2.Visible = false;
            Txt2.Visible = false;
            Txt3.Visible = false;
            Lbl3.Text = "Sportart";
            Lbl3.Visible = true;
            Sportart.Visible = true;
        }
        protected void RenderMitarbeiterForm()
        {
            Lbl1.Text = "Aufgaben";
            Lbl2.Visible = false;
            Txt2.Visible = false;
            Lbl3.Visible = true;
            Lbl3.Text = "Sportart";
            Sportart.Visible = true;
            Txt3.Visible = false;
        }
        protected void RadioButtonListPersonenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListPersonenType.SelectedItem.Value == "Fussballspieler")
            {
                RenderFussballForm();
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Handballspieler")
            {
                RenderHandballForm();
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Tennisspieler")
            {
                RenderTennisForm();
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "anderer Spielertyp")
            {
                RenderSpielerForm();
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Physiotherapeut")
            {
                RenderPhysiotherapeutForm();
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Trainer")
            {
                RenderTrainerForm();
            }
            else if (RadioButtonListPersonenType.SelectedItem.Value == "Person mit anderen Aufgaben")
            {
                RenderMitarbeiterForm();
            }

        }
        public bool Has_Permission(string rolle)
        {
            return (string)Session["rolle"] == rolle;
        }
        public void Access_Denied()
        {
            string script = string.Format("alert('{0}');", "Sie haben keine Berichtigung!");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if(Has_Permission("admin"))
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
                Response.Redirect("~/Personenverwaltung.aspx");
            }
            else
            {
                Access_Denied();
            }
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
                cell1.Text = k.ToString();
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
                    TennisSpieler t = p as TennisSpieler;
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
                    else if (p is Mitarbeiter)
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

                HyperLink link1 = new HyperLink();
                link1.NavigateUrl = "~/Personenverwaltung.aspx?do=bearbeiten&item=" + k;
                link1.Text = "Berabeiten";
                TableCell cell12 = new TableCell();
                cell12.Controls.Add(link1);
                row.Cells.Add(cell12);

                HyperLink link2 = new HyperLink();
                link2.NavigateUrl = "~/Personenverwaltung.aspx?do=entfernen&item=" + k;
                link2.Text = "Entfernen";

                TableCell cell13 = new TableCell();
                cell13.Controls.Add(link2);
                row.Cells.Add(cell13);

                Tbl.Rows.Add(row);
                k++;
            }
        }

        protected void Btn_Bearbeiten_Click(object sender, EventArgs e)
        {
            if(Has_Permission("admin"))
            {
                int item = Convert.ToInt32(Request.QueryString["item"]);
                Person person = Global.Personen.ElementAt(item);
                if (person is FussballSpieler)
                {
                    FussballSpieler s = person as FussballSpieler;
                    s.Spiele = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt1"]);
                    s.Tore = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt2"]);
                    s.Position = Request.Form["ctl00$MainContent$Txt3"];
                }
                else if (person is HandballSpieler)
                {
                    HandballSpieler s = person as HandballSpieler;
                    s.Spiele = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt1"]);
                    s.Tore = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt2"]);
                    s.Position = Request.Form["ctl00$MainContent$Txt3"];
                }
                else if (person is TennisSpieler)
                {
                    TennisSpieler s = person as TennisSpieler;
                    s.Spiele = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt1"]);
                    s.Tore = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt2"]);
                }
                else if (person is Spieler)
                {
                    Spieler s = person as Spieler;
                    s.Spiele = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt1"]);
                    s.Tore = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt2"]);
                    s.Sportart = Request.Form["ctl00$MainContent$Sportart"];
                }
                else if (person is Mitarbeiter)
                {
                    RenderMitarbeiterForm();
                    Mitarbeiter m = person as Mitarbeiter;
                    m.Aufgabe = Request.Form["ctl00$MainContent$Txt1"];
                    m.Sportart = Request.Form["ctl00$MainContent$Sportart"];
                }
                else if (person is Physiotherapeut)
                {
                    RenderPhysiotherapeutForm();
                    Physiotherapeut ph = person as Physiotherapeut;
                    ph.Jahre = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt1"]);
                    Sportart.Text = Request.Form["ctl00$MainContent$Sportart"];
                }
                else if (person is Trainer)
                {
                    RenderTrainerForm();
                    Trainer t = person as Trainer;
                    t.Vereine = Convert.ToInt32(Request.Form["ctl00$MainContent$Txt1"]);
                    t.Sportart = Request.Form["ctl00$MainContent$Sportart"];
                }
                person.Name = Request.Form["ctl00$MainContent$Txt_Name"];
                person.Vorname = Request.Form["ctl00$MainContent$Txt_Vorname"];
                person.Geburtsdatum = Convert.ToDateTime(Request.Form["ctl00$MainContent$Txt_Datum"]);
                Response.Redirect("~/Personenverwaltung.aspx");
            }
            else
            {
                Access_Denied();
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personenverwaltung.aspx");
        }

        protected void Btn_XMLDownload_Click(object sender, EventArgs e)
        {
            Turnier turnier = new Turnier(Global.Personen);
            XmlSerializer SR = new XmlSerializer(typeof(Turnier));
            FileStream FS = new FileStream(Server.MapPath("~/Files")+"/Personen.xml", FileMode.Create);
            SR.Serialize(FS, turnier);
            FS.Close();
            Response.Redirect("~/Files/Personen.xml");
        }
    }
}