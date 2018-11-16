namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class existing_data_in_the_MembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name='Pay As Per Go' WHERE Id = 1");
            Sql("update MembershipTypes set Name='Monthly' WHERE Id = 2");
            Sql("update MembershipTypes set Name='Quarterly' WHERE Id = 3");
            Sql("update MembershipTypes set Name='Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
