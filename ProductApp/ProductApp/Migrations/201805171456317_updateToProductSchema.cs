namespace ProductApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateToProductSchema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Picture", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Picture", c => c.Binary(nullable: false));
        }
    }
}
