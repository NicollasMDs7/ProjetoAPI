using WebAPI8_Trainne.Dto.Livro.Vinculo;
using WebAPI8_Trainne.Models;

namespace WebAPI8_Trainne.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
