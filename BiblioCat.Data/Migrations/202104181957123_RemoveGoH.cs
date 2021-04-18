namespace BiblioCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGoH : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Convention", "GuestOfHonor_AuthorId", "dbo.Author");
            DropIndex("dbo.Convention", new[] { "GuestOfHonor_AuthorId" });
            AlterColumn("dbo.Convention", "Hotel", c => c.String());
            DropColumn("dbo.Convention", "GuestOfHonor_AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Convention", "GuestOfHonor_AuthorId", c => c.Int());
            AlterColumn("dbo.Convention", "Hotel", c => c.String(nullable: false));
            CreateIndex("dbo.Convention", "GuestOfHonor_AuthorId");
            AddForeignKey("dbo.Convention", "GuestOfHonor_AuthorId", "dbo.Author", "AuthorId");
        }
    }
}
