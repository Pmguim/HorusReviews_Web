using app.Data;
using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Repositorio
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ComentarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        //Também lista o comentário no banco baseado no id dele (CodComent)
        public ComentarioModel ListarPorId(int CodComent)
        {
            return _bancoContext.Comentario.FirstOrDefault(x => x.CodComent == CodComent);
        }

        //Lista todos os comentários do banco.
        public List<ComentarioModel> BuscarTodos()
        {
            return _bancoContext.Comentario.ToList();
        }

        //Realiza o registro de um comentário no banco.
        public ComentarioModel Adicionar(ComentarioModel comentario)
        {
            comentario.DataPost = DateTime.Now;
            _bancoContext.Comentario.Add(comentario);
            _bancoContext.SaveChanges();
            return comentario;
        }

        //Atualiza/Edita um comentário no banco (não funcionando).
        public ComentarioModel Atualizar(ComentarioModel comentario)
        {
            ComentarioModel comentarioDB = ListarPorId(comentario.CodComent);

            if (comentarioDB == null) throw new System.Exception("Houve um erro na atualização do comentário.");

            comentarioDB.TextoComentario = comentario.TextoComentario;

            _bancoContext.Comentario.Update(comentarioDB);
            _bancoContext.SaveChanges();
            return comentarioDB;
        }

        public bool Apagar(int CodComent)
        {
            ComentarioModel comentarioDB = BuscarPorID(CodComent);

            if (comentarioDB == null) throw new System.Exception("Houve um erro na deleção do comentário.");

            _bancoContext.Comentario.Remove(comentarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ComentarioModel BuscarPorID(int CodComent)
        {
            return _bancoContext.Comentario.FirstOrDefault(x => x.CodComent == CodComent);
        }
    }
}
