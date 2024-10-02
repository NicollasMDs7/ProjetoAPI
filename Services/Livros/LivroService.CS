using Microsoft.EntityFrameworkCore;
using WebAPI8_Trainne.Data;
using WebAPI8_Trainne.Dto.Autor;
using WebAPI8_Trainne.Dto.Livro;
using WebAPI8_Trainne.Models;

namespace WebAPI8_Trainne.Services.Livro
{
    public class LivroService : ILivroInterface
        
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext Context { get; }

        Task<ResponseModel<List<LivroModel>>> ILivroInterface.BuscarLivroPorId(int idLivro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include( a => a.Autor).Where(livroBanco => livroBanco.Autor.Id ==  idAutor).ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livros localizados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        Task<ResponseModel<LivroModel>> ILivroInterface.BuscarLivroPorIdAutor(int idAutor)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado.";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();
                
                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            {
                ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
                try
                {
                    var livro = await _context.Livros.Include(autor => autor.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.id == livroEdicaoDto.Id);

                    var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.Id);

                    if (autor == null)
                    {
                        resposta.Mensagem = "Nenhum registro de autor localizado.";
                        return resposta;
                    }
                    if (livro == null)
                    {
                        resposta.Mensagem = "Nenhum registro de livro localizado.";
                        return resposta;
                    }

                    livro.Titulo = livroEdicaoDto.Titulo;
                    livro.Autor = autor;

                    _context.Update(livro);
                    await _context.SaveChangesAsync();

                    resposta.Dados = await _context.Livros.ToListAsync();
                    return resposta;

                }
                catch (Exception ex)
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluiLivro(int idLivro)
        {
            {
                ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
                try
                {
                    var livro = await _context.Livros.FirstOrDefaultAsync(livrBanco => livrBanco.id == idLivro);

                    if (livro == null)
                    {
                        resposta.Mensagem = "Nenhum livro localizado!";
                        return resposta;
                    }

                    _context.Remove(livro);
                    await _context.SaveChangesAsync();

                    resposta.Dados = await _context.Livros.ToListAsync();
                    resposta.Mensagem = "Livro Removido com sucesso!";
                    return resposta;

                }
                catch (Exception ex)
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {

                var livros = await _context.Livros.Include(autor => autor.Autor).ToListAsync();
                //_context entra no banco. // .Autores entra na tabela e o .ToList() transforma em lista todos os autores. 
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        

        
    }
}
