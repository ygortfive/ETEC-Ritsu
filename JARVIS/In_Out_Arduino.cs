using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace RITSU
{
    class In_Out_Arduino
    {
        
        public static void abrir_arduino()
        {
            Process openArduino = new Process();
            openArduino.StartInfo.FileName = "F:\\PC\\Software\\Arduino\\arduino.exe";
            openArduino.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            openArduino.Start();
        }
        public static void acender_led()
        {
            SerialPort con = new SerialPort("COM8", 9600);

            con.Open();
            con.Write("1");
            con.Close();
        }

        public static void apagar_led()
        {
            SerialPort con = new SerialPort("COM8", 9600);            

            con.Open();
            con.Write("0");
            con.Close();
        }
    }
}
