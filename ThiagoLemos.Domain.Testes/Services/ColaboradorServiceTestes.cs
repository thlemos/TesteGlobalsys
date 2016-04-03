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
    public class ColaboradorServiceTestes
    {
        private string cnpj = "87.486.907/0001-90";
        private string razaoSocial = "Razão";
        private string meunome = "Fantasia";
        private Empresa empresa;

        private string cpf = "088.868.437-12";
        
        private Pessoa pessoa;


        private Mock<IColaboradorRepository> mock;
        private IColaboradorService service;
        private string cargo = "Gerente";
        private double salario = 10000;
        private Colaborador colaborador;


        public ColaboradorServiceTestes()
        {
            empresa = new Empresa(meunome, razaoSocial, cnpj);
            empresa.Id = 1;
            pessoa = new Pessoa(meunome, DateTime.Now, cpf);
            pessoa.Id = 1;

            colaborador = new Colaborador(1,1,cargo,salario);
            mock = new Mock<IColaboradorRepository>();
            service = new ColaboradorService(mock.Object);

        }
        [TestMethod]
        public void ColaboradorService_ListarTodos()
        {
            var lista = new List<Colaborador>() { colaborador, colaborador, colaborador };
            mock.Setup(x => x.GetAll()).Returns(lista);
            mock.SetupAllProperties();

            var obtido = service.ObterTodos();
            mock.Verify();
            Assert.AreEqual(lista.Count, obtido.Count);

        }


        [TestMethod]
        public void ColaboradorService_InserirNovaEmpresa_Sucesso()
        {

            mock.Setup(x => x.Add(colaborador));
            mock.SetupAllProperties();

            service.Adicionar(colaborador);
            mock.Verify();

        }

        [TestMethod]
        public void ColaboradorService_InserirNovoColaborador_Erro_Pessoa_Ja_Colaborador_Empresa()
        {
            try
            {
                var lista = new List<Colaborador>() { colaborador };
                mock.Setup(x => x.GetAll()).Returns(lista);
                mock.Setup(x => x.Add(colaborador));

                mock.SetupAllProperties();

                service.AdicionarNovoColaborador(colaborador);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.Pessoa_ja_colaborador_Empresa), e.Message);
            }
        }


        [TestMethod]
        public void ColaboradorService_Alterar_Sucesso()
        {

            mock.Setup(x => x.Update(colaborador));

            mock.SetupAllProperties();

            service.AtualizarColaborador(colaborador);
            mock.VerifyAll();

        }

        [TestMethod]
        public void ColaboradorService_Alterar_ErroColaboradorJaCadastrado()
        {
            try
            {
                colaborador.Id = 999;
                var lista = new List<Colaborador>() { colaborador };
                mock.Setup(x => x.GetAll()).Returns(lista);
                mock.Setup(x => x.Update(colaborador));

                mock.SetupAllProperties();

                service.AtualizarColaborador(colaborador);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.Pessoa_ja_colaborador_Empresa), e.Message);
            }
        }


        [TestMethod]
        public void EmpresaService_ExcluirEmpresa_Sucesso()
        {
            
                empresa.Colaboradores = new List<Colaborador>();
                mock.Setup(x => x.Delete(colaborador));

                mock.SetupAllProperties();

                service.ExcluirColaborador(colaborador);
                mock.VerifyAll();
            
        }

        [TestMethod]
        public void EmpresaService_Demitir_Sucesso()
        {

            
            mock.Setup(x => x.Update(colaborador));

            mock.SetupAllProperties();

            service.Demitir(colaborador);
            mock.VerifyAll();

        }
        

    }
}
