using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int id { get; set; } = 0;

        public int id_dest { get; set; } = 0;

        public string nome { get; set; } = string.Empty;

        public double saldo { get; set; } = 0;

        public double saque { get; set; } = 0;

        #endregion

        #region Métodos

        public void Sacar()
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
                command.CommandText = "UPDATE tbconta SET saldo = (saldo - @valorSacado) WHERE id_conta = @id ;";

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
        }

        public void Depositar()
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
        }

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
                command.CommandText = "UPDATE tbconta SET saldo = (saldo - @valorTransferido) WHERE id_conta = @id_remetente;";
                command.CommandText += "UPDATE tbconta SET saldo = (saldo + @valorTransferido) WHERE id_conta = @id_destinatario;";

                command.Parameters.Add("@id_remetente", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@id_destinatario", MySqlDbType.Int32).Value = id_dest;
                command.Parameters.Add("@valorTransferido", MySqlDbType.Double).Value = saldo;

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

                    nome = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i);
                }
                else
                {
                    nome = string.Empty;
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
            return nome;
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
                command.CommandText = "SELECT saldo FROM tbconta WHERE id_conta = @id;";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    saldo = dataReader.IsDBNull(i) ? 0 : dataReader.GetDouble(i);
                }
                else
                {
                    saldo = 0;
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
            return saldo;
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

                    nome = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i); i++;
                }
                else
                {
                    nome = string.Empty;
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
