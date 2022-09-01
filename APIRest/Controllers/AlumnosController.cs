using APIRest.Contextos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace APIRest.Controllers
{
    [Route("api/v1/alumnos")]
    public class AlumnosController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILogger<AlumnosController> _logger;
        public AlumnosController(Context context, ILogger<AlumnosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("Cursos")]
        public async Task<IActionResult> QueryCursos()
        {
            var result = await _context.Profesores.Include(x => x.Cursos).ThenInclude(x => x.Alumnos).ToListAsync();
            return Ok(result);
        }
    }
}
