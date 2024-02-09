//Importiamo librerie ASPNetCore e OpenApi
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

//Importiamo le classi 
using Gestionale_Libreria.Models;

//Importiamo i service 
using Gestionale_Libreria.Services;

namespace Gestionale_Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GenereController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<Genere> GetId(int id)
        {
            var genere = GenereService.GetId(id);
            if (genere == null)
                return NotFound();
            return genere;
        }

        //Richiesta GetAll
        [HttpGet]
        public ActionResult<List<Genere>> GetAll() =>
            GenereService.GetAll();

        //Richiesta Post
        [HttpPost]
        public IActionResult Create(Genere genere)
        {
            GenereService.Add(genere);
            return CreatedAtAction(nameof(GetId), new { genere.id }, genere);
        }

        //Richiesta Put
        [HttpPut("{id}")]
        public IActionResult Update(int id, Genere genere)
        {
            if (id != genere.id)
                return BadRequest();
            var newGenere = GenereService.GetId(id);
            if (newGenere is null)
                return NotFound();
            GenereService.Update(genere);
            return Ok("ERRORE");
        }

        //Richiesta Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delGenere = GenereService.GetId(id);
            if (delGenere is null)
                return NotFound();
            GenereService.Delete(id);
            return NoContent();
        }

    }
}
