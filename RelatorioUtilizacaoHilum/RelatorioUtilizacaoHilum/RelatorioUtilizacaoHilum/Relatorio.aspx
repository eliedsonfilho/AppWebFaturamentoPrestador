<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="RelatorioUtilizacaoHilum.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        .auto-style2
        {
            width: 75px;
        }
        .auto-style3
        {
            width: 1061px;
        }
        .auto-style6
        {
            width: 50px;
            height: 23px;
        }
        .auto-style8
        {
            height: 23px;
        }
        .auto-style9
        {
            width: 163px;
        }
        .auto-style10
        {
            width: 110px;
        }
        .auto-style11
        {
            width: 620px;
        }
        .auto-style12
        {
            width: 487px;
        }
        .auto-style14
        {
            height: 23px;
        }
        .auto-style16
        {
            width: 50px;
            height: 22px;
        }
        .auto-style17
        {
            height: 22px;
        }
        .auto-style19
        {
            width: 273px;
        }
        .auto-style20
        {
            width: 219px;
        }
        .auto-style21
        {
            height: 23px;
        }
        .auto-style22
        {
            width: 50px;
            height: 20px;
        }
        .auto-style23
        {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/notepad.jpg" />
                </td>
                <td class="auto-style3" style="font-family: Verdana; font-size: 16px; color: #3399FF; font-weight: bold">Relatório Sintético de Utilização</td>
                <td class="auto-style2">
                    <asp:Image ID="Image2" runat="server" Height="60px" ImageUrl="~/Imagens/LogoUNIMED.PNG" style="margin-left: 17px" Width="168px" />
                </td>
            </tr>
    </table>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style22" style="color: #808080; font-family: Verdana; font-size: 10px; font-weight: bold;">Executante:</td>
                <td style="font-style: normal; font-size: 10px; font-family: Verdana; color: #000000; text-align: left" class="auto-style23">
                    <asp:Label ID="lblExecutante" runat="server" Font-Bold="True" Text="Acrisio Joao da Luz Fo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="color: #808080; font-family: Verdana; font-size: 10px; font-weight: bold;">Usuário:</td>
                <td class="auto-style8" style="font-style: normal; font-size: 10px; font-family: Verdana; color: #000000; text-align: left">
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Text="SIMULA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style16" style="color: #808080; font-family: Verdana; font-size: 10px; font-weight: bold;">Período:</td>
                <td class="auto-style17" style="font-style: normal; font-size: 10px; font-family: Verdana; color: #000000; text-align: left; font-weight: bold;">
                    <asp:Label ID="lblDataInicial" runat="server" Text="01/04/2014" Font-Bold="True"></asp:Label>
&nbsp;&nbsp; a&nbsp;&nbsp;
                    <asp:Label ID="lblDataFinal" runat="server" Text="17/05/2014" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style1" border="0" cellpadding="0" cellspacing="1" style="text-align: center;">
            <tr>
                <td class="auto-style9" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Data</td>
                <td class="auto-style20" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Autorização</td>
                <td class="auto-style19" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Tipo</td>
                <td class="auto-style12" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Cód. Beneficiário</td>
                <td class="auto-style11" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Beneficiário</td>
                <td class="auto-style10" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Bio?</td>
                <td style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; background-color: #F4F4F4; font-weight: bold; font-size: 10px; font-family: Verdana;">Situação</td>
            </tr>
            <tr>
                <td class="auto-style9" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblDataTran" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style20" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblAutorizacao" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style19" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblTipo" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style12" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblCodBeneficiario" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style11" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblNomeBenef" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style10" style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblBiometria" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="padding: 1px; margin: 1px; border-style: solid; border-width: thin; border-color: #CCCCCC; text-align: center; font-size: 10px; font-family: Verdana;">
                    <asp:Label ID="lblSituacao" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            </table>
        <p>
            &nbsp;</p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style8" colspan="5" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; font-size: 10px; font-family: Verdana;">TOTALIZADOR</td>
            </tr>
            <tr>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #F4F4F4; font-size: 10px; font-family: Verdana;">Transação</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #F4F4F4; font-size: 10px; font-family: Verdana;">Autorizado</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #F4F4F4; font-size: 10px; font-family: Verdana;">Negado</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #F4F4F4; font-size: 10px; font-family: Verdana;">Em Estudo</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #F4F4F4; font-size: 10px; font-family: Verdana;">Total Geral</td>
            </tr>
            <tr>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 10px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalTransacao" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 10px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalAutorizado" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 10px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalNegado" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 10px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalEmEstudo" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 10px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalTotalGeral" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21" style="text-align: right; color: #31A6FF; font-weight: bold; font-family: Verdana;"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagens/print_edit.gif" />
                    &nbsp;
                    Imprimir</td>
            </tr>
        </table>
    </form>
</body>
</html>
