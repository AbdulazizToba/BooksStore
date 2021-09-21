namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNeededTables1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
