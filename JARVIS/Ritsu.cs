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
using RITSU.One_for_All;
using RITSU.BLL;
using System.Net;
using System.Net.Mail;
using S22.Imap;
using RITSU.DTO;
using System.IO.Ports;
using System.Media;


// Para sintese e preciso o SpeechSDK5.1, Windows 10 ja tem System.Speech

namespace RITSU
{
    public partial class Ritsu : Form
    {     
        //String para PORTCOM
        string DadosCOM;
        //Random 
        List<string> Falha = new List<string>() { "Não consigo entender, poderia repetir?" , "NANI?" , "IRINEU" , "PERGUNTA LÁ NO POSTO IPIRANGA"};
        Random rndAll = new Random();
        List<string> images = new List<string>() {"1.jpg", "2.jpg","3.jpg","4.jpg","5.jpg","6.png","7.jpg","8.png","9.jpg","10.png"};
              
        //Forms nulos
        private SelectVoz selectVoice = null;

        //Fim dos forms
        private SpeechRecognitionEngine engine; //engine de reconhecimento
        private static SpeechSynthesizer synthesizer = new SpeechSynthesizer(); //Sintetizador de palavras
        private bool isRitsuListening = true; //variavel para parar de ouvir

        public Ritsu()
        {
            InitializeComponent();
            alterarBack();          
        }    

