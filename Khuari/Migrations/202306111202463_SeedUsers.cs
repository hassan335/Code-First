namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'173ba518-a362-4b51-a43f-608990d4d517', N'mhassan1@mvc.com', 0, N'AGhBY0/jndLJwGXaYpzXCA8KHa/lu6QF2QMbx5N8N3u1GkoKpn1hJDp6+g9DmzYv9w==', N'3a898190-62fd-40db-bacb-b09c5bda1eca', NULL, 0, 0, NULL, 1, 0, N'mhassan1@mvc.com')

INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'953f5c5c-ae21-446a-93b6-224f0c6c21a8', N'admin@vidl.com', 0, N'ADZq23mqlXbKdehojndNPn+CkcSHPaOkZjVKSCV1I2SmPF+gGPiJDcvxY/zE7laxqA==', N'f0e69aeb-ad10-4384-bf18-b4c916490f1a', NULL, 0, 0, NULL, 1, 0, N'admin@vidl.com')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e66eb8f-9cd7-49b1-b2e0-781522623270', N'CanManageMovies')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'953f5c5c-ae21-446a-93b6-224f0c6c21a8', N'1e66eb8f-9cd7-49b1-b2e0-781522623270')


");
        }
        
        public override void Down()
        {
        }
    }
}
