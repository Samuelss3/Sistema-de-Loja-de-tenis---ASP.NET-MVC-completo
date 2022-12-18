using ProjetoASP.Acoes;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class CadastroLoginController : Controller
    {
        acLogin aclog = new acLogin();
        ModelLogin MLog = new ModelLogin();
        acCliFunc acCliFunc = new acCliFunc();

        // GET: CadastroLogin
        public ActionResult Cadastrologin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrologin(ModelCadastroLogin cm)
        {
            if (!ModelState.IsValid)
            {
                return View(cm);
            }


            if (cm.IDtipoUsuario == null)
            {
                cm.IDtipoUsuario = "1";
            }
            aclog.InsertUsuario(cm);
            return RedirectToAction("index", "Home");
        }


        public ActionResult LoginForm(string ReturnUrl)
        {
            var modelLog = new ModelLogin
            {
                UrlRetorno = ReturnUrl
            };

            return View(modelLog);
        }

        [HttpPost]
        public ActionResult LoginForm(ModelLogin cm)
        {

            if (!ModelState.IsValid)
            {
                return View(cm);
            }


            var usuario = aclog.SelectUsuario(cm.Email);

            if (usuario == null | usuario.Email != cm.Email)
            {
                ModelState.AddModelError("Email", "Login incorreto");
                return View(cm);
            }

            if (usuario.Senha != cm.Senha)
            {
                ModelState.AddModelError("Senha", "Login incorreto");
                return View(cm);
            }

            ModelCadastroLogin ve = new ModelCadastroLogin
            {
                Email = cm.Email,
                Senha = cm.Senha,

            };

            Session["usuarioLogado"] = ve.Email.ToString();
            Session["senhaLogado"] = ve.Senha.ToString();
            Session["IDusuario"] = acLogin.IDusuarioValor;
            if (usuario.IDtipoUsuario == "1")
            {


                var indentity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name,usuario.Email),
                new Claim("Email",usuario.Email)
            }, "AppAplicationCookie");

                Request.GetOwinContext().Authentication.SignIn(indentity);

                if (!String.IsNullOrWhiteSpace(cm.UrlRetorno) || Url.IsLocalUrl(cm.UrlRetorno))
                    return Redirect(cm.UrlRetorno);

                else
                    return RedirectToAction("index", "home");

            }

            else
            {
                var indentity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name,usuario.Email),
                new Claim("Email",usuario.Email)
            }, "AppAplicationCookie");

                Request.GetOwinContext().Authentication.SignIn(indentity);

                if (!String.IsNullOrWhiteSpace(cm.UrlRetorno) || Url.IsLocalUrl(cm.UrlRetorno))
                    return Redirect(cm.UrlRetorno);

                else
                {
                    
                    acCliFunc.TestarUsuario(ve);

                    if (Session["usuarioLogado"] == null)
                    {
                        return RedirectToAction("Carrinho", "Carrinho");
                    } 

                    return RedirectToAction("Index", "Administrativo");
                }
            }

            }

        public ActionResult logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppAplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Teste()
        {
            return View();
        }



    }
}