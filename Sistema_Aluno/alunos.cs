using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aluno
{
    internal class alunos
    {
        public alunos()
        {

        }
        public alunos(string nome, string endereco, int idade) {
            this.Nome = nome;
            this.Endereco = endereco;
            this.Idade = idade;
        }
        private int _alunoID;
        public int AlunoID
        {
            get { return _alunoID; }
            set { _alunoID = value; }
        }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private string endereco;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private int idade;
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }
    }
}
