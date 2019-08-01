namespace MusicRama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "User_Id", "dbo.Users");
            DropIndex("dbo.Songs", new[] { "User_Id" });
            RenameColumn(table: "dbo.Songs", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Songs", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.Songs", "Hates", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "UserId");
            AddForeignKey("dbo.Songs", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "UserId", "dbo.Users");
            DropIndex("dbo.Songs", new[] { "UserId" });
            AlterColumn("dbo.Songs", "UserId", c => c.Int());
            DropColumn("dbo.Songs", "Hates");
            DropColumn("dbo.Songs", "Likes");
            RenameColumn(table: "dbo.Songs", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Songs", "User_Id");
            AddForeignKey("dbo.Songs", "User_Id", "dbo.Users", "Id");
        }
    }
}
