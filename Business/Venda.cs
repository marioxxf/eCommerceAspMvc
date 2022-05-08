using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Venda
    {
        public int id { get; set; }
        public string nomeProduto { get; set; }
        public double valorProduto { get; set; }
        public int qtd { get; set; }
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public double valorVendaTotal { get; set; }
        public DateTime dataVenda { get; set; }
    }
}
