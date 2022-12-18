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
    public class acCategoria
    {
        conexao con = new conexao();

        public void InsertCategoria(ModelCategoria cm)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into Categoria (nm_categoria) values (@nm_categoria)", con.MyConectarBD());

            cmd.Parameters.Add("@nm_categoria", MySqlDbType.VarChar).Value = cm.nm_categoria;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void updateCategoria(ModelCategoria cm)
        {
            MySqlCommand cmd = new MySqlCommand("update Categoria set nm_categoria = @nm_categoria where IDcategoria = @IDcategoria;", con.MyConectarBD());

            cmd.Parameters.Add("@nm_categoria", MySqlDbType.VarChar).Value = cm.nm_categoria;
            cmd.Parameters.Add("@IDcategoria", MySqlDbType.VarChar).Value = cm.IDcategoria;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void deleteCategoria(string usuario)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Categoria where IDcategoria = @IDcategoria;", con.MyConectarBD());
            cmd.Parameters.Add("@IDcategoria", MySqlDbType.VarChar).Value = usuario;
            cmd.ExecuteReader();
            con.MyDesconectarBD();
        }

        public ModelCategoria SelecionarIdCat(string ID)
        {
            ModelCategoria usu = new ModelCategoria();
 
            MySqlCommand cmd = new MySqlCommand("select * from categoria where IDcategoria = @IDcategoria", con.MyConectarBD());
            cmd.Parameters.Add("@IDcategoria", MySqlDbType.VarChar).Value = ID;

            var leitor = cmd.ExecuteReader();

            leitor.Read();
            {
                usu.IDcategoria = leitor["IDcategoria"].ToString();
                usu.nm_categoria = leitor["nm_categoria"].ToString();

                leitor.Close();
                con.MyDesconectarBD();
                return usu;
            }
        }

        public List<ModelCategoria> Categoria()
        {
            List<ModelCategoria> CategoriaList= new List<ModelCategoria>();

            MySqlCommand cmd = new MySqlCommand("select * from categoria;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                CategoriaList.Add(
                    new ModelCategoria
                    {
                        IDcategoria = Convert.ToString(dr["IDcategoria"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                    });
            }
            return CategoriaList;
        }

    }
}