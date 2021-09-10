namespace OperationBier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beer",
                c => new
                    {
                        BeerId = c.Int(nullable: false, identity: true),
                        BeerName = c.String(),
                        ABV = c.Double(nullable: false),
                        IsRecommended = c.Boolean(),
                        StyleId = c.Int(nullable: false),
                        BreweryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeerId)
                .ForeignKey("dbo.Brewery", t => t.BreweryId, cascadeDelete: true)
                .ForeignKey("dbo.Style", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId)
                .Index(t => t.BreweryId);
            
            CreateTable(
                "dbo.Brewery",
                c => new
                    {
                        BreweryId = c.Int(nullable: false, identity: true),
                        BreweryName = c.String(),
                        BreweryDescription = c.String(),
                        IsStillInBusiness = c.Boolean(nullable: false),
                        Address = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CountryOfOrigin = c.String(),
                    })
                .PrimaryKey(t => t.BreweryId);
            
            CreateTable(
                "dbo.Retail",
                c => new
                    {
                        RetailId = c.Int(nullable: false, identity: true),
                        RetailName = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IsOnPremise = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RetailId);
            
            CreateTable(
                "dbo.Style",
                c => new
                    {
                        StyleId = c.Int(nullable: false, identity: true),
                        StyleName = c.String(),
                        Description = c.String(),
                        IBU = c.Int(nullable: false),
                        CountryOfOrigin = c.String(),
                        RecommendedGlassware = c.String(),
                    })
                .PrimaryKey(t => t.StyleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Beer", "StyleId", "dbo.Style");
            DropForeignKey("dbo.RetailBeer", "Beer_BeerId", "dbo.Beer");
            DropForeignKey("dbo.RetailBeer", "Retail_RetailId", "dbo.Retail");
            DropForeignKey("dbo.Beer", "BreweryId", "dbo.Brewery");
            DropIndex("dbo.RetailBeer", new[] { "Beer_BeerId" });
            DropIndex("dbo.RetailBeer", new[] { "Retail_RetailId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Beer", new[] { "BreweryId" });
            DropIndex("dbo.Beer", new[] { "StyleId" });
            DropTable("dbo.RetailBeer");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Style");
            DropTable("dbo.Retail");
            DropTable("dbo.Brewery");
            DropTable("dbo.Beer");
        }
    }
}
