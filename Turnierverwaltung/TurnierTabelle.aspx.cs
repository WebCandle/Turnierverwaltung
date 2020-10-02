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
            if(Request.QueryString["item"] != null)
            {
                long turnier_id = long.Parse(Request.QueryString["item"]);
                if (turnier_id > 0)
                {
                    Turnier turnier = new Turnier(turnier_id);
                    lblTurnierName.Text = turnier.VereinName;
                    TTabelle tabelle = turnier.getTabelle();
                    int platz = 1;
                    foreach (TRow trow in tabelle.Rows)
                    {
                        TableRow row = new TableRow();
                        //
                        TableCell c1 = new TableCell();
                        c1.Text = platz.ToString();
                        row.Cells.Add(c1);
                        //
                        TableCell c2 = new TableCell();
                        c2.Text = trow.Mannschaft.Name;
                        row.Cells.Add(c2);
                        //
                        TableCell c3 = new TableCell();
                        c3.Text = trow.Spiele.ToString();
                        row.Cells.Add(c3);
                        //
                        TableCell c4 = new TableCell();
                        c4.Text = trow.Siege.ToString();
                        row.Cells.Add(c4);
                        //
                        TableCell c5 = new TableCell();
                        c5.Text = trow.Unentschieden.ToString();
                        row.Cells.Add(c5);
                        //
                        TableCell c6 = new TableCell();
                        c6.Text = trow.Niederlagen.ToString();
                        row.Cells.Add(c6);
                        //
                        TableCell c7 = new TableCell();
                        c7.Text = trow.Tore.ToString();
                        row.Cells.Add(c7);
                        //
                        TableCell c8 = new TableCell();
                        c8.Text = trow.gegenTore.ToString();
                        row.Cells.Add(c8);
                        //
                        TableCell c9 = new TableCell();
                        c9.Text = trow.Tordifferenz.ToString();
                        row.Cells.Add(c9);
                        //
                        Tbl.Rows.Add(row);
                        platz++;
                    }
                }

            }
            else
            {
                Response.Redirect("~/Turnierverwaltung.aspx", true);
            }
        }
    }
}