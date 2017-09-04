using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //log
using Microsoft.Speech.Recognition; //Adicionar namespace
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;
using System.Collections.Generic;


// Para sintese e preciso o SpeechSDK5.1, Windows 10 ja tem System.Speech

namespace RITSU
{
    public partial class Ritsu : Form
    {

        //Forms nulos
        private SelectVoz selectVoice = null;

        //Fim dos forms
        private SpeechRecognitionEngine engine; //engine de reconhecimento
        private static SpeechSynthesizer synthesizer = new SpeechSynthesizer(); //Sintetizador de palavras

        


        private bool isRitsuListening = true; //variavel para parar de ouvir
        public Ritsu()
        {
            InitializeComponent();
        }

        private void LoadSpeech() //metodo que carregara tudo
        {
            try
            {
                engine = new SpeechRecognitionEngine(); // Instancia do reconhecedor
                engine.SetInputToDefaultAudioDevice(); //microfone                     

                //carregando comandos na gramatica

                Choices cAIML = new Choices(AIML.GetWordsOrSentences()); //frases e palavras aiml
               
                Choices c_commandsOfSystem = new Choices();                
                c_commandsOfSystem.Add(GrammarRules.JarvisStartListening.ToArray()); //Voltar a falar
                c_commandsOfSystem.Add(GrammarRules.JarvisStopListening.ToArray()); //Parar de falar
                c_commandsOfSystem.Add(GrammarRules.MinimizeWindow.ToArray()); //Minimizar janela
                c_commandsOfSystem.Add(GrammarRules.MaximizeWindow.ToArray()); //Maximizar janela
                c_commandsOfSystem.Add(GrammarRules.NormalWindow.ToArray()); //Normal janela
                c_commandsOfSystem.Add(GrammarRules.CloseWindow.ToArray()); //Fechar janela
                

                //Comandos de processos

                string path = "choices\\cProcess.txt";
                string[] cmds = File.ReadAllLines(path, Encoding.UTF8);
                Choices cProcess = new Choices(cmds); // lista de comandos
                //Comandos sendo adicionados atraveis de arquivos na pasta debug       

               string path1 = "choices\\cCommands.txt";
               string[] cmds1 = File.ReadAllLines(path1, Encoding.UTF8);
               Choices cCommands = new Choices(cmds1); // palavras ou frases que são comandos
                //OBS.: NECESSÁRIO RETIRAR TODOS OS ACENTOS              
               
                
                
                Choices cNumbers = new Choices();
                for (int i = 0; i <= 100; i++)
                {
                    cNumbers.Add(i.ToString());
                }

                string path2 = "choices\\cArduino.txt";
                string[] cmds2 = File.ReadAllLines(path2, Encoding.UTF8);
                Choices cArduino = new Choices(cmds2);                

                Choices cInputText = new Choices();
                cInputText.Add("adicionar texto");

                // GrammarBuilder
                GrammarBuilder gb_comandsOfSystem = new GrammarBuilder();
                gb_comandsOfSystem.Append(c_commandsOfSystem);               

                GrammarBuilder gbProcess = new GrammarBuilder();
                gbProcess.Append(new Choices("abrir", "fechar")); // comando
                gbProcess.Append(cProcess); // adicionar lista de processos

                GrammarBuilder gbInputText = new GrammarBuilder();                
                gbInputText.Append(cInputText);
               

                GrammarBuilder gbCommands = new GrammarBuilder(); //para a lista de comandos
                gbCommands.Append(cCommands); // feito

                GrammarBuilder gbNumbers = new GrammarBuilder(); //para calcular
                gbNumbers.Append(cNumbers);// numero
                gbNumbers.Append(new Choices("mais", "vezes", "menos", "dividido", "porcento")); //operação
                gbNumbers.Append(cNumbers); //numero

                GrammarBuilder gbArduino = new GrammarBuilder();
                gbArduino.Append(cArduino);

                //Grammar
                Grammar g_comandsOfSystem = new Grammar(gb_comandsOfSystem);
                g_comandsOfSystem.Name = "sys";

                Grammar gProcess = new Grammar(gbProcess);
                gProcess.Name = "Process";

                Grammar gInputText = new Grammar(gbInputText);
                gInputText.Name = "InputText";

                Grammar gCommands = new Grammar(gbCommands); // gramática dos comandos
                gCommands.Name = "Commands"; // nome 

                Grammar gNumbers = new Grammar(gbNumbers);
                gNumbers.Name = "calc";

                Grammar gAIML = new Grammar(new GrammarBuilder(cAIML));
                gAIML.Name = "AIML";

                Grammar gArduino = new Grammar(gbArduino);
                gArduino.Name = "Arduino";

                // Lista de gramáticas 
                 List<Grammar> grammars = new List<Grammar>();
                 grammars.Add(gProcess);
                 grammars.Add(gCommands);
                 grammars.Add(gNumbers);
                 grammars.Add(gInputText);
                 grammars.Add(gArduino);
                 grammars.Add(gAIML);
                 grammars.Add(g_comandsOfSystem);               
                
                 
                //Carregar gramatica
                engine.LoadGrammar(g_comandsOfSystem);
                engine.LoadGrammar(gProcess);
                engine.LoadGrammar(gCommands);
                engine.LoadGrammar(gNumbers);
                engine.LoadGrammar(gInputText);
                engine.LoadGrammar(gArduino);
                engine.LoadGrammar(gAIML);
                                
                #region SpeechRecognition Events
                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec); //reconhecimento confirmado
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel); //audio do reconhecimento
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej); //reconhecimento rejeitado
                #endregion

