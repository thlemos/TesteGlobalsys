namespace ThiagoLemos.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaborador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Cargo = c.String(nullable: false, maxLength: 100, unicode: false),
                        Salario = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataDemissao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.EmpresaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 14, unicode: false),
                        NomeEmpresa = c.String(nullable: false, maxLength: 50, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colaborador", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Colaborador", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.Colaborador", new[] { "PessoaId" });
            DropIndex("dbo.Colaborador", new[] { "EmpresaId" });
            DropTable("dbo.Pessoa");
            DropTable("dbo.Empresa");
            DropTable("dbo.Colaborador");
        }
    }
}
