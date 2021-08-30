namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4c18e8e4-3190-4b76-ba43-13d6bd4044e0', N'admin@admin.pl', 0, N'AF0C9ukd22+8JDMD6UOMZjqYp0xa6QQ54RM4B4IKQcSh2aQCGhK/XHO2ir8eShy5jA==', N'e88f0394-a6e2-4550-92b2-f8762d7b7b5a', NULL, 0, 0, NULL, 1, 0, N'admin@admin.pl')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ecc6cf62-9569-4e39-93e3-296b6fa6d415', N'user@user.pl', 0, N'AFw3IS08hXg3liyg9tI3OK/t9/xcV1G3F/2suidNuN/VDdHoEhUXLlXVPIVnJM7Xyg==', N'7781bfc4-fb5b-43ac-84df-ba60b5392c5e', NULL, 0, 0, NULL, 1, 0, N'user@user.pl')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6b23c788-4262-403b-ad1a-5af15e1e4da2', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4c18e8e4-3190-4b76-ba43-13d6bd4044e0', N'6b23c788-4262-403b-ad1a-5af15e1e4da2')

");
        }
        
        public override void Down()
        {
        }
    }
}
