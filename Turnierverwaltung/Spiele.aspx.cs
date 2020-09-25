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

        }
    }
}