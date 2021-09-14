namespace OperationBier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidAuthorIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Brewery", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Retail", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Style", "AuthorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Style", "AuthorId");
            DropColumn("dbo.Retail", "AuthorId");
            DropColumn("dbo.Brewery", "AuthorId");
            DropColumn("dbo.Beer", "AuthorId");
        }
    }
}
