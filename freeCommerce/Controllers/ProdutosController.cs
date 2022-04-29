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
    public class ProdutosController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Produtos = new Item().Listar();
            ViewBag.QtdTotalEmEstoque = new Item().ListarQtdTotal();
            return View();
        }
        public ActionResult Cadastro()
        {
            ViewBag.UltimoIdRegistrado = new Item().ListarUltimoIdRegistrado();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Criar()
        {
            try
            {
                double precoC = Convert.ToDouble(Request["precoCusto"]);
                double precoV = Convert.ToDouble(Request["precoVenda"]);
                
                /*decimal precoC = decimal.Parse(Request["precoCusto"]);
                decimal precoV = decimal.Parse(Request["precoVenda"]);*/
                int qtdE = int.Parse(Request["qtdEstoque"]);

                var produto = new Item();

                List<Business.Item> ultimoId = new Item().ListarUltimoIdRegistrado();
                foreach (var id in ultimoId)
                {
                    int novoId = id.id;
                    produto.id = novoId;
                }

                produto.nome = Request["descricao"];
                produto.precoCusto = precoC;
                produto.precoVenda = precoV;
                produto.qtdEstoque = qtdE;
                produto.categoria = Request["categoria"];
                produto.Save();
                Response.Redirect("/produtos");
                TempData["sucesso"] = "Página criada com sucesso!";
            }
            catch (Exception erro)
            {
                TempData["erro"] = "A página não pode ser criada (" + erro.Message + ")!";
            }
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AnexarPorId(int id)
        {
            ViewBag.UltimoIdRegistrado = new Item().ListarUltimoIdRegistrado();
            return View();
        }

        public ActionResult Anexar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Anexar(HttpPostedFileBase file)
        {
            try
            {
                string nomeDoArquivo = "";
                string caminhoDoArquivo = "";

                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    // _FileName = Nome do arquivo
                    // _path = Caminho do arquivo (exemplo: "C:\\Users\\mario\\source\\repos\\freeCommerce\\freeCommerce\\UploadedFiles\\Screenshot_6.png")
                    file.SaveAs(_path);
                    nomeDoArquivo = _FileName;
                    caminhoDoArquivo = _path;
                }
                List<Business.Item> ultimoId = new Item().ListarUltimoIdRegistrado();
                foreach (var id in ultimoId)
                {
                    int novoId = id.id + 1;
                }
                var produto = new Item();
                produto.id = 4;
                produto.imgPath = caminhoDoArquivo;
                produto.imgFile = nomeDoArquivo;
                produto.SalvarImg();
                ViewBag.Message = "File Uploaded Successfully!!";
                Response.Redirect("/produtos/cadastro");
                return View();
            }
            catch (Exception err)
            {
                ViewBag.Message = "File upload failed! " + err.Message;
                return View();
            } 
        }

        public ActionResult Detalhes(int id)
        {
            var produto = Item.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();
        }
    }
}