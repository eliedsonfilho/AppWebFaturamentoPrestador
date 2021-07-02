using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public class Repositorio
    {

        #region Atributos

        private string _connectionString = @"Data Source=192.168.0.127;Initial Catalog=Cardio;Persist Security Info=True;User ID=sa;Password=uni40853vsf!";

        private SqlConnection _connection;
        
        #endregion

        public Repositorio()
        {
            _connection = new SqlConnection(_connectionString);
        }

        #region Metodos
        public SqlConnection AbrirConexao()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                else
                {
                    _connection.Close();
                    _connection.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return _connection;
        }

        public void FecharConexao()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao Obter Conexão" + exception.Message);
            }
        }

        public SqlDataReader ExecutarConsulta(SqlCommand command)
        {
            SqlDataReader dataReader = null;
            try
            {
                command.Connection = AbrirConexao();
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                FecharConexao();
                throw new Exception(exception.Message);
            }

            return dataReader;
        }
        #endregion

        #region Consultas
        public DataTable GerarRelatorio()
        {
            DataTable retorno = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            StringBuilder query = new StringBuilder();

            query.Append(@"");

            SqlCommand cmd = new SqlCommand(query.ToString());

            //Executando a pesquisa
            try
            {
                retorno = new DataTable();
                reader = ExecutarConsulta(cmd);
                retorno.Load(reader);
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        #endregion



    }
}
