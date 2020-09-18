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
            List<Mannschaft> mannschaften = Mannschaft.GetAll();
            foreach (Mannschaft mannschaft in mannschaften)
            {
                CheckBxLstMannschaften.Items.Add(new ListItem(mannschaft.Name, mannschaft.Mannschaft_ID.ToString()));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Turnier turnier = new Turnier(txtVereinName.Text, Convert.ToDateTime(txtDatumVon.Text), Convert.ToDateTime(txtDatumBis.Text), txtAdresse.Text);
            turnier.Save();
        }
    }
}