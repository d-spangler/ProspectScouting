

namespace ProspectScouting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prospect", "Report", c => c.String(nullable: false));
            DropColumn("dbo.Prospect", "ScoutingReport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prospect", "ScoutingReport", c => c.String(nullable: false));
            DropColumn("dbo.Prospect", "Report");
        }
    }
}
