namespace ProjetoFinanca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioCru : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                        Nivel_NivelId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Nivels", t => t.Nivel_NivelId)
                .Index(t => t.Nivel_NivelId);
            
            CreateTable(
                "dbo.Nivels",
                c => new
                    {
                        NivelId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.NivelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Nivel_NivelId", "dbo.Nivels");
            DropIndex("dbo.Usuarios", new[] { "Nivel_NivelId" });
            DropTable("dbo.Nivels");
            DropTable("dbo.Usuarios");
        }
    }
}
