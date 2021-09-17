namespace OperationBier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeStyleBreweryNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Retail", "Brewery_BreweryId", "dbo.Brewery");
            DropForeignKey("dbo.Retail", "Style_StyleId", "dbo.Style");
            DropForeignKey("dbo.Beer", "BreweryId", "dbo.Brewery");
            DropForeignKey("dbo.Beer", "StyleId", "dbo.Style");
            DropIndex("dbo.Beer", new[] { "StyleId" });
            DropIndex("dbo.Beer", new[] { "BreweryId" });
            DropIndex("dbo.Retail", new[] { "Brewery_BreweryId" });
            DropIndex("dbo.Retail", new[] { "Style_StyleId" });
            AlterColumn("dbo.Beer", "StyleId", c => c.Int());
            AlterColumn("dbo.Beer", "BreweryId", c => c.Int());
            CreateIndex("dbo.Beer", "StyleId");
            CreateIndex("dbo.Beer", "BreweryId");
            AddForeignKey("dbo.Beer", "BreweryId", "dbo.Brewery", "BreweryId");
            AddForeignKey("dbo.Beer", "StyleId", "dbo.Style", "StyleId");
            DropColumn("dbo.Retail", "Brewery_BreweryId");
            DropColumn("dbo.Retail", "Style_StyleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Retail", "Style_StyleId", c => c.Int());
            AddColumn("dbo.Retail", "Brewery_BreweryId", c => c.Int());
            DropForeignKey("dbo.Beer", "StyleId", "dbo.Style");
            DropForeignKey("dbo.Beer", "BreweryId", "dbo.Brewery");
            DropIndex("dbo.Beer", new[] { "BreweryId" });
            DropIndex("dbo.Beer", new[] { "StyleId" });
            AlterColumn("dbo.Beer", "BreweryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Beer", "StyleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Retail", "Style_StyleId");
            CreateIndex("dbo.Retail", "Brewery_BreweryId");
            CreateIndex("dbo.Beer", "BreweryId");
            CreateIndex("dbo.Beer", "StyleId");
            AddForeignKey("dbo.Beer", "StyleId", "dbo.Style", "StyleId", cascadeDelete: true);
            AddForeignKey("dbo.Beer", "BreweryId", "dbo.Brewery", "BreweryId", cascadeDelete: true);
            AddForeignKey("dbo.Retail", "Style_StyleId", "dbo.Style", "StyleId");
            AddForeignKey("dbo.Retail", "Brewery_BreweryId", "dbo.Brewery", "BreweryId");
        }
    }
}
