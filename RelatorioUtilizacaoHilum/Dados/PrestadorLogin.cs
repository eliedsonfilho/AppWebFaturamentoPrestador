using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class PrestadorLogin
    {
        private string _id;
        private string _codigo;
        private string _tipo;
        private string _nome;
        private string _conselhoUF;
        private string _conselhoSigla;
        private string _conselhoNumero;
        private string _ativo;
        private string _emitirUtilizacao;
        private string _nomeCodigo;

        public PrestadorLogin()
        {
        }

        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string ConselhoUf
        {
            get { return _conselhoUF; }
            set { _conselhoUF = value; }
        }

        public virtual string ConselhoSigla
        {
            get { return _conselhoSigla; }
            set { _conselhoSigla = value; }
        }

        public virtual string ConselhoNumero
        {
            get { return _conselhoNumero; }
            set { _conselhoNumero = value; }
        }

        public virtual string Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        public virtual string EmitirUtilizacao
        {
            get { return _emitirUtilizacao; }
            set { _emitirUtilizacao = value; }
        }

        public virtual string NomeCodigo
        {
            get { return _nomeCodigo; }
            set { _nomeCodigo = value; }
        }
    }
}
