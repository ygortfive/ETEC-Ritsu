using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITSU
{
    /// <summary>
    /// Classe que vai tratar de ajudar os usuários e programadores
    /// </summary>
    public class RITSUHelp
    {
        // Introdução ao assistente
        public static void Introduction()
        {
            Speaker.Speak("Olá, como estão? ");
            Speaker.Speak("Sou a assistente virtual, RITSU. ");
            Speaker.Speak("Fui desenvolvida por um grupo de excelentes programadores");
            Speaker.Speak("Sóó que não rue rue rue");
            Speaker.Speak("Tenho o objetivo de interagir com meus amados usuários com a intenção de ser útil, prático e uma companhia nas horas vagas");
            Speaker.Speak("No futuro quero estar presente em seu dia-a-dia, mas, por hora, não esqueça de me levar com vocês");
            Speaker.Speak("Eu vim para revolucionar seu futuro, HOJE! ");
            Speaker.Speak("Muito obrigada !");
        }
    }
}
