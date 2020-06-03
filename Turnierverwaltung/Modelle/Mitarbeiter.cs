#region Dateikopf
// Datei:       TennisSpieler.cs
// Klasse:      TennisSpieler
// Datum:      02.06.2020
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Turnierverwaltung
{
    [Serializable]
    public class Mitarbeiter : Person
    {
        #region Eigenschaften
        private string _Aufgabe;
        private string _Sportart;
        #endregion

        #region Accessoren/Modifiers
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        public string Aufgabe { get => _Aufgabe; set => _Aufgabe = value; }
        #endregion

        #region Konstruktorn
        public Mitarbeiter() : base()
        {
            Name = "<Neuer Mitarbeiter>";
        }
        public Mitarbeiter(string name, string vorname, DateTime geburtsdatum, Geschlecht geschlecht, string aufgabe, string sportart) : base(name, vorname, geburtsdatum, geschlecht)
        {
            Aufgabe = aufgabe;
            Sportart = sportart;
        }
        #endregion

        #region Worker

        #endregion
    }
}
