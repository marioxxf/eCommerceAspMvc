﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Conta
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public int statusLogin { get; set; }
        public int statusConta { get; set; }
        public int nivelAcesso { get; set; }
        public string idSessao { get; set; }

        public void Save()
        {
            new Database.Conta().Salvar(this.usuario, this.email, this.senha, this.idSessao);
        }

        public void Login()
        {
            new Database.Conta().Logar(this.usuario, this.senha, this.idSessao);
        }

        public void Desconecta(string idSessao)
        {
            new Database.Conta().Desconecta(idSessao);
        }

        public static object BuscaPorStatusLogin(string idSessao)
        {
            var conta = new Conta();
            var contaDb = new Database.Conta();
            foreach (DataRow row in contaDb.BuscaPorContaLogada(idSessao).Rows)
            {
                conta.id = Convert.ToInt32(row["id"]);
                conta.usuario = row["usuario"].ToString();
                conta.senha = row["senha"].ToString();
                conta.email = row["email"].ToString();
                conta.nivelAcesso = Convert.ToInt32(row["nivelAcesso"]);
            }
            return conta;
        }


    }
}
