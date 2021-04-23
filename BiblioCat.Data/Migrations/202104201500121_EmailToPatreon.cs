namespace BiblioCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailToPatreon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "Patreon", c => c.String());
            AddColumn("dbo.Convention", "Website", c => c.String());
            DropColumn("dbo.Author", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Author", "Email", c => c.String());
            DropColumn("dbo.Convention", "Website");
            DropColumn("dbo.Author", "Patreon");
        }
    }
}
