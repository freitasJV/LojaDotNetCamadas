using Loja.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Loja.DAL
{
    public class UsuarioDAL
    {
        public IList<usuario_DTO> CargaUsuario()
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = Properties.Settings.Default.CST;
                MySqlCommand cm = new MySqlCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT * FROM tb_usuarios";
                cm.Connection = con;

                MySqlDataReader er;

                IList<usuario_DTO> listUsuarioDTO = new List<usuario_DTO>();

                con.Open();
                er = cm.ExecuteReader();

                if (er.HasRows)
                {
                    while (er.Read())
                    {
                        usuario_DTO usu = new usuario_DTO();
                        usu.Cod_usuario = er.GetInt32(0);
                        usu.Nome = er.GetString(1);
                        usu.Login = er.GetString(2);
                        usu.Email = er.GetString(3);
                        usu.Senha = er.GetString(4);
                        usu.Cadastro = er.GetDateTime(5);
                        usu.Situacao = er.GetString(6);
                        usu.Perfil = er.GetInt32(7);
                        listUsuarioDTO.Add(usu);
                    }
                }

                return listUsuarioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsereUsuario(usuario_DTO USU)
        {
            try
            {
                MySqlConnection CON = new MySqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                MySqlCommand CM = new MySqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)" +
                    " VALUES (@nome, @login, @email, @senha, @cadastro, @situacao, @perfil)";
                CM.Parameters.Add("nome", MySqlDbType.VarChar).Value = USU.Nome;
                CM.Parameters.Add("login", MySqlDbType.VarChar).Value = USU.Login;
                CM.Parameters.Add("email", MySqlDbType.VarChar).Value = USU.Email;
                CM.Parameters.Add("senha", MySqlDbType.VarChar).Value = USU.Senha;
                CM.Parameters.Add("cadastro", MySqlDbType.DateTime).Value = USU.Cadastro;
                CM.Parameters.Add("situacao", MySqlDbType.VarChar).Value = USU.Situacao;
                CM.Parameters.Add("perfil", MySqlDbType.Int32).Value = USU.Perfil;

                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();

                return qtd;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public int EditaUsuario(usuario_DTO USU)
        {
            try
            {
                MySqlConnection CON = new MySqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                MySqlCommand CM = new MySqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "UPDATE tb_usuarios SET perfil=@perfil,"+
                    "nome=@nome, login=@login, email=@email, senha=@senha,"+
                    "cadastro=@cadastro, situacao=@situacao WHERE cod_usuarios=@cod_usuario";

                CM.Parameters.Add("perfil", MySqlDbType.Int32).Value = USU.Perfil;
                CM.Parameters.Add("nome", MySqlDbType.VarChar).Value = USU.Nome;
                CM.Parameters.Add("login", MySqlDbType.VarChar).Value = USU.Login;
                CM.Parameters.Add("email", MySqlDbType.VarChar).Value = USU.Email;
                CM.Parameters.Add("senha", MySqlDbType.VarChar).Value = USU.Senha;
                CM.Parameters.Add("cadastro", MySqlDbType.DateTime).Value = USU.Cadastro;
                CM.Parameters.Add("situacao", MySqlDbType.VarChar).Value = USU.Situacao;
                CM.Parameters.Add("cod_usuario", MySqlDbType.Int32).Value = USU.Cod_usuario;

                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeletaUsuario(usuario_DTO USU)
        {
            try
            {
                MySqlConnection CON = new MySqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                MySqlCommand CM = new MySqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "DELETE FROM tb_usuarios WHERE cod_usuarios=@cod_usuarios";

                CM.Parameters.Add("cod_usuarios", MySqlDbType.Int32).Value = USU.Cod_usuario;

                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
