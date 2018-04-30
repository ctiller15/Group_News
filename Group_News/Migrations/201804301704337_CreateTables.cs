namespace Group_News.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Headline = c.String(),
                        Body = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(),
                        AuthorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Stories", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Stories", new[] { "AuthorID" });
            DropIndex("dbo.Stories", new[] { "CategoryID" });
            DropTable("dbo.Stories");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
        }
    }
}
