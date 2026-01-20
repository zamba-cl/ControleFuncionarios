using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ControleFuncionarios
{
    public class AcessarDados
    {
        private string _connectionString;

        public AcessarDados()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        #region ExecutarSelect
        public DataTable ExecutarSelect(string sql, Hashtable parametros = null)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable tabela = new DataTable();

            try
            {
                AdicionarParametrosQueExistem(sql, parametros, cmd);

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabela);

                return tabela;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region ExecutarNonQuery
        public int ExecutarNonQuery(string sql, Hashtable parametros = null)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                AdicionarParametrosQueExistem(sql, parametros, cmd);

                conn.Open();

                return cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region ExecutarInsert
        public int ExecutarInsert(string sql, Hashtable parametros = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                AdicionarParametrosQueExistem(sql, parametros, cmd);
                conn.Open();

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
        #endregion

        #region ExecutarScalar
        public object ExecutarScalar(string sql, Hashtable parametros = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        foreach (DictionaryEntry item in parametros)
                        {
                            cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                        }
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        #endregion

        #region AdicionarParametrosQueExistem
        private void AdicionarParametrosQueExistem(string sql, Hashtable parametros, SqlCommand cmd)
        {
            if (parametros == null) return;

            foreach (DictionaryEntry item in parametros)
            {
                string nome = item.Key.ToString();

                if (sql.Contains(nome))
                    cmd.Parameters.AddWithValue(nome, item.Value);
            }
        }
        #endregion
    }
}