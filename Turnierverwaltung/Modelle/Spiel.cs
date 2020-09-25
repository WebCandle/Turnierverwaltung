#region Dateikopf
// Datei:       Spieler.cs
// Klasse:      Spiel
// Datum:      07.02.2020
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace Turnierverwaltung
{
    public class Spiel
    {
        #region Eigenschaften
        private long _Spiel_ID;
        private long _Turnier_ID;
        private long _Mannschaft_ID;
        private int _Punkte;
        private long _gegen_Mannschaft_ID;
        private int _gegen_Punkte;
        #endregion

        #region Accessor/Modifier
        public long Spiel_ID { get => _Spiel_ID; set => _Spiel_ID = value; }
        public long Mannschaft_ID { get => _Mannschaft_ID; set => _Mannschaft_ID = value; }
        public int Punkte { get => _Punkte; set => _Punkte = value; }
        public long Gegen_Mannschaft_ID { get => _gegen_Mannschaft_ID; set => _gegen_Mannschaft_ID = value; }
        public int Gegen_Punkte { get => _gegen_Punkte; set => _gegen_Punkte = value; }
        public long Turnier_ID { get => _Turnier_ID; set => _Turnier_ID = value; }
        #endregion

        #region Konstruktoren
        public Spiel(long turnier_id, long mannschaft_id, int punkte, long gegen_mannschaft_id, int gegen_punkte)
        {
            Turnier_ID = turnier_id;
            Mannschaft_ID = mannschaft_id;
            Punkte = punkte;
            Gegen_Mannschaft_ID = gegen_mannschaft_id;
            Gegen_Punkte = gegen_punkte;
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
                        string qry = string.Format("INSERT INTO `spiel`(`Turnier_ID`, `Mannschaft_ID`, `Punkte`, `Gegen_Mannschaft_ID`, `Gegen_Punkte`) VALUES ({0},{1},{2},{3},{4})", Turnier_ID,Mannschaft_ID,Punkte,Gegen_Mannschaft_ID,Gegen_Punkte);
                        cmd.CommandText = qry;
                        cmd.ExecuteNonQuery();
                        Spiel_ID = cmd.LastInsertedId;
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