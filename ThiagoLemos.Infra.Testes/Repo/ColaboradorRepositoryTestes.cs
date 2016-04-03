using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;
using ThiagoLemos.Infra.Repositories;

namespace ThiagoLemos.Infra.Testes
{
    [TestClass]
    public class ColaboradorRepositoryTestes
    {
        private Contexto db;
        private IColaboradorRepository repo;
        private Colaborador Colaborador;
        private Empresa empresa;
        private Pessoa pessoa;



        [TestInitialize]
        public void Iniciar()
        {
            db = new Contexto();
            repo = new ColaboradorRepository(db);

            db.Database.ExecuteSqlCommand(" DELETE FROM Colaborador; DBCC CHECKIDENT ('Globalsys.dbo.Colaborador',RESEED, 0);");
            db.Database.ExecuteSqlCommand(" DELETE FROM Pessoa; DBCC CHECKIDENT ('Globalsys.dbo.Colaborador',RESEED, 0);");
            db.Database.ExecuteSqlCommand(" DELETE FROM Empresa; DBCC CHECKIDENT ('Globalsys.dbo.Colaborador',RESEED, 0);");            

            InserirEmpresa();
            InserirPessoa();
            Colaborador = new Colaborador(pessoa.Id,empresa.Id,"Analista",1000);
        }


        [TestMethod]
        public void Colaborador_Repo_Inserir()
        {
            repo.Add(Colaborador);
            repo.Save();

            var obj = repo.GetById(1);
            Assert.AreEqual(obj.Cargo, Colaborador.Cargo);
            Assert.AreEqual(obj.Salario, Colaborador.Salario);
            Assert.AreEqual(obj.Pessoa.Nome, Colaborador.Pessoa.Nome);
            Assert.AreEqual(obj.Empresa.Nome, Colaborador.Empresa.Nome);

        }


        [TestMethod]
        public void Colaborador_Repo_Update()
        {
            var novosalario = 2000;
            InserirColaborador();

            var obj = repo.GetById(1);
            obj.Salario = novosalario;
            repo.Update(obj);
            repo.Save();

            Assert.AreEqual(novosalario,obj.Salario);

        }

        [TestMethod]
        public void Colaborador_Repo_ListarTodos()
        {
            InserirColaborador();
            InserirColaborador();
            var obj = repo.GetAll().ToList();
            Assert.AreEqual(2,obj.Count);

        }

        [TestMethod]
        public void Colaborador_Repo_ListarPorId()
        {
            
            InserirColaborador();
            var obj = repo.GetById(1);
            Assert.IsNotNull(obj.DataCadastro);
        }




        private void InserirColaborador()
        {
            repo.Add(Colaborador);
            repo.Save();
        }



        private void InserirEmpresa()
        {
            string cnpj_valido = "19.563.227/0001-73";
            empresa = new Empresa("Empresa XPTO", "XPTO Ltda", cnpj_valido);
            var empresaRepository = new EmpresaRepository(db);
            empresaRepository.Add(empresa);
            empresaRepository.Save();
        }



        private void InserirPessoa()
        {
            pessoa = new Pessoa("Nome1", DateTime.Now, "08886843712");
            var pessoaRepository = new PessoaRepository(db);
            pessoaRepository.Add(pessoa);
            pessoaRepository.Save();
        }

        [TestCleanup]
        public void Finalizar()
        {
            db.Database.ExecuteSqlCommand(" delete from colaborador; dbcc checkident ('globalsys.dbo.colaborador',reseed, 0);");
            db.Database.ExecuteSqlCommand(" delete from pessoa; dbcc checkident ('globalsys.dbo.colaborador',reseed, 0);");
            db.Database.ExecuteSqlCommand(" delete from empresa; dbcc checkident ('globalsys.dbo.colaborador',reseed, 0);");
            
        }

    }
}
