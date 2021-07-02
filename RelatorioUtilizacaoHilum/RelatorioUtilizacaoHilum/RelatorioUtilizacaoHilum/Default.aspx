<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RelatorioUtilizacaoHilum._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    

<link rel="stylesheet" href="JS/jquery-ui.css" />
<link href="CSS/ui.all.css" rel="stylesheet" /> 
<link href="CSS/estilo.css"/>

<script src="JS/jquery-1.8.2.js" ></script>
<script src="JS/jquery-ui.js"></script>
    

<head runat="server">
    <title></title>
    <script>
        $(function() {
            $("#txtDtInicial").datepicker({
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
    
    <script>
        $(function () {
            $("#txtDtFinal").datepicker({
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                changeMonth: true,
                changeYear: true
             });
        });
    </script>

    <style type="text/css">
        .auto-style3
        {
            width: 100%;
            float: left;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style4
        {
            height: 23px;
            width: 515px;
        }
        .auto-style5
        {
            width: 543px;
            height: 69px;
        }
        .auto-style6
        {
        }
        .auto-style7
        {
            width: 107px;
        }
        .auto-style8
        {
            height: 23px;
        }
        .auto-style10
        {
            width: 107px;
            height: 25px;
        }
        .auto-style11
        {
            height: 25px;
        }
        .auto-style12
        {
            height: 36px;
        }
        .auto-style13
        {
            width: 107px;
            height: 24px;
        }
        .auto-style14
        {
            height: 24px;
        }
        .auto-style15
        {
            width: 107px;
            height: 23px;
        }
        .auto-style16
        {
            width: 107px;
            height: 33px;
        }
        .auto-style17
        {
            height: 33px;
        }
    </style>

    </head>
<body>
    <form id="form1" runat="server">
    <div style="height: 264px; width: 551px">
    
        <table align="left" class="auto-style3" cellpadding="3" cellspacing="3" style="background-color: #F9F9F9">
            <tr>
                <td class="auto-style6" colspan="2">
                    <img alt="imgRelatorioUtilizacao" class="auto-style5" src="Imagens/relatorioUtilizacao.jpg" /></td>
            </tr>
            <tr>
                <td class="auto-style15" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Prestador:</td>
                <td class="auto-style8" style="font-family: Arial; font-size: 11px; font-weight: bold; color: #333333; background-color: #F9F9F9; text-transform: none;">
                    <asp:DropDownList ID="ddlPrestadores" runat="server" Width="181px" TabIndex="1">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style16" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Período:</td>
                <td class="auto-style17" style="font-family: Verdana; font-size: 10px; font-weight: bold; color: #5C5C5C; background-color: #F9F9F9">
                    <asp:TextBox  ID="txtDtInicial"  runat="server" Width="82px" MaxLength="10" TabIndex="2"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Até&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtDtFinal" runat="server" Width="82px" MaxLength="10" TabIndex="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Transações:</td>
                <td class="auto-style6" style="font-family: Verdana; font-size: 9px; font-weight: bold; color: #5C5C5C; background-color: #F9F9F9; text-align: left">
                    <asp:RadioButton ID="rdbSolicitacao" runat="server" Enabled="False" GroupName="grpTransacao" Text="Solicitação" TabIndex="4" />
&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:RadioButton ID="rdbExecucao" runat="server" Checked="True" GroupName="grpTransacao" Text="Execução" TabIndex="5" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbSomenteLocalExec" runat="server" Enabled="False" GroupName="grpTransacao" Text="Somente Local Exec." TabIndex="6" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Situações:</td>
                <td class="auto-style8" style="font-family: Verdana; font-size: 9px; font-weight: bold; color: #5C5C5C; background-color: #F9F9F9; text-align: left;">
                    <asp:RadioButton ID="rdbAutorizado" runat="server" Checked="True" GroupName="grpSituacao" Text="Autorizado" TabIndex="7" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbNegado" runat="server" GroupName="grpSituacao" Text="Negado" TabIndex="8" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbEmEstudo" runat="server" GroupName="grpSituacao" Text="Em estudo" TabIndex="9" />
&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbTodas" runat="server" GroupName="grpSituacao" Text="Todas" TabIndex="10" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Modelo:</td>
                <td class="auto-style4" style="font-family: Verdana; font-size: 9px; font-weight: bold; color: #5C5C5C; background-color: #F9F9F9; text-align: left">
                    <asp:RadioButton ID="rdbSintetico" runat="server" GroupName="grpModelo" Text="Sintético" Checked="True" TabIndex="11" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbAnalitico" runat="server" GroupName="grpModelo" Text="Analítico" Enabled="False" TabIndex="12" />
                </td>
            </tr>
            <tr>
                <td class="auto-style13" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Beneficiários:</td>
                <td class="auto-style14" style="font-family: Verdana; font-size: 9px; font-weight: bold; color: #5C5C5C; background-color: #F9F9F9; text-align: left">
                    <asp:RadioButton ID="rdbLocais" runat="server" GroupName="grpBeneficiarios" Text="Locais" Checked="True" TabIndex="13" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbIntercambio" runat="server" GroupName="grpBeneficiarios" Text="Intercâmbio" TabIndex="14" />
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="padding-left: 20px; color: #004E99; font-weight: bold; font-size: 13px; background-color: #F9F9F9; vertical-align: middle;">Validou Biometria:</td>
                <td class="auto-style11" style="font-family: Verdana; font-size: 9px; font-weight: bold; color: #5C5C5C; background-color: #F9F9F9; text-align: left">
                    <asp:RadioButton ID="rdbSIM" runat="server" GroupName="ValidouBio" Text="SIM" Checked="True" TabIndex="15" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdbNAO" runat="server" GroupName="ValidouBio" Text="NÃO" TabIndex="16" />
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style12" colspan="2" style="font-family: Verdana; background-color: #F9F9F9;" valign="bottom">
                    <asp:Button ID="Button1" runat="server" BackColor="#4A864A" BorderColor="#009ACE" ForeColor="White" Text="Visualizar" TabIndex="17" />
                </td>
            </tr>
        </table>
    
        
    
    </div>
    </form>
</body>
</html>
