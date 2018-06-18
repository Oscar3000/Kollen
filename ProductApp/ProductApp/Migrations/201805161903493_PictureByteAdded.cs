namespace ProductApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureByteAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Picture", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Picture", c => c.Byte(nullable: false));
        }
    }
}
