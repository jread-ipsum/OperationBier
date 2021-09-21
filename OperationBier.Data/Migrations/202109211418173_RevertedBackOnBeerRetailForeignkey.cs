namespace OperationBier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertedBackOnBeerRetailForeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Beer", "Retail_RetailId", "dbo.Retail");
            DropForeignKey("dbo.Beer", "RetailId", "dbo.Retail");
            DropForeignKey("dbo.Retail", "Beer_BeerId", "dbo.Beer");
            DropIndex("dbo.Beer", new[] { "RetailId" });
            DropIndex("dbo.Beer", new[] { "Retail_RetailId" });
            DropIndex("dbo.Retail", new[] { "Beer_BeerId" });
            CreateTable(
                "dbo.RetailBeer",
                c => new
                    {
                        Retail_RetailId = c.Int(nullable: false),
                        Beer_BeerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Retail_RetailId, t.Beer_BeerId })
                .ForeignKey("dbo.Retail", t => t.Retail_RetailId, cascadeDelete: true)
                .ForeignKey("dbo.Beer", t => t.Beer_BeerId, cascadeDelete: true)
                .Index(t => t.Retail_RetailId)
                .Index(t => t.Beer_BeerId);
            
            DropColumn("dbo.Beer", "RetailId");
            DropColumn("dbo.Beer", "Retail_RetailId");
            DropColumn("dbo.Retail", "Beer_BeerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Retail", "Beer_BeerId", c => c.Int());
            AddColumn("dbo.Beer", "Retail_RetailId", c => c.Int());
            AddColumn("dbo.Beer", "RetailId", c => c.Int());
            DropForeignKey("dbo.RetailBeer", "Beer_BeerId", "dbo.Beer");
            DropForeignKey("dbo.RetailBeer", "Retail_RetailId", "dbo.Retail");
            DropIndex("dbo.RetailBeer", new[] { "Beer_BeerId" });
            DropIndex("dbo.RetailBeer", new[] { "Retail_RetailId" });
            DropTable("dbo.RetailBeer");
            CreateIndex("dbo.Retail", "Beer_BeerId");
            CreateIndex("dbo.Beer", "Retail_RetailId");
            CreateIndex("dbo.Beer", "RetailId");
            AddForeignKey("dbo.Retail", "Beer_BeerId", "dbo.Beer", "BeerId");
            AddForeignKey("dbo.Beer", "RetailId", "dbo.Retail", "RetailId");
            AddForeignKey("dbo.Beer", "Retail_RetailId", "dbo.Retail", "RetailId");
        }
    }
}
