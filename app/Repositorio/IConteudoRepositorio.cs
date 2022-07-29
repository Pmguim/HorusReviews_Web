using app.Models;
using System.Collections.Generic;

namespace app.Repositorio
{
    public interface IConteudoRepositorio
    {

        List<ConteudoModel> BuscarTodos();

    }
}
