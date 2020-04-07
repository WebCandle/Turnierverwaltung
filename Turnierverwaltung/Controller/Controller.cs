using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Turnierverwaltung
{
    public class Controller
    {
        private Bundesliga _Bundesliga;
                
        public Bundesliga Bundesliga { get => _Bundesliga; set => _Bundesliga = value; }

        public Controller()
        {
            Mannschaft mannschaft = new Mannschaft();
            Trainer trainer1 = new Trainer();
            trainer1.Name = "Maher Al Abbasi";
            trainer1.Alt = 55;
            mannschaft.MitgliedAnnehmen(trainer1);

            Physiotherapeut physio1 = new Physiotherapeut();
            physio1.Name = "Wolfgang Stupp";
            physio1.Alt = 60;
            mannschaft.MitgliedAnnehmen(physio1);

            FussballSpieler fussballSpieler1 = new FussballSpieler();
            fussballSpieler1.Name = "Lional Messi";
            fussballSpieler1.Alt = 22;
            mannschaft.MitgliedAnnehmen(fussballSpieler1);

            FussballSpieler fussballSpieler2 = new FussballSpieler();
            fussballSpieler2.Name = "Ronaldo";
            fussballSpieler2.Alt = 20;
            mannschaft.MitgliedAnnehmen(fussballSpieler2);

            Verein verein = new Verein();
            verein.MannschaftAnmelden(mannschaft);
            Bundesliga = new Bundesliga("Deutschland", DateTime.Now, new List<Verein>(), DateTime.Now);
            Bundesliga.VereinAnmelden(verein);

            
        }
        public void Sichern()
        {
            //Speichern vom Objekt Bundesliga
            XmlSerializer SR = new XmlSerializer(typeof(Bundesliga));
            FileStream FS = new FileStream("Bundesliga.xml", FileMode.Create);
            SR.Serialize(FS, Bundesliga);
            FS.Close();
        }
    }
}
