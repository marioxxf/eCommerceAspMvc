﻿using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace freeCommerce.Controllers
{
    public class AutenticacaoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Criar()
        {
            try
            {
                var conta = new Conta();
                conta.usuario = Request["usuario"];
                conta.email = Request["email"];
                conta.senha = Request["senha"];
                conta.Save();
                Response.Redirect("/autenticacao/minhaconta");
                TempData["contaCriada"] = "Conta criada com sucesso!";
            }
            catch (Exception erro)
            {
                TempData["contaNaoCriada"] = "A conta não pode ser criada (" + erro.Message + ")!";
            }
        }
        public ActionResult Conta()
        {
            var conta = Business.Conta.BuscaPorStatusLogin();
            ViewBag.Conta = conta;
            return View();
        }

        [ChildActionOnly]
        public ActionResult SiteName()
        {
            var conta = Business.Conta.BuscaPorStatusLogin();
            Business.Conta contaLogada = (Conta)conta;
            string nomeUsuarioLogado = contaLogada.usuario;
            return new ContentResult { Content = nomeUsuarioLogado };
        }

        [HttpPost]
        public ActionResult Desconecta()
        {
            var conta = new Conta();
            conta.Desconecta();
            string message = "Sucesso!";
            return View();
        }
    }
}