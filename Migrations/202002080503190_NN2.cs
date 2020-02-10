namespace Alexandria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NN2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        AutorNome = c.String(),
                        AutorDataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.LivroAutors",
                c => new
                    {
                        LivroId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LivroId, t.AutorId })
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: true)
                .Index(t => t.LivroId)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                        LivroTitulo = c.String(),
                        LivroEditora = c.String(),
                        DataPublicacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LivroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LivroAutors", "LivroId", "dbo.Livroes");
            DropForeignKey("dbo.LivroAutors", "AutorId", "dbo.Autors");
            DropIndex("dbo.LivroAutors", new[] { "AutorId" });
            DropIndex("dbo.LivroAutors", new[] { "LivroId" });
            DropTable("dbo.Livroes");
            DropTable("dbo.LivroAutors");
            DropTable("dbo.Autors");
        }
    }
}
