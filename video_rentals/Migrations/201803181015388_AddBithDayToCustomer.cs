namespace video_rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBithDayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
