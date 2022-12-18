using MySql.Data.MySqlClient;
using ProjetoASP.Conexao;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoASP.Acoes
{
    public class acPagamento
    {
        conexao con = new conexao();
        public void PagarItem(ModelItenscarrinho cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into Pagamento values(default, @nomecompleto, @nm_log, @cep , @cidade, @ds_complemento, @no_card , @expira,@ cd_cartao)", con.MyConectarBD());

            cmd.Parameters.Add("@nomecompleto", MySqlDbType.VarChar).Value = cm.nomecompleto;
            cmd.Parameters.Add("@nm_log", MySqlDbType.VarChar).Value = cm.nm_log;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = cm.cep;
            cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cm.cidade;
            cmd.Parameters.Add("@ds_complemento", MySqlDbType.VarChar).Value = cm.ds_complemento;
            cmd.Parameters.Add("@no_card", MySqlDbType.VarChar).Value = cm.no_card;
            cmd.Parameters.Add("@expira", MySqlDbType.VarChar).Value = cm.expira;
            cmd.Parameters.Add("@cd_cartao", MySqlDbType.VarChar).Value = cm.cd_cartao;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}