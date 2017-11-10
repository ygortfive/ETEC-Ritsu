
using System;
using System.Diagnostics; // namespace usado

namespace RITSU
{
    /// <summary>
    /// Description of ProcessControl.
    /// </summary>
    public class ActionProcess
    {
        public ActionProcess()
        {
        }

        public static void OpenOrClose(string proc)
        {
            if (proc.StartsWith("abrir"))
            {
                proc = proc.Replace("abrir", ""); // remove o comando
                proc = proc.Trim(); // remove espaços em branco
                Speaker.SpeakOpenningProcess(proc);
                switch (proc) // verificando o argumento
                {                    
                    case "prompt de comando":
                        Process.Start("cmd");
                        break;                   
                    case "gerenciador de tarefas":
                        Process.Start("taskmgr");
                        break;
                    case "minhas pastas":
                        Process.Start("explorer");
                        break;                                
                    case "limpeza de disco":
                        Process.Start("cleanmgr");
                        break;              
                   case "gerenciamento de computador":
                        Process.Start("compmgmt.msc");
                        break;
                   case "definir programas padrão":
                        Process.Start("ComputerDefaults");
                        break;
                    case "painel de controle":
                        Process.Start("control.exe");
                        break;                 
                    case "desfragmentador de disco":
                        Process.Start("dfrgui.exe");
                        break;                  
                    case "gerenciador de dispositivos":
                        Process.Start("devmgmt.msc");
                        break;
                    case "discagem telefônica":
                        Process.Start("dialer.exe");
                        break;
                    case "gerenciamento de disco":
                        Process.Start("diskmgmt.msc");
                        break;
                }
            }
            else if (proc.StartsWith("fechar"))
            {
                proc = proc.Replace("fechar", "");
                proc = proc.Trim();
                switch (proc)
                {                    
                    case "prompt de comando":
                        CloseProcess("cmd", proc);
                        break;
                    case "gerenciador de tarefas":
                        CloseProcess("taskmgr", proc);
                        break;
                    case "minhas pastas":
                        CloseProcess("explorer" , proc);
                        break;
                    case "limpeza de disco":
                        CloseProcess("cleanmgr", proc);
                        break;
                    case "gerenciamento de computador":
                        CloseProcess("compmgmt", proc);
                        break;
                    case "definir programas padrão":
                        CloseProcess("ComputerDefaults", proc);
                        break;
                    case "painel de controle":
                        CloseProcess("control.exe", proc);
                        break;
                    case "desfragmentador de disco":
                        CloseProcess("dfrgui.exe", proc);
                        break;
                    case "gerenciador de dispositivos":
                        CloseProcess("devmgmt.msc", proc);
                        break;
                    case "discagem telefônica":
                        CloseProcess("dialer.exe", proc);
                        break;
                    case "gerenciamento de disco":
                        CloseProcess("diskmgmt.msc" , proc);
                        break;
                }
            }
        }
        private static void CloseProcess(string cmd, string proc)
        {
            try // vamos usar try/catch
            {
                Process[] p = Process.GetProcessesByName(cmd);
                if (p[0] != null) // se o processo não for nulo
                {
                    Speaker.SayWithStatus("fechando o " + proc);
                    p[0].Kill();
                }
                else // se for nulo
                {
                    Speaker.Speak("desculpe, mas o " + proc + " não estar aberto");
                }
            }
            catch (Exception ex) // jarvis vai nos ajudar no debug
            {
                Speaker.Speak("senhor, ocorreu um erro, desculpe, o erro foi, " + ex.Message);
            }
        }

        /// <summary>
        /// Faz algo sobre a lista de processos
        /// </summary>
        public static void ProcessesRunning()
        {
            try
            {
                Process[] procs = Process.GetProcesses(); // pega todos os processos
                Speaker.Speak("obtendo lista de processos");
                foreach (Process proc in procs) // percorrer os processos
                {
                    if (proc.MainWindowTitle != "") // se a janela tiver título
                    {
                        Speaker.Speak(proc.MainWindowTitle + " está usando " + Convert.ToString(proc.PagedMemorySize64 / 1024 / 1024) + " mega baites");
                    }
                }
            }
            catch (Exception ex)
            {
                Speaker.Speak("ocorreu um erro " + ex.Message); // fala o erro
            }
        }
    }
}
