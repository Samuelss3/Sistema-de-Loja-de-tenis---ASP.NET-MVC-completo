using MySql.Data.MySqlClient;
using ProjetoASP.Conexao;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoASP.Acoes
{
    public class acTamanho
    {
        conexao con = new conexao();

        public void InsertTamanho(ModelTamanho cm)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into tamanho (sg_tamanho) values (@sg_tamanho)", con.MyConectarBD());

            cmd.Parameters.Add("@sg_tamanho", MySqlDbType.VarChar).Value = cm.sg_tamanho;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void updateTamanho(ModelTamanho cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tamanho set sg_tamanho = @sg_tamanho where IDtamanho = @IDtamanho;", con.MyConectarBD());

            cmd.Parameters.Add("@sg_tamanho", MySqlDbType.VarChar).Value = cm.sg_tamanho;
            cmd.Parameters.Add("@IDtamanho", MySqlDbType.VarChar).Value = cm.IDtamanho;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void deleteTamanho(string usuario)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tamanho where IDtamanho = @IDtamanho;", con.MyConectarBD());
            cmd.Parameters.Add("@IDtamanho", MySqlDbType.VarChar).Value = usuario;
            cmd.ExecuteReader();
            con.MyDesconectarBD();
        }

        public ModelTamanho SelecionarIdtam(string ID)
        {
            ModelTamanho usu = new ModelTamanho();

            MySqlCommand cmd = new MySqlCommand("select * from tamanho where IDtamanho = @IDtamanho", con.MyConectarBD());
            cmd.Parameters.Add("@IDtamanho", MySqlDbType.VarChar).Value = ID;

            var leitor = cmd.ExecuteReader();

            leitor.Read();
            {
                usu.IDtamanho= leitor["IDtamanho"].ToString();
                usu.sg_tamanho= leitor["sg_tamanho"].ToString();

                leitor.Close();
                con.MyDesconectarBD();
                return usu;
            }
        }

        public List<ModelTamanho> Tamanho()
        {
            List<ModelTamanho> TamanhoList = new List<ModelTamanho>();

            MySqlCommand cmd = new MySqlCommand("select * from tamanho;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                TamanhoList.Add(
                    new ModelTamanho
                    {
                        IDtamanho = Convert.ToString(dr["IDtamanho"]),
                        sg_tamanho = Convert.ToString(dr["sg_tamanho"]),
                    });
            }
            return TamanhoList;
        }
    }
}