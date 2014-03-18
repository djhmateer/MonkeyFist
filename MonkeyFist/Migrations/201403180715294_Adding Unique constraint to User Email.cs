namespace MonkeyFist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUniqueconstrainttoUserEmail : DbMigration
    {
        public override void Up()
        {
            CreateIndex(table: "Users", column: "Email", unique: true, name: "UniqueEmailIdx");
        }
        
        public override void Down()
        {
            DropIndex(table: "Users", name: "UniqueEmail");
        }
    }
}
