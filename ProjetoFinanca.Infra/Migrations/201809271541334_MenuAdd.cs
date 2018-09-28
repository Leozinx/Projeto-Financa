namespace ProjetoFinanca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Titulo = c.String(nullable: false, maxLength: 20),
                        icone_nome = c.String(nullable: false, maxLength: 20),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menu");
        }
    }
}
