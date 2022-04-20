using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Item
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal precoCusto { get; set; }
        public decimal precoVenda { get; set; }
        public int qtdEstoque { get; set; }
        public string categoria { get; set; }
        public string imgPath { get; set; }
        public string imgFile { get; set; }

        public List<Item> Listar()
        {
            var lista = new List<Item>();
            var itensDoBanco = new Database.Item();
            foreach (DataRow row in itensDoBanco.ListaProdutos().Rows)
            {
                var item = new Item();
                item.id = Convert.ToInt32(row["id"]);
                item.nome = row["nome"].ToString();
                item.precoCusto = Convert.ToDecimal(row["precoCusto"]);
                item.precoVenda = Convert.ToDecimal(row["precoVenda"]);
                item.qtdEstoque = Convert.ToInt32(row["qtdEstoque"]);
                item.categoria = row["categoria"].ToString();
                item.imgFile = row["imgFile"].ToString();
                item.imgPath = row["imgPath"].ToString();

                lista.Add(item);
            }
            return lista;
        }

        public List<Item> ListarQtdTotal()
        {
            var lista = new List<Item>();
            var itensDoBanco = new Database.Item();
            foreach (DataRow row in itensDoBanco.ListaTotalProdutos().Rows)
            {
                var item = new Item();
                if (row["soma"] == DBNull.Value)
                {
                    item.qtdEstoque = 0;
                }
                else
                {
                    item.qtdEstoque = Convert.ToInt32(row["soma"]);
                }

                lista.Add(item);
            }
            return lista;
        }

        public List<Item> ListarUltimoIdRegistrado()
        {
            var lista = new List<Item>();
            var itensDoBanco = new Database.Item();
            foreach (DataRow row in itensDoBanco.ColetaUltimoIdRegistrado().Rows)
            {
                var item = new Item();
                item.id = Convert.ToInt32(row["id"]);
                item.nome = row["nome"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public void Save()
        {
            new Database.Item().Salvar(this.id, this.nome, this.precoCusto, this.precoVenda, this.qtdEstoque, this.categoria);
        }

        public void SalvarImg()
        {
            new Database.Item().SalvarImg(this.id, this.imgPath, this.imgFile);
        }

        public static object BuscaPorId(int id)
        {
            var produto = new Item();
            var produtoDb = new Database.Item();
            foreach (DataRow row in produtoDb.BuscaPorId(id).Rows)
            {
                produto.id = Convert.ToInt32(row["id"]);
                produto.nome = row["nome"].ToString();
                produto.precoCusto = Convert.ToDecimal(row["precoCusto"]);
                produto.precoVenda = Convert.ToDecimal(row["precoVenda"]);
                produto.qtdEstoque = Convert.ToInt32(row["qtdEstoque"]);
                produto.categoria = row["categoria"].ToString();
                produto.imgFile = row["imgFile"].ToString();
                produto.imgPath = row["imgPath"].ToString();
            }
            return produto;
        }
    }
}
