using WebAPI8_Trainne.Dto.Autor;
using WebAPI8_Trainne.Models;

namespace WebAPI8_Trainne.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluiAutor(int idAutor);
    }
}
