using app.Data;
using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorUserName(string UserName)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.UserName == UserName);
        }
        public UsuarioModel BuscarPorLogin(string Email)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Email.ToUpper() == Email.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
           return _bancoContext.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCad = DateTime.Now;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorUserName(usuario.UserName);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            usuario.UserName = usuario.UserName;
            usuario.Nome = usuario.Nome;
            usuario.Email = usuario.Email;
            usuario.Senha = usuario.Senha;
            usuario.DataAtualizacao = DateTime.Now;
            usuario.DataNasc = usuario.DataNasc;

            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(string UserName)
        {
            UsuarioModel usuarioDB = BuscarPorUserName(UserName);

            if (usuarioDB == null) throw new Exception("Houve um erro na deleção do usuário!");

            _bancoContext.Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }


    }
}
