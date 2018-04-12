namespace MvcMedEntityFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStreetNumbertoAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "StreetNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Address", "StreetNumber");
        }
    }
}
