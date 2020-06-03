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

namespace Turnierverwaltung
{
    [Serializable]
    public class Turnier
    {
        #region Eigenschaften
        private List<Person> _Mitglieder;
        #endregion

        #region Accessoren/Modifiers
        public List<Person> Mitglieder { get => _Mitglieder; set => _Mitglieder = value; }
        #endregion

        #region Konstruktoren
        public Turnier()
        {
        }
        public Turnier(List<Person> mitglieder)
        {
            Mitglieder = mitglieder;
        }
        #endregion

        #region Worker
        #endregion
    }
}
