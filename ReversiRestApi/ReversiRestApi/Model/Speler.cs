using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReversiRestApi
{
    public class Speler
    {
        public Spel spel = null;

        public string SpelerToken { get; set; }
        public string EmailAdres { get; set; }
        public string Naam { get; set; }
        public int AantalGewonnen { get; set; }
        public int AantalVerloren { get; set; }
        public int AantalGelijk { get; set; }
        public Kleur Kleur { get; set; }

    }
}