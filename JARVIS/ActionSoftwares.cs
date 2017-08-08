using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace RITSU
{
    class ActionSoftwares
    {
        #region Method
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;

        private static void FocusWord()
        {
            Process[] objProcesses = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(objProcesses[0].MainWindowHandle);
            }
        }

        //--------------------//

        private static bool verificarProcesso(string nomeProcesso)
        {
            Process[] listaProcessos = Process.GetProcesses();
            foreach (Process processo in listaProcessos)
            {
                if (processo.ProcessName == nomeProcesso)
                {
                    return true; 
                }
            }

            return false;
        }
        #endregion

        // - - - - Much parts (Grande parte) - - - -

        private static void Cut() //recortar
        {            
            KeyBoard_Simulator.ctrl_X();
        }

        private static void Copy() //copia
        {
            KeyBoard_Simulator.ctrl_C();
        }

        private static void Paste() //colar/
        {
            KeyBoard_Simulator.ctrl_V();
        }

        private static void SelectAll() //selecionar tudo
        {
            KeyBoard_Simulator.ctrl_A();
        }

        private static void Bolt() //negrito
        {
            KeyBoard_Simulator.ctrl_N();
        }

        private static void Italic() //italico
        {
            KeyBoard_Simulator.ctrl_I();
        }
        private static void Underline() //sublinhado
        {
            KeyBoard_Simulator.ctrl_U();
        }
        private static void Center() //centralizar
        {
            KeyBoard_Simulator.ctrl_E();
        }
        private static void Left() //alinhar a esquerda
        {
            KeyBoard_Simulator.ctrl_L();
        }
        private static void Right() //alinhar a direita
        {
            KeyBoard_Simulator.ctrl_R();
        }
        private static void Undo() //desfazer
        {
            KeyBoard_Simulator.ctrl_Z();
        }
        private static void Redo() //refazer
        {
            KeyBoard_Simulator.ctrl_Y();
        }


        // - - - - Word - - - -

        
        public static void WordOpen() //abrir
        {
            Process p = new Process();
            p.StartInfo.FileName = "WINWORD.EXE";
            p.Start();
            Speaker.Speak("Abrindo word");
        }
        public static void WordNew() //novo
        {
           //if (verificarProcesso("WINWORD.EXE"))
            //{
                FocusWord();
                KeyBoard_Simulator.ctrl_O();
                Speaker.Speak("Novo documento");
           //}
            //else 
            //{
                Speaker.Speak("Word não está em execução");
           //}
        }
        public static void WordSave() //salvo
        {
            //if (verificarProcesso("WINWORD.EXE"))
            //{
                FocusWord();
                KeyBoard_Simulator.ctrl_S();
                Speaker.Speak("Salvando documento");
            //}
        }
        public static void WordClose() //fechar
        {
            //if (verificarProcesso("WINWORD.EXE"))
            //{
                FocusWord();
                Speaker.Speak("Fechando o word");
                Thread.Sleep(300);
                KeyBoard_Simulator.ctrl_W();
                Speaker.Speak("Ta bom, irei clicar no X para você");                
            //}
        }
        public static void WordCut()
        {
            FocusWord();
            Cut();
        }
        public static void WordCopy()
        {
            FocusWord();
            Copy();
        }
        public static void WordPaste()
        {
            FocusWord();
            Paste();
        }
        public static void WordAll()
        {
            FocusWord();
            SelectAll();
        }
        public static void WordBolt()
        {
            FocusWord();
            Bolt();
        }
        public static void WordItalic()
        {
            FocusWord();
            Italic();
        }
        public static void WordUnderline()
        {
            FocusWord();
            Underline();
        }
        public static void WordCenter()
        {
            FocusWord();
            Center();
        }
        public static void WordLeft()
        {
            FocusWord();
            Left();
        }
        public static void WordRight()
        {
            FocusWord();
            Right();
        }
        public static void WordUndo()
        {
            FocusWord();
            Undo();
        }
        public static void WordRedo()
        {
            FocusWord();
            Redo();
        }
        
        
    }
}
