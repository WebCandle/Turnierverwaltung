﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung
{
    public partial class Spiele : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["item"] == null)
            {
                Response.Redirect("~/Turnierverwaltung.aspx", true);
            }

            if (!Page.IsPostBack)
            {
                lstmannschaft.Items.Clear();
                lstgegenmannschaft.Items.Clear();
                List<Mannschaft> mannschaften = Mannschaft.GetAll();
                foreach (Mannschaft mannschaft in mannschaften)
                {
                    ListItem listItem1 = new ListItem(mannschaft.Sportart + " - " + mannschaft.Name, mannschaft.Mannschaft_ID.ToString());
                    lstmannschaft.Items.Add(listItem1);
                    ListItem listItem2 = new ListItem(mannschaft.Sportart + " - " + mannschaft.Name, mannschaft.Mannschaft_ID.ToString());
                    lstgegenmannschaft.Items.Add(listItem2);
                }
                if (Request.QueryString["do"] == "bearbeiten")
                {
                    long spiel_id = long.Parse(Request.QueryString["spiel"]);
                    Spiel spiel = new Spiel(spiel_id);
                    txtPunkte1.Text = spiel.Punkte.ToString();
                    txtPunkte2.Text = spiel.Gegen_Punkte.ToString();
                    //ddLstMannschaft2.SelectedIndex = ddLstMannschaft2.Items.IndexOf(ddLstMannschaft2.Items.FindByValue(spiel.Gegen_Mannschaft_ID.ToString()));
                    //ddLstMannschaft1.SelectedIndex = ddLstMannschaft1.Items.IndexOf(ddLstMannschaft1.Items.FindByValue(spiel.Mannschaft_ID.ToString()));

                    lstmannschaft.Items.FindByValue(spiel.Mannschaft_ID.ToString()).Selected = true;
                    lstgegenmannschaft.Items.FindByValue(spiel.Gegen_Mannschaft_ID.ToString()).Selected = true;
                }
                else if(Request.QueryString["do"] == "entfernen")
                {
                    long turnier_id = long.Parse(Request.QueryString["item"]);
                    long spiel_id = long.Parse(Request.QueryString["spiel"]);
                    Turnier turnier = new Turnier(turnier_id);
                    if (turnier.Turnier_ID != 0 && spiel_id != 0)
                    {
                        turnier.DeleteSpiel(spiel_id);
                    }
                    Response.Redirect("~/Spiele.aspx?item=" + Request.QueryString["item"]);
                }
            }
            Render();
        }

        protected void btnSichern_Click(object sender, EventArgs e)
        {
            long turnier_id = Convert.ToInt32(Request.QueryString["item"]);
            Turnier turnier = new Turnier(turnier_id);
            if(turnier.Turnier_ID != 0)
            {
                if (Request.QueryString["do"] == "bearbeiten")
                {
                    long spiel_id = long.Parse(Request.QueryString["spiel"]);
                    if( spiel_id > 0)
                    {
                        Spiel spiel = new Spiel(spiel_id);
                        spiel.Punkte = Convert.ToInt32(txtPunkte1.Text);
                        spiel.Gegen_Punkte = Convert.ToInt32(txtPunkte2.Text);
                        spiel.Save();
                    }
                }
                else
                {
                    Spiel spiel = new Spiel(turnier_id, Convert.ToInt32(lstmannschaft.SelectedItem.Value), Convert.ToInt32(txtPunkte1.Text), Convert.ToInt32(lstgegenmannschaft.SelectedItem.Value), Convert.ToInt32(txtPunkte2.Text));
                    spiel.Save();
                }
                Render();
            }
        }
        private void Render()
        {
            Tbl.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();

            TableHeaderCell h1 = new TableHeaderCell();
            h1.Text = "Mannschaft";
            header.Cells.Add(h1);
            TableHeaderCell h2 = new TableHeaderCell();
            h2.Text = "Punkte";
            header.Cells.Add(h2);

            TableHeaderCell h22 = new TableHeaderCell();
            h22.Text = "gegen Mannschaft";
            header.Cells.Add(h22);

            TableHeaderCell h3 = new TableHeaderCell();
            h3.Text = "Punkte";
            header.Cells.Add(h3);
            TableHeaderCell h4 = new TableHeaderCell();
            h4.Text = "Bearbeiten";
            header.Cells.Add(h4);
            TableHeaderCell h5 = new TableHeaderCell();
            h5.Text = "Entfernen";
            header.Cells.Add(h5);


            Tbl.Rows.Add(header);
            long turnier_id = Convert.ToInt32(Request.QueryString["item"]);
            Turnier turnier = new Turnier(turnier_id);
            foreach (Spiel spiel in turnier.Spiele)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                Mannschaft mannschaft = new Mannschaft(spiel.Mannschaft_ID);
                cell1.Text = spiel.Punkte>spiel.Gegen_Punkte? "<b>"+mannschaft.Name+"</b>": mannschaft.Name;
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = spiel.Punkte.ToString();
                row.Cells.Add(cell2);
                TableCell cell3 = new TableCell();
                Mannschaft gegen_mannschaft = new Mannschaft(spiel.Gegen_Mannschaft_ID);
                cell3.Text = spiel.Punkte<spiel.Gegen_Punkte? "<b>"+gegen_mannschaft.Name+"</b>": gegen_mannschaft.Name;
                row.Cells.Add(cell3);

                TableCell cell222 = new TableCell();
                cell222.Text = spiel.Gegen_Punkte.ToString();
                row.Cells.Add(cell222);

                HyperLink link1 = new HyperLink();
                link1.NavigateUrl = "~/Spiele.aspx?item=" + Request.QueryString["item"] + "&do=bearbeiten&spiel=" + spiel.Spiel_ID.ToString();
                link1.Text = "bearbeiten";
                TableCell cell12 = new TableCell();
                cell12.Controls.Add(link1);
                row.Cells.Add(cell12);

                HyperLink link2 = new HyperLink();
                link2.NavigateUrl = "~/Spiele.aspx?item="+ Request.QueryString["item"] + "&do=entfernen&spiel=" + spiel.Spiel_ID.ToString();
                link2.Text = "X";

                TableCell cell13 = new TableCell();
                cell13.Controls.Add(link2);
                row.Cells.Add(cell13);

                Tbl.Rows.Add(row);
            }
        }
    }
}