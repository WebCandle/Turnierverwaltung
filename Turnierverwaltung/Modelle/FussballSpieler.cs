#region Dateikopf
// Datei:       FussballSpieler.cs
// Klasse:      FussballSpieler
// Datum:      07.02.2020
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
    public class FussballSpieler : Person
    {
        #region Eigenschaften
        private long _FussballSpieler_ID;
        private int _Spiele;
        private int _Tore;
        private string _Position;
        #endregion

        #region Accessoren/Modifiers
        public int Spiele { get => _Spiele; set => _Spiele = value; }
        public int Tore { get => _Tore; set => _Tore = value; }
        public string Position { get => _Position; set => _Position = value; }
        public long FussballSpieler_ID { get => _FussballSpieler_ID; set => _FussballSpieler_ID = value; }
        #endregion

        #region Konstruktorn
        public FussballSpieler() : base()
        {
            Name = "<Neuer FussballSpieler>";
        }
        public FussballSpieler(string name, string vorname, DateTime geburtsdatum, Geschlecht geschlecht, int spiele, int tore, string position) : base(name, vorname, geburtsdatum, geschlecht)
        {
            Spiele = spiele;
            Tore = tore;
            Position = position;
        }
        #endregion

        #region Worker
        public void PositionAendern(string position)
        {
            Position = position;
        }
        #endregion
    }
}
