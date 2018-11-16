namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemoviemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOfItemsInStock", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberOfItemsInStock");
        }
    }
}
