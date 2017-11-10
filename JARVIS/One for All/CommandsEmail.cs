using RITSU.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using RITSU.DTO;
using System.Data;
using System.Threading;

namespace RITSU.One_for_All
{
    class CommandsEmail
    {
        public static void ExecuteEmail(string cmd)
        {
            //ApplicationEmail AppEmail = new ApplicationEmail();
            clsMetodosBanco banco = new clsMetodosBanco();
            MySqlDataReader DataReader;
            DataSet DataSet;
            ApplicationEmail AppEmail = new ApplicationEmail();
            List<string> MeusEmails = new List<string>();
            EmailAtual meuEmail = new EmailAtual();
            

            switch (cmd)
            {
                //Carregar email antes de utilizar
                case "carregar email":
                    try
                    {
                        AppEmail.Show();
                        DataReader = banco.RetornaLogin();
                        if (AppEmail == null)
                        {
                            if (DataReader.Read())
                            {
                                AppEmail.StartReceiving(DataReader["email"].ToString(), DataReader["senha"].ToString());
                                Speaker.Speak("Email carregado com sucesso.");
                            }
                            AppEmail.Dispose();
                        }
                        else
                        {
                            if (DataReader.Read())
                                AppEmail.StartReceiving(DataReader["email"].ToString(), DataReader["senha"].ToString());
                                Speaker.Speak("Email carregado com sucesso.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Speaker.Speak("Ocorreu um erro na leitura dos emails.");
                        MessageBox.Show(ex.ToString());
                    }
                    break;

                //Leitura de emails da ultima hora
                case "ler email":
                    try
                    {
                        DataReader = banco.RetornaEmail();
                        while(DataReader.Read())
                        {
                                MeusEmails.Add("De: " + DataReader.GetString(1).Replace("<","").Replace(">","") + "Titulo: " + DataReader.GetString(2));                           
                        }

                        foreach(string t in MeusEmails)
                        {
                            Speaker.Speak(t);
                            Thread.Sleep(9000);
                        }

                    }
                     catch (Exception ex)
                    {
                        Speaker.Speak("Ocorreu um erro na leitura dos emails.");
                        MessageBox.Show(ex.ToString());
                    }

                    break;
                
                case "meu email":                    
                    meuEmail.Show();
                    break;

                case "fechar meu email":
                    meuEmail.Close();
                    break;
            }
        }
    }
}
