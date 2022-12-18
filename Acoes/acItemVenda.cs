using MySql.Data.MySqlClient;
using ProjetoASP.Conexao;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoASP.Acoes
{
    public class acItemVenda
    {

        conexao con = new conexao();
        public void inserirItem(ModelItenscarrinho cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into itemVenda values(default, @IDVenda, @IDproduto, @qtdeVendas , @valorParcial)", con.MyConectarBD());

            cmd.Parameters.Add("@IDVenda", MySqlDbType.VarChar).Value = cm.PedidoID;
            cmd.Parameters.Add("@IDproduto", MySqlDbType.VarChar).Value = cm.IDproduto;
            cmd.Parameters.Add("@qtdeVendas", MySqlDbType.VarChar).Value = cm.Qtd;
            cmd.Parameters.Add("@valorParcial", MySqlDbType.VarChar).Value = cm.valorParcial;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}