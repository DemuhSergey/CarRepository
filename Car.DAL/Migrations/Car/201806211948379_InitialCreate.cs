namespace Car.DAL.Migrations.Car
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.Binary(),
                        Valume = c.String(),
                        Color = c.String(),
                        Transmission = c.String(),
                        ModelName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelName)
                .Index(t => t.ModelName);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 30),
                        MarkName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Marks", t => t.MarkName)
                .Index(t => t.MarkName);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "MarkName", "dbo.Marks");
            DropForeignKey("dbo.Cars", "ModelName", "dbo.Models");
            DropIndex("dbo.Models", new[] { "MarkName" });
            DropIndex("dbo.Cars", new[] { "ModelName" });
            DropTable("dbo.Marks");
            DropTable("dbo.Models");
            DropTable("dbo.Cars");
        }
    }
}
