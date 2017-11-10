using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using S22.Imap;
using RITSU.DTO;
using RITSU.BLL;

namespace RITSU
{
    public partial class ApplicationEmail : Form
    {
        static ApplicationEmail f;
        //GetSetLogin login = new GetSetLogin();
        
        public ApplicationEmail()
        {
            InitializeComponent();
            f = this;
            btnSend.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var message = new MailMessage(txtEmail.Text, txtRecipient.Text);
            message.Subject = txtSubject.Text;
            message.Body = rtxtBody.Text;

            using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
            {
                mailer.Credentials = new NetworkCredential(txtEmail.Text, txtPassword.Text);
                mailer.EnableSsl = true;
                mailer.Send(message);
            }

            txtPassword.Text = null;
            txtEmail.Text = null;
            txtRecipient.Text = null;
            txtSubject.Text = null;
            rtxtBody.Text = null;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = true;
            btnReceive.Enabled = false;
            //StartReceiving();
        }

        public void StartReceiving(string login, string senha)
        {
            Task.Run(() =>
            {
                using (ImapClient client = new ImapClient("imap.gmail.com", 993, login,
                    senha, AuthMethod.Login, true))
                {
                    if (client.Supports("IDLE") == false)
                    {
                        MessageBox.Show("Servidor não suporta IMAP IDLE");
                        return;
                    }
                    client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                    while (true) ;
                }
            });
        }

        static void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            clsMetodosBanco banco = new clsMetodosBanco();
            GetSetEmail gse = new GetSetEmail();
            DateTime dateTime = DateTime.Now;

            //MessageBox.Show("Nova mensagem recebida!");
            Speaker.Speak("Você recebeu um novo email!");
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            f.Invoke((MethodInvoker)delegate
            {
                gse.Remetente = Convert.ToString(m.From);
                gse.Titulo = m.Subject;
                gse.Conteudo = m.Body;
                gse.Hora = dateTime;
                gse.Data = dateTime;
                try
                {
                    banco.CadastrarEmail(gse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                f.rtxtReceive.AppendText("De: " + m.From + "\n" + "Titulo: " + m.Subject + "\n" + "Conteúdo:" + m.Body + "\n");
            });
        }
    }
}
