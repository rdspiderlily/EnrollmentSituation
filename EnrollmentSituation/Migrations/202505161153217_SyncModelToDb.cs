namespace EnrollmentSituation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncModelToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudIDNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudIDNumber");
        }
    }
}
