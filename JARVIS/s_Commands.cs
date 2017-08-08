using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RITSU
{
    /// <summary>
    /// Classe que vai executar comandos especiais
    /// </summary>
    public static class s_Commands
    {
        public static void ShutdownComputer()
        {
            Process.Start("shutdown", "-s -t 30");
            Speaker.Speak("encerrando computador");
        }

        public static void CancelShutdown()
        {
            Process.Start("shutdown", "-a");
            Speaker.Speak("cancelando");
        }

        public static void RestartComputer()
        {
            Process.Start("shutdown", "-r -t 30");
            Speaker.Speak("reiniciando computador");
        }
    }
}
