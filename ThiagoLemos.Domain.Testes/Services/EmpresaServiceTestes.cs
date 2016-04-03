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
    public class EmpresaServiceTestes
    {
        private string cnpj = "87.486.907/0001-90";
        private string razaoSocial = "Razão";
        private string meunome = "Fantasia";
        private Empresa empresa;
        private Mock<IEmpresaRepository> mock;
        private IEmpresaService service;
        public EmpresaServiceTestes()
        {
            empresa = new Empresa(meunome, razaoSocial, cnpj);
            mock = new Mock<IEmpresaRepository>();
            service = new EmpresaService(mock.Object);

        }
        [TestMethod]
        public void EmpresaService_ListarTodasEmpresas()
        {
            var lista = new List<Empresa>() { empresa, empresa, empresa };
            mock.Setup(x => x.GetAll()).Returns(lista);
            mock.SetupAllProperties();

            var obtido = service.ObterTodos();
            mock.Verify();
            Assert.AreEqual(lista.Count, obtido.Count);

        }


        [TestMethod]
        public void EmpresaService_InserirNovaEmpresa_Sucesso()
        {

            mock.Setup(x => x.Add(empresa));
            mock.SetupAllProperties();

            service.Adicionar(empresa);
            mock.Verify();

        }

        [TestMethod]
        public void EmpresaService_InserirNovaEmpresa_ErroCNPJJaCadastrado()
        {
            try
            {
                var lista = new List<Empresa>() { empresa };
                mock.Setup(x => x.GetAll()).Returns(lista);
                mock.Setup(x => x.Add(empresa));

                mock.SetupAllProperties();

                service.AdicionarNovaEmpresa(empresa);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.CNPJ_ja_cadastrado), e.Message);
            }
        }


        [TestMethod]
        public void EmpresaService_AlterarNovaEmpresa_Sucesso()
        {

            mock.Setup(x => x.Update(empresa));

            mock.SetupAllProperties();

            service.AtualizarEmpresa(empresa);
            mock.VerifyAll();

        }

        [TestMethod]
        public void EmpresaService_AlterarNovaEmpresa_ErroCNPJJaCadastrado()
        {
            try
            {
                var lista = new List<Empresa>() { empresa };
                mock.Setup(x => x.GetAll()).Returns(lista);
                mock.Setup(x => x.Update(empresa));

                mock.SetupAllProperties();

                service.AtualizarEmpresa(empresa);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.CNPJ_ja_cadastrado), e.Message);
            }
        }


        [TestMethod]
        public void EmpresaService_ExcluirEmpresa_Sucesso()
        {
            
                empresa.Colaboradores = new List<Colaborador>();
                mock.Setup(x => x.Delete(empresa));

                mock.SetupAllProperties();

                service.ExcluirEmpresa(empresa);
                mock.VerifyAll();
            
        }

        [TestMethod]
        public void EmpresaService_ExcluirEmpresa_ErroEmpresaColaboradoresCadastrados()
        {
            try
            {
                empresa.Colaboradores = new List<Colaborador> { new Colaborador() };
                mock.Setup(x => x.Delete(empresa));

                mock.SetupAllProperties();

                service.ExcluirEmpresa(empresa);
                mock.VerifyAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(EnumHelper.Descricao(MensagemErro.EmpresaColaboradoresCadastrados), e.Message);
            }
        }
        

    }
}
