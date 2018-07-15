using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Senha : Palavra
    {
        public Senha(string senha) : base(senha) { }

        public int Score
        {
            get
            {
                var score = base.QuantidadeDeCaracteres * 4;

                if ((base.QuantidadeDeCaracteresMaiusculos > 0) &&
                    (base.QuantidadeDeCaracteresMaiusculos < base.QuantidadeDeCaracteres))
                {
                    score += ((base.QuantidadeDeCaracteres - base.QuantidadeDeCaracteresMaiusculos) * 2);
                }

                if ((base.QuantidadeDeCaracteresMinusculos > 0) &&
                    (base.QuantidadeDeCaracteresMinusculos < base.QuantidadeDeCaracteres))
                {
                    score += ((base.QuantidadeDeCaracteres - base.QuantidadeDeCaracteresMinusculos) * 2);
                }

                if ((base.QuantidadeDeCaracteresNumericos > 0) &&
                    (base.QuantidadeDeCaracteresNumericos < base.QuantidadeDeCaracteres))
                {
                    score += (base.QuantidadeDeCaracteresNumericos * 4);
                }

                if (base.QuantidadeDeCaracteresSimbolos > 0)
                {
                    score += (base.QuantidadeDeCaracteresSimbolos * 6);
                }

                if (base.QuantidadeDeCaracteresNumericosOuSimbolosNoMeio > 0)
                {
                    score += (base.QuantidadeDeCaracteresNumericosOuSimbolosNoMeio * 2);
                }

                if (base.QuantidadeDeCaracteres >= 8)
                {
                    var requisitos = this.RequisitosMinimosAtendidos();

                    if (requisitos >= 4)
                    {
                        score += (requisitos * 2);
                    }
                }

                //apenas letras
                if ((base.QuantidadeDeCaracteresNumericos == 0) &&
                    (base.QuantidadeDeCaracteresSimbolos == 0))
                {
                    score -= base.QuantidadeDeCaracteresSemEspacosEmBranco;
                }

                //apenas números
                if ((base.QuantidadeDeCaracteresMaiusculos == 0) &&
                    (base.QuantidadeDeCaracteresMinusculos == 0) &&
                    (base.QuantidadeDeCaracteresSimbolos == 0))
                {
                    score -= base.QuantidadeDeCaracteresSemEspacosEmBranco;
                }

                //caracteres repetidos
                score -= this.CalculoDeComplexidadeParaCaracteresRepetidos();

                //letras maiusculas consecutivas
                score -= (this.CaracteresMaiusculosConsecutivos() * 2);

                //letras minusculas consecutivas
                score -= (this.CaracteresMinusculosConsecutivos() * 2);

                //numeros consecutivos
                score -= (this.CaracteresNumericosConsecutivos() * 2);

                //letras sequencias
                score -= (this.CaracteresLetrasSequenciais() * 3);

                //numeros sequenciais
                score -= (this.CaracteresNumericosSequenciais() * 3);

                //simbolos sequenciais
                score -= (this.CaracteresSimbolosSequenciais() * 3);

                return (score > 100 ? 100 : score < 0 ? 0 : score);
            }
        }

        public string Complexidade
        {
            get
            {
                var complexidade = "Muito curta";

                var score = this.Score;

                if (!string.IsNullOrEmpty(base.Valor))
                {
                    if ((score >= 0) && (score < 20))
                    {
                        complexidade = "Muito fraca";
                    }
                    else if ((score >= 20) && (score < 40))
                    {
                        complexidade = "Fraca";
                    }
                    else if ((score >= 40) && (score < 60))
                    {
                        complexidade = "Boa";
                    }
                    else if ((score >= 60) && (score < 80))
                    {
                        complexidade = "Forte";
                    }
                    else if ((score >= 80) && (score <= 100))
                    {
                        complexidade = "Muito forte";
                    }
                }

                return (complexidade);
            }
        }

        private int RequisitosMinimosAtendidos()
        {
            var requisitosAtendidos = 0;

            if (base.QuantidadeDeCaracteres >= 8)
            {
                requisitosAtendidos++;
            }

            if (base.QuantidadeDeCaracteresMaiusculos > 0)
            {
                requisitosAtendidos++;
            }

            if (base.QuantidadeDeCaracteresMinusculos > 0)
            {
                requisitosAtendidos++;
            }

            if (base.QuantidadeDeCaracteresNumericos > 0)
            {
                requisitosAtendidos++;
            }

            if (this.QuantidadeDeCaracteresSimbolos > 0)
            {
                requisitosAtendidos++;
            }

            return (requisitosAtendidos);
        }

        private int CalculoDeComplexidadeParaCaracteresRepetidos()
        {
            var caracteresRepetidos = 0;
            var complexidade = 0M;
            var valor = base.ValorSemEspacosEmBranco;

            for (var i = 0; i < base.QuantidadeDeCaracteresSemEspacosEmBranco; i++)
            {
                var caracterRepetido = false;

                for (var j = 0; j < base.QuantidadeDeCaracteresSemEspacosEmBranco; j++)
                {
                    if ((valor[i] == valor[j]) &&
                        (i != j))
                    {
                        caracterRepetido = true;
                        complexidade += Math.Abs(base.QuantidadeDeCaracteresSemEspacosEmBranco / Convert.ToDecimal(j - i));
                    }
                }

                if (caracterRepetido)
                {
                    var valorSemRepetidos = (base.QuantidadeDeCaracteresSemEspacosEmBranco - (++caracteresRepetidos));
                    complexidade = (valorSemRepetidos > 0) ? Math.Ceiling(complexidade / valorSemRepetidos) : Math.Ceiling(complexidade);
                }
            }

            return (Convert.ToInt32(complexidade));
        }

        private int CaracteresConsecutivos(string padrao)
        {
            var grupos = Regex.Matches(base.ValorSemEspacosEmBranco, padrao);

            var caracteresConsecutivos = 0;

            for (var i = 0; i < grupos.Count; i++)
            {
                caracteresConsecutivos += (grupos[i].Value.ToString().Length - 1);
            }

            return (caracteresConsecutivos);
        }

        private int CaracteresMaiusculosConsecutivos()
        {
            return (this.CaracteresConsecutivos(@"[A-Z]{2,9999}"));
        }

        private int CaracteresMinusculosConsecutivos()
        {
            return (this.CaracteresConsecutivos(@"[a-z]{2,9999}"));
        }

        private int CaracteresNumericosConsecutivos()
        {
            return (this.CaracteresConsecutivos(@"[0-9]{2,9999}"));
        }

        private int CaracteresSequenciais(string caracteres)
        {
            var caracteresSequenciais = 0;

            var valor = this.ValorSemEspacosEmBranco.ToLower();

            for (int i = 0; i < caracteres.Length - 3; i++)
            {
                var str = caracteres.Substring(i, 3);

                if (valor.Contains(str) || valor.Contains(new string(str.Reverse().ToArray())))
                {
                    caracteresSequenciais++;
                }
            }

            return (caracteresSequenciais);
        }

        private int CaracteresLetrasSequenciais()
        {
            return (this.CaracteresSequenciais("abcdefghijklmnopqrstuvwxyz"));
        }

        private int CaracteresNumericosSequenciais()
        {
            return (this.CaracteresSequenciais("01234567890"));
        }

        private int CaracteresSimbolosSequenciais()
        {
            return (this.CaracteresSequenciais(")!@#$%^&*("));
        }
    }
}
