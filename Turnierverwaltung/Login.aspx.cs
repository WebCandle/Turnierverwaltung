using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Turnierverwaltung
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["do"] == "logout")
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx",true);
            }
        }
        public string MD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        string qry = string.Format("SELECT * FROM `users` WHERE `name` = \"{0}\" AND `password` = \"{1}\" LIMIT 1", MySqlHelper.EscapeString(LoginMaske.UserName), MD5(LoginMaske.Password));
                        cmd.CommandText = qry;
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int active = Convert.ToInt32(reader["active"]);
                                if (active == 1)
                                {
                                    LblMsg.Visible = false;
                                    Session["auth"] = true;
                                    Session["name"] = Convert.ToString(reader["name"]);
                                    Session["rolle"] = Convert.ToString(reader["rolle"]);
                                    Response.Redirect("~/Default.aspx");
                                }
                                else
                                {
                                    Login_Failed();
                                }
                            }
                            else
                            {
                                Login_Failed();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Login_Failed()
        {
            //Access denied!
            Session["auth"] = false;
            LblMsg.Visible = true;
        }
    }
}