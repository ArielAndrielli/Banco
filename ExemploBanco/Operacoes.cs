using MySql.Data.MySqlClient;
using System;

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

        #endregion

        #region Métodos

        public void Extrato()
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
                command.CommandText = @"

                    SELECT Id_conta,
                    SUM(if (Tipo = 'D' or tipo = 'E', Valor,-Valor)) AS cSumSaldo 
                    FROM tbconta 
                    WHERE Data_mov = (@dt1) 
                    GROUP BY Id_conta 
                    ORDER BY Id_conta 
                    ;";

                command.Parameters.Add("@dt1", MySqlDbType.DateTime).Value = data_mov;

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

        public void D()
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
                command.CommandText = @"INSERT INTO tbconta (Id_conta, Aux_conta, Tipo, Valor, Aux_valor, Data_mov)
                                        VALUES(null, @aux_c, @tipo, @valor, @valor, @data);";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id_conta;
                command.Parameters.Add("@aux_c", MySqlDbType.VarChar).Value = aux_conta;
                command.Parameters.Add("@valor", MySqlDbType.Double).Value = valor;
                command.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = tipo = "D";
                //command.Parameters.Add("@aux_valor", MySqlDbType.Double).Value = aux_valor;s
                command.Parameters.Add("@data", MySqlDbType.DateTime).Value = data_mov = DateTime.Now;

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

        public void S()
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
                command.CommandText = @"INSERT INTO tbconta (Id_conta, Aux_conta, Tipo, Valor, Aux_valor, Data_mov) 
                                        VALUES(null, @aux_c, @tipo, @valor, @valor, @data;";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id_conta;
                command.Parameters.Add("@aux_c", MySqlDbType.VarChar).Value = aux_conta;
                command.Parameters.Add("@valor", MySqlDbType.Double).Value = valor;
                command.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = tipo = "E";
                //command.Parameters.Add("@aux_valor", MySqlDbType.Double).Value = aux_valor;s
                command.Parameters.Add("@data", MySqlDbType.DateTime).Value = data_mov = DateTime.Now;

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


        //Arrumar Transferência
        public void Transferir()
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
                command.CommandText = @"";

                command.Parameters.Add("@dt1", MySqlDbType.DateTime);

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

        public void Selecionar(int pId)
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
                command.CommandText = "SELECT Nome FROM tblogin WHERE Id = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    aux_conta = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i); i++;
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
        }

        #endregion
    }
}
