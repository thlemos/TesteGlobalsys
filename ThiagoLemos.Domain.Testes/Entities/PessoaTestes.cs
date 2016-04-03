using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Domain.Entities;

namespace ThiagoLemos.Domain.Testes
{
    [TestClass]
    public class PessoaTestes
    {
        string nome = "Joe";
        DateTime dataNascimento = DateTime.Now;
        string cpf = "08886843712";
        




        [TestMethod]
        public void InstanciarPessoaConstrutor()
        {

            Pessoa empresa = new Pessoa(nome, dataNascimento, cpf);
            
            Assert.AreEqual(nome, empresa.Nome);
            Assert.AreEqual(cpf, empresa.Cpf);
            Assert.AreEqual(dataNascimento, empresa.DataNascimento);
        }

        [TestMethod]

        public void InstanciarPessoa_Erro_Cpf_Vazio()
        {
            try
            {
                cpf = "";
                Pessoa empresa = new Pessoa(nome, dataNascimento, cpf);
                Assert.AreNotEqual(cpf, empresa.Cpf);
            }
            catch (Exception e)
            {
                Assert.AreEqual("CPF vazio", e.Message);
            }            
        }


        [TestMethod]

        public void InstanciarPessoa_Erro_Cpf_Inválido()
        {
            try
            {
                cpf = "08886843713";
                Pessoa empresa = new Pessoa(nome, dataNascimento, cpf);
                Assert.AreNotEqual(cpf, empresa.Cpf);

            }
            catch (Exception e)
            {
                Assert.AreEqual("CPF Inválido", e.Message);
            }
        }

    }
}
