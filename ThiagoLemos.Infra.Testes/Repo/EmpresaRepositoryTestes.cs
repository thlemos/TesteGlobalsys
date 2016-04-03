using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;
using ThiagoLemos.Infra.Repositories;

namespace ThiagoLemos.Infra.Testes
{
    [TestClass]
    public class EmpresaRepositoryTestes
    {
        private Contexto db;
        private IEmpresaRepository repo;
        private Empresa empresa;
        private string cnpj = "19.563.227/0001-73";


        [TestInitialize]
        public void Iniciar()
        {
            db = new Contexto();
            repo = new EmpresaRepository(db);
            empresa = new Empresa("Empresa XPTO", "XPTO Ltda", cnpj);
            db.Database.ExecuteSqlCommand(" DELETE FROM EMPRESA; DBCC CHECKIDENT ('Globalsys.dbo.Empresa',RESEED, 0);");
        }


        [TestMethod]
        public void Empresa_Repo_Inserir()
        {
            repo.Add(empresa);
            repo.Save();

            var obj = repo.GetById(1);
            Assert.AreEqual(obj.Nome,empresa.Nome);
            Assert.AreEqual(obj.Cnpj, empresa.Cnpj);
            Assert.AreEqual(obj.RazaoSocial, empresa.RazaoSocial);

        }

        [TestMethod]
        public void Empresa_Repo_Update()
        {
            var novoNome = "novonome";
            InserirEmpresa();

            var obj = repo.GetById(1);
            obj.Nome = novoNome;
            repo.Update(obj);
            repo.Save();

            Assert.AreEqual(novoNome,obj.Nome);

        }

        [TestMethod]
        public void Empresa_Repo_ListarTodos()
        {
            InserirEmpresa();
            InserirEmpresa();
            var obj = repo.GetAll().ToList();
            Assert.AreEqual(2,obj.Count);

        }

        [TestMethod]
        public void Empresa_Repo_ListarPorId()
        {
            
            InserirEmpresa();
            var obj = repo.GetById(1);
            Assert.IsNotNull(obj.DataCadastro);
        }




        private void InserirEmpresa()
        {
            repo.Add(empresa);
            repo.Save();
        }

        [TestCleanup]
        public void Finalizar()
        {
            db.Database.ExecuteSqlCommand(" DELETE FROM EMPRESA; DBCC CHECKIDENT ('Globalsys.dbo.Empresa',RESEED, 0);");
        }

    }
}
