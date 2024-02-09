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

    public class ScaffaleController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<Scaffale> GetId(int id)
        {
            var scaffale = ScaffaleService.GetId(id);
            if (scaffale == null)
                return NotFound();
            return scaffale;
        }

        //Richiesta GetAll
        [HttpGet]
        public ActionResult<List<Scaffale>> GetAll() =>
            ScaffaleService.GetAll();

        //Richiesta Post
        [HttpPost]
        public IActionResult Create(Scaffale scaffale)
        {
            ScaffaleService.Add(scaffale);
            return CreatedAtAction(nameof(GetId), new { scaffale.id }, scaffale);
        }

        //Richiesta Put
        [HttpPut("{id}")]
        public IActionResult Update(int id, Scaffale scaffale)
        {
            if (id != scaffale.id)
                return BadRequest();
            var newScaffale = ScaffaleService.GetId(id);
            if (newScaffale is null)
                return NotFound();
            ScaffaleService.Update(scaffale);
            return Ok("ERRORE");
        }

        //Richiesta Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delScaffale = ScaffaleService.GetId(id);
            if (delScaffale is null)
                return NotFound();
            ScaffaleService.Delete(id);
            return NoContent();
        }

    }
}
