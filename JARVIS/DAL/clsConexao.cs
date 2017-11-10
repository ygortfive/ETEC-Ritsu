using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RITSU.DAL
{
    class clsConexao
    {
        public static MySqlConnection AbreBanco()
        {
            string StringConexao = "server=localhost;database=bd_ritsu;uid=root;pwd=";

            try
            {
                MySqlConnection conn = new MySqlConnection(StringConexao);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FechaBanco(MySqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RetornaDataSet(string strQuery)
        {
            MySqlConnection conn;
            conn = AbreBanco();

            try
            {
                DataSet ds = new DataSet();
                MySqlCommand cmdComando = new MySqlCommand(strQuery, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmdComando);
                da.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FechaBanco(conn);
            }
        }

        public MySqlDataReader RetornaDataReader(string strQuery)
        {
            try
            {
                MySqlDataReader dr;
                MySqlCommand cmdComando = new MySqlCommand(strQuery, AbreBanco());
                dr = cmdComando.ExecuteReader();
                //dr.Read();

                return dr;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExecutaComando(string strQuery)
        {
            MySqlConnection conn;
            conn = AbreBanco();

            try
            {
                MySqlCommand sqlComm = new MySqlCommand(strQuery, conn);
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FechaBanco(conn);
            }
        }
    }
}
