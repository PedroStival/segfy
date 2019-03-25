namespace Insurance.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(),
                        DtInsert = c.DateTime(nullable: false),
                        DtUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoTipo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Tipo = c.String(),
                        DtInsert = c.DateTime(nullable: false),
                        DtUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seguro",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Cpf = c.String(maxLength: 14),
                        ProdutoTipoId = c.Long(nullable: false),
                        ProdutoId = c.Long(nullable: false),
                        DtInsert = c.DateTime(nullable: false),
                        DtUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .ForeignKey("dbo.ProdutoTipo", t => t.ProdutoTipoId)
                .Index(t => t.ProdutoTipoId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seguro", "ProdutoTipoId", "dbo.ProdutoTipo");
            DropForeignKey("dbo.Seguro", "ProdutoId", "dbo.Produto");
            DropIndex("dbo.Seguro", new[] { "ProdutoId" });
            DropIndex("dbo.Seguro", new[] { "ProdutoTipoId" });
            DropTable("dbo.Seguro");
            DropTable("dbo.ProdutoTipo");
            DropTable("dbo.Produto");
        }
    }
}
