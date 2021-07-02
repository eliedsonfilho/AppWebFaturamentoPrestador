using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dados;


namespace Repositorio
{
    public class Repositorio
    {

        #region Atributos

        private string _connectionStringCardio = @"Data Source=192.168.0.127;Initial Catalog=Cardio;Persist Security Info=True;User ID=sa;Password=uni40853vsf!";
        private string _connectionStringHilum = @"Data Source=192.168.0.127;Initial Catalog=Hilum;Persist Security Info=True;User ID=sa;Password=uni40853vsf!";


        private SqlConnection _connectionCardio;
        private SqlConnection _connectionHilum;
        
        #endregion

        public Repositorio()
        {
            _connectionCardio = new SqlConnection(_connectionStringCardio);
            _connectionHilum = new SqlConnection(_connectionStringHilum);
        }

        #region Metodos Conexao Cardio
        public SqlConnection AbrirConexaoCardio()
        {
            try
            {
                if (_connectionCardio.State == ConnectionState.Closed)
                {
                    _connectionCardio.Open();
                }
                else
                {
                    _connectionCardio.Close();
                    _connectionCardio.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return _connectionCardio;
        }

        public void FecharConexaoCardio()
        {
            try
            {
                if (_connectionCardio.State == ConnectionState.Open)
                {
                    _connectionCardio.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao Obter Conexão Cardio" + exception.Message);
            }
        }

        public SqlDataReader ExecutarConsultaCardio(SqlCommand command)
        {
            SqlDataReader dataReader = null;
            try
            {
                command.Connection = AbrirConexaoCardio();
                command.CommandTimeout = 0;
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                FecharConexaoCardio();
                throw new Exception(exception.Message);
            }

            return dataReader;
        }
        #endregion
        
        #region Metodos Conexao Hilum
        public SqlConnection AbrirConexaoHilum()
        {
            try
            {
                if (_connectionHilum.State == ConnectionState.Closed)
                {
                    _connectionHilum.Open();
                }
                else
                {
                    _connectionHilum.Close();
                    _connectionHilum.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return _connectionHilum;
        }

        public void FecharConexaoHilum()
        {
            try
            {
                if (_connectionCardio.State == ConnectionState.Open)
                {
                    _connectionCardio.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao Obter Conexão Cardio" + exception.Message);
            }
        }

        public SqlDataReader ExecutarConsultaHilum(SqlCommand command)
        {
            SqlDataReader dataReader = null;
            try
            {
                command.Connection = AbrirConexaoHilum();
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                FecharConexaoHilum();
                throw new Exception(exception.Message);
            }

            return dataReader;
        }
        #endregion

        #region Consultas
        public DataTable ValidaLogin(string Login, string Senha)
        {
            DataTable retorno = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            StringBuilder query = new StringBuilder();

            query.Append(@"SELECT TOP 1 * FROM users
                           WHERE users.login = @Login 
                           AND users.password = @Senha");

            SqlCommand cmd = new SqlCommand(query.ToString());

            SqlParameter parametroLogin = new SqlParameter("@Login", Login);
            SqlParameter parametroSenha = new SqlParameter("@Senha", Senha);

            cmd.Parameters.Add(parametroLogin);
            cmd.Parameters.Add(parametroSenha);


            //Executando a pesquisa
            try
            {
                retorno = new DataTable();
                reader = ExecutarConsultaHilum(cmd);
                retorno.Load(reader);
                reader.Close();
            }
            catch (Exception)
            {
                throw new Exception("Login ou senha invalido!");
            }

            return retorno;
        }

        public Dados.Login ObterLogin(string Login)
        {
            Dados.Login login = new Dados.Login();
            SqlCommand command = new SqlCommand();
            SqlDataReader retorno = null;
            StringBuilder query = new StringBuilder();

            query.Append(@"SELECT TOP 1 
                                id, 
                                login, 
                                name, 
                                '', 
                                password, 
                                oldPassword, 
                                tipoAcesso, 
                                blockedaccess  
                            FROM users
                            WHERE users.login = @Login");

            SqlCommand cmd = new SqlCommand(query.ToString());

            SqlParameter parametroLogin = new SqlParameter("@Login", Login);

            cmd.Parameters.Add(parametroLogin);

            //Executando a pesquisa
            try
            {   
                retorno = ExecutarConsultaHilum(cmd);
                
                while (retorno.Read())
                {
                 login.Id = retorno[0].ToString();
                 login.LoginHilum = retorno[1].ToString();
                 login.Nome = retorno[2].ToString();
                 login.Sobrenome = retorno[3].ToString();
                 login.SenhaAtual = retorno[4].ToString();
                 login.SenhaAnterior = retorno[5].ToString();
                 login.TipoAcesso = retorno[6].ToString();
                 login.AcessoBloqueado = retorno[7].ToString();

                }

                retorno.Close();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter Login");
            }

            return login;
        }

        public IList<Dados.PrestadorLogin> ObterPrestadorLogin(string Login)
        {
            IList<Dados.PrestadorLogin> listaObjetosPesquisados = new List<Dados.PrestadorLogin>();
            
            SqlCommand command = new SqlCommand();
            SqlDataReader retorno = null;
            StringBuilder query = new StringBuilder();

//            query.Append(@"SELECT  
//                        prestador.id, 
//                        CONVERT(VARCHAR, prestador.codigo) + CONVERT(VARCHAR, prestador.digitoVerificador) AS Codigo, 
//                        prestador.tipo,
//                        prestador.nome, 
//                        prestador.siglaUFconselho, 
//                        prestador.siglaConselho, 
//                        prestador.numeroConselho, 
//                        prestador.ativo,
//                        CASE prestadorlogin.emitirUtilizacoes WHEN 1 THEN '1' ELSE 0 END AS ExibeUtilizacao,
//                        prestador.nome + ' (' + CONVERT(VARCHAR, prestador.codigo) + CONVERT(VARCHAR, prestador.digitoVerificador) + ')' As NomeCodigo  
//                        FROM            prestadorlogin INNER JOIN
//                                                    prestador ON prestadorlogin.prestador_id = prestador.id INNER JOIN
//                                                    users ON prestadorlogin.user_id = users.id
//                        WHERE (prestador.ativo = 1) AND
//                        (prestador.tipo <> 9) AND
//                        (users.login = @loginhilum)
//
//                        UNION
//
//                        SELECT '', '0', '', '', '', '', '', '', '', ''
//
//                        ORDER BY  prestador.nome
//                        ");
            query.Append(@"SELECT  
                        prestador.id, 
                        CONVERT(VARCHAR, prestador.codigo) + CASE WHEN CONVERT(VARCHAR,prestador.digitoVerificador) IS NULL THEN '' ELSE CONVERT(VARCHAR,prestador.digitoVerificador) END AS Codigo, 
                        prestador.tipo,
                        prestador.nome, 
                        prestador.siglaUFconselho, 
                        prestador.siglaConselho, 
                        prestador.numeroConselho, 
                        prestador.ativo,
                        CASE prestadorlogin.emitirUtilizacoes WHEN 1 THEN '1' ELSE 0 END AS ExibeUtilizacao,
                        prestador.nome + ' (' + CONVERT(VARCHAR, prestador.codigo) + CASE WHEN CONVERT(VARCHAR, prestador.digitoVerificador) IS NULL THEN '' ELSE CONVERT(VARCHAR, prestador.digitoVerificador) END  + ')' As NomeCodigo  
                        FROM            prestadorlogin INNER JOIN
                                                    prestador ON prestadorlogin.prestador_id = prestador.id INNER JOIN
                                                    users ON prestadorlogin.user_id = users.id
                        WHERE (prestador.ativo = 1) AND
                        (prestador.tipo <> 9) AND
                        (users.login = @loginhilum)

                        UNION

                        SELECT '', '0', '', '', '', '', '', '', '', ''

                        ORDER BY  prestador.nome");

            SqlCommand cmd = new SqlCommand(query.ToString());

            SqlParameter parametroLogin = new SqlParameter("@loginhilum", Login);

            cmd.Parameters.Add(parametroLogin);

            //Executando a pesquisa
            try
            {
                retorno = ExecutarConsultaHilum(cmd);

                while (retorno.Read())
                {
                    Dados.PrestadorLogin prestadorLogin = new Dados.PrestadorLogin();
                    prestadorLogin.Id = retorno[0].ToString();
                    prestadorLogin.Codigo = retorno[1].ToString();
                    prestadorLogin.Tipo = retorno[2].ToString();
                    prestadorLogin.Nome = retorno[3].ToString();
                    prestadorLogin.ConselhoUf = retorno[4].ToString();
                    prestadorLogin.ConselhoSigla = retorno[5].ToString();
                    prestadorLogin.ConselhoNumero = retorno[6].ToString();
                    prestadorLogin.Ativo = retorno[7].ToString();
                    prestadorLogin.EmitirUtilizacao = retorno[8].ToString();
                    prestadorLogin.NomeCodigo = retorno[9].ToString();

                    if ((prestadorLogin.Id == "0") || (prestadorLogin.Id == "419"))
                    {
                        int i;
                    }
                    listaObjetosPesquisados.Add(prestadorLogin);
                }
                

                retorno.Close();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter PrestadorLogin");
            }

            return listaObjetosPesquisados;
        }

        public IList<Dados.Transacao> ObterTransacoes(string login, string codPrestador, string dtInicial, string dtFinal, string tpAtendimento, string situacao, string chkBio, string tpBenef, string exibeUtil)
        {
            IList<Dados.Transacao> listaObjetosPesquisados = new List<Dados.Transacao>();

            SqlDataReader retorno;
            StringBuilder query = new StringBuilder();

       //     query.Append(@"

       //                     SELECT DISTINCT
       //                     CONVERT(VARCHAR, SolicitacaoServico.DataSolicitacao, 3) Data,         
       //                     SolicitacaoServico.Codigo Autorizacao,
       //                     (CASE SolicitacaoServico.GrupoApro WHEN 1 THEN 'Consulta' WHEN 2 THEN 'SADT' WHEN 5 THEN 'Internacao' END) AS Tipo,
       //                     SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 1, 4) +'.'+
       //                     SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 5, 12)+'-'+
       //                     SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 17, 1) AS CodBenef,
       //                     Pessoa.Nome AS NomeBenef, 
       //                     (CASE SolicitacaoServico.ValidouBiometria WHEN 1 THEN 'S' ELSE 'N' END) AS ValidouBiometria ,
       //                     (CASE WHEN ((SolicitacaoServico.Parecer = 1) AND (SolicitacaoServico.Situacao = 7)) THEN 'Aut.' ELSE 
       //                     CASE WHEN ((SolicitacaoServico.Parecer = 2) AND (SolicitacaoServico.Situacao = 7)) THEN 'Neg.' ELSE
       //                     CASE WHEN ((SolicitacaoServico.Parecer IS NULL) AND (SolicitacaoServico.Situacao <> 7)) THEN 'Est.' END END END) AS Situacao,
       //                     SolicitacaoServico.Atendente LoginHilum,
       //                     CASE WHEN VSF_GRUPO_MODELO.Grupo = 'LIXO' THEN '' ELSE VSF_GRUPO_MODELO.Grupo END AS Plano
							//FROM            SolicitacaoServico WITH (NOLOCK) INNER JOIN
							//				 Beneficiario WITH (NOLOCK)  ON SolicitacaoServico.Beneficiario = Beneficiario.AutoId INNER JOIN
							//				 PrestadorServico WITH (NOLOCK) ON SolicitacaoServico.EncPrestador = PrestadorServico.AutoId INNER JOIN
							//				 Pessoa WITH (NOLOCK) ON Beneficiario.Pessoa = Pessoa.AutoId INNER JOIN
							//				 Contrato WITH (NOLOCK) ON Contrato.AutoId = Beneficiario.Contrato INNER JOIN
							//				 VSF_GRUPO_MODELO WITH (NOLOCK) ON Contrato.Modelo = VSF_GRUPO_MODELO.AutoId INNER JOIN
							//				 ItemSolServico WITH (NOLOCK) ON SolicitacaoServico.AutoId = ItemSolServico.Solicitacao LEFT OUTER JOIN
							//				 PrestadorServico AS PrestadorItem WITH (NOLOCK) ON ItemSolServico.Executante = PrestadorItem.AutoId
       //                     WHERE (SolicitacaoServico.DataParecer BETWEEN '" + dtInicial + "' AND '" + dtFinal + "')" + @"
       //                     AND (SolicitacaoServico.CanalSolicitacao = 90)
       //                     AND ((SELECT PrestadorServico.AutoId 
       //                                         FROM  PrestadorServico WITH (NOLOCK) INNER JOIN
       //                                             ClassePrestador WITH (NOLOCK) ON PrestadorServico.Classe = ClassePrestador.Codigo
       //                                         WHERE (convert(int,(SUBSTRING(CONVERT(varchar, PrestadorServico.Codigo), 4, 9)) 
       //                                         --+ REPLICATE('0',(9 - LEN(CAST((SUBSTRING(CONVERT(varchar, PrestadorServico.Codigo), 4, 9)) AS VARCHAR))))) = 
       //                                         )='" + codPrestador + @"')
       //                                             AND (ClassePrestador.Codigo NOT IN (10, 5)) AND (PrestadorServico.CodigoReduzido IS NOT NULL)) = ISNULL(PrestadorItem.AutoId, PrestadorServico.AutoId))
       //                     AND (SolicitacaoServico.Atendente IN (
			    //                                                    SELECT Hilum.dbo.users.login FROM Hilum.dbo.users WITH (NOLOCK) 
			    //                                                    WHERE Hilum.dbo.users.login LIKE CASE WHEN " + exibeUtil + @" = '1' THEN '%' ELSE '" + login + @"' END))
       //                     AND (CONVERT(VARCHAR, SolicitacaoServico.GrupoApro) LIKE (CASE WHEN '" + tpAtendimento + @"' = 9 THEN '%' ELSE CONVERT(VARCHAR, '" + tpAtendimento + @"') END))
       //                     AND (SolicitacaoServico.Situacao <> 8) -- Cancelado
       //                     AND '" + situacao + @"' = (CASE WHEN '" + situacao + @"' = 'T' THEN 'T' ELSE
       //                                      CASE WHEN ((SolicitacaoServico.Parecer = 1) AND (SolicitacaoServico.Situacao = 7)) 
							//				 AND ((ItemSolServico.ParecerAuditoria = 1) AND (ItemSolServico.SituacaoAuditoria = 7) AND (ItemSolServico.QteAutorizada > 0)) THEN 'A' ELSE 
       //                                      CASE WHEN ((SolicitacaoServico.Parecer = 2) AND (SolicitacaoServico.Situacao = 7)) THEN 'N' ELSE
       //                                      CASE WHEN ((SolicitacaoServico.Parecer IS NULL) AND (SolicitacaoServico.Situacao <> 7)) THEN 'E' 
       //                                      END END END END) 
       //                     AND ('" + chkBio + @"' = (CASE WHEN SolicitacaoServico.ValidouBiometria  = 0 THEN 'N' ELSE 'S' END))
       //                     AND ('" + tpBenef + @"' = CASE WHEN Beneficiario.Codigo LIKE '210%' AND LEN(Beneficiario.Codigo)= 16 THEN 'L' ELSE 'I' END)
       //                     ORDER BY 2, 1

       //       ");

            SqlCommand sqlCommand = new SqlCommand("ConsultaSolicitacoesPrestador_Prestador");

            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parCodPrest = new SqlParameter("@CodPrestador",codPrestador);
            SqlParameter parDtIni = new SqlParameter("@DataInicio", dtInicial);
            SqlParameter parDtFim = new SqlParameter("@DataFim", dtFinal);
            SqlParameter parchkBio = new SqlParameter("@ValidouBio", chkBio);
            SqlParameter partpBenef = new SqlParameter("@TpBenef", tpBenef);
            SqlParameter partpAtendimento = new SqlParameter("@TpAtendimento", tpAtendimento);
            SqlParameter parsituacao = new SqlParameter("@Situacao", situacao);
            SqlParameter parlogin = new SqlParameter("@Login", login);
            SqlParameter parexibeUtil = new SqlParameter("@ExibeTodaUtil", exibeUtil);
            sqlCommand.Parameters.Add(parCodPrest);
            sqlCommand.Parameters.Add(parDtIni);
            sqlCommand.Parameters.Add(parDtFim);
            sqlCommand.Parameters.Add(parchkBio);
            sqlCommand.Parameters.Add(partpBenef);
            sqlCommand.Parameters.Add(partpAtendimento);
            sqlCommand.Parameters.Add(parsituacao);
            sqlCommand.Parameters.Add(parlogin);
            sqlCommand.Parameters.Add(parexibeUtil);

                                           

            //Executando a pesquisa
            try
            {
                retorno = ExecutarConsultaCardio(sqlCommand);
                //retorno = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (retorno.HasRows)
                {
                    while (retorno.Read())
                    {
                        Transacao transacao = new Transacao();
                        transacao.Data = retorno[0].ToString();
                        transacao.Autorizacao = retorno[1].ToString();
                        transacao.Tipo = retorno[2].ToString();
                        transacao.CodBenef = retorno[3].ToString();
                        transacao.NomeBenef = retorno[4].ToString();
                        transacao.ValidouBiometria = retorno[5].ToString();
                        transacao.Situacao = retorno[6].ToString();
                        transacao.LoginHilum = retorno[7].ToString();
                        transacao.Tipoplano = retorno[8].ToString();
                        transacao.ValorAtendimento = decimal.Parse(retorno[9].ToString());

                        listaObjetosPesquisados.Add(transacao);
                    }                    
                }
                else
                {
                    listaObjetosPesquisados = null;
                }

                retorno.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter Transacao");                
            }

            return listaObjetosPesquisados;
        }

        public IList<Dados.Execucao> ObterExecucoes(string login, string codPrestador, string dtInicial, string dtFinal, string tpAtendimento, string situacao, string chkBio, string tpBenef, string exibeUtil)
        {
            IList<Dados.Execucao> listaObjetosPesquisados = new List<Dados.Execucao>();

            SqlDataReader retorno;
            StringBuilder query = new StringBuilder();

            //query.Append(@"

            //                SELECT  
            //                CONVERT(VARCHAR, Evento.DataAbertura, 3) /*+' '+ SUBSTRING(CONVERT(VARCHAR, Evento.DataAbertura, 14),1,5)*/  dataExecucao , 
            //                SolicitacaoServico.Codigo autorizacao, 
            //                (CASE Evento.GrupoApro WHEN 1 THEN 'Consulta' WHEN 2 THEN 'SADT' WHEN 5 THEN 'Internacao' END) AS Tipo, 
            //                SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 1, 4) +'.'+
            //                SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 5, 12)+'-'+
            //                SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 17, 1) AS CodBenef,
            //                Pessoa.Nome AS nomeBenef,
            //                --Hilum.dbo.transacao.usoubiometria,
            //                CASE WHEN Hilum.dbo.transacao.usoubiometria = 1 THEN 'S' ELSE 'N' END usoubiometria,
            //                ServicoOperadora.Codigo CodigoServico, 
            //                SUBSTRING(ServicoOperadora.Nome,1,35) + '...'  DescricaoServico, 
            //                CONVERT(INT, ExecItemSolParticip.QteExecutada) QteExecutada,
            //                (CASE WHEN ((ItemEvento.ParecerAuditoria = 0) AND (ItemEvento.Concluido = 0)) THEN 'Aut.' ELSE 
            //                CASE WHEN ((ItemEvento.ParecerAuditoria = 1) AND (ItemEvento.Concluido = 0)) THEN 'Neg.' END END) SituacaoExecucao, 
            //                Evento.Atendente LoginHilum,
            //                CASE WHEN VSF_GRUPO_MODELO.Grupo = 'LIXO' THEN '' ELSE VSF_GRUPO_MODELO.Grupo END AS Plano,
            //                SUM(CAST(ISNULL(CompVlItemEvento.TotalPago,0) AS DECIMAL(18,2))) ValorServico

            //                --Evento.* 
            //                FROM            Evento  WITH (NOLOCK)  INNER JOIN
            //                                         ItemEvento  WITH (NOLOCK)  ON Evento.AutoId = ItemEvento.Evento INNER JOIN
            //                                         CompVlItemEvento WITH (NOLOCK)  ON ItemEvento.AutoId = CompVlItemEvento.ItemEvento INNER JOIN
            //                                         LoteDocServico  WITH (NOLOCK)  ON Evento.Lote = LoteDocServico.AutoId INNER JOIN
            //                                         ServicoOperadora  WITH (NOLOCK)  ON ItemEvento.Servico = ServicoOperadora.AutoId INNER JOIN
            //                                         PrestadorServico  WITH (NOLOCK)  ON CompVlItemEvento.Prestador = PrestadorServico.AutoId INNER JOIN
            //                                         SolicitacaoServico  WITH (NOLOCK)  ON Evento.Solicitacao = SolicitacaoServico.AutoId INNER JOIN
            //                                         Beneficiario  WITH (NOLOCK)  ON Evento.Beneficiario = Beneficiario.AutoId INNER JOIN
            //                                         Pessoa  WITH (NOLOCK)  ON Beneficiario.Pessoa = Pessoa.AutoId INNER JOIN
						      //                       Contrato  WITH (NOLOCK)  ON Beneficiario.Contrato = Contrato.AutoId INNER JOIN
						      //                       VSF_GRUPO_MODELO  WITH (NOLOCK)  ON Contrato.Modelo = VSF_GRUPO_MODELO.AutoId INNER JOIN
						      //                       ExecItemSolParticip  WITH (NOLOCK)  ON ItemEvento.AutoId = ExecItemSolParticip.ItemEvento INNER JOIN
						      //                       Hilum.dbo.transacao  WITH (NOLOCK)  ON ItemEvento.CodigoDocumento = Hilum.dbo.transacao.nrTransReq AND Hilum.dbo.transacao.numRequisicao = SolicitacaoServico.codigo
						 
            //                WHERE --(LoteDocServico.Provisorio = 1) AND
            //                    --(Hilum.dbo.transacao.PrestExec_Id IS NOT NULL) AND
            //                    (Evento.Cancelado = 0)
            //                AND (Evento.DataAbertura BETWEEN  '" + dtInicial + "' AND '" + dtFinal + "')" + @"
            //                AND (PrestadorServico.AutoId = (SELECT PrestadorServico.AutoId 
            //                                    FROM  PrestadorServico  WITH (NOLOCK)  INNER JOIN
            //                                        ClassePrestador  WITH (NOLOCK)  ON PrestadorServico.Classe = ClassePrestador.Codigo
            //                                    WHERE (convert(int,(SUBSTRING(CONVERT(varchar, PrestadorServico.Codigo), 4, 9)) 
            //                                    )='" + codPrestador + @"') 
					       //                     AND (ClassePrestador.Codigo NOT IN (10, 5)) AND (PrestadorServico.CodigoReduzido IS NOT NULL)))
            //                AND (Evento.Atendente IN (SELECT Hilum.dbo.users.login FROM Hilum.dbo.users 
			         //                                 WHERE Hilum.dbo.users.login LIKE CASE WHEN " + exibeUtil + @" = '1' THEN '%' ELSE '" + login + @"' END))
            //                AND (CONVERT(VARCHAR, Evento.GrupoApro) LIKE (CASE WHEN '" + tpAtendimento + @"' = 9 THEN '%' ELSE CONVERT(VARCHAR, '" + tpAtendimento + @"') END))
            //                AND ('" + situacao + @"' = (CASE WHEN ((ItemEvento.ParecerAuditoria = 0) AND (ItemEvento.Concluido = 0)) THEN 'A' ELSE 
							     //                       CASE WHEN ((ItemEvento.ParecerAuditoria = 1) AND (ItemEvento.Concluido = 0)) THEN 'N' END END)) 
            //                AND ('" + chkBio + @"' = (CASE WHEN Hilum.dbo.transacao.usoubiometria  = 1 THEN 'S' ELSE 'N' END))
            //                AND ('" + tpBenef + @"'= CASE WHEN Beneficiario.Codigo LIKE '210%' AND LEN(Beneficiario.Codigo)= 16 THEN 'L' ELSE 'I' END)
                            
            //                GROUP BY 
                            
            //                CONVERT(VARCHAR, Evento.DataAbertura, 3) /*+' '+ SUBSTRING(CONVERT(VARCHAR, Evento.DataAbertura, 14),1,5)*/, 
            //                SolicitacaoServico.Codigo, 
            //                (CASE Evento.GrupoApro WHEN 1 THEN 'Consulta' WHEN 2 THEN 'SADT' WHEN 5 THEN 'Internacao' END), 
            //                SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 1, 4) +'.'+
            //                SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 5, 12)+'-'+
            //                SUBSTRING(REPLICATE('0',(17 - LEN(CONVERT(VARCHAR, Beneficiario.Codigo))))+CONVERT(VARCHAR, Beneficiario.Codigo), 17, 1),
            //                Pessoa.Nome,
            //                --Hilum.dbo.transacao.usoubiometria,
            //                CASE WHEN Hilum.dbo.transacao.usoubiometria = 1 THEN 'S' ELSE 'N' END,
            //                ServicoOperadora.Codigo, 
            //                SUBSTRING(ServicoOperadora.Nome,1,35) + '...', 
            //                CONVERT(INT, ExecItemSolParticip.QteExecutada),
            //                (CASE WHEN ((ItemEvento.ParecerAuditoria = 0) AND (ItemEvento.Concluido = 0)) THEN 'Aut.' ELSE 
            //                CASE WHEN ((ItemEvento.ParecerAuditoria = 1) AND (ItemEvento.Concluido = 0)) THEN 'Neg.' END END), 
            //                Evento.Atendente,
            //                CASE WHEN VSF_GRUPO_MODELO.Grupo = 'LIXO' THEN '' ELSE VSF_GRUPO_MODELO.Grupo END

            //                order by 2, 1


            //  ");



            SqlCommand sqlCommand = new SqlCommand("ConsultaExecucoesPrestador_Prestador");

            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parCodPrest = new SqlParameter("@CodPrestador", codPrestador);
            SqlParameter parDtIni = new SqlParameter("@DataInicio", dtInicial);
            SqlParameter parDtFim = new SqlParameter("@DataFim", dtFinal);
            SqlParameter parchkBio = new SqlParameter("@ValidouBio", chkBio);
            SqlParameter partpBenef = new SqlParameter("@TpBenef", tpBenef);
            SqlParameter partpAtendimento = new SqlParameter("@TpAtendimento", tpAtendimento);
            SqlParameter parsituacao = new SqlParameter("@Situacao", situacao);
            SqlParameter parlogin = new SqlParameter("@Login", login);
            SqlParameter parexibeUtil = new SqlParameter("@ExibeTodaUtil", exibeUtil);
            sqlCommand.Parameters.Add(parCodPrest);
            sqlCommand.Parameters.Add(parDtIni);
            sqlCommand.Parameters.Add(parDtFim);
            sqlCommand.Parameters.Add(parchkBio);
            sqlCommand.Parameters.Add(partpBenef);
            sqlCommand.Parameters.Add(partpAtendimento);
            sqlCommand.Parameters.Add(parsituacao);
            sqlCommand.Parameters.Add(parlogin);
            sqlCommand.Parameters.Add(parexibeUtil);


            //Executando a pesquisa
            try
            {
                retorno = ExecutarConsultaCardio(sqlCommand);
                if (retorno.HasRows)
                {
                    while (retorno.Read())
                    {
                        Execucao execucao = new Execucao();
                        execucao.DataExecucao = retorno[0].ToString();
                        execucao.Autorizacao = retorno[1].ToString();
                        execucao.Tipo = retorno[2].ToString();
                        execucao.CodBenef = retorno[3].ToString();
                        execucao.NomeBenef = retorno[4].ToString();
                        execucao.ValidouBiometria = retorno[5].ToString();
                        execucao.CodigoServico = retorno[6].ToString();
                        execucao.DescricaoServico = retorno[7].ToString();
                        execucao.QteExecutada = retorno[8].ToString();
                        execucao.SituacaoExecucao = retorno[9].ToString();
                        execucao.LoginHilum = retorno[10].ToString();
                        execucao.Tipoplano = retorno[11].ToString();
                        execucao.ValorAtendimento = decimal.Parse(retorno[12].ToString());

                        listaObjetosPesquisados.Add(execucao);
                    }
                }
                else
                {
                    listaObjetosPesquisados = null;
                }

                retorno.Close();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter Execuções");
            }

            return listaObjetosPesquisados;
        }


        public string RetornaSaltLoginHilum(string login)
        {
            SqlDataReader retorno = null;
            StringBuilder query = new StringBuilder();
            string retornoSalt = String.Empty;

            query.Append(@"SELECT passwordsalt 
                            FROM users
                            WHERE login = @Login");

            SqlCommand cmd = new SqlCommand(query.ToString());

            SqlParameter parametroLogin = new SqlParameter("@Login", login);

            cmd.Parameters.Add(parametroLogin);

            //Executando a pesquisa
            try
            {
                retorno = ExecutarConsultaHilum(cmd);

                while (retorno.Read())
                {
                    retornoSalt = retorno[0].ToString();
                }

                retorno.Close();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter Login");
            }

            return retornoSalt;

        }

        #endregion



    }
}
