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
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["auth"] == null || !(bool)Session["auth"])
            {
                Session["redirect"] = "~/Mannschaftsverwaltung.aspx";
                Response.Redirect("~/Login.aspx", true);
            }
            else
            {
                if(Has_Permission("admin"))
                {
                    PnlVerwaltung.Visible = true;
                    if (Page.IsPostBack == false)
                    {
                        Sportart.Items.Clear();
                        Sportart.Items.Add("Fussball");
                        Sportart.Items.Add("Handball");
                        Sportart.Items.Add("Tennis");

                        int k = 0;
                        LstBxP.Items.Clear();
                        foreach (var person in Global.Personen)
                        {
                            ListItem item = new ListItem(person.Name, k.ToString());
                            LstBxP.Items.Add(item);
                            k++;
                        }

                        if (Request.QueryString["do"] == "entfernen")
                        {
                            int item = Convert.ToInt32(Request.QueryString["item"]);
                            Global.Mannschaften.RemoveAt(item);
                            Response.Redirect("~/Mannschaftsverwaltung.aspx");
                        }
                        else if (Request.QueryString["do"] == "bearbeiten")
                        {
                            personentbl.Visible = false;
                            Mannschaft mannschaft = Global.Mannschaften.ElementAt(Convert.ToInt32(Request.QueryString["item"]));
                            Txt_Name.Text = mannschaft.Name;
                            Sportart.Text = mannschaft.Sportart;

                            Btn_Add.Visible = false;
                            Btn_Sichern.Visible = true;
                            Btn_Abbrechen.Visible = true;
                        }
                        else
                        {
                            personentbl.Visible = true;
                            Btn_Add.Visible = true;
                            Btn_Sichern.Visible = false;
                            Btn_Abbrechen.Visible = false;
                        }
                    }
                }
                else
                {
                    PnlVerwaltung.Visible = false;
                }
        

                Render();
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

            TableHeaderCell h22 = new TableHeaderCell();
            h22.Text = "Sportart";
            header.Cells.Add(h22);

            TableHeaderCell h3 = new TableHeaderCell();
            h3.Text = "Mitglieder";
            header.Cells.Add(h3);
            TableHeaderCell h4 = new TableHeaderCell();
            h4.Text = "Bearbeiten";
            header.Cells.Add(h4);
            TableHeaderCell h5 = new TableHeaderCell();
            h5.Text = "Entfernen";
            header.Cells.Add(h5);


            Tbl.Rows.Add(header);

            int k = 0;
            foreach (Mannschaft m in Global.Mannschaften)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = k.ToString();
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = m.Name;
                row.Cells.Add(cell2);
                TableCell cell22 = new TableCell();
                cell22.Text = m.Sportart;
                row.Cells.Add(cell22);
                TableCell cell3 = new TableCell();
                cell3.Text = "";
                foreach (Person person in m.Mitglieder)
                {
                    cell3.Text += person.Name+"<br />";
                }
                row.Cells.Add(cell3);

                HyperLink link1 = new HyperLink();
                link1.NavigateUrl = "~/Mannschaftsverwaltung.aspx?do=bearbeiten&item=" + k;
                link1.Text = "Berabeiten";
                TableCell cell12 = new TableCell();
                cell12.Controls.Add(link1);
                row.Cells.Add(cell12);

                HyperLink link2 = new HyperLink();
                link2.NavigateUrl = "~/Mannschaftsverwaltung.aspx?do=entfernen&item=" + k;
                link2.Text = "Entfernen";

                TableCell cell13 = new TableCell();
                cell13.Controls.Add(link2);
                row.Cells.Add(cell13);

                Tbl.Rows.Add(row);
                k++;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LstBxM.Items.Add(LstBxP.SelectedItem);
            LstBxP.Items.Remove(LstBxP.SelectedItem);
        }

        protected void Btn2_Click(object sender, EventArgs e)
        {
            LstBxP.Items.Add(LstBxM.SelectedItem);
            LstBxM.Items.Remove(LstBxM.SelectedItem);
        }

        protected void Btn_add(object sender, EventArgs e)
        {
            if(Has_Permission("admin"))
            {
                Mannschaft mannschaft = new Mannschaft();
                mannschaft.Name = Txt_Name.Text;
                mannschaft.Sportart = Sportart.Text;
                foreach (ListItem item in LstBxM.Items)
                {
                    Person person = Global.Personen.ElementAt(Convert.ToInt32(item.Value));
                    mannschaft.MitgliedAnnehmen(person);
                }
                Global.Mannschaften.Add(mannschaft);
                Render();
            }
            else
            {
                Access_Denied();
            }
        }
        protected void Btn_Abbrechen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mannschaftsverwaltung.aspx");
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
        protected void Btn_Sichern_Click(object sender, EventArgs e)
        {
            if (Has_Permission("admin"))
            {
                Mannschaft mannschaft = Global.Mannschaften.ElementAt(Convert.ToInt32(Request.QueryString["item"]));
                mannschaft.Name = Request.Form["ctl00$MainContent$Txt_Name"];
                mannschaft.Sportart = Request.Form["ctl00$MainContent$Sportart"];
                Response.Redirect("~/Mannschaftsverwaltung.aspx");
            }
            else
            {
                Access_Denied();
            }
        }
        protected void Btn_XMLDownload_Click(object sender, EventArgs e)
        {
            Turnier turnier = new Turnier(Global.Mannschaften);
            XmlSerializer SR = new XmlSerializer(typeof(Turnier));
            string name = Server.MapPath("~/Files") + "/Personen.xml";
            FileStream FS = new FileStream(name, FileMode.Create);
            SR.Serialize(FS, turnier);
            FS.Close();
            Response.Redirect("~/Files/Personen.xml");
            //Response.AddHeader("Content-Disposition", "attachment; filename="+name);
        }
    }
}