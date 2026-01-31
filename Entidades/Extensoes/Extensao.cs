using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extensoes
{
    public class Extensao
    {
        public Extensao()
        {
            extensoes = new List<Extensao>();
        }

        [NotMapped]
        public List<Extensao> extensoes;

        [NotMapped]
        public string Propriedade { get; set; } = string.Empty;

        [NotMapped]
        public string Mensagem { get; set; } = string.Empty;

        public bool ValidaPropriedadeString(string valor, string propriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(propriedade))
            {
                extensoes.Add(new Extensao
                {
                    Propriedade = propriedade,
                    Mensagem = "Campo obrigatório",
                });
                return false;
            }
            return true;
        }

        public static DateTime DATA_MINIMA = DateTime.MinValue; //TODO: Criar no Projeto Helper.DateTime
        public bool ValidaPropriedadeData(DateTime? valor, string propriedade)
        {
            if (valor == null || string.IsNullOrWhiteSpace(propriedade))
            {
                extensoes.Add(new Extensao
                {
                    Propriedade = propriedade,
                    Mensagem = "Campo obrigatório",
                });
                return false;
            }
            if (valor <= DATA_MINIMA)
            {
                extensoes.Add(new Extensao
                {
                    Propriedade = propriedade,
                    Mensagem = "Data Inválida",
                });
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return string.Join(", ", extensoes.Select(e => string.Format("{0}: {1}", e.Propriedade, e.Mensagem)));
        }
        public string ErrPropriedades()
        {
            return string.Join("; ", extensoes.Select(e => string.Format("{0}", e.Propriedade)));
        }
        public string ErrMensagens()
        {
            return string.Join("; ", extensoes.Select(e => string.Format("{0}", e.Mensagem)));
        }

    }
}
