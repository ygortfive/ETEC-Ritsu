using RITSU.BLL;
using RITSU.DTO;
using RITSU.One_for_All;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITSU
{
    public partial class LoginEmail : Form
    {
        GetSetLogin login = new GetSetLogin();

        public LoginEmail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            login.Email = txtEmail.Text;
            login.Senha = txtSenha.Text;                       

            clsMetodosBanco banco = new clsMetodosBanco();
            banco.CadastrarLogin(login);            
            login.Logado = true;
            this.Dispose();
        }

        public GetSetLogin VoltaLogin()
        {
            return login;
        }
    }
}
