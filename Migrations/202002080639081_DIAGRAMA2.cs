namespace Alexandria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DIAGRAMA2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emprestimoes", "EmprestimoData", c => c.DateTime(nullable: false));
            AddColumn("dbo.Emprestimoes", "EmprestimoEntrega", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emprestimoes", "EmprestimoEntrega");
            DropColumn("dbo.Emprestimoes", "EmprestimoData");
        }
    }
}
