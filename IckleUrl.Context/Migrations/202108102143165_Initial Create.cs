namespace IckleUrl.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ickle_Urls",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        full_url = c.String(nullable: false, maxLength: 1000),
                        ip = c.String(nullable: false, maxLength: 50),
                        pointer = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ickle_Urls");
        }
    }
}
