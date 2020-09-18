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
        public Turnier(string name, DateTime von, DateTime bis, string adresse)
        {
            VereinName = name;
            Datum_Von = von;
            Datum_Von = bis;
            Adresse = adresse;
        }
        #endregion

        #region Worker
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
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
