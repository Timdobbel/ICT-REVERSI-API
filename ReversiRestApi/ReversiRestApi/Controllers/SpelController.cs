using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ReversiRestApi.Model;

namespace ReversiRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpelController : ControllerBase
    {

        private readonly ISpelRepository iRepository;

        public SpelController(ISpelRepository repository)
        {
            iRepository = repository;
        }

        // GET api/spel
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return iRepository.GetSpellen()
                .Where(i => i.Speler2Token == null)
                .Select(i => i.Omschrijving)
                .ToArray();
        }

        // GET api/spel/{token}
        [HttpGet]
        [Route("{Token}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Spel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Spel()
        {
            Spel spel = iRepository.GetSpel(RouteData.Values["Token"].ToString());
            if (spel != null)
            {
                return Ok(JsonConvert.SerializeObject(spel));
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/apiSpeler/{token}

        // GET api/spel/beurt/{token}
        [HttpGet]
        [Route("Beurt/{Token}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Spel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Beurt()
        {
            Spel spel = iRepository.GetSpel(RouteData.Values["Token"].ToString());
            if (spel != null)
            {
                return Ok(JsonConvert.SerializeObject(spel.AandeBeurt));
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/spel/zet

        [HttpPut]
        [Route("Zet")]
        public IActionResult Zet([FromBody] Zet zet)
        {
            Debug.WriteLine($"<<zet, Kolom: {zet.kolomZet} Rij: {zet.rijZet}>>");
            Spel spel = iRepository.GetSpel(zet.Token);

            if (spel != null)
            {

                if (zet.Pas)
                {
                    spel.Pas();
                    return Ok("Passed");
                }
                else
                {
                    bool zetMogelijk = spel.DoeZet(zet.rijZet, zet.kolomZet);
                    return Ok(zetMogelijk);
                }
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/spel/opgeven
        [HttpPut]
        [Route("Opgeven")]
        public IActionResult Opgeven([FromBody] Opgeven opgeven)
        {
            return null;
        }

        [HttpPost]
        [Route("MaakNieuwSpel")]
        public ActionResult<string> MaakNieuwSpel([FromBody] NieuwSpel nieuwSpel)
        {
            Debug.Write("MaakNieuwSpel:" + nieuwSpel.Omschrijving + "," + nieuwSpel.SpelerToken);

            Spel spel = new Spel()
            {
                Token = Guid.NewGuid().ToString(),
                Omschrijving = nieuwSpel.Omschrijving,
                Speler1Token = nieuwSpel.SpelerToken
            };

            iRepository.AddSpel(spel);

            return spel.Token;
        }
    }
}
