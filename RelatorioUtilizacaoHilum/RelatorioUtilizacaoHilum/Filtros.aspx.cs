using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dados;

namespace RelatorioUtilizacaoHilum
{
    public partial class Filtros : System.Web.UI.Page
    {
        Repositorio.Repositorio repositorio = new Repositorio.Repositorio();
        private IList<Dados.PrestadorLogin> _listaPrestadores;
        private IList<Transacao> _listaTransacao;
        private IList<Execucao> _listaExecucao;
        private Dados.Login _login;

        private string CodigoPrestador = "";

        private string TipoTransacao = "";
        private string TipoSituacao = "";
        private string TipoBeneficiario = "";
        private string ChkBiometria = "";
        private string ExibeUtil = "";

        private string DataInicial;
        private string DataFinal;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                CarregaListaPrestadores();

            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }


        }

        private void CarregaListaPrestadores()
        {
            string loginhilum = Session["loginhilum"].ToString();
            _login = new Dados.Login();
            _listaPrestadores = new List<PrestadorLogin>();

            _login = repositorio.ObterLogin(loginhilum);
            _listaPrestadores = repositorio.ObterPrestadorLogin(_login.LoginHilum);

            ddlPrestadores.DataSource = _listaPrestadores;
            ddlPrestadores.DataTextField = "NomeCodigo";
            ddlPrestadores.DataValueField = "Codigo";
            ddlPrestadores.DataBind();

            //foreach (var listaPrestadore in _listaPrestadores)
            //{
            //    ddlPrestadores.Items.Add(new ListItem(listaPrestadore.NomeCodigo, listaPrestadore.Codigo));               
            //}

        }

  
        private void CarregaParametrosRelatorio()
        {
            TipoTransacao = rdbConsulta.Checked ? "1" : TipoTransacao;
            TipoTransacao = rdbSADT.Checked ? "2" : TipoTransacao;
            TipoTransacao = rdbInternacao.Checked ? "5" : TipoTransacao;
            TipoTransacao = rdbTodasTpTransacao.Checked ? "9" : TipoTransacao;

            TipoSituacao = rdbAutorizado.Checked ? "A" : TipoSituacao;
            TipoSituacao = rdbNegado.Checked ? "N" : TipoSituacao;
            TipoSituacao = rdbEmEstudo.Checked ? "E" : TipoSituacao;
            TipoSituacao = rdbTodas.Checked ? "T" : TipoSituacao;

            TipoBeneficiario = rdbLocais.Checked ? "L" : "I";

            ChkBiometria = rdbSIM.Checked ? "S" : "N";

            if (String.IsNullOrEmpty(txtDtInicial.Text))
            {
                txtDtInicial.BorderWidth = 3;
                txtDtInicial.BorderColor = System.Drawing.Color.Red;
                txt_msgErro.Text = "Campo de preenchimento obrigatório";
            }
            else
            {
                txtDtInicial.BorderWidth = 1;
                txtDtInicial.BorderColor = System.Drawing.Color.Empty;
                txt_msgErro.Text = null;
                DataInicial = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Parse(txtDtInicial.Text+" 00:00:00"));              
            }

            if (String.IsNullOrEmpty(txtDtFinal.Text))
            {
                txtDtFinal.BorderWidth = 3;
                txtDtFinal.BorderColor = System.Drawing.Color.Red;
                txt_msgErro.Text = "Campo de preenchimento obrigatório";
            }
            else
            {
                txtDtFinal.BorderWidth = 1;
                txtDtInicial.BorderColor = System.Drawing.Color.Empty;
                txt_msgErro.Text = null;
                DataFinal = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Parse(txtDtFinal.Text + " 23:59:59"));
            }

            if (ddlPrestadores.SelectedItem.Value == "0")
            {
                ddlPrestadores.BorderWidth = 3;
                ddlPrestadores.BorderColor = System.Drawing.Color.Red;
                txt_msgErro.Text = "Campo de preenchimento obrigatório";
            }
            else
            {
                ddlPrestadores.BorderWidth = 1;
                ddlPrestadores.BorderColor = System.Drawing.Color.Empty;
                txt_msgErro.Text = null;
                CodigoPrestador = ddlPrestadores.SelectedItem.Value;
                ExibeUtil = (from c in _listaPrestadores where c.Codigo == CodigoPrestador select c.EmitirUtilizacao).SingleOrDefault();
            }
           
        }


        protected void btExecutarRelatorio_Click(object sender, EventArgs e)
        {
                if(ValidarCampos())
                {
                    CarregaParametrosRelatorio();
                    _listaTransacao = new List<Transacao>();
                    _listaExecucao = new List<Execucao>();


                    _listaTransacao = repositorio.ObterTransacoes(_login.LoginHilum, CodigoPrestador, DataInicial, DataFinal, TipoTransacao,
                                                TipoSituacao, ChkBiometria, TipoBeneficiario, ExibeUtil);

                    _listaExecucao = repositorio.ObterExecucoes(_login.LoginHilum, CodigoPrestador, DataInicial, DataFinal, TipoTransacao,
                                                TipoSituacao, ChkBiometria, TipoBeneficiario, ExibeUtil);


                    Session["Transacoes"] = _listaTransacao;
                    Session["Execucoes"] = _listaExecucao;

                    Session["NomePrestador"] = (from c in _listaPrestadores where c.Codigo == CodigoPrestador select c.Nome).SingleOrDefault();

                    Session["Login"] = _login.LoginHilum;

                    Session["Periodo"] = txtDtInicial.Text + " a " + txtDtFinal.Text;

                    Response.Redirect("Relatorio.aspx");
                }
        }

        public bool ValidarCampos()
        {
            List<string> listaErros = new List<string>();

            if (ddlPrestadores.SelectedIndex == 0)
            {
                listaErros.Add("É necessário informar o nome do Profissional!");
            }
            if ((String.IsNullOrEmpty(txtDtInicial.Text)) || (txtDtInicial.Text == "01/01/0001"))
            {
                listaErros.Add("É necessário informar a Data Inicial!");
            }
            if ((String.IsNullOrEmpty(txtDtFinal.Text)) || (txtDtFinal.Text == "01/01/0001"))
            {
                listaErros.Add("É necessário informar Data Final!");
            }

            TimeSpan intervalo = Convert.ToDateTime(txtDtFinal.Text) - Convert.ToDateTime(txtDtInicial.Text);
            int intervalodias = intervalo.Days;
            if (intervalodias > 31)
            {
                listaErros.Add("Intervalo de datas maior que o permitido!");
            }

            TimeSpan periodo = DateTime.Now - Convert.ToDateTime(txtDtFinal.Text);
            int periodolimite = periodo.Days;
            if (periodolimite > 180)
            {
                listaErros.Add("Data Inicial superior a 6 meses!");
            }




            StringBuilder mensagemErro = new StringBuilder();
            foreach (string erro in listaErros)
            {
                mensagemErro.Append(erro +"\\n");
            }

            if (mensagemErro.Length > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagemErro +"');", true);
                //MessageBox.Show(mensagemErro.ToString());
                return false;

            }
            else
            {
                return true;
            }
        }



    }
}