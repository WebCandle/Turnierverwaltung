using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung
{
    public partial class TurnierTabelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long turnier_id = long.Parse(Request.QueryString["item"]);
            if( turnier_id > 0)
            {
                Turnier turnier = new Turnier(turnier_id);
                foreach (Mannschaft mannschaft in turnier.Mannschaften)
                {
                    TableRow row = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Text = mannschaft.Name;
                    row.Cells.Add(c1);
                    Tbl.Rows.Add(row);
                    //
                }
            }
            
        }
        private void Render()
        {
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
                    cell3.Text += mannschaft.Name + "<br />";
                }
                row.Cells.Add(cell3);

                TableCell cell222 = new TableCell();
                cell222.Text = turnier.Datum_Von.ToShortDateString() + "/" + turnier.Datum_Bis.ToShortDateString();
                row.Cells.Add(cell222);

                HyperLink link1 = new HyperLink();
                link1.NavigateUrl = "~/Spiele.aspx?item=" + turnier.Turnier_ID.ToString();
                link1.Text = "Spiele";
                HyperLink link12 = new HyperLink();
                link12.NavigateUrl = "~/TurnierTabelle.aspx?item=" + turnier.Turnier_ID.ToString();
                link12.Text = "Tabelle";
                Label l = new Label();
                l.Text = " / ";
                TableCell cell12 = new TableCell();
                cell12.Controls.Add(link1);
                cell12.Controls.Add(l);
                cell12.Controls.Add(link12);
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
    }
}