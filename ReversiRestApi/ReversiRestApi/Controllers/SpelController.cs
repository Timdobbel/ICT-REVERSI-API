using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ReversiRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpelController : ControllerBase
    {
        private readonly ILogger<SpelController> _logger;

        public SpelController(ILogger<SpelController> logger)
        {
            _logger = logger;
        }

        // Misschien moet dit anders worden opgelost. Static is nodig ivm elke keer nieuwe instantie.

        static private Dictionary<string, Spel> spellen = new Dictionary<string, Spel>();

        static private Dictionary<string, Speler> spelers = new Dictionary<string, Speler>();

        // Set en Get moet nog goed worden gezet. Misschien een POST....

        [HttpPut]
        [Route("Speler/{Kleur}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Speler([FromBody] Speler speler)
        {
            


            return Ok();
        }





        [HttpGet]
        [Route("{Token}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Spel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Spel()
        {
            Spel spel = null;

            if (RouteData.Values.ContainsKey("Token"))
            {
                String spelToken = RouteData.Values["Token"].ToString();

                if (spellen.ContainsKey(spelToken))
                {
                    spel = spellen[spelToken];
                }
                else
                {
                    spel = new Spel();
                    spel.ID = spellen.Count;        // Waar moet het ID mee gevuld worden. Is nu een teller.
                    spel.Token = spelToken;         // SpelToken moet worden gegenereerd bij makan van een nieuw spel.

                    spel.AandeBeurt = Kleur.Wit;

                    spellen.Add(spelToken, spel);
                }

                return Ok(JsonConvert.SerializeObject(spel));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Beurt/{Token}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Beurt()
        {
            Spel spel = null;

            if (RouteData.Values.ContainsKey("Token"))
            {
                String spelToken = RouteData.Values["Token"].ToString();

                if (spellen.ContainsKey(spelToken))
                {
                    spel = spellen[spelToken];

                    return Ok(spel.AandeBeurt);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("Zet/{Kleur}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Zet([FromBody] Zet zet)
        {
            Spel spel = null;

            if (spellen.ContainsKey(zet.Token))
            {
                spel = spellen[zet.Token];

                bool zetMogelijk = spel.DoeZet(zet.rijZet, zet.kolomZet);

                return Ok(zetMogelijk);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
