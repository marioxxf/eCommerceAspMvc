using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Item
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable ListaProdutos()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from produtos";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable ListaTotalProdutos()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select sum(qtdEstoque) as 'soma' from produtos";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable ColetaUltimoIdRegistrado()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select top 1 * from produtos order by id desc";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string descricao, double precoCusto, double precoVenda, int qtdEstoque, string categoria)
        {

            /*string a = precoCusto.ToString();
            a = a.Replace(".", ",");
            a = a.Replace(",", ".");
            string b = precoVenda.ToString();
            b = b.Replace(".", ",");
            b = b.Replace(",", ".");
            precoCusto = decimal.Parse(a);
            precoVenda = decimal.Parse(b);*/

            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                /*string queryString = "insert into produtos (nome, precoCusto, precoVenda, qtdEstoque, categoria) " +
                                     "values ('" + descricao + "', " + ((float)precoCusto) + ", " + ((float)precoVenda) + ", '" + qtdEstoque + "', '" + categoria + "') where id = " + id;*/

                string queryString = "update produtos set nome = '" + descricao + "', precoCusto = " + ((float)precoCusto) + ", precoVenda = " + ((float)precoVenda) + ", qtdEstoque = " + qtdEstoque + ", categoria = '" + categoria + "' where id = " + id;


                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void SalvarImg(int id, string imgPath, string imgFile)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
                string queryString = "insert into produtos (imgPath, imgFile) " +
                                     "values ('" + imgPath + "', '" + imgFile + "');";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from produtos where id = " + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
