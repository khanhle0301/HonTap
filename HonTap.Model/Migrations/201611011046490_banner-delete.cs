namespace HonTap.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bannerdelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PostCategories", "Description");
            DropColumn("dbo.Posts", "HotFlag");
            DropColumn("dbo.Posts", "HotNewsFlag");
            DropColumn("dbo.Posts", "EventFlag");
            DropTable("dbo.Banners");
            DropTable("dbo.Blocks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        Type = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        Type = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "EventFlag", c => c.Boolean());
            AddColumn("dbo.Posts", "HotNewsFlag", c => c.Boolean());
            AddColumn("dbo.Posts", "HotFlag", c => c.Boolean());
            AddColumn("dbo.PostCategories", "Description", c => c.String(maxLength: 500));
        }
    }
}
