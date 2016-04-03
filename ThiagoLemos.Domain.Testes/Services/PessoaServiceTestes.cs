using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;
using ThiagoLemos.Domain.Interfaces.Repositories;
using ThiagoLemos.Domain.Interfaces.Services;
using ThiagoLemos.Domain.Services;

namespace ThiagoLemos.Domain.Testes.Services
{
    [TestClass]
    public class PessoaServiceTestes
    {
        private string cpf = "088.868.437-12";
        private string razaoSocial = "Razão";
        private string meunome = "Fantasia";
        private Pessoa pessoa;
        private Mock<IPessoaRepository> mock;
        private IPessoaService service;
        public PessoaServiceTestes()
        {
            pessoa = new Pessoa(meunome, DateTime.Now, cpf);
            mock = new Mock<IPessoaRepository>();
            service = new PessoaService(mock.Object);

        }
        [TestMethod]
        public void PessoaService_ListarTodasPessoas()
        {
            var lista = new List<Pessoa>() { pessoa, pessoa, pessoa };
            mock.Setup(x => x.GetAll()).Returns(lista);
            mock.SetupAllProperties();

            var obtido = service.ObterTodos();
            mock.Verify();
            Assert.AreEqual(lista.Count, obtido.Count);

        }


        [TestMethod]
        public void PessoaService_InserirNovaPessoa_Sucesso()
        {

            mock.Setup(x => x.Add(pessoa));
            mock.SetupAllProperties();

            service.Adicionar(pessoa);
            mock.Verify();

        }

        [TestMethod]
        public void PessoaService_InserirNovaPessoa_ErroCNPJJaCadastrado()
        {
            try
            {
                var lista = new List<Pessoa>() { pessoa };
                mock.Setup(x => x.GetAll()).Returns(lista);
                mock.Setup(x => x.Add(pessoa));

                mock.SetupAllProperties();

                service.AdicionarNovaPessoa(pessoa);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.CPF_ja_cadastrado), e.Message);
            }
        }


        [TestMethod]
        public void PessoaService_AlterarNovaPessoa_Sucesso()
        {

            mock.Setup(x => x.Update(pessoa));

            mock.SetupAllProperties();

            service.AtualizarPessoa(pessoa);
            mock.VerifyAll();

        }

        [TestMethod]
        public void PessoaService_AlterarNovaPessoa_ErroCNPJJaCadastrado()
        {
            try
            {
                var lista = new List<Pessoa>() { pessoa };
                mock.Setup(x => x.GetAll()).Returns(lista);
                mock.Setup(x => x.Update(pessoa));

                mock.SetupAllProperties();

                service.AtualizarPessoa(pessoa);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.CNPJ_ja_cadastrado), e.Message);
            }
        }


        [TestMethod]
        public void PessoaService_ExcluirPessoa_Sucesso()
        {
            
                pessoa.Colaboradores = new List<Colaborador>();
                mock.Setup(x => x.Delete(pessoa));

                mock.SetupAllProperties();

                service.ExcluirPessoa(pessoa);
                mock.VerifyAll();
            
        }

        [TestMethod]
        public void PessoaService_ExcluirPessoa_ErroPessoaColaboradoresCadastrados()
        {
            try
            {
                pessoa.Colaboradores = new List<Colaborador> { new Colaborador() };
                mock.Setup(x => x.Delete(pessoa));

                mock.SetupAllProperties();

                service.ExcluirPessoa(pessoa);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.PessoaColaboradoresCadastrados), e.Message);
            }
        }
        

    }
}
