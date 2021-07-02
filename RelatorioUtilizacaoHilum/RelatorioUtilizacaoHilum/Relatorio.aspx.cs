using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dados;

namespace RelatorioUtilizacaoHilum
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Transacao> transacoes = new List<Transacao>();
            IList<Execucao> execucao = new List<Execucao>();

            transacoes = Session["Transacoes"] as IList<Transacao>;
            execucao = Session["Execucoes"] as IList<Execucao>;

            //foreach (var transacoe in transacoes)
            //{
            //    Response.Write(transacoe.Autorizacao);
            //}

            if ((execucao != null) && (execucao.Count > 0))
            {
                lblErro.Text = "";

                GridView2.DataSource = execucao;
                GridView2.DataBind();

                lblTipo0.Text = "EXECUÇÃO";

                lblTotalTransacao0.Text = (from c in execucao select c.Tipo).First();

                lblTotalAutorizado0.Text = (from c in execucao where c.SituacaoExecucao == "Aut." select c).Count().ToString();

                lblTotalEmEstudo0.Text = (from c in execucao where c.SituacaoExecucao == "Est." select c).Count().ToString();

                lblTotalNegado0.Text = (from c in execucao where c.SituacaoExecucao == "Neg." select c).Count().ToString();

                lblTotalTotalGeral0.Text = (from c in execucao select c.Tipo).Count().ToString();

                lblVlrTotal0.Text = (from c in execucao where c.SituacaoExecucao == "Aut." select c.ValorAtendimento).Sum().ToString("N2");

                lblErro0.Text = "EXECUÇÃO";

            }
            else
            {
                lblErro0.Text = "NENHUMA EXECUÇÃO ENCONTRADA PARA OS FILTROS INFORMADOS!";
            }



            if ((transacoes != null) && (transacoes.Count >0))
            {
                lblErro.Text = "";

                GridView1.DataSource = transacoes;
                GridView1.DataBind();

                lblTipo.Text = "SOLICITAÇÃO/EXECUÇÃO";

                lblTotalTransacao.Text = (from c in transacoes select c.Tipo).First();

                lblTotalAutorizado.Text = (from c in transacoes where c.Situacao == "Aut." select c).Count().ToString();

                lblTotalEmEstudo.Text = (from c in transacoes where c.Situacao == "Est." select c).Count().ToString();

                lblTotalNegado.Text = (from c in transacoes where c.Situacao == "Neg." select c).Count().ToString();

                lblTotalTotalGeral.Text = (from c in transacoes select c.Tipo).Count().ToString();

                lblVlrTotal.Text = (from c in transacoes where c.Situacao == "Aut." select c.ValorAtendimento).Sum().ToString("N2");





                lblExecutante.Text = Session["NomePrestador"].ToString();

                lblUsuario.Text = Session["Login"].ToString();

                lblPeriodo.Text = Session["Periodo"].ToString();

                lblErro.Text = "SOLICITAÇÃO / EXECUÇÃO";


            }
            else
            {
                lblErro.Text = "NENHUMA SOLICITAÇÃO/EXECUÇÃO ENCONTRADA PARA OS FILTROS INFORMADOS!";
            }
        }

        protected void imgbtnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Filtros.aspx");
        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Filtros.aspx");
        }

        protected void lnkImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Imprimir();
        }

        
        public void Imprimir()
        {
            String s = "<script language='javascript'>";
            s += "window.print();";
            s += "</script>";
            Page.RegisterClientScriptBlock("Print", s);
        }
    }
}