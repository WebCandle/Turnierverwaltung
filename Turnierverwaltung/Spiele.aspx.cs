using System;
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
            if(!Page.IsPostBack)
            {
                ddLstMannschaft1.Items.Clear();
                ddLstMannschaft2.Items.Clear();
                List<Mannschaft> mannschaften = Mannschaft.GetAll();
                foreach (Mannschaft mannschaft in mannschaften)
                {
                    ListItem listItem = new ListItem(mannschaft.Sportart + " - " + mannschaft.Name, mannschaft.Mannschaft_ID.ToString());
                    ddLstMannschaft1.Items.Add(listItem);
                    ddLstMannschaft2.Items.Add(listItem);
                }
            }

        }

        protected void btnSichern_Click(object sender, EventArgs e)
        {
            long turnier_id = Convert.ToInt32(Request.QueryString["item"]);
            Turnier turnier = new Turnier(turnier_id);
            if(turnier.Turnier_ID != 0)
            {
                Spiel spiel = new Spiel(turnier_id, Convert.ToInt32(ddLstMannschaft1.SelectedItem.Value), Convert.ToInt32(txtPunkte1.Text), Convert.ToInt32(ddLstMannschaft2.SelectedItem.Value), Convert.ToInt32(txtPunkte2.Text));
                spiel.Save();
            }
            
        }
    }
}