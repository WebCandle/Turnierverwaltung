#region Dateikopf
// Datei:       Person.cs
// Klasse:      Person
// Datum:      06.02.2020
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
    [XmlInclude(typeof(FussballSpieler))]
    [XmlInclude(typeof(HandballSpieler))]
    [XmlInclude(typeof(TennisSpieler))]
    [XmlInclude(typeof(Spieler))]
    [XmlInclude(typeof(Physiotherapeut))]
    [XmlInclude(typeof(Trainer))]
    [XmlInclude(typeof(Mitarbeiter))]
    [Serializable]
    public class Person
    {
        #region Eigenschaften
        private long _Person_ID;
        private string _Name;
        private string _Vorname;
        private DateTime _Geburtsdatum;
        private Geschlecht _Geschlecht;
        private string _Art;
        private long _Art_ID;
        #endregion

        #region Accessor/Modifiers
        public string Name { get => _Name; set => _Name = value; }
        public DateTime Geburtsdatum { get => _Geburtsdatum; set => _Geburtsdatum = value; }
        public Geschlecht Geschlecht { get => _Geschlecht; set => _Geschlecht = value; }
        public string Vorname { get => _Vorname; set => _Vorname = value; }
        public long Person_ID { get => _Person_ID; set => _Person_ID = value; }
        public string Art { get => _Art; set => _Art = value; }
        public long Art_ID { get => _Art_ID; set => _Art_ID = value; }
        #endregion

        #region Konstruktoren
        public Person()
        {
            Name = "";
            Geburtsdatum = DateTime.Now;
            Geschlecht = Geschlecht.Maenlich;
        }
        public Person(Person person)
        {
            Name = person.Name;
            Vorname = person.Vorname;
            Geburtsdatum = person.Geburtsdatum;
            Geschlecht = person.Geschlecht;
        }
        public Person(string name, string vorname, DateTime geburtsdatum, Geschlecht geschlecht)
        {
            Name = name;
            Vorname = vorname;
            Geburtsdatum = geburtsdatum;
            Geschlecht = geschlecht;
        }
        public Person(long person_id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = string.Format("SELECT `Person_ID`, `Art`, `Art_ID`, `Vorname`, `Nachname`, `Geburtsdatum` FROM `person` WHERE `Person_ID` = {0} LIMIT 1", person_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Person_ID = long.Parse(reader["Person_ID"].ToString());
                                    Vorname = reader["Vorname"].ToString();
                                    Name = reader["Nachname"].ToString();
                                    Geburtsdatum = Convert.ToDateTime(reader["Geburtsdatum"].ToString());
                                    Art = reader["Art"].ToString();
                                    Art_ID = long.Parse(reader["Art_ID"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
                        string qry;
                        if (Person_ID != 0)
                        {
                            //update
                            qry = string.Format("UPDATE `person` SET `Vorname`=[value-4],`Nachname`=[value-5],`Geburtsdatum`=[value-6] WHERE 1", MySqlHelper.EscapeString(this.Vorname), MySqlHelper.EscapeString(this.Name), MySqlHelper.EscapeString(Geburtsdatum.ToShortDateString()));
                            cmd.CommandText = qry;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            //Insert
                            qry = string.Format("INSERT INTO `person`(`Vorname`, `Nachname`, `Geburtsdatum`) VALUES (\"{0}\",\"{1}\",STR_TO_DATE(\"{2}\", '%d.%m.%y'))", MySqlHelper.EscapeString(this.Vorname), MySqlHelper.EscapeString(this.Name), MySqlHelper.EscapeString(Geburtsdatum.ToShortDateString()));
                            cmd.CommandText = qry;
                            cmd.ExecuteNonQuery();
                            Person_ID = cmd.LastInsertedId;
                        }


                        string art = "Person";
                        long art_id = Person_ID;
                        switch (this.GetType().ToString())
                        {
                            case "Turnierverwaltung.FussballSpieler":
                                FussballSpieler fussballSpieler = this as FussballSpieler;
                                qry = string.Format("INSERT INTO `fussballspieler`( `Person_ID`, `Spiele`, `Tore`, `Position`) VALUES ({0},{1},{2},\"{3}\")", Person_ID, fussballSpieler.Spiele, fussballSpieler.Tore, fussballSpieler.Position);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    fussballSpieler.FussballSpieler_ID = cmd2.LastInsertedId;
                                    art = "FussballSpieler";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                            case "Turnierverwaltung.HandballSpieler":
                                HandballSpieler handballSpieler = this as HandballSpieler;
                                qry = string.Format("INSERT INTO `handballspieler`(`Person_ID`, `Spiele`, `Tore`, `Position`) VALUES ({0},{1},{2},\"{3}\")", Person_ID, handballSpieler.Spiele, handballSpieler.Tore, handballSpieler.Position);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    handballSpieler.HandballSpieler_ID = cmd2.LastInsertedId;
                                    art = "HandballSpieler";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                            case "Turnierverwaltung.TennisSpieler":
                                TennisSpieler tennisSpieler = this as TennisSpieler;
                                qry = string.Format("INSERT INTO `tennisspieler`(`Person_ID`, `Spiele`, `Gewonnene_Spiele`) VALUES ({0},{1},{2})", Person_ID, tennisSpieler.Spiele, tennisSpieler.Tore);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    tennisSpieler.TennisSpieler_ID = cmd2.LastInsertedId;
                                    art = "TennisSpieler";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                            case "Turnierverwaltung.Spieler":
                                Spieler spieler = this as Spieler;
                                qry = string.Format("INSERT INTO `spieler`(`Person_ID`, `Spiele`, `Gewonnene_Spiele`, `Sport_Art`) VALUES ({0},{1},{2},\"{3}\")", Person_ID, spieler.Spiele, spieler.Tore, spieler.Sportart);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    spieler.Spieler_ID = cmd2.LastInsertedId;
                                    art = "Spieler";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                            case "Turnierverwaltung.Physiotherapeut":
                                Physiotherapeut physiotherapeut = this as Physiotherapeut;
                                qry = string.Format("INSERT INTO `physiotherapeut`(`Person_ID`, `Jahre`, `Sport_Art`) VALUES ({0},{1},\"{2}\")", Person_ID, physiotherapeut.Jahre, physiotherapeut.Sportart);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    physiotherapeut.Physiotherapeut_ID = cmd2.LastInsertedId;
                                    art = "Physiotherapeut";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                            case "Turnierverwaltung.Trainer":
                                Trainer trainer = this as Trainer;
                                qry = string.Format("INSERT INTO `trainer`(`Person_ID`, `Vereine`, `Sport_Art`) VALUES ({0},{1},\"{2}\")", Person_ID, trainer.Vereine, trainer.Sportart);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    trainer.Trainer_ID = cmd2.LastInsertedId;
                                    art = "Trainer";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                            case "Turnierverwaltung.Mitarbeiter":
                                Mitarbeiter mitarbeiter = this as Mitarbeiter;
                                qry = string.Format("INSERT INTO `mitarbeiter`(`Person_ID`, `Aufgabe`, `Sport_Art`) VALUES ({0},\"{1}\",\"{2}\")", Person_ID, mitarbeiter.Aufgabe, mitarbeiter.Sportart);
                                using (MySqlCommand cmd2 = conn.CreateCommand())
                                {
                                    cmd2.CommandText = qry;
                                    cmd2.ExecuteNonQuery();
                                    mitarbeiter.Mitarbeiter_ID = cmd2.LastInsertedId;
                                    art = "Mitarbeiter";
                                    art_id = cmd2.LastInsertedId;
                                }
                                break;
                        }
                        using (MySqlCommand cmd3 = conn.CreateCommand())
                        {
                            cmd3.CommandText = string.Format("UPDATE `person` SET `Art`=\"{0}\",`Art_ID`={1} WHERE `Person_ID`={2}", art, art_id, Person_ID);
                            cmd3.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static List<Person> GetAll()
        {
            List<Person> personen = new List<Person>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM `person`";
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    long person_id = long.Parse(reader["Person_ID"].ToString());
                                    string art = reader["Art"].ToString();
                                    long art_id = long.Parse(reader["Art_ID"].ToString());
                                    switch (art)
                                    {
                                        case "FussballSpieler":
                                            Person fussballspieler = new FussballSpieler(art_id);
                                            personen.Add(fussballspieler);
                                            break;
                                        case "HandballSpieler":
                                            Person handballspieler = new HandballSpieler(art_id);
                                            personen.Add(handballspieler);
                                            break;
                                        case "TennisSpieler":
                                            Person tenissspieler = new TennisSpieler(art_id);
                                            personen.Add(tenissspieler);
                                            break;
                                        case "Spieler":
                                            Person spieler = new Spieler(art_id);
                                            personen.Add(spieler);
                                            break;
                                        case "Mitarbeiter":
                                            Person mitarbeiter = new Mitarbeiter(art_id);
                                            personen.Add(mitarbeiter);
                                            break;
                                        case "Physiotherapeut":
                                            Person physiotherapeut = new Physiotherapeut(art_id);
                                            personen.Add(physiotherapeut);
                                            break;
                                        case "Trainer":
                                            Person trainer = new Trainer(art_id);
                                            personen.Add(trainer);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return personen;
        }
        public void Delete()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Global.mySqlConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        string qry = string.Format("DELETE FROM `person` WHERE `Person_ID` = {0}", Person_ID);
                        cmd.CommandText = qry;
                        cmd.ExecuteNonQuery();
                        using (MySqlCommand cmd1 = conn.CreateCommand())
                        {
                            string qry1 = "";
                            switch (Art)
                            {
                                case "FussballSpieler":
                                    qry1 = string.Format("DELETE FROM `FussballSpieler` WHERE `Fussballspieler_ID` = {0}", Art_ID);
                                    break;
                                case "HandballSpieler":
                                    qry1 = string.Format("DELETE FROM `handballspieler` WHERE `Handballspieler_ID` = {0}", Art_ID);
                                    break;
                                case "Mitarbeiter":
                                    qry1 = string.Format("DELETE FROM `mitarbeiter` WHERE `Mitarbeiter_ID` = {0}", Art_ID);
                                    break;
                                case "Physiotherapeut":
                                    qry1 = string.Format("DELETE FROM `physiotherapeut` WHERE `Physiotherapeut_ID` = {0}", Art_ID);
                                    break;
                                case "Spieler":
                                    qry1 = string.Format("DELETE FROM `spieler` WHERE `Spieler_ID` = {0}", Art_ID);
                                    break;
                                case "TennisSpieler":
                                    qry1 = string.Format("DELETE FROM `tennisspieler` WHERE `Tennisspieler_ID` = {0}", Art_ID);
                                    break;
                                case "Trainer":
                                    qry1 = string.Format("DELETE FROM `trainer` WHERE `Trainer_ID` = {0}", Art_ID);
                                    break;
                            }
                            if(qry1 != "")
                            {
                                cmd1.CommandText = qry1;
                                cmd1.ExecuteNonQuery();
                            }
                        }

                    }
                    conn.Close();
                }
            } catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
