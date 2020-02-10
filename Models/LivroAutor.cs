using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class LivroAutor
    {
        [Key, Column(Order = 1)]
        [DisplayName("Livro")]
        public int LivroId { get; set; }
        [Key, Column(Order = 2)]
        [DisplayName("Autor")]
        public int AutorId { get; set; }
        public Livro Livro { get; set; }
        public Autor Autor { get; set; }

        public void Salvar()
        {
            var db = new BaseContext();
            db.LivroAutor.Add(this);
            db.SaveChanges();
        }

        public List<LivroAutor> Todos()
        {
            var db = new BaseContext();
            return db.LivroAutor.ToList();
        }
    }

}

