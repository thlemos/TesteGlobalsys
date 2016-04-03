using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThiagoLemos.Domain.Entities;
using ThiagoLemos.Domain.Enums;

namespace ThiagoLemos.Domain.Testes
{
    [TestClass]
    public class ColaboradorTestes
    {
        private string cargo = "cargo 1";
        private double salario = 1000;
        
        




        [TestMethod]
        public void InstanciarColaboradorColaboradorConstrutor()
        {
            
            Colaborador Colaborador = new Colaborador(1,1,cargo,salario);
            Assert.AreEqual(cargo, Colaborador.Cargo);
            Assert.AreEqual(salario, Colaborador.Salario);
            Assert.AreEqual(Status.Ativo, Colaborador.Status);

        }

        

    }
}
