using ProjetoASP.Acoes;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class CarrinhoController : Controller
    {
        acProduto acProd = new acProduto();
        acVendas acVend = new acVendas();
        acItemVenda acItem = new acItemVenda();

        public ActionResult Index()
        {
            return View(acProd.Produto());
        }

        public static string codigo;

        public ActionResult AdicionarCarrinho(int ID, double pre)
        {
            ModelVenda carrinho = Session["Carrinho"] != null ? (ModelVenda)Session["Carrinho"] : new ModelVenda();
            var produto = acProd.SelecionarIdProd(ID);
            codigo = ID.ToString();

            ModelProduto modelprod = new ModelProduto();

            if (produto != null)
            {
                var itemPedido = new ModelItenscarrinho();
                itemPedido.ItemVenda = Guid.NewGuid();
                itemPedido.IDproduto = ID.ToString();
                itemPedido.Produto = produto.nomeprod;
                itemPedido.Qtd = 1;
                itemPedido.ValorUnit = pre;
                itemPedido.imgProd = produto.imgProd;

                List<ModelItenscarrinho> x = carrinho.itensPedido.FindAll(l => l.Produto == itemPedido.Produto);

                if (x.Count != 0)
                {
                    carrinho.itensPedido.FirstOrDefault(p => p.Produto == produto.nomeprod).Qtd += 1;
                    itemPedido.valorParcial = itemPedido.Qtd * itemPedido.ValorUnit;
                    carrinho.valorFinal += itemPedido.valorParcial;
                    carrinho.itensPedido.FirstOrDefault(p => p.Produto == produto.nomeprod).valorParcial = carrinho.itensPedido.FirstOrDefault(p => p.Produto == produto.nomeprod).Qtd * itemPedido.ValorUnit;

                }

                else
                {
                    itemPedido.valorParcial = itemPedido.Qtd * itemPedido.ValorUnit;
                    carrinho.valorFinal += itemPedido.valorParcial;
                    carrinho.itensPedido.Add(itemPedido);
                }

                Session["Carrinho"] = carrinho;
            }

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            ModelVenda carrinho = Session["Carrinho"] != null ? (ModelVenda)Session["Carrinho"] : new ModelVenda();

            return View(carrinho);
        }
        
        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (ModelVenda)Session["Carrinho"] : new ModelVenda();
            var itemExclusao = carrinho.itensPedido.FirstOrDefault(i => i.ItemVenda == id);

            carrinho.valorFinal -= itemExclusao.valorParcial;

            carrinho.itensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        [Authorize]
        public ActionResult SalvarCarrinho(ModelVenda x)
        {
            ModelCadastroLogin ve = new ModelCadastroLogin
            {
                IDusuario = x.IDusuario,
            };

            var carrinho = Session["Carrinho"] != null ? (ModelVenda)Session["Carrinho"] : new ModelVenda();

            ModelVenda md = new ModelVenda();
            ModelItenscarrinho mdV = new ModelItenscarrinho();

            md.datavenda = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy");
            md.Horavenda = DateTime.Now.ToLocalTime().ToString("HH:mm");
            md.IDusuario = Session["IDusuario"].ToString();
            md.valorFinal = carrinho.valorFinal;

            acVend.inserirVenda(md);


            acVend.buscaIdVenda(x);

            for (int i = 0; i < carrinho.itensPedido.Count; i++)
            {

                mdV.PedidoID = x.IDVenda;
                mdV.IDproduto = carrinho.itensPedido[i].IDproduto;
                mdV.Qtd = carrinho.itensPedido[i].Qtd;
                mdV.valorParcial = carrinho.itensPedido[i].valorParcial;
                acItem.inserirItem(mdV);
            }

            carrinho.valorFinal = 0;
            carrinho.itensPedido.Clear();

            return RedirectToAction("confvenda");

        }

        public ActionResult confVenda()
        {
            return View();
        }

    }
}