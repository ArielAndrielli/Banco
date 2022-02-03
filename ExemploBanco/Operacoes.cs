using Banco;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ExemploBanco
{
    class Operacoes
    {
        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        #endregion

        #region Propriedades

        public bool HasError { get; set; } = false;

        public string MsgError { get; set; } = string.Empty;

        public int id_conta{ get; set; } = 0;

        public string aux_conta { get; set; } = string.Empty;

        public string tipo { get; set; } = string.Empty;

        public double valor { get; set; } = 0;

        public double aux_valor { get; set; } = 0;

        public DateTime data_mov { get; set; }

        public string desc { get; set; }

        #endregion

        #region Métodos

        public double Extrato(int id)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader dataReader;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = @"

                    SELECT Id_conta,
                    SUM(if (Tipo = 'C' or tipo = 'D', Valor,-Valor)) AS cSumSaldo 
                    FROM tbconta 
                    WHERE Id_conta = @id 
                    GROUP BY Id_conta 
                    ORDER BY Id_conta 
                    ;";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id_conta;

                command.ExecuteNonQuery();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 1;

                    valor = dataReader.IsDBNull(i) ? 0 : dataReader.GetDouble(i);
                }
                else
                {
                    valor = 0;
                }

            }

            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
            return valor;
        }

        public double Saldo(int id)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader dataReader;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = @"

                    SELECT
                    SUM(if (Tipo = 'C' or Tipo = 'D', Valor, -Valor)) AS cSumSaldo 
                    FROM tbconta 
                    WHERE Id_conta = @id 
                    GROUP BY Id_conta 
                    ORDER BY Id_conta 
                    ;";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                command.ExecuteNonQuery();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    valor = dataReader.IsDBNull(i) ? 0 : dataReader.GetDouble(i);
                }
                else
                {
                    valor = 0;
                }

            }

            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
            return valor;
        }

        public void Incluir()
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO tbconta (Id_conta, Tipo, Valor, Aux_valor, Data_mov, Descricao)
                                        VALUES(@id, @tipo, @valor, @valor, @data, @desc);";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id_conta;
              //command.Parameters.Add("@aux_c", MySqlDbType.VarChar).Value = aux_conta = MostrarNome(id_conta);
                command.Parameters.Add("@valor", MySqlDbType.Double).Value = valor;
                command.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = tipo;
                command.Parameters.Add("@aux_valor", MySqlDbType.Double).Value = aux_valor;
                command.Parameters.Add("@data", MySqlDbType.DateTime).Value = data_mov = DateTime.Now;
                command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
        }


        public string MostrarNome(int pId)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader dataReader = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT Nome FROM tblogin WHERE Id = @id;";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    aux_conta = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i);
                }
                else
                {
                    aux_conta = string.Empty;
                }

            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
            return aux_conta;
        }

        public double MostrarSaldo(int id)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader dataReader = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT saldo FROM tbconta WHERE Id_conta = @id;";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    valor = dataReader.IsDBNull(i) ? 0 : dataReader.GetDouble(i);
                }
                else
                {
                    valor = 0;
                }

            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
            return valor;
        }

        public DataTable ListarExtrato(int pId)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = @"SELECT tbconta.Id, tbconta.Id_conta, tblogin.Nome, tbconta.Tipo, 
                                        tbconta.Valor, tbconta.Aux_valor, tbconta.Data_mov, tbconta.Descricao
                                        FROM tbconta
                                        INNER JOIN tblogin ON tblogin.Id = tbconta.Id_conta
                                        WHERE tbconta.Id_conta = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = pId;

                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }

            return result;
        }

        #endregion
    }
}
