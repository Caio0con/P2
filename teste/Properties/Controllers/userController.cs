using Microsoft.AspNetCore.Mvc;
using NavarroProva.Properties.Model;
using teste.Properties.Data;


namespace NavarroProva.Properties.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("criarUsuario")]
        public IActionResult CriarUsuario([FromBody] usuario novoUsuario)
        {
            novoUsuario.Id = 0;
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPost("criarPost")]
        public IActionResult CriarPost([FromBody] Post novoPost )
        {
            if (novoPost.Id != 0)
            {
                return BadRequest("Usuário não informado");
            }
            _context.Posts.Add(novoPost);
            int v = _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPost), new { id = novoPost.Id }, novoPost);
        }

        [HttpGet("obterUsuario/{id}")]
        public IActionResult ObterUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet("obterPost/{id}")]
        public IActionResult ObterPost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}