using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RITSU
{    
    public class Runner
    {
        //metodo para falar as horas
        public static void WhatTimeIs()
        {
            Speaker.Speak(DateTime.Now.ToShortTimeString());
        }

        //metodo para falar o dia
        public static void WhatDateIs()
        {
            Speaker.Speak(DateTime.Now.ToShortDateString());
        }       

    }
}
