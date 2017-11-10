using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITSU
{
    public class GrammarRules
    {
       /* public static IList<string> WhatTimeIs = new List<string>()
        {
            "Que horas sao","Me diga as horas","Poderia me dizer que horas sao"
        };

        public static IList<string> WhatDateIs = new List<string>
        {
            "Que dia e hoje","data do dia","poderia me dizer que dia e hoje"
        }; */

        public static IList<string> MinimizeWindow = new List<string>()
        {
            "Se esconda", "Minimize a janela","Ritsu minimize a janela"
        };

        public static IList<string> MaximizeWindow = new List<string>()
        {
            "Apareça agora", "Maximizar janela", "Ritsu apareça"
        };

        public static IList<string> NormalWindow = new List<string>()
        {
            "Volte ao tamanho normal", "janela original", "Ritsu, fique no tamanho original"
        };

        public static IList<string> CloseWindow = new List<string>()
        {
            "Fechar" , "Vamos encerrar por hoje"
        };

        public static IList<string> JarvisStartListening = new List<string>()
        {
            "Ritsu","Ritsu voce esta ai?","Ola Ritsu","Oi Ritsu"
        };

        public static IList<string> JarvisStopListening = new List<string>()
        {
            "Pare de ouvir", "Basta por hora","Intervalo"
        };       
        
        public static IList<string> OpenProgram = new List<string>()
        {
            "Media Player"
        };
        
        //change = mudar/alterar
        public static IList<string> ChangeVoice = new List<string>()
        {
            "Altere a voz" , "Alterar voz"
        };
    }
}
