using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoASP.Models;

namespace ProjetoASP.Models
{
    public class ModelVenda
    {
        public string IDVenda { get; set; }
        public string IDusuario { get; set; }
        public string datavenda { get; set; }
        public string Horavenda { get; set; }
        public double valorFinal { get; set; }

        public List<ModelItenscarrinho> itensPedido = new List<ModelItenscarrinho>();
    }
}