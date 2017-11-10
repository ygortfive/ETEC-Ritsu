using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RITSU.DTO;

namespace RITSU
{
    public partial class EmailAtual : Form
    {
        MySqlDataReader dr;
        clsMetodosBanco banco = new clsMetodosBanco();
        

        public EmailAtual()
        {
            
            InitializeComponent();            
        }

        private void EmailAtual_Load(object sender, EventArgs e)
        {
            dr = banco.RetornaLogin();
            if (dr.Read())
            {
                txtEmail.Text = dr["email"].ToString();
            }
        }
    }
}
