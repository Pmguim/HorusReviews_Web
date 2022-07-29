using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace app.Models
{
    public class ConteudoModel
    {
        [Key, NotNull]
        public int ContCod { get; set; }
        [NotNull]
        public string ContNome { get; set; }

        [NotNull]
        public string Diretor { get; set; }

        [NotNull]
        public DateTime DataLanc { get; set; }

        [NotNull]
        public string Sinopse { get; set; }

        [NotNull]
        public string Categoria { get; set; }

    }
}
