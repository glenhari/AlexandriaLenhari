using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class Livro
    {
        [Key()]
        public int LivroId { get; set; }
        [DisplayName("Titulo")]
        public string LivroTitulo { get; set; }
        [DisplayName("Editora")]
        public string LivroEditora { get; set; }
        [DisplayName("Publicação")]
        public DateTime DataPublicacao { get; set; }
        //[ForeignKey("Autor")]
        //public int AutorId { get; set; }
        //public virtual Autor Autor { get; set; }

        public virtual ICollection<LivroAutor> LivroAutors { get; set; }

        public void Salvar()
        {
            var db = new BaseContext();
            db.Livro.Add(this);
            db.SaveChanges();
        }

        public List<Livro> Todos()
        {
            var db = new BaseContext();
            return db.Livro.ToList();
        }
    }
}