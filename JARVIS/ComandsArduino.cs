using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITSU
{
    class ComandsArduino
    {
        public static void Iniciar(string play)
        {
            switch (play)
            {
                case "abrir arduino":
                    In_Out_Arduino.abrir_arduino();
                    break;
                case "acender led":
                    In_Out_Arduino.acender_led();
                    break;

               case "apagar led":
                    In_Out_Arduino.apagar_led();
                    break;
            }
        }
    }
}
