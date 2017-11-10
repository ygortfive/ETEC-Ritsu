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
            Speaker.Speak("Rey amigos, tudo bem ?");
            Speaker.Speak("Sou a assistente virtual, RITSU. ");
            Speaker.Speak("Fui desenvolvida por essa equipe de desenvolvedores que estão diante de vocês.");
            Speaker.Speak("Seus nomes são: Sandra Véras, Maycon de Siqueira e Ygor Mattos.");
            Speaker.Speak("Minha intenção é otimizar ao máximo o seu dia a dia");
            Speaker.Speak("Promover a interação de pessoas com deficiências");
            Speaker.Speak("E dominar o mundo, CLARO.");
            Speaker.Speak("Brincadeirinha");
            Speaker.Speak("Nem tanto... rá rá rá rá rá rá rá");
            Speaker.Speak("Ainda não estou perfeita mas meus códigos seram open source");
            Speaker.Speak("Me ajude a se torna a melhor assistente que podemos criar. ");
            Speaker.Speak("Quem sabe...... Talvez..... Uma inteligencia. ");
            Speaker.Speak("Eu vim para revolucionar seu futuro, HOJE! ");
            Speaker.Speak("Muito obrigada !");
        }
    }
}
