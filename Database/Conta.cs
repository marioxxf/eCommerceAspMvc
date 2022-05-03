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
    public class Conta
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public void Salvar(string usuario, string email, string senha)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update usuarios set statusLogin = 0;" +
                    "insert into usuarios values('" + usuario + "', '" + senha + "', 1, 1, 1, '" + email + "')";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Desconecta()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "update usuarios set statusLogin = 0";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorContaLogada()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from usuarios where statusLogin = 1";
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