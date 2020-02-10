using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class Exemplar
    {
        [Key]
        public int ExemplarId { get; set; }
        [ForeignKey("Livro")]
        [DisplayName("Livro")]
        public int LivroId { get; set; }
        [DisplayName("Serial")]
        public string ExemplarSerial { get; set; }
        public enum ExemplarStatus { Indisponível = 0, Disponível = 1, Reservado = 2 };
        public virtual Livro Livro { get; set; }

        public virtual ICollection<Emprestimo> Emprestimos { get; set; }

        public void Salvar()
        {
            var db = new BaseContext();
            db.Exemplar.Add(this);
            db.SaveChanges();
        }

        public List<Exemplar> Todos()
        {
            var db = new BaseContext();
            return db.Exemplar.ToList();
        }

    }
}