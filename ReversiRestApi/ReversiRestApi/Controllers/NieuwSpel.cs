using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReversiRestApi
{
    public class NieuwSpel
    {
        public string SpelerToken { get; set; }
        public string Omschrijving { get; set; }

    }
}