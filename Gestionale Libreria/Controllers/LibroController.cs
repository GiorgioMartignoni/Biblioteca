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

    public class LibroController : ControllerBase
    {

        //Richiesta GetId (LibroService) --> get un solo libro 
        [HttpGet("{id}")]
        public ActionResult<Libro> GetId(int id)
        {
            var libro = LibroService.GetId(id);
            if (libro == null)
                return NotFound();
            return libro;
        }

        //Richiesta GetAll
        [HttpGet]
        public ActionResult<List<Libro>> GetAll() =>
            LibroService.GetAll();

        //Richiesta Post
        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            LibroService.Add(libro);
            return CreatedAtAction(nameof(GetId), new {libro.id}, libro);
        }

        //Richiesta Put
        [HttpPut("{id}")]
        public IActionResult Update(int id, Libro libro) {
            if (id != libro.id)
                return BadRequest();
            var newLibro = LibroService.GetId(id);
            if (newLibro is null)
                return NotFound();
            LibroService.Update(libro);
            return NoContent();
        }

        //Richiesta Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delLibro = LibroService.GetId(id);
            if (delLibro is null)
                return NotFound();
            LibroService.Delete(id);
            return NoContent();
        }

    }
}
