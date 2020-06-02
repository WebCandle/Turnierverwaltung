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

namespace Turnierverwaltung
{
    public class Spieler: Person
    {
        #region Eigenschaften
        private int _Spiele;
        private int _Tore;
        private string _Sportart;
        #endregion

        #region Accessoren/Modifiers
        public int Spiele { get => _Spiele; set => _Spiele = value; }
        public int Tore { get => _Tore; set => _Tore = value; }
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        #endregion

        #region Konstruktorn
        public Spieler() : base()
        {
            Name = "<Neuer Spieler>";
        }
        public Spieler(string name, string vorname, DateTime geburtsdatum, Geschlecht geschlecht, int spiele, int tore, string sportart) : base(name, vorname, geburtsdatum, geschlecht)
        {
            Spiele = spiele;
            Tore = tore;
            Sportart = sportart;
        }
        #endregion

        #region Worker

        #endregion
    }
}
