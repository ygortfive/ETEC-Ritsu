using RITSU.BLL;
using RITSU.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RITSU.DTO
{
    class clsMetodosBanco
    {
        clsConexao conexao = new clsConexao();
        DateTime time = DateTime.Now;

        public void CadastrarEmail(GetSetEmail gse)
        {
            MessageBox.Show(gse.Hora.ToString());
            try
            {
                conexao.ExecutaComando("insert into tb_emails values (default,'" + gse.Remetente + "','" + gse.Titulo
                    + "','" + gse.Conteudo + "','" + gse.Hora.Hour + "','" + gse.Data.Date.Day + "', 1);");                
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void CadastrarLogin(GetSetLogin gsl)
        {
            try
            {
                conexao.ExecutaComando("insert into tb_logins values (default,'" + gsl.Email + "','" + gsl.Senha
                                        + "');");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MySqlDataReader RetornaLogin()
        {
            try
            {
                string strQuery = "select * from tb_logins where id_logins = (select count(*) from tb_logins);";
                return conexao.RetornaDataReader(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlDataReader RetornaEmail()
        {
            try
            {
                //MessageBox.Show(time.Hour.ToString());
                string strQuery = "select * from tb_emails where hora >= (" + (time.Hour - 1) + ") and dia = " + time.Date.Day + ";";
                return conexao.RetornaDataReader(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
