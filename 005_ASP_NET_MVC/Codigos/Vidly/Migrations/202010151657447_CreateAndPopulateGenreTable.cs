namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAndPopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Comedy')");
        }

        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
