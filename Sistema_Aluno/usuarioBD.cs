using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aluno
{
    internal class usuarioBD
    {
        private MySqlConnection Con;
        public usuarioBD()
        {
            Con = new MySqlConnection("Persist Security Info=false; server=localhost; database=bd_aluno; uid=root;pwd=");
            //Con = ConfigurationSettings.AppSettings["ConexaoBD"];
        }
        public usuario selecionaUser(string login, string senha)
        {
            //MySqlConnection CN = new MySqlConnection(con)
            try
            {
                Con.Open();
                MySqlCommand cmd = Con.CreateCommand();
                cmd.CommandText = "SELECT * from tbl_usuario WHERE usu_login=?login and usu_senha=?senha";
                cmd.Parameters.AddWithValue("?login", login);
                cmd.Parameters.AddWithValue("?senha", senha);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                usuario usuLogin = new usuario();
                while(dr.Read())
                {
                    usuLogin.Nome = dr["usu_nome"].ToString();
                    usuLogin.Senha = dr["usu_senha"].ToString();
                    usuLogin.Tipo = dr["usu_tipo"].ToString();
                }
                return usuLogin;
            } catch(Exception ex)
            {
                throw new ApplicationException(ex.ToString());

            } finally
            {
                Con.Close();
            }
        }
    }
}
