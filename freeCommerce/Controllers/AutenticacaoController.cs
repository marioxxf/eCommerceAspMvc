using Business;
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
                conta.idSessao = Request["idSessao"];
                conta.Save();
                Response.Redirect("/autenticacao/login");
                TempData["contaCriada"] = "Conta criada com sucesso! Agora você já pode fazer seu login abaixo.";
            }
            catch (Exception erro)
            {
                TempData["contaNaoCriada"] = "A conta não pode ser criada (" + erro.Message + ")!";
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Logar()
        {
            try
            {
                var conta = new Conta();
                conta.usuario = Request["usuario"];
                conta.senha = Request["senha"];
                conta.idSessao = Request["idSessao"];
                conta.Login();
                Response.Redirect("/autenticacao/logado");
                TempData["contaLogada"] = "Conta logada com sucesso!";
            }
            catch (Exception erro)
            {
                TempData["contaNaoCriada"] = "A conta não pode ser logada (" + erro.Message + ")!";
            }
        }
        public ActionResult Conta()
        {
            var conta = Business.Conta.BuscaPorStatusLogin(Session.SessionID);
            ViewBag.Conta = conta;
            return View();
        }

        public ActionResult Logado()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult UsuarioLogado()
        {
            var conta = Business.Conta.BuscaPorStatusLogin(Session.SessionID);
            Business.Conta contaLogada = (Conta)conta;
            string nomeUsuarioLogado = contaLogada.usuario;
            return new ContentResult { Content = nomeUsuarioLogado };
        }

        [HttpPost]
        public ActionResult Desconecta()
        {
            var conta = new Conta();
            conta.Desconecta(Session.SessionID);
            string message = "Sucesso!";
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmaLogin()
        {
            List<Business.Conta> ultimoRegistro = new Conta().ListarUltimoRegistro();
            int ultimoIdCadastrado = 0;
            foreach(var ultimaConta in ultimoRegistro)
            {
                ultimoIdCadastrado = ultimaConta.id;
            }
            var conta = new Conta();
            conta.ConfirmaLogin(Session.SessionID, ultimoIdCadastrado);
            string message = "Mario Gioia vive muito!";
            return new ContentResult { Content = "Mario Gioia vive sim!" };
        }
    }
}