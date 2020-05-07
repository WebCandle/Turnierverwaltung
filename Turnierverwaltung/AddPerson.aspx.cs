using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Turnierverwaltung
{
    public partial class AddPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Conn = new MySqlConnection();
                Conn.ConnectionString = "server=localhost;database=Turnierverwaltung;uid=root;password=;";
                Conn.Open();
                string sql = "insert into person(Vorname,Geburtsdatum) values (\""+ txtName .Text+ "\",\""+ datum.Text+ "\");";
                MySqlCommand command = new MySqlCommand(sql, Conn);
                int anzahl = command.ExecuteNonQuery();
                Msg.Text = anzahl.ToString();
                Conn.Clone();
            }
            catch (MySqlException ex)
            {
                Msg.Text = ex.Message;
            }
        }
    }
}