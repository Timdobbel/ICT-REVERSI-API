using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Model
{
    public class SpelRepository : ISpelRepository
    {
        // Lijst met tijdelijke spellen
        public List<Spel> Spellen { get; set; }

        public SpelRepository()
        {
            Spel spel1 = new Spel();
            Spel spel2 = new Spel();
            Spel spel3 = new Spel();

            spel1.Speler1Token = "b-A";
            spel1.Omschrijving = "Potje snel reveri, dus niet lang nadenken";
            spel1.AandeBeurt = Kleur.Zwart;
            spel1.Token = "a-spela";

            spel2.Speler1Token = "B";
            spel2.Speler2Token = "mnopqr";
            spel2.Omschrijving = "Ik zoek een gevorderde tegenspeler!";
            spel2.Token = "a-spelb";

            spel3.Speler1Token = "C";
            spel3.Omschrijving = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";
            spel3.Token = "a-spelc";

            Spellen = new List<Spel> { spel1, spel2, spel3 };
        }

        public void AddSpel(Spel spel)
        {
            Spellen.Add(spel);
        }

        public List<Spel> GetSpellen()
        {
            return Spellen;
        }

        public Spel GetSpel(string spelToken)
        {
            try
            {
                return Spellen.First(i => i.Token == spelToken);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
