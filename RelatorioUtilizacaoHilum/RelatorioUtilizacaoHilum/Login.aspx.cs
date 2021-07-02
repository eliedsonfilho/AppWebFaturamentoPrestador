using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace RelatorioUtilizacaoHilum
{
    public partial class Login : System.Web.UI.Page
    {
        Repositorio.Repositorio repositorio = new Repositorio.Repositorio();

        protected void Page_Load(object sender, EventArgs e)
        {
            txb_login.Focus();
        }

        protected void bt_login_Click(object sender, EventArgs e)
        {
            string login = txb_login.Text;
            string salt = repositorio.RetornaSaltLoginHilum(login);
            string senha = sha256_hash(txb_senha.Text+salt);

            DataTable ExisteLogin = repositorio.ValidaLogin(login, senha);

            if  (ExisteLogin.Rows.Count >= 1)
            {
                txt_msgErro.Text = "";
                Session["loginhilum"] = login;
                Response.Redirect("Filtros.aspx");
            }
            else
            {
                txt_msgErro.Text = "Login ou Senha Invalido!";
            }

        }

        public static String sha256_hash(String value)
        {
            var Sb2 = new StringBuilder();

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result) Sb.Append(b.ToString("x2"));
            }
           
            if (Sb.ToString().Substring(0,1).Equals("0"))
            {
                //Sb2.Append(Sb.ToString().Substring(1, Sb.ToString().Length - 1));
                Sb2.Append(Sb.ToString().TrimStart('0'));
            }
            else
            {
                Sb2= Sb;
            }

            return Sb2.ToString();
        }

    }
}