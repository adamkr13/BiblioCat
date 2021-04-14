namespace BiblioCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImproveModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "GenreOfBook", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "FormatOfBook", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "FormatOfBook");
            DropColumn("dbo.Book", "GenreOfBook");
        }
    }
}
