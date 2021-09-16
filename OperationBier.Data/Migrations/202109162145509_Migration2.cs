namespace OperationBier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Retail", "Brewery_BreweryId", c => c.Int());
            AddColumn("dbo.Retail", "Style_StyleId", c => c.Int());
            CreateIndex("dbo.Retail", "Brewery_BreweryId");
            CreateIndex("dbo.Retail", "Style_StyleId");
            AddForeignKey("dbo.Retail", "Brewery_BreweryId", "dbo.Brewery", "BreweryId");
            AddForeignKey("dbo.Retail", "Style_StyleId", "dbo.Style", "StyleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Retail", "Style_StyleId", "dbo.Style");
            DropForeignKey("dbo.Retail", "Brewery_BreweryId", "dbo.Brewery");
            DropIndex("dbo.Retail", new[] { "Style_StyleId" });
            DropIndex("dbo.Retail", new[] { "Brewery_BreweryId" });
            DropColumn("dbo.Retail", "Style_StyleId");
            DropColumn("dbo.Retail", "Brewery_BreweryId");
        }
    }
}
