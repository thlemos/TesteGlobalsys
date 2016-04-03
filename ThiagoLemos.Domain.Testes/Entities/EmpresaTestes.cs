using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Domain.Testes
{
    [TestClass]
    public class EmpresaTestes
    {
        string nomeEmpresa = "Empresa 1";
        string razaoSocial = "Empresa XXXXX";
        string cnpj_valido = "19.563.227/0001-73";
        string cnpj_valido_sem_ponto = "19563227000173";
        private string cnpj_invalido;
        




        [TestMethod]
        public void InstanciarEmpresaConstrutor()
        {

            Empresa empresa = new Empresa(nomeEmpresa, razaoSocial, cnpj_valido);
            
            Assert.AreEqual(nomeEmpresa, empresa.Nome);
            Assert.AreEqual(razaoSocial, empresa.RazaoSocial);
            Assert.AreEqual(cnpj_valido_sem_ponto, empresa.Cnpj);

        }

        [TestMethod]
        
        public void InstanciarEmpresa_Erro_Cnpj_Vazio()
        {
            try
            {
                cnpj_valido = "";
                Empresa empresa = new Empresa(nomeEmpresa, razaoSocial, cnpj_valido);
                Assert.AreNotEqual(cnpj_valido, empresa.Cnpj);
            }
            catch (Exception e)
            {
                Assert.AreEqual("CNPJ vazio", e.Message);
            }            
        }


        [TestMethod]
        
        public void InstanciarEmpresa_Erro_Cnpj_Inválido()
        {
            try
            {
                cnpj_invalido = "08886843713";
                Empresa empresa = new Empresa(nomeEmpresa, razaoSocial, cnpj_invalido);
                Assert.AreNotEqual(cnpj_invalido, empresa.Cnpj);

            }
            catch (Exception e)
            {
                Assert.AreEqual("CNPJ Inválido", e.Message);
            }
        }

    }
}
