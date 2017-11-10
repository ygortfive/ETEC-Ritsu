using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITSU.BLL
{
    public class GetSetLogin
    {
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private bool logado = false;

        public bool Logado
        {
            get { return logado; }
            set { logado = value; }
        }

    }
}
