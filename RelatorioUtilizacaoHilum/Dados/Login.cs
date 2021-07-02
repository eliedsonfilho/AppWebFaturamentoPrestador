using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class Login
    {
        private string _id;
        private string _loginHilum;
        private string _nome;
        private string _sobrenome;
        private string _senhaAtual;
        private string _senhaAnterior;
        private string _tipoAcesso;
        private string _acessoBloqueado;

        public Login()
        {
        }

        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string LoginHilum
        {
            get { return _loginHilum; }
            set { _loginHilum = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value; }
        }

        public virtual string SenhaAtual
        {
            get { return _senhaAtual; }
            set { _senhaAtual = value; }
        }

        public virtual string SenhaAnterior
        {
            get { return _senhaAnterior; }
            set { _senhaAnterior = value; }
        }

        public virtual string TipoAcesso
        {
            get { return _tipoAcesso; }
            set { _tipoAcesso = value; }
        }

        public virtual string AcessoBloqueado
        {
            get { return _acessoBloqueado; }
            set { _acessoBloqueado = value; }
        }
    }
}
