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

        public void DepSac()
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

                    select Id_conta 
                  , sum(if (Tipo = 'D' or tipo = 'E', Valor,-Valor)) as cSumSaldo  
                    from tbconta 
                    where Data_mov = (@dt1) 
                    group by Id_conta 
                    order by Id_conta 
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

        /*public void Depositar()
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
                command.CommandText = "UPDATE tbconta SET saldo = (saldo + @valorSacado) WHERE id_conta = @id ;" + 
                    "INSERT IGNORE INTO tbconta (id_conta, saldo) VALUES (@id, @valorSacado);";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@valorSacado", MySqlDbType.Double).Value = saldo;

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
        }*/

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
                command.CommandText = @"
                
                select Id_conta 
              , sum(if (tipo = 'D' or tipo = 'E', valor,-valor)) as cSumSaldo  
                from tbconta 
                where Data_mov = (@dt1) 
                group by Id_conta 
                order by Id_conta 
                ";

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
