using app.Models;
using System.Collections.Generic;

namespace app.Repositorio
{
    public interface IComentarioRepositorio //ComentarioRepositorio
    {
        ComentarioModel ListarPorId(int CodComent);
        List<ComentarioModel> BuscarTodos();
        ComentarioModel BuscarPorID(int CodComent);
        ComentarioModel Adicionar(ComentarioModel comentario);
        ComentarioModel Atualizar(ComentarioModel comentario);
        bool Apagar(int CodComent);

    }
}
