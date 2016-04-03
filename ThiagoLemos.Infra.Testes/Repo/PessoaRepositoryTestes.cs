using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Infra.Contextos;

namespace ThiagoLemos.Infra.Testes
{
    [TestClass]
    public class PessoaRepositoryTestes
    {
        private Contexto db;
        private IPessoaRepository repo;
        private Pessoa pessoa;



        [TestInitialize]
        public void Iniciar()
        {
            db = new Contexto();
            repo = new PessoaRepository(db);
            pessoa = new Pessoa("Nome1", DateTime.Now, "08886843712");
            db.Database.ExecuteSqlCommand(" DELETE FROM PESSOA; DBCC CHECKIDENT ('Globalsys.dbo.PESSOA',RESEED, 0);");
        }


        [TestMethod]
        public void Pessoa_Repo_Inserir()
        {
            repo.Add(pessoa);
            repo.Save();

            var obj = repo.GetById(1);
            Assert.AreEqual(obj.Nome,pessoa.Nome);
            Assert.AreEqual(obj.Cpf, pessoa.Cpf);
            Assert.AreEqual(obj.DataNascimento, pessoa.DataNascimento);

        }

        [TestMethod]
        public void Pessoa_Repo_Update()
        {
            var novoNome = "novonome";
            InserirPessoa();

            var obj = repo.GetById(1);
            obj.Nome = novoNome;
            repo.Update(obj);
            repo.Save();

            Assert.AreEqual(novoNome,obj.Nome);

        }

        [TestMethod]
        public void Pessoa_Repo_ListarTodos()
        {
            InserirPessoa();
            InserirPessoa();
            var obj = repo.GetAll().ToList();
            Assert.AreEqual(2,obj.Count);

        }

        [TestMethod]
        public void Pessoa_Repo_ListarPorId()
        {
            
            InserirPessoa();
            var obj = repo.GetById(1);
            Assert.IsNotNull(obj.DataCadastro);
        }




        private void InserirPessoa()
        {
            repo.Add(pessoa);
            repo.Save();
        }

        [TestCleanup]
        public void Finalizar()
        {
            db.Database.ExecuteSqlCommand(" DELETE FROM PESSOA; DBCC CHECKIDENT ('Globalsys.dbo.PESSOA',RESEED, 0);");
        }

    }
}
