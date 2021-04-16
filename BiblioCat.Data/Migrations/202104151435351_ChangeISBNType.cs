namespace BiblioCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeISBNType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "ISBN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "ISBN", c => c.Int(nullable: false));
        }
    }
}
