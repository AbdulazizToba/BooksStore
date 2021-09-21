namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNeededTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
