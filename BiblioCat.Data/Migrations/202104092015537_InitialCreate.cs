namespace BiblioCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorBook",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.BookId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Email = c.String(),
                        OfficialWebsite = c.String(),
                        AmazonPage = c.String(),
                        GoodreadsPage = c.String(),
                        TwitterHandle = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.AuthorPublisher",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.PublisherId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PublisherWebsite = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.BookPublisher",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.PublisherId })
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        PublicationDate = c.DateTime(nullable: false),
                        ISBN = c.Int(nullable: false),
                        LoanedTo = c.String(),
                        Narrator = c.String(),
                        Translator = c.String(),
                        Illustrator = c.String(),
                        IsFirstEdition = c.Boolean(nullable: false),
                        IHaveRead = c.Boolean(nullable: false),
                        IOwn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.SeriesBook",
                c => new
                    {
                        SeriesId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SeriesId, t.BookId })
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SeriesId = c.Int(nullable: false, identity: true),
                        SeriesName = c.String(nullable: false),
                        SeriesDescription = c.String(),
                    })
                .PrimaryKey(t => t.SeriesId);
            
            CreateTable(
                "dbo.SeriesAuthor",
                c => new
                    {
                        SeriesId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SeriesId, t.AuthorId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.AuthorConvention",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        ConventionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.ConventionId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Convention", t => t.ConventionId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.ConventionId);
            
            CreateTable(
                "dbo.Convention",
                c => new
                    {
                        ConventionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Hotel = c.String(nullable: false),
                        GuestOfHonor_AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.ConventionId)
                .ForeignKey("dbo.Author", t => t.GuestOfHonor_AuthorId)
                .Index(t => t.GuestOfHonor_AuthorId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.AuthorBook", "BookId", "dbo.Book");
            DropForeignKey("dbo.AuthorBook", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.AuthorConvention", "ConventionId", "dbo.Convention");
            DropForeignKey("dbo.Convention", "GuestOfHonor_AuthorId", "dbo.Author");
            DropForeignKey("dbo.AuthorConvention", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.AuthorPublisher", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.BookPublisher", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.BookPublisher", "BookId", "dbo.Book");
            DropForeignKey("dbo.SeriesBook", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.SeriesAuthor", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.SeriesAuthor", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.SeriesBook", "BookId", "dbo.Book");
            DropForeignKey("dbo.AuthorPublisher", "AuthorId", "dbo.Author");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Convention", new[] { "GuestOfHonor_AuthorId" });
            DropIndex("dbo.AuthorConvention", new[] { "ConventionId" });
            DropIndex("dbo.AuthorConvention", new[] { "AuthorId" });
            DropIndex("dbo.SeriesAuthor", new[] { "AuthorId" });
            DropIndex("dbo.SeriesAuthor", new[] { "SeriesId" });
            DropIndex("dbo.SeriesBook", new[] { "BookId" });
            DropIndex("dbo.SeriesBook", new[] { "SeriesId" });
            DropIndex("dbo.BookPublisher", new[] { "PublisherId" });
            DropIndex("dbo.BookPublisher", new[] { "BookId" });
            DropIndex("dbo.AuthorPublisher", new[] { "PublisherId" });
            DropIndex("dbo.AuthorPublisher", new[] { "AuthorId" });
            DropIndex("dbo.AuthorBook", new[] { "BookId" });
            DropIndex("dbo.AuthorBook", new[] { "AuthorId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Convention");
            DropTable("dbo.AuthorConvention");
            DropTable("dbo.SeriesAuthor");
            DropTable("dbo.Series");
            DropTable("dbo.SeriesBook");
            DropTable("dbo.Book");
            DropTable("dbo.BookPublisher");
            DropTable("dbo.Publisher");
            DropTable("dbo.AuthorPublisher");
            DropTable("dbo.Author");
            DropTable("dbo.AuthorBook");
        }
    }
}
