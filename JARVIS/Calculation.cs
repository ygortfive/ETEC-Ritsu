using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;

namespace RITSU
{
    public class Calculation
    {
        
        public static string calcSolve(string operacao)
        //Passar uma operação, ex.: 3 vezes 6
        {
            string[] parts = operacao.Split(' '); //a operação que irá chegar sera divida em um array pelos seus ' ' (espaços) == [3,vezes,6] == [0],[1],[2]

            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[2]);
            double z = 0;

            switch(parts[1])
            {
                case "vezes":
                    z = x * y;
                    break;
                case "mais":
                    z = x + y;
                    break;
                case "menos":
                    z = x - y;
                    break;
                case "dividido":
                    z = (x / y);
                    break;
                case "porcento":
                    z = (x * y) / 100;
                    break;
            }           
            return z.ToString();
        }
    }
}
