using app.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace app.Models
{
    public class UsuarioModel
    {
        [Key, Required(ErrorMessage = "Digite o nome de usuário"), StringLength(15), NotNull]
        public string UserName { get; set; }

        [NotNull]
        public DateTime DataCad { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [NotNull, Required(ErrorMessage = "Digite o nome do usuário"), StringLength(50)]
        public string Nome { get; set; }

        [NotNull, Required(ErrorMessage = "Digite a data de nascimento")]
        public System.DateTime DataNasc { get; set; }

        [NotNull, Required(ErrorMessage = "Digite o endereço de email"), StringLength(55)]
        [EmailAddress(ErrorMessage = "Insira um endereço de email válido")]
        public string Email { get; set; }

        [NotNull, Required(ErrorMessage = "Digite a senha"), StringLength(12, MinimumLength = 8)]
        public string Senha { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
