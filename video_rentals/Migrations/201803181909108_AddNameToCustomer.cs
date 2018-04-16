namespace video_rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Name = 'Omar' WHERE Id = 3");
            Sql("UPDATE Customers SET Name = 'faruk' WHERE Id = 4");
          
        }
        
        public override void Down()
        {
        }
    }
}
