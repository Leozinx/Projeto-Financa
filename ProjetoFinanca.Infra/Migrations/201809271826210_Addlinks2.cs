namespace ProjetoFinanca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlinks2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Action", c => c.String());
            AddColumn("dbo.Menu", "Controller", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "Controller");
            DropColumn("dbo.Menu", "Action");
        }
    }
}
