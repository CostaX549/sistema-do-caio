using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aluno
{
    internal class usuario
    {
        public int _usuarioID;
        public int UsuarioID
        {
            get { return _usuarioID; }
            set { _usuarioID = value; }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value;  }
        } 
        public usuario()
        {

        }
        public usuario(string nome, string senha, string login, string tipo)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Login = login;
            this.Tipo = tipo;

        }

    }
}
