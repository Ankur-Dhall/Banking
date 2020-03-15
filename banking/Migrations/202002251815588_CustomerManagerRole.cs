namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerManagerRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'905f0524-8458-4a20-8ca3-3aad35342571', N'admin@banking.com', 0, N'AF+fhKhVBj0CiFEcXlgYpZkiA2NpfYNd2ex08c1ZNiiXqbvo+UVQ5+TpESsHbQfJGw==', N'6fee4e40-5ff4-48f7-992a-90529cc89707', NULL, 0, 0, NULL, 1, 0, N'admin@banking.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cf451edf-9021-49e9-b45f-9405d8e2b8b7', N'CustomerManager')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'905f0524-8458-4a20-8ca3-3aad35342571', N'cf451edf-9021-49e9-b45f-9405d8e2b8b7')
");
        }
        
        public override void Down()
        {
        }
    }
}
