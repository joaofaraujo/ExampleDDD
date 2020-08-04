using Inception.Domain.Entities;
using NUnit.Framework;
using System;

namespace Inception.Test.Domain
{
    public class InceptionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateInceptions()
        {
            // arrange
            string nome = "Criação de um aplicativo para abertura de conta digital";
            DateTime dataCriacao = DateTime.Now;

            //act
            var inception = new Inceptions(nome, dataCriacao);

            //assert
            Assert.AreEqual(nome, inception.Nome);
            Assert.AreEqual(dataCriacao, inception.DataCriacao);
        }

        [Test]
        public void CreateInceptionsAndGenerateNewIdentificador()
        {
            // arrange
            string nome = "Criação de um aplicativo para abertura de conta digital";
            DateTime dataCriacao = DateTime.Now;

            //act
            var inception = new Inceptions(nome, dataCriacao);
            inception.SetNewIdentificador(1);

            //assert
            Assert.AreEqual(nome, inception.Nome);
            Assert.AreEqual(dataCriacao, inception.DataCriacao);
            Assert.AreEqual("IN-2020-2", inception.Identificador);
        }

        [Test]
        public void UpdateInceptions()
        {
            // arrange
            string nome = "Criação de um aplicativo para abertura de conta digital";
            string nomeAtualizado = "Criação de um aplicativo para abertura de conta digital - Pessoas Físicas";
            DateTime dataCriacao = DateTime.Now;

            //act
            var inception = new Inceptions(nome, dataCriacao);

            inception.UpdateInceptions(nomeAtualizado);

            //assert
            Assert.AreEqual(nomeAtualizado, inception.Nome);
            Assert.AreEqual(DateTime.Now.Date, inception.DataAtualizacao.Value.Date);
        }
    }
}