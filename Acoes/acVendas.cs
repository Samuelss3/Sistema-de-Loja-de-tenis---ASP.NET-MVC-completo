using MySql.Data.MySqlClient;
using ProjetoASP.Conexao;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoASP.Acoes
{
    public class acVendas
    {
        conexao con = new conexao();

        public void inserirVenda(ModelVenda cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into Venda values(default, @IDusuario, @datavenda, @horaVenda, @valorFinal)", con.MyConectarBD());

            cmd.Parameters.Add("@IDusuario", MySqlDbType.VarChar).Value = cm.IDusuario;
            cmd.Parameters.Add("@datavenda", MySqlDbType.VarChar).Value = cm.datavenda;
            cmd.Parameters.Add("@horavenda", MySqlDbType.VarChar).Value = cm.Horavenda;
            cmd.Parameters.Add("@valorFinal", MySqlDbType.VarChar).Value = cm.valorFinal;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        MySqlDataReader dr;
        public void buscaIdVenda(ModelVenda vend)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT IDVenda FROM Venda ORDER BY IDVenda DESC limit 1", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vend.IDVenda = dr[0].ToString();
            }
            con.MyDesconectarBD();
        }
    }
}