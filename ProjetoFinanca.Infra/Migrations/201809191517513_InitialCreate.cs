namespace ProjetoFinanca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movimentacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 7, scale: 2),
                        Descricao = c.String(nullable: false, maxLength: 20),
                        CategoriaId = c.Int(nullable: false),
                        PeriodoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Periodo", t => t.PeriodoId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.PeriodoId);
            
            CreateTable(
                "dbo.Periodo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 7, scale: 2),
                        Situacao = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentacao", "PeriodoId", "dbo.Periodo");
            DropForeignKey("dbo.Movimentacao", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Movimentacao", new[] { "PeriodoId" });
            DropIndex("dbo.Movimentacao", new[] { "CategoriaId" });
            DropTable("dbo.Periodo");
            DropTable("dbo.Movimentacao");
            DropTable("dbo.Categoria");
        }
    }
}
