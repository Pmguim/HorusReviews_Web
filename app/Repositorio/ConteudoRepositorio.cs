using app.Data;
using app.Models;
using System.Collections.Generic;
using System.Linq;

namespace app.Repositorio
{
    public class ConteudoRepositorio : IConteudoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ConteudoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ConteudoModel> BuscarTodos()
        {
            return _bancoContext.Conteudo.ToList();
        }
    }
}