                #region SpeechSynthesizer Events
                synthesizer.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(speakStarted);
                synthesizer.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(speakProgress);
                #endregion

                engine.RecognizeAsync(RecognizeMode.Multiple); //Iniciar um reconhecimento             
                                

                Speak("Um momento...");
            }
            catch (Exception ex) //se algum error ocorrer, entrara aqui
            {
                MessageBox.Show("Ocorreu um erro no LoadSpeech()" + ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            Speak("Olá, estou pronta para te ajudar! ");            
            AIML.ConfigAIMLFiles();
            
        }

        // Metodo chamado quando algo é reconhecido
        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text; //string que reconhece voz
            
            float conf = e.Result.Confidence; //float que recebe confianca

            //logs
            string date = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString(); //definir data do arquivo
            string log_filename = "log\\" + date + ".txt"; //nome do arquivo

            StreamWriter sw = File.AppendText(log_filename);
            if (File.Exists(log_filename))
            {
                sw.WriteLine(speech);
            }
            else
            {
                sw.WriteLine(speech);
            }

            sw.Close();

            //end logs
                        
            if (conf > 0.5f)
            {
                //this.label1.BackColor = Color.DarkGray; //mudar cor do background quando reconhecido
                this.label1.ForeColor = Color.LawnGreen; //mudar cor da fonte quando reconhecido
                lbl_rec.Text = "User: " + speech;
                if (GrammarRules.JarvisStopListening.Any(x => x == speech)) //Se for falado qualquer coisa dentro das condições do metodo JavisStopListening ira executar essa if
                {
                    Speak("Te vejo mais tarde","Vejo você depois","OK");
                    isRitsuListening = false;
                }
                else if (GrammarRules.JarvisStartListening.Any(x => x == speech))
                {
                    isRitsuListening = true;
                    Speak("Ola, estou de volta!", "Estou aqui","Bem vindo");
                }

                if (isRitsuListening == true) //so ira executar os comandos de fala se ele estiver ouvindo
                {
                    switch (e.Result.Grammar.Name)
                    {                    
                        case "sys":
                            if (GrammarRules.MaximizeWindow.Any(x => x == speech))
                            {
                                MaximizeWindow();
                            }
                            else if (GrammarRules.MinimizeWindow.Any(x => x == speech))
                            {
                                MinimizeWindow();
                            }
                            else if (GrammarRules.NormalWindow.Any(x => x == speech))
                            {
                                NormalWindow();
                            }
                            else if (GrammarRules.CloseWindow.Any(x => x == speech))
                            {
                                CloseWindow();
                            }
                            break;
                        case "Process":
                            ActionProcess.OpenOrClose(speech);
                            break;

                        case "Commands":                            
                                Commands.Execute(speech);                                  
                            break;

                        case "calc":
                            if (conf >= 0.6)
                            {
                                Speak(Calculation.calcSolve(speech));
                            }
                            break;                        

                        case "Arduino":
                            ComandsArduino.Iniciar(speech);
                            break;

                        default:
                            Speaker.Speak(AIML.GetOutputChat(speech)); //pega resposta
                            break;
                    }
                }
            }            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        //metodo para volume do reconhecimento
        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }

        //metodo para reconhecimento rejeitado
        private void rej(object s, SpeechRecognitionRejectedEventArgs e)
        {
            if (isRitsuListening == true)
            {
                this.label1.ForeColor = Color.Red; //mudar cor da fonte quando nao reconhecido
                Speak("Não consigo entender, poderia repetir?");
            }           

        }

        #region Speak Methods
        private void Speak(string text)
        {
            //synthesizer.SelectVoice("IVONA 2 Vitória");
            synthesizer.SpeakAsync(text);
        }

        private void Speak(params string[] texts)
        {
            Random r = new Random();
            Speak(texts[r.Next(0, texts.Length)]);
        }

        private void speakStarted(object s, SpeakStartedEventArgs e)
        {
            lbl_Ritsu.Text = "Ritsu: ";
        }

        private void speakProgress(object s, SpeakProgressEventArgs e)
        {
            lbl_Ritsu.Text += e.Text + " ";
        }

        public static void SetVoice(string voice)
        {
            try
            {
                synthesizer.SelectVoice(voice);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro em Speaker: " + ex.Message);
            }
        }

        #endregion


        //metodo para minimizar janela
        private void MinimizeWindow()
        {
            //se a janela estiver normal ou maximizada
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                Speak("Minimizando a janela", "como quiser", "tudo bem");
            }
            else
            {
                Speak("Ja estou escondida", "Não quer me ver mesmo ein");
            }
        }

        private void MaximizeWindow()
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                Speak("Estou subindo", "OK", "Estou aqui", "Estou de volta");
            }
            else
            {
                Speak("Ja estou na sua frente", "Não posso ficar maior que isso");
            }
        }

        private void NormalWindow()
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                Speak("Certo", "OK", "Pronto");
            }
            else
            {
                Speak("Ja estou na sua frente", "Não tenho mais o que fazer");
            }
        }

        private void CloseWindow()
        {
            Speak("Tudo bem, foi bom estar com você");
            Thread.Sleep(4000); //tempo antes de continuar        
            //this.Close();    
            Application.Exit();
        }             
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }


    }
}
