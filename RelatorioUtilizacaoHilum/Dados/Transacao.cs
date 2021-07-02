using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class Transacao
    {
        private string _data;
        private string _autorizacao;
        private string _tipo;
        private string _codBenef;
        private string _nomeBenef;
        private string _validouBiometria;
        private string _situacao;
        private string _loginHilum;
        private string _tipoplano;
        private decimal _valorAtendimento;

        public Transacao()
        {
        }

        public decimal ValorAtendimento
        {
            get { return _valorAtendimento; }
            set { _valorAtendimento = value; }
        }


        public string Tipoplano
        {
            get { return _tipoplano; }
            set { _tipoplano = value; }
        }

        public virtual string Data 
        {
            get { return _data; }
            set { _data = value; }
        }

        public virtual string Autorizacao
        {
            get { return _autorizacao; }
            set { _autorizacao = value; }
        }

        public virtual string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual string CodBenef
        {
            get { return _codBenef; }
            set { _codBenef = value; }
        }

        public string NomeBenef
        {
            get { return _nomeBenef; }
            set { _nomeBenef = value; }
        }

        public virtual string ValidouBiometria
        {
            get { return _validouBiometria; }
            set { _validouBiometria = value; }
        }

        public virtual string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        public virtual string LoginHilum
        {
            get { return _loginHilum; }
            set { _loginHilum = value; }
        }
    }
}
