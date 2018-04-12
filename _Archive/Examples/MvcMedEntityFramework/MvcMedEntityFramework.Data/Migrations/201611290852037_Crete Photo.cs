namespace MvcMedEntityFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CretePhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StreetName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Address");
        }
    }
}
