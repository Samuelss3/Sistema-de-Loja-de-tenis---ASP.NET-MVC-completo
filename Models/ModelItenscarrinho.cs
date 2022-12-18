using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoASP.Models
{
    public class ModelItenscarrinho
    {
        [Key]
        public Guid ItemVenda { get; set; }

        public string IDproduto { get; set; }
        public string Produto { get; set; }
        public string PedidoID { get; set; }
        public int Qtd { get; set; }
        public double ValorUnit { get; set; }
        public double valorParcial { get; set; }
        public string imgProd { get; set; }
       
        
        public string nomecompleto { get; set; }
        public string nm_log { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string ds_complemento { get; set; }
        public string no_card { get; set; }
        public string expira { get; set; }
        public string cd_cartao { get; set; }
        public string IDitemVenda { get; set; }



    }
}