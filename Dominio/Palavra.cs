using System.Text.RegularExpressions;

namespace Dominio
{
    public class Palavra
    {
        public string Valor { get; private set; }

        public Palavra(string valor)
        {
            this.Valor = valor;
        }

        public int QuantidadeDeCaracteres
        {
            get
            {
                return (this.Valor.Length);
            }
        }

        public string ValorSemEspacosEmBranco
        {
            get
            {
                return (Regex.Replace(this.Valor, @"\s", string.Empty));
            }
        }

        public int QuantidadeDeCaracteresSemEspacosEmBranco
        {
            get
            {
                return (this.ValorSemEspacosEmBranco.Length);
            }
        }

        public int QuantidadeDeCaracteresMaiusculos
        {
            get
            {
                return (Regex.Matches(this.ValorSemEspacosEmBranco, @"[A-Z]").Count);
            }
        }

        public int QuantidadeDeCaracteresMinusculos
        {
            get
            {
                return (Regex.Matches(this.ValorSemEspacosEmBranco, @"[a-z]").Count);
            }
        }

        public int QuantidadeDeCaracteresNumericos
        {
            get
            {
                return (Regex.Matches(this.ValorSemEspacosEmBranco, @"[\d]").Count);
            }
        }

        public int QuantidadeDeCaracteresSimbolos
        {
            get
            {
                return (Regex.Matches(this.ValorSemEspacosEmBranco, @"[^a-zA-Z0-9_]").Count);
            }
        }

        public int QuantidadeDeCaracteresNumericosOuSimbolosNoMeio
        {
            get
            {
                var numerosOuSimbolosNoMeio = 0;

                var valor = this.ValorSemEspacosEmBranco;

                if (valor.Length > 2)
                {
                    valor = valor.Substring(1, valor.Length - 2);

                    numerosOuSimbolosNoMeio += Regex.Matches(valor, @"[\d]").Count;
                    numerosOuSimbolosNoMeio += Regex.Matches(valor, @"[^a-zA-Z0-9_]").Count;
                }

                return (numerosOuSimbolosNoMeio);
            }
        }
    }
}