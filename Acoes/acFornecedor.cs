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
    public class acFornecedor
    {
        conexao con = new conexao();
        public void InsertFornecedor(ModelFornecedor cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into fornecedor(nome, telefone, cnpj, nm_log, no_log, ds_complemento, bairro, uf) values (@nome, @telefone, @cnpj, @nm_log, @no_log, @ds_complemento, @bairro, @uf)", con.MyConectarBD());

            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cm.nome;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cm.telefone;
            cmd.Parameters.Add("@CNPJ", MySqlDbType.VarChar).Value = cm.CNPJ;
            cmd.Parameters.Add("@nm_log", MySqlDbType.VarChar).Value = cm.nm_log;
            cmd.Parameters.Add("@no_log", MySqlDbType.VarChar).Value = cm.no_log;
            cmd.Parameters.Add("@ds_complemento", MySqlDbType.VarChar).Value = cm.ds_complemento;
            cmd.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = cm.bairro;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar).Value = cm.uf;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void updateFornecedor(ModelFornecedor cm)
        {
            MySqlCommand cmd = new MySqlCommand("update Fornecedor set nome = @nome, telefone =@telefone, CNPJ = @CNPJ, nm_log = @nm_log, no_log = @no_log, ds_complemento = @ds_complemento, bairro = @bairro, uf = @uf where IDfornecedor = @IDfornecedor;", con.MyConectarBD());

            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cm.nome;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cm.telefone;
            cmd.Parameters.Add("@CNPJ", MySqlDbType.VarChar).Value = cm.CNPJ;
            cmd.Parameters.Add("@nm_log", MySqlDbType.VarChar).Value = cm.nm_log;
            cmd.Parameters.Add("@no_log", MySqlDbType.VarChar).Value = cm.no_log;
            cmd.Parameters.Add("@ds_complemento", MySqlDbType.VarChar).Value = cm.ds_complemento;
            cmd.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = cm.bairro;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar).Value = cm.uf;
            cmd.Parameters.Add("@IDfornecedor", MySqlDbType.VarChar).Value = cm.IDfornecedor;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }


        public void deleteFornecedor(string usuario)
        {
            MySqlCommand cmd = new MySqlCommand("delete from fornecedor where IDfornecedor = @IDfornecedor;", con.MyConectarBD());
            cmd.Parameters.Add("@IDfornecedor", MySqlDbType.VarChar).Value = usuario;
            cmd.ExecuteReader();
            con.MyDesconectarBD();
        }


        public List<ModelFornecedor> Fornecedor()
        {
            List<ModelFornecedor> FornecedorList = new List<ModelFornecedor>();

            MySqlCommand cmd = new MySqlCommand("select * from Fornecedor;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FornecedorList.Add(
                    new ModelFornecedor
                    {
                        IDfornecedor = Convert.ToString(dr["IDfornecedor"]),
                        nome = Convert.ToString(dr["nome"]),
                        telefone = Convert.ToString(dr["telefone"]),
                        CNPJ = Convert.ToString(dr["CNPJ"]),
                        nm_log = Convert.ToString(dr["nm_log"]),
                        no_log = Convert.ToString(dr["no_log"]),
                        ds_complemento = Convert.ToString(dr["ds_complemento"]),
                        bairro = Convert.ToString(dr["Bairro"]),
                        uf = Convert.ToString(dr["uf"]),
                    });
            }
            return FornecedorList;
        }

        public ModelFornecedor SelecionarIdForn(string ID)
        {
            ModelFornecedor usu = new ModelFornecedor();

            MySqlCommand cmd = new MySqlCommand("select * from fornecedor where IDfornecedor = @IDfornecedor", con.MyConectarBD());
            cmd.Parameters.Add("@IDfornecedor", MySqlDbType.VarChar).Value = ID;

            var leitor = cmd.ExecuteReader();

            leitor.Read();
            {
                usu.IDfornecedor = leitor["IDfornecedor"].ToString();
                usu.nome = leitor["nome"].ToString();
                usu.telefone = leitor["telefone"].ToString();
                usu.CNPJ = leitor["CNPJ"].ToString();
                usu.nm_log = leitor["nm_log"].ToString();
                usu.no_log = leitor["no_log"].ToString();
                usu.ds_complemento = leitor["ds_complemento"].ToString();
                usu.bairro = leitor["bairro"].ToString();
                usu.uf = leitor["uf"].ToString();

                leitor.Close();
                con.MyDesconectarBD();
                return usu;
            }
        }
    }
}