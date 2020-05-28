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
            DropDownList_Sportart.Items.Add("Fussball");
            DropDownList_Sportart.Items.Add("Handball");
            DropDownList_Sportart.Items.Add("Tennis");
        }

        protected void changed(object sender, EventArgs e)
        {
            if (RadioButtonListPersonenType.SelectedItem.Value == "Fussballspieler")
            {

            }
            else
            {
                Lbl_Anzahl_Spiele.Visible = false;
                Txt_Anzahl_Spiele.Visible = false;
                Lbl_Geschossene_Tore.Visible = false;
                Txt_Geschossene_Tore.Visible = false;
                Lbl_Spielposition.Visible = false;
                Txt_Spielposition.Visible = false;

                if (RadioButtonListPersonenType.SelectedItem.Value == "Handballspieler")
                {
                    Lbl_Anzahl_Spiele.Visible = true;
                    Txt_Anzahl_Spiele.Visible = true;
                    Lbl_Geworfene_Tore.Visible = true;
                    Txt_Geworfene_Tore.Visible = true;
                    Lbl_Einsatzbereich.Visible = true;
                    Txt_Einsatzbereich.Visible = true;
                }
            }
        }
    }
}