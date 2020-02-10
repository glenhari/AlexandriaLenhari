using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class Autor
    {
        [Key()]
        public int AutorId { get; set; }
        [DisplayName("Nome")]
        public string AutorNome { get; set; }
        [DisplayName("Data de nascimento")]
        public DateTime AutorDataNascimento { get; set; }
        public virtual ICollection<LivroAutor> LivroAutors { get; set; }

        public void Salvar()
        {
            var db = new BaseContext();
            db.Autor.Add(this);
            db.SaveChanges();
        }

        public List<Autor> Todos()
        {
            var db = new BaseContext();
            return db.Autor.ToList();
        }

    }
}