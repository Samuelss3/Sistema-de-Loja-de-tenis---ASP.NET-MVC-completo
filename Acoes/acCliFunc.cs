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
    public class acCliFunc
    {
        conexao con = new conexao();
        public List<ModelCadastroLogin> Cliente()
        {
            List<ModelCadastroLogin> ClienteList = new List<ModelCadastroLogin>();

            MySqlCommand cmd = new MySqlCommand("select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario = TelefoneCLi.IDUsuario and idTipoUsuario = 1;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ClienteList.Add(
                    new ModelCadastroLogin
                    {
                        IDusuario = Convert.ToString(dr["IDusuario"]),
                        nome = Convert.ToString(dr["nome"]),
                        sobrenome = Convert.ToString(dr["sobrenome"]),
                        datanasc = Convert.ToString(dr["datanasc"]),
                        cpf = Convert.ToString(dr["cpf"]),
                        cep = Convert.ToString(dr["cep"]),
                        nm_log = Convert.ToString(dr["nm_log"]),
                        no_log = Convert.ToString(dr["no_log"]),
                        ds_complemento = Convert.ToString(dr["ds_complemento"]),
                        bairro = Convert.ToString(dr["Bairro"]),
                        uf = Convert.ToString(dr["uf"]),
                        Email = Convert.ToString(dr["Email"]),
                        Senha = Convert.ToString(dr["Senha"]),
                        IDtipoUsuario = Convert.ToString(dr["IDtipoUsuario"]),
                        telefoneCliente = Convert.ToString(dr["telefoneCliente"]),
                    });
            }
            return ClienteList;
        }

        public List<ModelCadastroLogin> Funcionario()
        {
            List<ModelCadastroLogin> funcionarioList = new List<ModelCadastroLogin>();

            MySqlCommand cmd = new MySqlCommand("select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario = TelefoneCLi.IDUsuario and idTipoUsuario = 2;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                funcionarioList.Add(
                    new ModelCadastroLogin
                    {
                        IDusuario = Convert.ToString(dr["IDusuario"]),
                        nome = Convert.ToString(dr["nome"]),
                        sobrenome = Convert.ToString(dr["sobrenome"]),
                        datanasc = Convert.ToString(dr["datanasc"]),
                        cpf = Convert.ToString(dr["cpf"]),
                        cep = Convert.ToString(dr["cep"]),
                        nm_log = Convert.ToString(dr["nm_log"]),
                        no_log = Convert.ToString(dr["no_log"]),
                        ds_complemento = Convert.ToString(dr["ds_complemento"]),
                        bairro = Convert.ToString(dr["Bairro"]),
                        uf = Convert.ToString(dr["uf"]),
                        Email = Convert.ToString(dr["Email"]),
                        Senha = Convert.ToString(dr["Senha"]),
                        IDtipoUsuario = Convert.ToString(dr["IDtipoUsuario"]),
                        telefoneCliente = Convert.ToString(dr["telefoneCliente"]),
                    });
            }
            return funcionarioList;
        }


        public ModelCadastroLogin SelecionarId(string ID)
        {
            ModelCadastroLogin usu = new ModelCadastroLogin();
           
            MySqlCommand cmd = new MySqlCommand ("select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario =@IDusuario = TelefoneCLi.codtelefonecli;", con.MyConectarBD());
            cmd.Parameters.Add("@IDusuario", MySqlDbType.VarChar).Value = ID;

            var leitor = cmd.ExecuteReader();

            leitor.Read();
            { 

            usu.IDusuario = leitor["IDusuario"].ToString();
            usu.nome = leitor["nome"].ToString();
            usu.sobrenome = leitor["sobrenome"].ToString();
            usu.datanasc = leitor["datanasc"].ToString();
            usu.cpf = leitor["cpf"].ToString();
            usu.cep = leitor["cep"].ToString();
            usu.nm_log = leitor["nm_log"].ToString();
            usu.no_log = leitor["no_log"].ToString();
            usu.ds_complemento = leitor["ds_complemento"].ToString();
            usu.bairro = leitor["bairro"].ToString();
            usu.uf = leitor["uf"].ToString();
            usu.Email = leitor["Email"].ToString();
            usu.Senha = leitor["Senha"].ToString();
            usu.IDtipoUsuario = leitor["IDtipoUsuario"].ToString();
            usu.telefoneCliente = leitor["telefoneCliente"].ToString();


            leitor.Close();
                con.MyDesconectarBD();
                return usu;
            }
        }
        
        public void deleteUsuario(string usuario)
        {
            MySqlCommand cmd = new MySqlCommand("Call deleteUsuario(@IDusuario)", con.MyConectarBD());
            cmd.Parameters.Add("@IDusuario", MySqlDbType.VarChar).Value = usuario;
            cmd.ExecuteReader();
            con.MyDesconectarBD();
        }
    

    public void updateUsuario(ModelCadastroLogin cm)
            {
            MySqlCommand cmd = new MySqlCommand("call updateUsuario(@Nome,@Sobrenome,@datanasc, @cpf, @cep, @nm_log, @no_log, @ds_complemento, @bairro, @UF, @Email, @Senha, @IDtipoUsuario, @telefonecliente, @IDUsuario, last_insert_id())", con.MyConectarBD());

            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cm.nome;
            cmd.Parameters.Add("@Sobrenome", MySqlDbType.VarChar).Value = cm.sobrenome;
            cmd.Parameters.Add("@datanasc", MySqlDbType.VarChar).Value = cm.datanasc;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cm.cpf;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = cm.cep;
            cmd.Parameters.Add("@nm_log", MySqlDbType.VarChar).Value = cm.nm_log;
            cmd.Parameters.Add("@no_log", MySqlDbType.VarChar).Value = cm.no_log;
            cmd.Parameters.Add("@ds_complemento", MySqlDbType.VarChar).Value = cm.ds_complemento;
            cmd.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = cm.bairro;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar).Value = cm.uf;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cm.Email;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cm.Senha;
            cmd.Parameters.Add("@IDtipoUsuario", MySqlDbType.VarChar).Value = cm.IDtipoUsuario;
            cmd.Parameters.Add("@telefoneCliente", MySqlDbType.VarChar).Value = cm.telefoneCliente;
            cmd.Parameters.Add("@IDusuario", MySqlDbType.VarChar).Value = cm.IDusuario;
            cmd.Parameters.Add("@last_insert_id()", MySqlDbType.VarChar).Value = cm.IDusuario;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void TestarUsuario(ModelCadastroLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from CadastroLogin where Email = @Email", con.MyConectarBD());
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = user.Email;
            MySqlDataReader leitor; leitor = cmd.ExecuteReader();
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.Email = Convert.ToString(leitor["Email"]);
                    user.Senha = Convert.ToString(leitor["Senha"]);
                    user.IDusuario = Convert.ToString(leitor["IDusuario"]);
                }
            }
            else
            {
                user.Email = null;
                user.Email = null;
            }

            con.MyDesconectarBD();
        }


    }
}