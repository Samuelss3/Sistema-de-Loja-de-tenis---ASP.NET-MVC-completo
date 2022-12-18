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
    public class acProduto
    {
        conexao con = new conexao();

        public void InsertProduto(ModelProduto cm)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into Produto (nomeprod, imgProd, imgProd2, imgProd3, imgProd4, imgProd5, imgProd6, imgProd7, preco, estoque, descricao, IDcategoria, IDfornecedor) values (@nomeprod, @imgProd, @imgProd2, @imgProd3, @imgProd4, @imgProd5, @imgProd6, @imgProd7, @preco, @estoque , @descricao, @IDCategoria, @IDfornecedor)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeprod", MySqlDbType.VarChar).Value = cm.nomeprod;
            cmd.Parameters.Add("@imgProd", MySqlDbType.VarChar).Value = cm.imgProd;
            cmd.Parameters.Add("@imgProd2", MySqlDbType.VarChar).Value = cm.imgProd2;
            cmd.Parameters.Add("@imgProd3", MySqlDbType.VarChar).Value = cm.imgProd3;
            cmd.Parameters.Add("@imgProd4", MySqlDbType.VarChar).Value = cm.imgProd4;
            cmd.Parameters.Add("@imgProd5", MySqlDbType.VarChar).Value = cm.imgProd5;
            cmd.Parameters.Add("@imgProd6", MySqlDbType.VarChar).Value = cm.imgProd6;
            cmd.Parameters.Add("@imgProd7", MySqlDbType.VarChar).Value = cm.imgProd7;
            cmd.Parameters.Add("@preco", MySqlDbType.VarChar).Value = cm.preco;
            cmd.Parameters.Add("@estoque", MySqlDbType.VarChar).Value = cm.estoque;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = cm.descricao;
            cmd.Parameters.Add("@IDcategoria", MySqlDbType.VarChar).Value = cm.IDcategoria;
            cmd.Parameters.Add("@IDfornecedor", MySqlDbType.VarChar).Value = cm.IDfornecedor;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void updateProduto(ModelProduto cm)
        {
            MySqlCommand cmd = new MySqlCommand("update produto set nomeprod = @nomeprod, imgProd = @imgProd,  imgProd2 = @imgProd2, imgProd3 = @imgProd3 ,imgProd4 = @imgProd4, imgProd5 = @imgProd5 ,imgProd6 = @imgProd6, imgProd7 = @imgProd7, preco = @preco, estoque =@estoque, descricao = @descricao, IDtamanho= @IDtamanho, IDcategoria=@IDcategoria, IDfornecedor= @IDfornecedor where IDproduto = @IDproduto;", con.MyConectarBD());

            cmd.Parameters.Add("@nomeprod", MySqlDbType.VarChar).Value = cm.nomeprod;
            cmd.Parameters.Add("@imgProd", MySqlDbType.VarChar).Value = cm.imgProd;
            cmd.Parameters.Add("@imgProd2", MySqlDbType.VarChar).Value = cm.imgProd2;
            cmd.Parameters.Add("@imgProd3", MySqlDbType.VarChar).Value = cm.imgProd3;
            cmd.Parameters.Add("@imgProd4", MySqlDbType.VarChar).Value = cm.imgProd4;
            cmd.Parameters.Add("@imgProd5", MySqlDbType.VarChar).Value = cm.imgProd5;
            cmd.Parameters.Add("@imgProd6", MySqlDbType.VarChar).Value = cm.imgProd6;
            cmd.Parameters.Add("@imgProd7", MySqlDbType.VarChar).Value = cm.imgProd7;
            cmd.Parameters.Add("@preco", MySqlDbType.VarChar).Value = cm.preco;
            cmd.Parameters.Add("@estoque", MySqlDbType.VarChar).Value = cm.estoque;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = cm.descricao;
            cmd.Parameters.Add("@IDcategoria", MySqlDbType.VarChar).Value = cm.IDcategoria;
            cmd.Parameters.Add("@IDfornecedor", MySqlDbType.VarChar).Value = cm.IDfornecedor;
            cmd.Parameters.Add("@IDproduto", MySqlDbType.VarChar).Value = cm.IDproduto;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void deleteProduto(string usuario)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Produto where IDproduto = @IDproduto;", con.MyConectarBD());
            cmd.Parameters.Add("@IDproduto", MySqlDbType.VarChar).Value = usuario;
            cmd.ExecuteReader();
            con.MyDesconectarBD();
        }

        public ModelProduto SelecionarIdProd(int ID)
        {
            ModelProduto usu = new ModelProduto();

            MySqlCommand cmd = new MySqlCommand("select * from produto where IDproduto = @IDproduto;", con.MyConectarBD());
            cmd.Parameters.Add("@IDproduto", MySqlDbType.VarChar).Value = ID;

            var leitor = cmd.ExecuteReader();


            leitor.Read();
            {
                usu.IDproduto = leitor["IDproduto"].ToString();
                usu.nomeprod = leitor["nomeprod"].ToString();
                usu.imgProd = leitor["imgProd"].ToString();
                usu.imgProd2 = leitor["imgProd2"].ToString();
                usu.imgProd3 = leitor["imgProd3"].ToString();
                usu.imgProd4 = leitor["imgProd4"].ToString();
                usu.imgProd5 = leitor["imgProd5"].ToString();
                usu.imgProd6 = leitor["imgProd6"].ToString();
                usu.imgProd7 = leitor["imgProd7"].ToString();
                usu.preco = leitor["preco"].ToString();
                usu.estoque = leitor["estoque"].ToString();
                usu.descricao = leitor["descricao"].ToString();
                usu.IDcategoria = leitor["IDcategoria"].ToString();
                usu.IDfornecedor = leitor["IDfornecedor"].ToString();

                leitor.Close();
                con.MyDesconectarBD();
                return usu;
            }
        }

        public List<ModelProduto> Produto()
        {
            List<ModelProduto> ProdutoList = new List<ModelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from Produto;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoList.Add(
                    new ModelProduto
                    {
                        IDproduto = Convert.ToString(dr["IDproduto"]),
                        nomeprod = Convert.ToString(dr["nomeprod"]),
                        imgProd = Convert.ToString(dr["imgProd"]),
                        imgProd2 = Convert.ToString(dr["imgProd2"]),
                        imgProd3 = Convert.ToString(dr["imgProd3"]),
                        imgProd4 = Convert.ToString(dr["imgProd4"]),
                        imgProd5 = Convert.ToString(dr["imgProd5"]),
                        imgProd6 = Convert.ToString(dr["imgProd6"]),
                        imgProd7 = Convert.ToString(dr["imgProd7"]),
                        preco = Convert.ToString(dr["preco"]),
                        estoque = Convert.ToString(dr["estoque"]),
                        descricao = Convert.ToString(dr["descricao"]),
                        IDcategoria = Convert.ToString(dr["IDcategoria"]),
                        IDfornecedor = Convert.ToString(dr["IDfornecedor"]),
                    });
            }
            return ProdutoList;
        }
    }
}