namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIsAvailableFromViewingAppointments : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ViewingAppointments", "IsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewingAppointments", "IsAvailable", c => c.Boolean(nullable: false));
        }
    }
}
