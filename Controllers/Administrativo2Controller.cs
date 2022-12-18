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
    public class Administrativo2Controller : Controller
    {

        ModelCadastroLogin usuario = new ModelCadastroLogin();
        acCliFunc acCF = new acCliFunc();
        acFornecedor acForn = new acFornecedor();
        ModelFornecedor usuarioForn = new ModelFornecedor();
        // GET: Administrativo2
        public ActionResult Index()
        {
            return View();
        }

        //--------------------------------------------------CRUD CLIENTE--------------------------------------------------
        public ActionResult ClienteList()
        {
            return View(acCF.Cliente());
        }

        public ActionResult ClienteDetails(string ID)
        {
            usuario = acCF.SelecionarId(ID);
            return View(usuario);
        }

        public ActionResult ClienteUpdate(string ID)
        {
            CarregaTipoUsuario();
            usuario = acCF.SelecionarId(ID);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult ClienteUpdate(ModelCadastroLogin cm)
        {
            CarregaTipoUsuario();
            if (!ModelState.IsValid)
            {
                return View(cm);
            }
            cm.IDtipoUsuario = Request["tipoUsu"];
            acCF.updateUsuario(cm);
            
            return RedirectToAction("ClienteList", "Administrativo2");
        }

        public ActionResult ClienteDelete(string ID)
        {
            usuario = acCF.SelecionarId(ID);
            return View(usuario);
        }

        [HttpPost, ActionName("ClienteDelete")]

        public ActionResult ConfirmaDelete(string Id)
        {
            acCF.deleteUsuario(Id);
            return RedirectToAction("ClienteList", "administrativo2");
        }
        //--------------------------------------------------CRUD CLIENTE--------------------------------------------------        
        //--------------------------------------------------CRUD Funcionario----------------------------------------------

        public ActionResult funcionario1()
        {
            CarregaTipoUsuario();
            return View();
        }

        [HttpPost]
        public ActionResult funcionario1(ModelCadastroLogin cm)
        {
            if (!ModelState.IsValid)
            {
                return View(cm);
            }
            cm.IDtipoUsuario = Request["tipoUsu"];
            acLogin aclog = new acLogin();
            aclog.InsertUsuario(cm);
            CarregaTipoUsuario();
            return RedirectToAction("index", "Administrativo");
        }

        public ActionResult funcionarioList()
        {
            return View(acCF.Funcionario());
        }

        public ActionResult funcionarioDetails(string ID)
        {
            usuario = acCF.SelecionarId(ID);
            return View(usuario);
        }

        public ActionResult funcionarioUpdate(string ID)
        {
            CarregaTipoUsuario();
            usuario = acCF.SelecionarId(ID);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult funcionarioUpdate(ModelCadastroLogin cm)
        {
            CarregaTipoUsuario();
            if (!ModelState.IsValid)
            {
                return View(cm);
            }
            cm.IDtipoUsuario = Request["tipoUsu"];
            acCF.updateUsuario(cm);

            return RedirectToAction("funcionarioList", "Administrativo2");
        }

        public ActionResult funcionarioDelete(string ID)
        {
            usuario = acCF.SelecionarId(ID);
            return View(usuario);
        }

        [HttpPost, ActionName("funcionarioDelete")]

        public ActionResult ConfirmafuncionarioDelete(string Id)
        {
            acCF.deleteUsuario(Id);
            return RedirectToAction("funcionarioList", "administrativo2");
        }

        //--------------------------------------------------CRUD Funcionario---------------------------------------------- 

        //--------------------------------------------------CRUD Fornecedor---------------------------------------------- 

        public ActionResult FornecedorInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FornecedorInsert(ModelFornecedor cm)
        {
            if (!ModelState.IsValid)
            {
                return View(cm);
            }

            acForn.InsertFornecedor(cm);
            return RedirectToAction("FornecedorList", "Administrativo2");
        }

        public ActionResult FornecedorList()
        {
            return View(acForn.Fornecedor());
        }
        
        
        public ActionResult FornecedorUpdate(string ID)
        {
            usuarioForn = acForn.SelecionarIdForn(ID);
            return View(usuarioForn);
        }

        [HttpPost]
        public ActionResult FornecedorUpdate(ModelFornecedor cm)
        {

            acForn.updateFornecedor(cm);

            return RedirectToAction("FornecedorList", "Administrativo2");
        }


        public ActionResult FornecedorDelete(string ID)
        {
            usuarioForn = acForn.SelecionarIdForn(ID);
            return View(usuarioForn);
        }

        [HttpPost, ActionName("funcionarioDelete")]

        public ActionResult ConfirmafornecedorDelete(string Id)
        {
            acForn.deleteFornecedor(Id);
            return RedirectToAction("FornecedorList", "administrativo2");
        }

        //--------------------------------------------------CRUD Fornecedor---------------------------------------------- 

        public void CarregaTipoUsuario()
        {
            List<SelectListItem> TipoUsu = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=BD_PROJETOASP;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tipoUsuario;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TipoUsu.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();
            }
            ViewBag.tipoUsu = new SelectList(TipoUsu, "Value", "Text");
        }
    }
}
    