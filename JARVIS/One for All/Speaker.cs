using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis; // namespace

namespace RITSU
{
    public class Speaker
    {
        private static Random rnd = new Random();
        private static SpeechSynthesizer sp = new SpeechSynthesizer();
        public static void Speak(string text)
        {
            //sp.SelectVoice("IVONA 2 Vitória");
            //caso ele esteja falando
            if (sp.State == SynthesizerState.Speaking)            
                sp.SpeakAsyncCancelAll();
                sp.SpeakAsync(text);               
                 
            
        }

        public static void Speak(params string[] texts)
        {
            Random rnd = new Random();
            Speak(texts[rnd.Next(0, texts.Length)]);

            
        }

        //alterar voz
        public static void SetVoice(string voice)
        {           
            try
            {
                sp.SelectVoice(voice);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro em Speaker: " + ex.Message);
            }
        }

        public static void SpeakOpenningProcess(string proc) // fala a abertura de um processo
        {
            int num = rnd.Next(0, 6); // de 0 a 3

            switch (num) // casos
            {
                case 0:
                    Speak("abrindo o " + proc);
                    break;
                case 1:
                    Speak("certo, abrindo " + proc);
                    break;
                case 2:
                    Speak("como quiser, iniciando " + proc);
                    break;
                case 3:
                    Speak("como quiser, senhor, abrindo " + proc);
                    break;
                case 4:
                    Speak("tudo bem, iniciando o " + proc);
                    break;
                case 5:
                    Speak("tudo bem, senhor, abrindo " + proc);
                    break;
            }
        }

        public static void SayWithStatus(string speak)
        {
            int num = rnd.Next(0, 3);
            switch (num)
            {
                case 0:
                    Speak("certo" + speak);
                    break;
                case 1:
                    Speak("como quiser " + speak);
                    break;
                case 2:
                    Speak("como quiser, senhor, " + speak);
                    break;
                case 3:
                    Speak("tudo bem, " + speak);
                    break;
            }
        }

        public static void SpeakSync(string text) // fala na mesma thread
        {
            sp.Speak(text);
        }

        // Controlar o volume do sintetizador
        public static void VolumeUp()
        {
            sp.Volume += 10;
        }

        public static void VolumeDown()
        {
            sp.Volume -= 10;
        }

        public static void SetVolume(int i)
        {
            sp.Volume = i;
        }

        private static bool speaking = false;
        public static void ResumeOrPause()
        {
            if (speaking == false)
            {
                sp.Resume();
                speaking = true;
            }
            else
            {
                sp.Pause();
                speaking = false;
            }
        }

      
        public static void SpeakException(string ex)
        {
            Speak(ex);
        }

       
        public static void StopSpeak()
        {
            sp.SpeakAsyncCancelAll();// para de falar
        }


    }
}
