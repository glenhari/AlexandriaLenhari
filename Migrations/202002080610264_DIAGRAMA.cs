namespace Alexandria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DIAGRAMA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exemplars",
                c => new
                    {
                        ExemplarId = c.Int(nullable: false, identity: true),
                        LivroId = c.Int(nullable: false),
                        ExemplarSerial = c.String(),
                    })
                .PrimaryKey(t => t.ExemplarId)
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: true)
                .Index(t => t.LivroId);
            
            CreateTable(
                "dbo.Emprestimoes",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        ExemplarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.ExemplarId })
                .ForeignKey("dbo.Exemplars", t => t.ExemplarId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.ExemplarId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        UsuarioNome = c.String(),
                        UsuarioCPF = c.String(),
                        UsuarioDataNascimento = c.DateTime(nullable: false),
                        UsuarioTelefone = c.String(),
                        UsuarioEmail = c.String(),
                        UsuarioEndereco = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exemplars", "LivroId", "dbo.Livroes");
            DropForeignKey("dbo.Emprestimoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Emprestimoes", "ExemplarId", "dbo.Exemplars");
            DropIndex("dbo.Emprestimoes", new[] { "ExemplarId" });
            DropIndex("dbo.Emprestimoes", new[] { "UsuarioId" });
            DropIndex("dbo.Exemplars", new[] { "LivroId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Emprestimoes");
            DropTable("dbo.Exemplars");
        }
    }
}
