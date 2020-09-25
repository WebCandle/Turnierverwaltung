using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                txtDatumVon.Text = DateTime.Now.ToShortDateString();
                txtDatumBis.Text = DateTime.Now.ToShortDateString();
                CheckBxLstMannschaften.Items.Clear();
                List<Mannschaft> mannschaften = Mannschaft.GetAll();
                foreach (Mannschaft mannschaft in mannschaften)
                {
                    CheckBxLstMannschaften.Items.Add(new ListItem(mannschaft.Name, mannschaft.Mannschaft_ID.ToString()));
                }
                if (Request.QueryString["do"] == "entfernen")
                {
                    long turnier_id = long.Parse(Request.QueryString["item"]);
                    Turnier turnier = new Turnier(turnier_id);
                    turnier.Delete();
                    Response.Redirect("~/Turnierverwaltung.aspx", true);
                }
            }
            Render();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<Mannschaft> mannschaften = new List<Mannschaft>();
            foreach (ListItem item in CheckBxLstMannschaften.Items)
            {
                if(item.Selected)
                {
                    mannschaften.Add(new Mannschaft(long.Parse(item.Value)));
                }
            }
            Turnier turnier = new Turnier(txtVereinName.Text, Convert.ToDateTime(txtDatumVon.Text), Convert.ToDateTime(txtDatumBis.Text), txtAdresse.Text,mannschaften);
            turnier.Save();
            Response.Redirect("~/Turnierverwaltung.aspx",true);
        }
        private void Render()
        {
            Tbl.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();

            TableHeaderCell h1 = new TableHeaderCell();
            h1.Text = "Verein";
            header.Cells.Add(h1);
            TableHeaderCell h2 = new TableHeaderCell();
            h2.Text = "Adresse";
            header.Cells.Add(h2);

            TableHeaderCell h22 = new TableHeaderCell();
            h22.Text = "Mannschaften";
            header.Cells.Add(h22);

            TableHeaderCell h3 = new TableHeaderCell();
            h3.Text = "Von/Bis";
            header.Cells.Add(h3);
            TableHeaderCell h4 = new TableHeaderCell();
            h4.Text = "Spiele";
            header.Cells.Add(h4);
            TableHeaderCell h5 = new TableHeaderCell();
            h5.Text = "Entfernen";
            header.Cells.Add(h5);


            Tbl.Rows.Add(header);

            foreach (Turnier turnier in Turnier.GetAll())
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = turnier.VereinName;
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = turnier.Adresse;
                row.Cells.Add(cell2);
                TableCell cell3 = new TableCell();
                cell3.Text = "";
                foreach (Mannschaft mannschaft in turnier.Mannschaften)
                {
                    cell3.Text += mannschaft.Name+ "<br />";
                }
                row.Cells.Add(cell3);

                TableCell cell222 = new TableCell();
                cell222.Text = turnier.Datum_Von.ToShortDateString()+"/"+turnier.Datum_Bis.ToShortDateString();
                row.Cells.Add(cell222);

                HyperLink link1 = new HyperLink();
                link1.NavigateUrl = "~/Spiele.aspx?item=" + turnier.Turnier_ID.ToString();
                link1.Text = "Spiele";
                TableCell cell12 = new TableCell();
                cell12.Controls.Add(link1);
                row.Cells.Add(cell12);

                HyperLink link2 = new HyperLink();
                link2.NavigateUrl = "~/Turnierverwaltung.aspx?do=entfernen&item=" + turnier.Turnier_ID.ToString();
                link2.Text = "X";

                TableCell cell13 = new TableCell();
                cell13.Controls.Add(link2);
                row.Cells.Add(cell13);

                Tbl.Rows.Add(row);
            }
        }

        protected void Btn_XMLDownload_Click(object sender, EventArgs e)
        {

        }
    }
}