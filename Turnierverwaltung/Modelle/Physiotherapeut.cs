﻿#region Dateikopf
// Datei:       Physiotherapeut.cs
// Klasse:      Physiotherapeut
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
    public class Physiotherapeut : Person
    {
        #region Eigenschaften
        private long _Physiotherapeut_ID;
        private int _Jahre;
        private string _Sportart;
        #endregion

        #region Accessoren/Modifiers
        public int Jahre { get => _Jahre; set => _Jahre = value; }
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        public long Physiotherapeut_ID { get => _Physiotherapeut_ID; set => _Physiotherapeut_ID = value; }
        #endregion

        #region Konstuktoren
        public Physiotherapeut() : base()
        {
            Name = "<Neuer Physiotherapeut>";
        }
        public Physiotherapeut(Physiotherapeut physiotherapeut) : base(physiotherapeut)
        {
            Jahre = physiotherapeut.Jahre;
            Sportart = physiotherapeut.Sportart;
        }
        public Physiotherapeut(string name, string vorname, DateTime geburtsdatum, Geschlecht geschlecht, int jahre, string sportart) : base(name, vorname, geburtsdatum, geschlecht)
        {
            Jahre = jahre;
            Sportart = sportart;
        }
        #endregion

        #region Worker

        #endregion
    }
}
