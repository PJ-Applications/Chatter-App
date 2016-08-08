namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chats40 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followers", new[] { "UserId" });
            DropIndex("dbo.Followers", new[] { "FollowerId" });
            RenameColumn(table: "dbo.Chats", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Chats", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            DropTable("dbo.Followers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerId });
            
            RenameIndex(table: "dbo.Chats", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Chats", name: "User_Id", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Followers", "FollowerId");
            CreateIndex("dbo.Followers", "UserId");
            AddForeignKey("dbo.Followers", "FollowerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
