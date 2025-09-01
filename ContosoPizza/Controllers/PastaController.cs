using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PastaController : ControllerBase
    {
        private readonly PastaService _pastaService;
        public PastaController(PastaService pastaService)
        {
            _pastaService = pastaService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pasta>> GetAll()
        {
            var pastas = _pastaService.GetPastas();
            return Ok(pastas);
        }
        [HttpPost]
        public ActionResult<Pasta> Create(Pasta pasta)
        {
            if (!ModelState.IsValid || pasta == null)
            {
                return BadRequest();
            }
            _pastaService.AddPasta(pasta);
            return CreatedAtAction(nameof(GetAll), pasta);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _pastaService.DeletePasta(id);
            return NoContent();
        }
    }
}