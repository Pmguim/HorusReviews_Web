using app.Models;
using System.Collections.Generic;

namespace app.Repositorio
{
    public interface IUsuarioRepositorio //UsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string Email);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorUserName(string UserName);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(string UserName);
    }
}
