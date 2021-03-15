using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReversiRestApi
{
    public class Zet
    {
        public string Token { get; set; }
        public string SpelerToken { get; set; }
        public int kolomZet { get; set; }
        public int rijZet { get; set; }
        public bool Pas { get; set; }

    }
}