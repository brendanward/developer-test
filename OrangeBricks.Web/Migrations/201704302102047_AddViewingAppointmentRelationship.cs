namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewingAppointmentRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewingAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentTime = c.DateTime(nullable: false),
                        BuyerUserId = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViewingAppointments", "Property_Id", "dbo.Properties");
            DropIndex("dbo.ViewingAppointments", new[] { "Property_Id" });
            DropTable("dbo.ViewingAppointments");
        }
    }
}
