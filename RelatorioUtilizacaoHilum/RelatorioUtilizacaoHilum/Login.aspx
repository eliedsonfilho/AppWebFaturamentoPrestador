<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RelatorioUtilizacaoHilum.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="../CSS/estilo.css" rel="stylesheet" type="text/css">
    <title>Unimed VSF</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="470">
            <tr>
                <td class="txt_formBack" colspan="3">
                    <img src="Imagens/loginHilum3.png" /></td>
            </tr>
        </table>
       <table width="470" border="0" align="center" cellpadding="0" cellspacing="0" style="border-left:1px solid #cccccc;border-right:1px solid #cccccc;">
        <tr valign="top">
        <td width="100%" bgcolor="#F9F9F9">
        
        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="20" valign="top" colspan="2"></td>
            </tr>
            <tr>
                <td height="22" width="35%" class="caps8 espacamento" align="right">Login :&nbsp; </td>
                <td>
                    <asp:TextBox ID="txb_login" runat="server" CssClass="caps8" MaxLength="50" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="22" class="caps8 espacamento" align="right">Senha :&nbsp; </td>
                <td>
                    <asp:TextBox ID="txb_senha" runat="server" CssClass="caps8" TextMode="Password" Width="150px" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" valign="middle" class="espacamento">
                    <center>
                        
                        <asp:Button ID="bt_login" runat="server" Text="Entrar" OnClick="bt_login_Click" />
                        
                    </center>
                </td>
            </tr>
         </table>
         
         <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
		            <tr>
		                <td colspan="2" class="txt_msgErro espacamento">
		                    <center>
                                <asp:Label ID="txt_msgErro" runat="server"></asp:Label>
                            </center>
		                </td>
		            </tr>
		        <tr>
		            <td height="1" valign="top" colspan="2" class="txt_formTitle"></td>
		        </tr>
		        <tr>
		            <td height="20" valign="middle" class="txt_formBack2"></td>
		            <td height="40" width="70%" valign="middle" class="txt_formBack3"></td>
		        </tr>
    	  </table>
    	  
      </td>
      </tr>
    </table>
    
    <table width="470" align="center" border="0" cellpadding="0" cellspacing="0">
  	  <tr>
         <td height="6" valign="top" colspan="3"><img src="Imagens/baseLogin3.jpg"></td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
