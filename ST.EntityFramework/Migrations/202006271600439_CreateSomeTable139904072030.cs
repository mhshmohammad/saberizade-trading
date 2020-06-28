namespace ST.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSomeTable139904072030 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bse.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        EnTitle = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 2000),
                        EnDescription = c.String(nullable: false),
                        Labels = c.String(),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "bse.Certificate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        EnName = c.String(maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        EnDescription = c.String(maxLength: 2000),
                        Labels = c.String(),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "bse.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Family = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Type = c.Int(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "bse.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        EnName = c.String(maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        EnDescription = c.String(maxLength: 1000),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "bse.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        EnName = c.String(maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        EnDescription = c.String(maxLength: 1000),
                        SendPriceInRange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SendPriceOutRange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCategoryId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Int(nullable: false),
                        Labels = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .ForeignKey("bse.ProductCategory", t => t.ProductCategoryId, cascadeDelete: false)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.IsDeleted)
                .Index(t => t.CreatorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("bse.Product", "ProductCategoryId", "bse.ProductCategory");
            DropForeignKey("bse.Product", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("bse.ProductCategory", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("bse.ContactUs", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("bse.Certificate", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("bse.Blog", "CreatorUserId", "dbo.AbpUsers");
            DropIndex("bse.Product", new[] { "CreatorUserId" });
            DropIndex("bse.Product", new[] { "IsDeleted" });
            DropIndex("bse.Product", new[] { "ProductCategoryId" });
            DropIndex("bse.ProductCategory", new[] { "CreatorUserId" });
            DropIndex("bse.ContactUs", new[] { "CreatorUserId" });
            DropIndex("bse.Certificate", new[] { "CreatorUserId" });
            DropIndex("bse.Blog", new[] { "CreatorUserId" });
            DropTable("bse.Product",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("bse.ProductCategory");
            DropTable("bse.ContactUs");
            DropTable("bse.Certificate");
            DropTable("bse.Blog");
        }
    }
}
