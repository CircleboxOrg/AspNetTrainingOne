namespace Technicality.AspNetTrainingOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class City : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.City");
        }
    }
}
