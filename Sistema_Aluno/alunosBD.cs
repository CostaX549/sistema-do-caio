using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace Sistema_Aluno
{
    internal class alunosBD
    {
        private MySqlConnection mCon;
        public alunosBD()
        {
            mCon = new MySqlConnection("Persist Security Info=false; server=localhost; database=bd_aluno; uid=root;pwd=");
        }
        public DataTable getAlunos()
        {
            MySqlCommand cmd = mCon.CreateCommand();
            MySqlDataAdapter da;
            cmd.CommandText = "SELECT * from tbl_aluno";
            try
            {
                mCon.Open();
                cmd = new MySqlCommand(cmd.CommandText, mCon);
                da = new MySqlDataAdapter(cmd);
                DataTable dtAlunos = new DataTable();
                da.Fill(dtAlunos);
                return dtAlunos;
            } catch(MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            } finally
            {
                mCon.Close();
            }

        }
        public void IncluirAluno(alunos alunos)
        {
            MySqlCommand Com = mCon.CreateCommand();
            Com.CommandText = "INSERT INTO tbl_aluno(alu_nome, alu_endereco, alu_idade) Values (?nome, ?endereco, ?idade)";
            Com.Parameters.AddWithValue("?nome", alunos.Nome);
            Com.Parameters.AddWithValue("?endereco", alunos.Endereco);
            Com.Parameters.AddWithValue("?idade", alunos.Idade);
            try
            {
                mCon.Open();
                int registrosAfetados = Com.ExecuteNonQuery();
            } catch(MySqlException ex)
            {

                throw new ApplicationException(ex.ToString());
            } finally
            {
                mCon.Close();
            }

        }
        public alunos selecionaAluno(int id)
        {
            try
            {
                mCon.Open();
                MySqlCommand cmd = mCon.CreateCommand();
                cmd.CommandText = "SELECT * from tbl_aluno WHERE alu_cod = ?id";
                cmd.Parameters.AddWithValue("?id", id);
                MySqlDataReader dr;
                alunos aluSelect = new alunos();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while(dr.Read())
                {
                    aluSelect.AlunoID = Convert.ToInt32(dr["alu_cod"]);
                    aluSelect.Nome = dr["alu_nome"].ToString();
                    aluSelect.Endereco = dr["alu_end"].ToString();
                    aluSelect.Idade = Convert.ToInt32(dr["alu_idade"]);
                }
                return aluSelect;
            } catch(Exception ex)
            {
               throw new ApplicationException(ex.ToString());
            } finally
            {
                mCon.Close();
            }
        }

    }
}
