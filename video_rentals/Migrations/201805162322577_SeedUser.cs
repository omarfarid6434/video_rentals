namespace video_rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ac62122-2773-42ca-bb93-5b060f969835', N'admin@gmail.com', 0, N'AMj4A8Ix/plJ8np0GMNEHz00i1fzjZpu8niAT8RCb5P99J0HVMyWfVN6hHUcMP+97Q==', N'c9df6bfb-79c9-4df4-84f3-270bb51aa600', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'74ab9f83-b517-418b-8a5c-b7b0fb89adc0', N'omar@gmail.com', 0, N'AO6h+JGlM9PPr3vSJMFtej/VTEEv3eDKcMfSC2sR3N6ECpmaRll4lwDTa3xb2fas6Q==', N'2ed79257-cd56-49c6-b1af-2cd981b62c04', NULL, 0, 0, NULL, 1, 0, N'omar@gmail.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'896049ce-f2b0-4140-ae1d-75eeeb873935', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1ac62122-2773-42ca-bb93-5b060f969835', N'896049ce-f2b0-4140-ae1d-75eeeb873935')
                

                ");
        }
        
        public override void Down()
        {
        }
    }
}
