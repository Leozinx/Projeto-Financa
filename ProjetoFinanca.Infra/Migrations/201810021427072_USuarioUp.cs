namespace ProjetoFinanca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USuarioUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Username", c => c.String());
            AddColumn("dbo.Usuarios", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Status");
            DropColumn("dbo.Usuarios", "Username");
        }
    }
}
