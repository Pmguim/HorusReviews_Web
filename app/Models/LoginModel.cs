using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace app.Models
{
    public class LoginModel
    {
       
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
