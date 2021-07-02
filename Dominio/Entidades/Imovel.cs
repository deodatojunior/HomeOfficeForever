using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Imovel
    {
        public Imovel(string cidade, string bairro, string quantidade, double valor)
        {
            this.cidade = cidade;
            this.bairro = bairro;
            this.quantidade = quantidade;
            this.valor = valor;
        }

        public int id { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string quantidade { get; set; }
        public double valor { get; set; }

        public void AtualizarImovel(string cidade, string bairro, string quantidade, double valor)
        {
            this.cidade = cidade;
            this.bairro = bairro;
            this.quantidade = quantidade;
            this.valor = valor;
        }
    }
}
