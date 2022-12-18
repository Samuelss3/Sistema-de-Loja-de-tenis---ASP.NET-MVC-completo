using MySql.Data.MySqlClient;
using ProjetoASP.Conexao;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoASP.Acoes
{
    public class acLogin
    {
        conexao cn = new conexao();

        public void InsertUsuario(ModelCadastroLogin cm)
        {
            MySqlCommand cmd = new MySqlCommand("call insertUsuario(@Nome,@Sobrenome,@datanasc, @cpf, @cep, @nm_log, @no_log, @ds_complemento, @bairro, @UF, @Email, @Senha, @IDtipoUsuario, @telefonecliente)", cn.MyConectarBD());

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
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
        public static string IDusuarioValor;

        public ModelCadastroLogin SelectUsuario(string vEmail)
        {
            MySqlCommand cmd = new MySqlCommand("call SelectUsuario(@Email);", cn.MyConectarBD());
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = vEmail;
            var readUsuario = cmd.ExecuteReader();
            var TempUsuario = new ModelCadastroLogin();

            if (readUsuario.Read())
            {
                IDusuarioValor = readUsuario["IDusuario"].ToString();
               
                TempUsuario.IDusuario = readUsuario["IDusuario"].ToString();
                TempUsuario.nome = readUsuario["Nome"].ToString();
                TempUsuario.sobrenome = readUsuario["Sobrenome"].ToString();
                TempUsuario.datanasc = readUsuario["datanasc"].ToString();
                TempUsuario.cpf = readUsuario["cpf"].ToString();
                TempUsuario.cep = readUsuario["cep"].ToString();
                TempUsuario.nm_log = readUsuario["nm_log"].ToString();
                TempUsuario.no_log = readUsuario["no_log"].ToString();
                TempUsuario.ds_complemento = readUsuario["ds_complemento"].ToString();
                TempUsuario.bairro = readUsuario["bairro"].ToString();
                TempUsuario.uf = readUsuario["UF"].ToString();
                TempUsuario.Email = readUsuario["Email"].ToString();
                TempUsuario.Senha = readUsuario["Senha"].ToString();
                TempUsuario.IDtipoUsuario = readUsuario["IDtipoUsuario"].ToString();
            };

            readUsuario.Close();
            cn.MyDesconectarBD();
            return TempUsuario;
        }

    }
}