#region Dateikopf
// Datei:       Mannschaft.cs
// Klasse:      Mannschaft
// Datum:      07.02.2020
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
    public class Mannschaft
    {
        #region Eigenschaften
        private long _Mannschaft_ID;
        private string _Name;
        private List<Person> _Mitglieder;
        private string _Sportart;
        #endregion

        #region Accessoren/Modifiers
        public string Name { get => _Name; set => _Name = value; }
        public List<Person> Mitglieder { get => _Mitglieder; set => _Mitglieder = value; }
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        public long Mannschaft_ID { get => _Mannschaft_ID; set => _Mannschaft_ID = value; }
        #endregion

        #region Konstruktoren
        public Mannschaft()
        {
            Name = "<Neue Mannschaft>";
            Mitglieder = new List<Person>();
        }
        public Mannschaft(long id)
        {
            _Mannschaft_ID = id;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = string.Format("SELECT `Mannschaft_ID`, `Name`, `Sport_Art` FROM `mannschaft` WHERE `Mannschaft_ID` = {0} LIMIT 1",_Mannschaft_ID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Name = reader["Name"].ToString();
                                    Sportart = reader["Sport_Art"].ToString();
                                    
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Name = "<Konnte nicht ermitteln!>";
                Sportart = "<Konnte nicht ermitteln!>";
            }
        }
        public Mannschaft(string name, List<Person> personen)
        {
            Name = name;

            Mitglieder = personen;
        }
        public Mannschaft(long id, string name, string sportart)
        {
            Mannschaft_ID = id;
            Name = name;
            Sportart = sportart;
        }
        #endregion

        #region Worker
        public void MitgliedAnnehmen(Person person)
        {
            Mitglieder.Add(person);
        }
        public void MitgliedEntlassen(Person person)
        {
            Mitglieder.Remove(person);
        }
        public void SortMitgliederByName()
        {
            //Sort-Alguritmus basiert auf Bubblesort
            //bool PaarSortiert;
            //do
            //{
            //    PaarSortiert = true;
            //    for (int i = 0; i < Mitglieder.Count - 1; i++)
            //    {
            //        if (Mitglieder.ElementAt(i).CompareByName(Mitglieder.ElementAt(i + 1)) == 1)
            //        {
            //            Person temp = Mitglieder[i];
            //            Mitglieder[i] = Mitglieder[i + 1];
            //            Mitglieder[i + 1] = temp;
            //            PaarSortiert = false;
            //        }
            //    }
            //} while (!PaarSortiert);
        }
        public static List<Mannschaft> GetAll()
        {
            List<Mannschaft> mannschaften = new List<Mannschaft>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM `mannschaft`";
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    long id = long.Parse(reader["Mannschaft_ID"].ToString());
                                    string name = reader["Name"].ToString();
                                    string sportart = reader["Sport_Art"].ToString();
                                    Mannschaft mannschaft = new Mannschaft(id, name, sportart);
                                    mannschaften.Add(mannschaft);
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
            return mannschaften;
        }
        #endregion
    }
}
