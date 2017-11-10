using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITSU.BLL
{
    class GetSetEmail
    {
        private string remetente;

        public string Remetente
        {
            get { return remetente; }
            set { remetente = value; }
        }
        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        private string conteudo;

        public string Conteudo
        {
            get { return conteudo; }
            set { conteudo = value; }
        }

        private DateTime hora;

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