        private void LoadSpeech() //metodo que carregara tudo
        {
            try
            {
                engine = new SpeechRecognitionEngine(); // Instancia do reconhecedor
                engine.SetInputToDefaultAudioDevice(); //microfone  
                //engine.RecognizeAsync();   

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

               path = "choices\\cCommands.txt";
               cmds = File.ReadAllLines(path, Encoding.UTF8);
               Choices cCommands = new Choices(cmds); // palavras ou frases que são comandos
                //OBS.: NECESSÁRIO RETIRAR TODOS OS ACENTOS

                //Deve-se iniciar com o carregar email
               path = "choices\\cEmail.txt";
               cmds = File.ReadAllLines(path, Encoding.UTF8);
               Choices cEmail = new Choices(cmds);         
                          
                
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

                GrammarBuilder gbEmail = new GrammarBuilder();
                gbEmail.Append(cEmail);

                /*
                GrammarBuilder gbDictation = new GrammarBuilder();
                gbDictation.AppendDictation();

                GrammarBuilder startStop = new GrammarBuilder();
                startStop.Append(new SemanticResultKey("StartDictation", new SemanticResultValue("Start Dictation", true)));
                startStop.Append(new SemanticResultKey("DictationInput", gbDictation));
                startStop.Append(new SemanticResultKey("StopDictation", new SemanticResultValue("Stop Dictation", false)));
                 */

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

                Grammar gEmail = new Grammar(gbEmail);
                gEmail.Name = "Email";

                /*
                Grammar gDictation = new Grammar(startStop);
                gDictation.Name = "Dicionario";
                 */

                // Lista de gramáticas 
                 List<Grammar> grammars = new List<Grammar>();
                 grammars.Add(gProcess);
                 grammars.Add(gCommands);
                 grammars.Add(gNumbers);
                 grammars.Add(gInputText);
                 grammars.Add(gArduino);
                 grammars.Add(gAIML);
                 grammars.Add(g_comandsOfSystem);
                 grammars.Add(gEmail);
                 //grammars.Add(gDictation);
                
                 
                //Carregar gramatica
                engine.LoadGrammar(g_comandsOfSystem);
                engine.LoadGrammar(gProcess);
                engine.LoadGrammar(gCommands);
                engine.LoadGrammar(gNumbers);
                engine.LoadGrammar(gInputText);
                engine.LoadGrammar(gArduino);
                engine.LoadGrammar(gAIML);
                engine.LoadGrammar(gEmail);
                //engine.LoadGrammar(gDictation);
                                
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
                MessageBox.Show("Ocorreu um erro no LoadSpeech() \n" + ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            Speak("Olá, estou pronta para te ajudar! ");
            Speak("Se não souber por onde começar diga: lista de comandos");
            AIML.ConfigAIMLFiles();
            alterarBack();
            
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
                recValidate.Image = Image.FromFile("true_false\\green_btn.png"); //mudar imagem quando reconhecido
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
                            alterarBack();
                            break;

                        case "Commands":                            
                                Commands.Execute(speech);
                                alterarBack();     
                            break;

                        case "calc":
                            if (conf >= 0.6)
                            {
                                Speak(Calculation.calcSolve(speech));
                                alterarBack();
                            }
                            break;                        

                        case "Arduino":
                            ComandsArduino.Iniciar(speech);
                            alterarBack();
                            break;

                        case "Email":
                            CommandsEmail.ExecuteEmail(speech);
                            alterarBack();
                            break;

                        default:
                            Speaker.Speak(AIML.GetOutputChat(speech)); //pega resposta
                            alterarBack();
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
                recValidate.Image = Image.FromFile("true_false\\red_btn.png"); //mudar cor da fonte quando nao reconhecido                 
                Speak(Falha[rndAll.Next(Falha.Count)]);
                alterarBack();
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
        /*
        public void Receive(GetSetLogin gsl)
        {
            //GetSetLogin gsl = new GetSetLogin();           

            Task.Run(() =>
            {
                using (ImapClient client = new ImapClient("imap.gmail.com", 993, gsl.Email,
                    gsl.Senha, AuthMethod.Login, true))
                {
                    if (client.Supports("IDLE") == false)
                    {
                        MessageBox.Show("Servidor não suporta IMAP IDLE");
                        return;
                    }
                    client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                    while (true) ;
                }
            });
        }

        static Ritsu f;
        static void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            

            clsMetodosBanco banco = new clsMetodosBanco();
            GetSetEmail gse = new GetSetEmail();
            DateTime time = DateTime.Now;

            //Speaker.Speak("Nova mensagem recebida!");
            MessageBox.Show("Nova mensagem recebida!");
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            f.Invoke((MethodInvoker)delegate
            {
                gse.Remetente = Convert.ToString(m.From);
                gse.Titulo = m.Subject;
                gse.Conteudo = m.Body;
                gse.Hora = time.Hour;
                try
                {
                    banco.CadastrarEmail(gse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //f.rtxtReceive.AppendText("De: " + m.From + "\n" + "Titulo: " + m.Subject + "\n" + "Conteúdo:" + m.Body + "\n");
            });
        }
        */

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }        

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            if(PortCOM.IsOpen != false)
                PortCOM.DataReceived += PortCOM_DataReceived;
        }

        void PortCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DadosCOM = PortCOM.ReadExisting();
            Thread.Sleep(10000);
            this.Invoke(new EventHandler(trataDadoRecebido));
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            if (DadosCOM == "1")
            {
                Speak("Olá, pode entrar!");
                Thread.Sleep(10000);
            }
        }

        private void alterarBack()
        {
            string image = images[rndAll.Next(images.Count())];
            if (image == "1.jpg" || image == "7.jpg")
            {                
                lbl_rec.ForeColor = Color.White;               
                lbl_Ritsu.ForeColor = Color.White;
                lbl_rec.Font = new Font(lbl_rec.Font, FontStyle.Regular);
                lbl_Ritsu.Font = new Font(lbl_Ritsu.Font, FontStyle.Regular);
            }
            else if (image == "6.png")
            {
                lbl_rec.ForeColor = Color.DarkGray;
                lbl_Ritsu.ForeColor = Color.DarkGray;
                lbl_rec.Font = new Font(lbl_rec.Font, FontStyle.Regular);
                lbl_Ritsu.Font = new Font(lbl_Ritsu.Font, FontStyle.Regular);
            }
            else
            {
                lbl_rec.ForeColor = Color.Black;          
                lbl_Ritsu.ForeColor = Color.Black;
                lbl_rec.Font = new Font(lbl_rec.Font, FontStyle.Bold);
                lbl_Ritsu.Font = new Font(lbl_Ritsu.Font, FontStyle.Bold);
            }
            BackgroundImage = Image.FromFile("images\\"+image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alterarBack();
        }


    }
}
