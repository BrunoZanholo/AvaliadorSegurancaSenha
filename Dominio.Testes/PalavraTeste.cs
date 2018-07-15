using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dominio.Testes
{
    /// <summary>
    /// Classe de testes unitários do dominio: Palavra
    /// </summary>
    [TestClass]
    public class PalavraTeste
    {
        [TestMethod]
        public void QuandoPalavraVazia_Valores_IguaisA_Vazio()
        {
            var palavra = new Palavra(string.Empty);

            Assert.AreEqual(string.Empty, palavra.Valor);
            Assert.AreEqual(string.Empty, palavra.ValorSemEspacosEmBranco);
        }

        [TestMethod]
        public void QuandoPalavraVazia_Quantidades_IguaisA_Zero()
        {
            var palavra = new Palavra(string.Empty);

            Assert.AreEqual(0, palavra.QuantidadeDeCaracteres);
            Assert.AreEqual(0, palavra.QuantidadeDeCaracteresSemEspacosEmBranco);
            Assert.AreEqual(0, palavra.QuantidadeDeCaracteresMaiusculos);
            Assert.AreEqual(0, palavra.QuantidadeDeCaracteresMinusculos);
            Assert.AreEqual(0, palavra.QuantidadeDeCaracteresNumericos);
            Assert.AreEqual(0, palavra.QuantidadeDeCaracteresNumericosOuSimbolosNoMeio);            
            Assert.AreEqual(0, palavra.QuantidadeDeCaracteresSimbolos);
        }

        [TestMethod]
        public void QuandoPalavraDiferenteDeVazia_Valores_DiferentesDe_Vazio()
        {
            var palavra = new Palavra("palavra");

            Assert.AreNotEqual(string.Empty, palavra.Valor);
            Assert.AreNotEqual(string.Empty, palavra.ValorSemEspacosEmBranco);
        }

        [TestMethod]
        public void QuandoPalavraDiferenteDeVazia_QuantidadeDeCaracteres_DiferenteDe_Zero()
        {
            var palavra = new Palavra("palavra");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteres);
        }

        [TestMethod]
        public void QuandoPalavraDiferenteDeVaziaComEspacosEmBranco_QuantidadeDeCaracteresSemEspacosEmBranco_DiferenteDe_Zero()
        {
            var palavra = new Palavra("pal  avra");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteresSemEspacosEmBranco);
        }

        [TestMethod]
        public void QuandoPalavraComLetrasMinusculas_QuantidadeDeCaracteresMinusculos_DiferenteDe_Zero()
        {
            var palavra = new Palavra("palavra");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteresMinusculos);
        }

        [TestMethod]
        public void QuandoPalavraComLetrasMaiusculas_QuantidadeDeCaracteresMaiusculos_DiferenteDe_Zero()
        {
            var palavra = new Palavra("paLAvra");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteresMaiusculos);
        }

        [TestMethod]
        public void QuandoPalavraComCaracteresNumericos_QuantidadeDeCaracteresNumericos_DiferenteDe_Zero()
        {
            var palavra = new Palavra("paLAvra2000");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteresNumericos);
        }

        [TestMethod]
        public void QuandoPalavraComCaracteresSimbolos_QuantidadeDeCaracteresSimbolos_DiferenteDe_Zero()
        {
            var palavra = new Palavra("paLAvra@");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteresSimbolos);
        }

        [TestMethod]
        public void QuandoPalavraComNumericosOuSimbolosNoMeio_QuantidadeDeCaracteresNumericosOuSimbolosNoMeio_DiferenteDe_Zero()
        {
            var palavra = new Palavra("paLAvra@2000k");

            Assert.AreNotEqual(0, palavra.QuantidadeDeCaracteresNumericosOuSimbolosNoMeio);
        }
    }
}
