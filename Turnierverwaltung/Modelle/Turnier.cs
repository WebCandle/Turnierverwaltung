#region Dateikopf
// Datei:       Turnier.cs
// Klasse:      Mannschaft
// Datum:      03.06.2020
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Turnierverwaltung
{
    [Serializable]
    public class Turnier
    {
        #region Eigenschaften
        private long _Turnier_ID;
        private string _VereinName;
        private DateTime _Datum_Von;
        private DateTime _Datum_Bis;
        private string _Adresse;
        private List<Mannschaft> _Mannschaften;
        #endregion

        #region Accessoren/Modifiers
        public List<Mannschaft> Mannschaften { get => _Mannschaften; set => _Mannschaften = value; }
        public string VereinName { get => _VereinName; set => _VereinName = value; }
        public DateTime Datum_Von { get => _Datum_Von; set => _Datum_Von = value; }
        public DateTime Datum_Bis { get => _Datum_Bis; set => _Datum_Bis = value; }
        public string Adresse { get => _Adresse; set => _Adresse = value; }
        public long Turnier_ID { get => _Turnier_ID; set => _Turnier_ID = value; }
        #endregion

        #region Konstruktoren
        public Turnier(long turnier_id)
        {
            Turnier_ID = turnier_id;
            Mannschaften = FetchMannschaften(turnier_id);
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = string.Format("SELECT `Turnier_ID`, `Verein_Name`, `Adresse`, `Datum_von`, `Datum_bis` FROM `turnier` WHERE `Turnier_ID` = {0} LIMIT 1", _Turnier_ID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    VereinName = reader["Verein_Name"].ToString();
                                    Adresse = reader["Adresse"].ToString();
                                    Datum_Von = Convert.ToDateTime(reader["Datum_von"].ToString());
                                    Datum_Bis = Convert.ToDateTime(reader["Datum_bis"].ToString());

                                }
                            }
                        }
                    }
                    conn.Close();
                }
            } catch(Exception ex)
            {
                VereinName = "<Konnte nicht ermitteln!>";
                Adresse = "<Konnte nicht ermitteln!>";
                Datum_Von = DateTime.Now;
                Datum_Bis = DateTime.Now;
            }
            }
        public Turnier(string vereinName, DateTime von, DateTime bis, string adresse, List<Mannschaft> mannschaften)
        {
            VereinName = vereinName;
            Datum_Von = von;
            Datum_Bis = bis;
            Adresse = adresse;
            Mannschaften = mannschaften;
        }
        #endregion

        #region Worker
        public void Delete()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        string qry = string.Format("DELETE FROM `turnier` WHERE `Turnier_ID` = {0}", Turnier_ID);
                        cmd.CommandText = qry;
                        cmd.ExecuteNonQuery();
                        using (MySqlCommand cmd1 = conn.CreateCommand())
                        {
                            string qry1 = string.Format("DELETE FROM `turnier_mannschaft` WHERE `Turnier_ID` = {0}", Turnier_ID);
                            cmd1.CommandText = qry1;
                            cmd1.ExecuteNonQuery();
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Save()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        string qry = string.Format("INSERT INTO `turnier`(`Verein_Name`, `Adresse`, `Datum_von`, `Datum_bis`) VALUES (\"{0}\",\"{1}\",STR_TO_DATE(\"{2}\", '%d.%m.%y'),STR_TO_DATE(\"{3}\", '%d.%m.%y'))", MySqlHelper.EscapeString(VereinName), MySqlHelper.EscapeString(Adresse), MySqlHelper.EscapeString(Datum_Von.ToShortDateString()), MySqlHelper.EscapeString(Datum_Bis.ToShortDateString()));
                        cmd.CommandText = qry;
                        cmd.ExecuteNonQuery();
                        Turnier_ID = cmd.LastInsertedId;
                        foreach (Mannschaft mannschaft in Mannschaften)
                        {
                            using (MySqlCommand cmd1 = conn.CreateCommand())
                            {
                                string qry1 = string.Format("INSERT INTO `turnier_mannschaft`(`Turnier_ID`, `Mannschaft_ID`) VALUES ({0},{1})", Turnier_ID, mannschaft.Mannschaft_ID);
                                cmd1.CommandText = qry1;
                                cmd1.ExecuteNonQuery();
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
        public static List<Turnier> GetAll()
        {
            //hat hier nicht akzeptiert !!
            List<Turnier> turniere = new List<Turnier>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM `turnier`";
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    long turnier_id = long.Parse(reader["Turnier_ID"].ToString());
                                    //string name = reader["Verein_Name"].ToString();
                                    //string adresse = reader["Adresse"].ToString();
                                    //DateTime von = Convert.ToDateTime(reader["Datum_von"].ToString());
                                    //DateTime bis = Convert.ToDateTime(reader["Datum_bis"].ToString());
                                    //List<Mannschaft> mannschaften = Turnier.FetchMannschaften(id);
                                    Turnier turnier = new Turnier(turnier_id);
                                    turniere.Add(turnier);
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return turniere;
        }
        public static List<Mannschaft> FetchMannschaften(long trunier_id)
        {
            List<Mannschaft> mannschaften = new List<Mannschaft>();
            using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                        cmd.CommandText = "SELECT `Turnier_Mannschaft_ID`, `Turnier_ID`, `Mannschaft_ID` FROM `turnier_mannschaft` WHERE `Turnier_ID` = " + trunier_id.ToString();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    long mannschaft_id = long.Parse(reader["Mannschaft_ID"].ToString());
                                    mannschaften.Add(new Mannschaft(mannschaft_id));
                                }
                            }
                        }
                }
                conn.Close();
            }
            return mannschaften;
        }
        #endregion
    }
}
