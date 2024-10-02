using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8_Trainne.Dto.Autor;
using WebAPI8_Trainne.Dto.Livro;
using WebAPI8_Trainne.Models;
using WebAPI8_Trainne.Services.Autor;
using WebAPI8_Trainne.Services.Livro;

namespace WebAPI8_Trainne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorID/{idlivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarAutorPorIdLivro(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }

        [HttpDelete("ExcluiLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluiLivro(int idLivro)
        {
            var livros = await _livroInterface.ExcluiLivro(idLivro);
            return Ok(livros);
        }
    }
}
