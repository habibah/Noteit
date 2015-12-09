namespace Noteit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteAddedToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MyNotes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.MyNotes");
        }
    }
}
