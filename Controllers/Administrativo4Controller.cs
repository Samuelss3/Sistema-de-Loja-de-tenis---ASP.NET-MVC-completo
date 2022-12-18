using MySql.Data.MySqlClient;
using ProjetoASP.Acoes;
using ProjetoASP.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class Administrativo4Controller : Controller
    {

        acProduto acProd = new acProduto();
        ModelProduto Modelprod = new ModelProduto();
        public ActionResult Index()
        {
            return View(acProd.Produto());
        }

        public ActionResult ProdutoInsert()
        {

            CarregaCategoria();
            CarregaFornecedor();
            return View();
        }

        [HttpPost]
        public ActionResult ProdutoInsert(ModelProduto cm, HttpPostedFileBase file, HttpPostedFileBase filee2, HttpPostedFileBase filee3, 
            HttpPostedFileBase filee4, HttpPostedFileBase filee5, HttpPostedFileBase filee6, HttpPostedFileBase filee7)
        {

            CarregaCategoria();
            CarregaFornecedor();

            if (!ModelState.IsValid)
            {
                return View(cm);
            }
            
            cm.IDcategoria = Request["cat"];
            cm.IDfornecedor = Request["forn"];

            string arquivo = Path.GetFileName(file.FileName);
            string file1 = "/Imagens/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);
            cm.imgProd = file1;

            string arquivo2 = Path.GetFileName(filee2.FileName);
            string file2 = "/Imagens/" + Path.GetFileName(filee2.FileName);
            string _path2 = Path.Combine(Server.MapPath("~/Imagens"), arquivo2);
            filee2.SaveAs(_path2);
            cm.imgProd2 = file2;

            string arquivo3 = Path.GetFileName(filee3.FileName);
            string file3 = "/Imagens/" + Path.GetFileName(filee3.FileName);
            string _path3 = Path.Combine(Server.MapPath("~/Imagens"), arquivo3);
            filee3.SaveAs(_path3);
            cm.imgProd3 = file3;

            string arquivo4 = Path.GetFileName(filee4.FileName);
            string file4 = "/Imagens/" + Path.GetFileName(filee4.FileName);
            string _path4 = Path.Combine(Server.MapPath("~/Imagens"), arquivo4);
            filee4.SaveAs(_path4);
            cm.imgProd4 = file4;

            string arquivo5 = Path.GetFileName(filee5.FileName);
            string file5 = "/Imagens/" + Path.GetFileName(filee5.FileName);
            string _path5 = Path.Combine(Server.MapPath("~/Imagens"), arquivo5);
            filee5.SaveAs(_path5);
            cm.imgProd5 = file5;

            string arquivo6 = Path.GetFileName(filee6.FileName);
            string file6 = "/Imagens/" + Path.GetFileName(filee6.FileName);
            string _path6 = Path.Combine(Server.MapPath("~/Imagens"), arquivo6);
            filee6.SaveAs(_path6);
            cm.imgProd6 = file6;

            string arquivo7 = Path.GetFileName(filee7.FileName);
            string file7 = "/Imagens/" + Path.GetFileName(filee7.FileName);
            string _path7 = Path.Combine(Server.MapPath("~/Imagens"), arquivo7);
            filee7.SaveAs(_path7);
            cm.imgProd7 = file7;

            acProd.InsertProduto(cm);
            ViewBag.msg = "Cadastro realizado";
            return RedirectToAction("index", "Administrativo4");
        }

        public ActionResult ProdutoDetails(int ID)
        {

            CarregaCategoria();
            CarregaFornecedor();

            Modelprod = acProd.SelecionarIdProd(ID);
            return View(Modelprod);
        }

        [HttpPost]
        public ActionResult ProdutoDetails(int ID, ModelProduto cm)
        {
      
            CarregaCategoria();
            CarregaFornecedor();

           
            cm.IDcategoria = Request["cat"];
            cm.IDfornecedor = Request["forn"];

            Modelprod = acProd.SelecionarIdProd(ID);
            return View(Modelprod);
        }




        public void CarregaCategoria()
        {
            List<SelectListItem> Cat = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=BD_PROJETOASP;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Categoria;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cat.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();
            }
            ViewBag.cat = new SelectList(Cat, "Value", "Text");
        }

        public void CarregaFornecedor()
        {
            List<SelectListItem> Forn = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=BD_PROJETOASP;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Fornecedor;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Forn.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();
            }
            ViewBag.forn = new SelectList(Forn, "Value", "Text");
        }
    }
}

//string arquivo2 = Path.GetFileName(file.FileName);
//string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
//string _path2 = Path.Combine(Server.MapPath("~/Imagens"), arquivo2);
//file.SaveAs(_path2);
//cm.imgProd2 = file2;

//string arquivo3 = Path.GetFileName(file.FileName);
//string file3 = "/Imagens/" + Path.GetFileName(file.FileName);
//string _path3 = Path.Combine(Server.MapPath("~/Imagens"), arquivo3);
//file.SaveAs(_path3);
//cm.imgProd2 = file3;

//string arquivo4 = Path.GetFileName(file.FileName);
//string file4 = "/Imagens/" + Path.GetFileName(file.FileName);
//string _path4 = Path.Combine(Server.MapPath("~/Imagens"), arquivo4);
//file.SaveAs(_path4);
//cm.imgProd2 = file4;

//string arquivo5 = Path.GetFileName(file.FileName);
//string file5 = "/Imagens/" + Path.GetFileName(file.FileName);
//string _path5 = Path.Combine(Server.MapPath("~/Imagens"), arquivo5);
//file.SaveAs(_path5);
//cm.imgProd2 = file5;

//string arquivo6 = Path.GetFileName(file.FileName);
//string file6 = "/Imagens/" + Path.GetFileName(file.FileName);
//string _path6 = Path.Combine(Server.MapPath("~/Imagens"), arquivo6);
//file.SaveAs(_path6);
//cm.imgProd2 = file6;

//string arquivo7 = Path.GetFileName(file.FileName);
//string file7 = "/Imagens/" + Path.GetFileName(file.FileName);
//string _path7 = Path.Combine(Server.MapPath("~/Imagens"), arquivo7);
//file.SaveAs(_path7);
//cm.imgProd2 = file7;
