namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert_data_into_genre_table : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Name) values ('Comedy')");
            Sql("insert into Genres (Name) values ('Action')");
            Sql("insert into Genres (Name) values ('Romance')");
            Sql("insert into Genres (Name) values ('Science Fiction')");
            Sql("insert into Genres (Name) values ('War')");
        }
        
        public override void Down()
        {
        }
    }
}
