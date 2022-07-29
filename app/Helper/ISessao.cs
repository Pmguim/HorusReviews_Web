using app.Models;

namespace app.Helper
{
    public interface ISessao
    {

        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
