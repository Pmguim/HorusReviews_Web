using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace app.Models
{
    public class ComentarioModel
    {
        [Key, NotNull]
        public int CodComent { get; set; }

        [NotNull]
        public string UserName { get; set; }

        [NotNull]
        public DateTime DataPost { get; set; }

        [NotNull, StringLength(950)]
        public string TextoComentario { get; set; }
    }
}
