namespace ThiagoLemos.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresa", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.Empresa", "NomeEmpresa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empresa", "NomeEmpresa", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.Empresa", "Nome");
        }
    }
}
