namespace video_rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSetBirthDayToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = CAST('1980-01-01' AS DATETIME) WHERE Id=3");
            Sql("UPDATE Customers SET Birthday = CAST('1990-02-02' AS DATETIME) WHERE Id=4");

        }
        
        public override void Down()
        {
        }
    }
}
