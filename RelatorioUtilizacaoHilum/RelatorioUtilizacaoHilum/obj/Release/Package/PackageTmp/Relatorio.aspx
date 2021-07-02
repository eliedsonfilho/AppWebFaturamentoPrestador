<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="RelatorioUtilizacaoHilum.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unimed VSF</title>
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
        .auto-style24 {
            height: 23px;
            width: 178px;
        }
        .auto-style25 {
            width: 178px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
    <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/notepad.jpg" />
                </td>
                <td class="auto-style3" style="font-family: Verdana; font-size: 16px; color: #3399FF; font-weight: bold">Relatório Sintético de Utilização</td>
                <td class="auto-style2">
                    <asp:Image ID="Image2" runat="server" Height="60px" ImageUrl="~/Imagens/logo_univsf.PNG" style="margin-left: 17px" Width="168px" />
                </td>
            </tr>
    </table>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style22" style="color: #808080; font-family: Verdana; font-size: 10px; font-weight: bold;">Executante:</td>
                <td style="font-style: normal; font-size: 10px; font-family: Verdana; color: #000000; text-align: left" class="auto-style23">
                    <asp:Label ID="lblExecutante" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="color: #808080; font-family: Verdana; font-size: 10px; font-weight: bold;">Usuário:</td>
                <td class="auto-style8" style="font-style: normal; font-size: 10px; font-family: Verdana; color: #000000; text-align: left">
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style16" style="color: #808080; font-family: Verdana; font-size: 10px; font-weight: bold;">Período:</td>
                <td class="auto-style17" style="font-style: normal; font-size: 10px; font-family: Verdana; color: #000000; text-align: left; font-weight: bold;">
                    <asp:Label ID="lblPeriodo" runat="server" Font-Bold="True"></asp:Label>
&nbsp;&nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <div style="height: 20px; text-align: center;">
            <asp:Label ID="lblErro" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#31BAFF"></asp:Label>
        </div>
        <div align="center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="1" CellSpacing="2" EnableModelValidation="True"  Width="1070px">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Data">
                    <ControlStyle Width="50px" />
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Autorizacao" HeaderText="Autorização">
                    <ControlStyle Width="50px" />
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                    <ControlStyle Width="60px" />
                    <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CodBenef" HeaderText="Cód.Beneficiário">
                    <ControlStyle Width="110px" />
                    <ItemStyle Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NomeBenef" HeaderText="Beneficiário">
                    <ControlStyle Width="210px" />
                    <ItemStyle Width="210px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Tipoplano" HeaderText="Plano" SortExpression="Plano">
                    <ControlStyle Width="80px" />
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ValidouBiometria" HeaderText="Bio?">
                    <ControlStyle Width="30px" />
                    <ItemStyle Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Situacao" HeaderText="Situação">
                    <ControlStyle Width="52px" />
                    <ItemStyle Width="52px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LoginHilum" HeaderText="Login">
                    <ControlStyle Width="52px" />
                    <ItemStyle Width="52px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ValorAtendimento" HeaderText="Vlr. Atd" Visible="False">
                    <ControlStyle Width="52px" />
                    <ItemStyle Width="52px" HorizontalAlign="Right" />
                    </asp:BoundField>

                </Columns>
                <EditRowStyle Font-Size="10px" />
                <HeaderStyle BackColor="Silver" />
                <PagerStyle Wrap="False" />
                <RowStyle Font-Size="14px" HorizontalAlign="Center" VerticalAlign="Bottom" Wrap="True" />
            </asp:GridView>

            <div style="height: 20px" align="center">
                <br />
            </div>

        <div style="height: 20px; text-align: center;">
            <asp:Label ID="lblErro0" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#31BAFF"></asp:Label>
        </div>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="1" CellSpacing="2" EnableModelValidation="True" Width="1069px">
                <Columns>
                    <asp:BoundField DataField="DataExecucao" HeaderText="Data Exec.">
                    <ControlStyle Width="50px" />
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Autorizacao" HeaderText="Autorização">
                    <ControlStyle Width="70px" />
                    <ItemStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                    <ControlStyle Width="60px" />
                    <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CodBenef" HeaderText="Cód.Beneficiário">
                    <ControlStyle Width="140px" />
                    <ItemStyle Width="140px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NomeBenef" HeaderText="Beneficiário">
                    <ControlStyle Width="310px" />
                    <ItemStyle Width="310px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Tipoplano" HeaderText="Plano" SortExpression="Plano">
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ValidouBiometria" HeaderText="Bio?">
                    <ControlStyle Width="30px" />
                    <ItemStyle Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CodigoServico" HeaderText="Cod. Serviço" />
                    <asp:BoundField DataField="DescricaoServico" HeaderText="Desc. Serviço" >
                    <ControlStyle Width="320px" />
                    <ItemStyle Width="320px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QteExecutada" HeaderText="Qte. Exec" />
                    <asp:BoundField DataField="SituacaoExecucao" HeaderText="Situação">
                    <ControlStyle Width="52px" />
                    <ItemStyle Width="52px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LoginHilum" HeaderText="Login">
                    <ControlStyle Width="52px" />
                    <ItemStyle Width="52px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ValorAtendimento" HeaderText="Vlr. Atd" Visible="False">
                    <ControlStyle Width="52px" />
                    <ItemStyle Width="52px" HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle Font-Size="10px" />
                <HeaderStyle BackColor="Silver" />
                <PagerStyle Wrap="False" />
                <RowStyle Font-Size="14px" HorizontalAlign="Center" VerticalAlign="Bottom" Wrap="True" />
            </asp:GridView>

            <div style="height: 20px" align="center">
                <br />
            </div>
        <table class="auto-style1" style="width: 1000px" align="center">
            <tr>
                <td class="auto-style8" colspan="7" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; font-size: 14px; font-family: Verdana; background-color: #C6C3C6;">TOTALIZADOR</td>
            </tr>
            <tr>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Tipo</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Transação</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Autorizado</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Negado</td>
                <td class="auto-style24" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Em Estudo</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Total Geral</td>
                <td class="auto-style8" style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; text-align: center; font-weight: bold; background-color: #C6C3C6; font-size: 14px; font-family: Verdana;">Vlr. Total</td>
            </tr>
            <tr>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTipo" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalTransacao" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalAutorizado" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalNegado" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;" class="auto-style25">
                    <asp:Label ID="lblTotalEmEstudo" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalTotalGeral" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblVlrTotal" runat="server" BorderStyle="Outset" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTipo0" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalTransacao0" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalAutorizado0" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalNegado0" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;" class="auto-style25">
                    <asp:Label ID="lblTotalEmEstudo0" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblTotalTotalGeral0" runat="server"></asp:Label>
                </td>
                <td style="border-style: solid; border-width: thin; border-color: #D6CFD6; padding: 1px; margin: 1px; font-size: 14px; font-family: Verdana; text-align: center;">
                    <asp:Label ID="lblVlrTotal0" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style21" style="text-align: right; color: #31A6FF; font-weight: bold; font-family: Verdana;">&nbsp;<asp:ImageButton ID="imgbtnVoltar" runat="server" Height="20px" ImageUrl="~/Imagens/bt_voltar.png" OnClick="imgbtnVoltar_Click" Width="35px" />
&nbsp;<asp:LinkButton ID="lnkVoltar" runat="server" Font-Overline="False" ForeColor="#31A6FF" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagens/print_edit.gif" OnClick="ImageButton1_Click" />
                    &nbsp;<asp:LinkButton ID="lnkImprimir" runat="server" Font-Overline="False" ForeColor="#31A6FF" OnClick="lnkImprimir_Click">Imprimir</asp:LinkButton>
&nbsp; </td>
            </tr>
        </table>
                    </div>
    </form>
</body>
</html>
