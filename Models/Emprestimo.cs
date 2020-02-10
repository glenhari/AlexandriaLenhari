using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class Emprestimo
    {
        [Key,Column(Order = 1)]
        [DisplayName("Usuário")]
        public int UsuarioId { get; set; }
        [Key, Column(Order = 2)]
        [DisplayName("Exemplar")]
        public int ExemplarId { get; set; }
        [DisplayName("Data de empréstimo")]
        public DateTime EmprestimoData { get; set; }
        [DisplayName("Data de entrega")]
        public DateTime EmprestimoEntrega { get; set; }
        public Usuario Usuario { get; set; }
        public Exemplar Exemplar { get; set; }
    }
}