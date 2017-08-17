using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITSU
{
    /// <summary>
    ///  Classe que vai executar os comandos do JARVIS
    /// </summary>
    public class Commands
    {
        private static MediaPlayer mediaPlayer = null; // media player
        //private static AddNewCommand addNewCommand = null; // janela de comandos
        private static ProcessList processList = null;
        private static Notepad notepad = null; //bloco de notas
        public static void Execute(string cmd) // método estático
        {
            DateTime time = DateTime.Now;
            switch (cmd)
            {
                case "que horas sao": // fala as horas

                    if (time.Hour <= 12 && time.Hour > 5)
                    {
                        Speaker.Speak("são " + time.Hour.ToString() + " horas da manhã e " + time.Minute.ToString() + " minutos");
                    }
                    else if (time.Hour > 12 && time.Hour < 18)
                    {
                        int h = time.Hour - 12;
                        Speaker.Speak("são " + h.ToString() + " horas da tarde e " + time.Minute.ToString() + " minutos");
                    }
                    else if (time.Hour > 18 && time.Hour < 24)
                    {
                        int h = time.Hour - 12;
                        Speaker.Speak("são " + h + " horas da noite e " + time.Minute.ToString() + "minutos");
                    }
                    else
                    {
                        //Speaker.Speak("são " + time.Hour.ToString() + " horas " + time.Minute.ToString() + " minutos");
                        Speaker.Speak(time.Hour.ToString() + " hora e " + time.Minute.ToString() + " minutos");
                    }
                    break;
                case "data de hoje":
                    Speaker.Speak(DateTime.Now.ToShortDateString());
                    break;
                case "que dia é hoje":
                    Speaker.Speak(DateTime.Today.ToString("dddd"));
                    break;
                case "em que mês estamos":
                    // vamos usar switch para pegar o nome do mes
                    string month = "";
                    int n = time.Month;
                    switch (n)
                    {
                        case 1:
                            month = "janeiro";
                            break;
                        case 2:
                            month = "fevereiro";
                            break;
                        case 3:
                            month = "março";
                            break;
                        case 4:
                            month = "abril";
                            break;
                        case 5:
                            month = "maio";
                            break;
                        case 6:
                            month = "junho";
                            break;
                        case 7:
                            month = "julho";
                            break;
                        case 8:
                            month = "agosto";
                            break;
                        case 9:
                            month = "setembro";
                            break;
                        case 10:
                            month = "outubro";
                            break;
                        case 11:
                            month = "novembro";
                            break;
                        case 12:
                            month = "dezembro";
                            break;
                    }
                    Speaker.Speak("estamos no mês de " + month);
                    break;
                case "em que ano estamos":
                    Speaker.Speak(DateTime.Today.ToString("yyyy"));
                    break;

                // SpeechSynthesizer
                case "pare de falar":
                    Speaker.StopSpeak(); // para de falar
                    break;

                case "alterar voz":
                    SelectVoz voice = new SelectVoz();
                    voice.Show();
                    break;

                // media player
                case "media player":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.Show();
                        Speaker.Speak("abrindo media player");
                     }
                     else
                     {
                         mediaPlayer = new MediaPlayer();
                         mediaPlayer.Show();
                         Speaker.Speak("abrindo media player");
                     }
                     break;
                 case "selecionar arquivo":
                     if (mediaPlayer != null)
                     {
                         Speaker.Speak("Selecione um arquivo");
                         mediaPlayer.Show();
                         mediaPlayer.OpenFile();                         
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "pausar":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.Pause();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "continuar":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.Play();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "parar":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.Stop();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "fechar media player":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.Close();
                         mediaPlayer = null;
                         Speaker.Speak("fechando o media player");
                     }
                     else
                     {
                         Speaker.Speak("media player já esta fechado");
                     }
                     break;
                 case "abrir diretório para reproduzir":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.OpenDirectory();
                         mediaPlayer.Show();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "próximo":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.NextFile();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "anterior":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.BackFile();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "aumentar volume":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.VolumeUp();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "diminuir volume":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.VolumeDown();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "mudo":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.Mute();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "voltar som":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.UnMute();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "media player em tela cheia":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.FullScreen();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "media player em tamanho normal":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.NotFullScreen();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;
                 case "que arquivo está tocando":
                     if (mediaPlayer != null)
                     {
                         mediaPlayer.SayFileThatIsPlaying();
                     }
                     else
                     {
                         Speaker.Speak("media player, não está aberto!"); // diz algo
                     }
                     break;

                case "bloco de notas":
                     if (notepad != null)
                     {
                         notepad.Show();
                         Speaker.Speak("Abrindo bloco de notas");
                     }
                     else
                     {
                         notepad = new Notepad();
                         notepad.Show();
                         Speaker.Speak("Abrindo bloco de notas");
                     }
                     break;
                case "salvar texto":
                     if (notepad != null)
                     {
                         Speaker.Speak("Insira o nome do arquivo");
                         notepad.SaveFile();
                     }
                     else
                     {
                         Speaker.Speak("Bloco de notas não esta aberto");
                     }
                     break;
                case "trocar fonte":
                     if (notepad != null)
                     {
                         Speaker.Speak("Abrindo configurações de fonte");
                         notepad.OpenFont();
                     }
                     else
                     {
                         Speaker.Speak("Bloco de notas não esta aberto");
                     }
                     break;
                case "fechar bloco de notas":
                     if (notepad != null)
                     {
                         notepad.Close();
                         notepad = null;
                         Speaker.Speak("Fechando bloco de notas");
                         
                     }
                     else
                     {
                         Speaker.Speak("Bloco de notas já esta fechado");
                     }
                     break;               
                

                // -------------- Comandos ------------------

                /* case "adicionar novo comando":
                     if (addNewCommand == null)
                     {
                         addNewCommand = new AddNewCommand();
                         addNewCommand.Show();
                     }
                     else
                     {
                         Speaker.Speak("certo, vou abrir");
                         addNewCommand.Show();
                     }
                     break; */
                case "detalhes dos processos":
                    ActionProcess.ProcessesRunning(); // chama o método
                    break;

                case "introdução ao assistente ritsu":
                    RITSUHelp.Introduction();
                    break;

                case "lista de processos":
                    if (processList == null)
                    {
                        processList = new ProcessList();
                        processList.Show();
                    }
                    else
                    {
                        processList.Show();
                    }
                    break;
                case "fechar o processo selecionado":
                    if (processList != null)
                    {
                        processList.CloseSelectedProcess();
                    }
                    break;

                // informações do sistema
                case "em quanto estar o uso do processador?":
                    Speaker.Speak("o uso do processador estar em " + Math.Round(PCStats.GetCPUUsage(), 2).ToString() + " porcento");
                    break;
                case "quanta memória ram estar sendo usada?":
                    Speaker.Speak("estão sendo usados " + ((int)PCStats.GetTotalMemory() - PCStats.GetFreeMemory()).ToString() + " megas baites de memória ram");
                    break;
                case "quanta mamória ram ainda há livre?":
                    Speaker.Speak("há " + (int)PCStats.GetFreeMemory() + " megas baites de memória ram livres");
                    break;
                case "quanta memória ram há no total?":
                    Speaker.Speak("há " + (int)PCStats.GetTotalMemory() + " megas baites de memória ram no total");
                    break;                   

                case "desligar computador":
                    s_Commands.ShutdownComputer();
                    break;
                case "reiniciar computador":
                    s_Commands.RestartComputer();
                    break;
                case "cancelar desligamento":
                    s_Commands.CancelShutdown();
                    break;
                case "cancelar reinicialização":
                    s_Commands.CancelShutdown();
                    break;

                    //Softwares
                        
                        //----Word----
                case "abrir word":
                    ActionSoftwares.WordOpen();
                    break;
                case "word novo documento":
                    ActionSoftwares.WordNew();
                    break;
                case "word salvar documento":
                    ActionSoftwares.WordSave();
                    break;
                case "word fechar":
                    ActionSoftwares.WordClose();
                    break;
                case "word recortar":
                    ActionSoftwares.WordCut();
                    break;
                case "word copiar":
                    ActionSoftwares.WordCopy();
                    break;
                case "word colar":
                    ActionSoftwares.WordPaste();
                    break;
                case "word selecionar tudo":
                    ActionSoftwares.WordAll();
                    break;
                case "word negrito":
                    ActionSoftwares.WordBolt();
                    break;
                case "word itálico":
                    ActionSoftwares.WordItalic();
                    break;
                case "word sublinhado":
                    ActionSoftwares.WordUnderline();
                    break;
                case "word centralizar":
                    ActionSoftwares.WordCenter();
                    break;
                case "word desfazer":
                    ActionSoftwares.WordUndo();
                    break;
                case "word refazer":
                    ActionSoftwares.WordRedo();
                    break;
            }
        }

        private static void Speak(string p)
        {
            throw new NotImplementedException();
        }
    }
}
