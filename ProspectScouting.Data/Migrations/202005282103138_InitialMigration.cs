namespace ProspectScouting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        AssignmentRequest = c.String(nullable: false),
                        SchoolID = c.Int(nullable: false),
                        ScoutID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.School", t => t.SchoolID, cascadeDelete: true)
                .ForeignKey("dbo.Scout", t => t.ScoutID, cascadeDelete: true)
                .Index(t => t.SchoolID)
                .Index(t => t.ScoutID);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        SchoolID = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolID);
            
            CreateTable(
                "dbo.Scout",
                c => new
                    {
                        ScoutID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ScoutID);
            
            CreateTable(
                "dbo.Prospect",
                c => new
                    {
                        ProspectID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Position = c.Int(nullable: false),
                        SchoolID = c.Int(nullable: false),
                        ScoutingReport = c.String(nullable: false),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BigBoard = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProspectID)
                .ForeignKey("dbo.School", t => t.SchoolID, cascadeDelete: true)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Prospect", "SchoolID", "dbo.School");
            DropForeignKey("dbo.Assignment", "ScoutID", "dbo.Scout");
            DropForeignKey("dbo.Assignment", "SchoolID", "dbo.School");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Prospect", new[] { "SchoolID" });
            DropIndex("dbo.Assignment", new[] { "ScoutID" });
            DropIndex("dbo.Assignment", new[] { "SchoolID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Prospect");
            DropTable("dbo.Scout");
            DropTable("dbo.School");
            DropTable("dbo.Assignment");
        }
    }
}
