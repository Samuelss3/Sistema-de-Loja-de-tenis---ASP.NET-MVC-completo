using MySql.Data.MySqlClient;
using ProjetoASP.Acoes;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class HomeController : Controller
    {
        acProduto acProd = new acProduto();
        ModelProduto Modelprod = new ModelProduto();
        public ActionResult Index()
        {
            return View(acProd.Produto());
        }

        public ActionResult detalhes(int ID)
        {
            CarregaTamanho();
            Modelprod = acProd.SelecionarIdProd(ID);
            return View(Modelprod);
        }        
        
        [HttpPost]
        public ActionResult detalhes(int ID, ModelProduto cm)
        {
            CarregaTamanho();
            cm.IDtamanho = Request["tam"];
            Modelprod = acProd.SelecionarIdProd(ID);
            return View(Modelprod);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void CarregaTamanho()
        {
            List<SelectListItem> Tam = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=BD_PROJETOASP;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tamanho;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Tam.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();
            }
            ViewBag.tam = new SelectList(Tam, "Value", "Text");
        }

    }
}