using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class Execucao
    {
        private string _dataExecucao;
        private string _autorizacao;
        private string _tipo;
        private string _codBenef;
        private string _nomeBenef;
        private string _validouBiometria;
        private string _situacaoExecucao;
        private string _loginHilum;
        private string _tipoplano;
        private string _codigoServico;
        private string _descricaoServico;
        private string _qteExecutada;
        private decimal _valorAtendimento;


        public Execucao()
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

        public virtual string DataExecucao 
        {
            get { return _dataExecucao; }
            set { _dataExecucao = value; }
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

        public virtual string SituacaoExecucao
        {
            get { return _situacaoExecucao; }
            set { _situacaoExecucao = value; }
        }

        public virtual string LoginHilum
        {
            get { return _loginHilum; }
            set { _loginHilum = value; }
        }

        public virtual string CodigoServico
        {
            get { return _codigoServico; }
            set { _codigoServico = value; }
        }

        public virtual string DescricaoServico
        {
            get { return _descricaoServico; }
            set { _descricaoServico = value; }
        }

        public virtual string QteExecutada
        {
            get { return _qteExecutada; }
            set { _qteExecutada = value; }
        }
    }
}
