namespace SaveDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaveGames",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MapName = c.String(nullable: false),
                        JsonMapDictionary = c.String(nullable: false),
                        Columns = c.Int(nullable: false),
                        Rows = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SaveGames");
        }
    }
}
