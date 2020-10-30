namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'18ac6234-c2c8-47d3-b9a3-1c5978394efb', N'admin@user.com', 0, N'AJSOAFbS4QFrYcti2KUTtBdtQ6nKfiSLrmxfU64hgBVWx/DsKfx1i2T+E5Ic6fds+A==', N'871c3211-6acc-49f9-85c0-282f4b887a3a', NULL, 0, 0, NULL, 1, 0, N'admin@user.com');
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'42f48dd2-7f9d-473a-82e1-e43468a9c523', N'correo1@microsoft.com', 0, N'AHmmNecEgHCXRyDfTopwIaTlxaB6l3ELoKOK8HWC3k+74ZqmHAzpfBPYSMcjoB0OYQ==', N'1be26e67-bc3f-49f6-aae8-78d708166937', NULL, 0, 0, NULL, 1, 0, N'correo1@microsoft.com');
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f0749fdb-a9c3-4825-99bd-400a6756c962', N'guest@user.com', 0, N'AMNCmOCHppAPKfjj+RZQ8NHzUPhwu8Yjj8JQfA2HDbiJtfYocFCwt3aF5BEjJ0zlig==', N'ade614d9-8f92-4fc0-b85f-8df4f0fcd45c', NULL, 0, 0, NULL, 1, 0, N'guest@user.com');
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'68604c2f-5da1-4eb3-8cda-6e14bfe10f30', N'CanManageMovies');

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'18ac6234-c2c8-47d3-b9a3-1c5978394efb', N'68604c2f-5da1-4eb3-8cda-6e14bfe10f30');
            ");
        }
        
        public override void Down()
        {
        }
    }
}
