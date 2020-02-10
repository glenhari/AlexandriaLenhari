using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [DisplayName("Nome")]
        public string UsuarioNome { get; set; }
        [DisplayName("CPF")]
        public string UsuarioCPF { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime UsuarioDataNascimento { get; set; }
        [DisplayName("Telefone")]
        public string UsuarioTelefone { get; set; }
        [DisplayName("Email")]
        public string UsuarioEmail { get; set; }
        [DisplayName("Endereço")]
        public string UsuarioEndereco { get; set; }

        public virtual ICollection<Emprestimo> Emprestimos { get; set; }

    }
}