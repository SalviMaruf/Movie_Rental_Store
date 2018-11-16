namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7de9abff-a9c2-4371-bb15-51feb018649f', N'admin@salvi.com', 0, N'AGlRLvbmzVZ93PH6YRBVpsbUaBXarjBlyK8vxLt/7KxAZJvA/v5ReF8JACzyihJntw==', N'74591d39-7dd8-4139-96d1-98549689ed73', NULL, 0, 0, NULL, 1, 0, N'admin@salvi.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd525d39e-4c8f-48d1-89ab-67aa5cefe82c', N'guest@vidly.com', 0, N'AORdZ8+DigGJpvYvcdeUy0YMRbxzUzPG6u418xpUmuULb3x4WHsHFbIblzNZUoqQtw==', N'f405cbc8-d616-4517-997d-1349980b5d2c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff5a6178-0a1d-42f0-813c-2e923c6c0c72', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7de9abff-a9c2-4371-bb15-51feb018649f', N'ff5a6178-0a1d-42f0-813c-2e923c6c0c72')

    ");
        }
        
        public override void Down()
        {
        }
    }
}
