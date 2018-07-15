using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dominio.Testes
{
    /// <summary>
    /// Classe de testes unitários do dominio: Senha
    /// </summary>
    [TestClass]
    public class SenhaTeste
    {
        const string SenhaScoreMuitoFraco = "paSS";
        const string SenhaScoreFraco = "paSS2";
        const string SenhaScoreBom = "paSS2@";
        const string SenhaScoreForte = "paSS2@2";
        const string SenhaScoreMuitoForte = "paSS2@22M";

        [TestMethod]
        public void QuandoSenhaVazia_Complexidade_IgualA_MuitoCurta()
        {
            var senha = new Senha(string.Empty);

            Assert.AreEqual("Muito curta", senha.Complexidade);
        }

        [TestMethod]
        public void QuandoScore_MaiorIgualA0_MenorQue20_Complexidade_IgualA_MuitoFraca()
        {
            var senha = new Senha(SenhaScoreMuitoFraco);

            Assert.AreEqual("Muito fraca", senha.Complexidade);            
        }

        [TestMethod]
        public void QuandoScore_MaiorIgualA20_MenorQue40_Complexidade_IgualA_Fraca()
        {
            var senha = new Senha(SenhaScoreFraco);

            Assert.AreEqual("Fraca", senha.Complexidade);
        }

        [TestMethod]
        public void QuandoScore_MaiorIgualA40_MenorQue60_Complexidade_IgualA_Boa()
        {
            var senha = new Senha(SenhaScoreBom);

            Assert.AreEqual("Boa", senha.Complexidade);
        }

        [TestMethod]
        public void QuandoScore_MaiorIgualA60_MenorQue80_Complexidade_IgualA_Forte()
        {
            var senha = new Senha(SenhaScoreForte);

            Assert.AreEqual("Forte", senha.Complexidade);
        }

        [TestMethod]
        public void QuandoScore_MaiorIgualA80_MenorIgual100_Complexidade_IgualA_Muitoforte()
        {
            var senha = new Senha(SenhaScoreMuitoForte);

            Assert.AreEqual("Muito forte", senha.Complexidade);
        }
    }
}