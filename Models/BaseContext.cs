using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Alexandria.Models
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("dbconnection")
        {
        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<Exemplar> Exemplar { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
    }
}