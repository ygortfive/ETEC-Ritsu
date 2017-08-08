using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RITSU
{
    public partial class MediaPlayer : Form
    {
        private string[] supportedFiles = { ".mp3", ".mp4", ".wav", ".wmv", ".wma", ".avi" };
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void MediaPlayer_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        
        public void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayFile(ofd.FileName);
            }
        }

        public void PlayFile(string file)
        {
            WindowsMediaPlayer.URL = file;
            WindowsMediaPlayer.Ctlcontrols.play();
        }      
  
        public void Play()
        {
            WindowsMediaPlayer.Ctlcontrols.play();
            Speaker.Speak("Reproduzindo arquivo");
        }

        public void Pause()
        {
            WindowsMediaPlayer.Ctlcontrols.pause();
            Speaker.Speak("Pausando arquivo");
        }

        public void Stop()
        {
            WindowsMediaPlayer.Ctlcontrols.stop();
            Speaker.Speak("Arquivo interrompido");
        }

        public void NextFile()
        {
            WindowsMediaPlayer.Ctlcontrols.next();
            Speaker.Speak("Próximo arquivo");
        }

        public void BackFile()
        {
            WindowsMediaPlayer.Ctlcontrols.previous();
            Speaker.Speak("Arquivo anterior");
        }

        public void VolumeUp()
        {
            WindowsMediaPlayer.settings.volume += 10;
            Speaker.SayWithStatus("Aumentando volume");
        }

        public void VolumeDown()
        {
            WindowsMediaPlayer.settings.volume -= 10;
            Speaker.SayWithStatus("Diminuindo volume");
        }

        public void Mute()
        {
            WindowsMediaPlayer.settings.mute = true;
            Speaker.SayWithStatus("Mudo ligado");
        }

        public void UnMute()
        {
            WindowsMediaPlayer.settings.mute = false;
            Speaker.SayWithStatus("Mudo desligado");
        }

        public void FullScreen()
        {
            try
            {
                WindowsMediaPlayer.fullScreen = true;
                Speaker.Speak("media player em tela cheia");
            }
            catch (Exception ex)
            {
                Speaker.Speak(ex.Message);
            }
        }

        public void NotFullScreen()
        {
            try
            {
                WindowsMediaPlayer.fullScreen = false;
                Speaker.Speak("media player em tamanho normal");
            }
            catch (Exception ex)
            {
                Speaker.Speak(ex.Message);
            }
        }

        public void SayFileThatIsPlaying()
        {
            string file = WindowsMediaPlayer.currentMedia.sourceURL;
            if (WindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                string[] vet = file.Split('\\');
                Speaker.Speak(vet[vet.Length - 1]);
            }
        }

        public void OpenDirectory()
        {
            Speaker.Speak("certo, selecione um diretório para obter arquivos");
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                PlayDirectory(fd.SelectedPath); 
            }
        }

        public void PlayDirectory(string dir)
        {
            string[] files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories); // obter arquivos, de todos os formatos, e em sub-diretórios
            List<string> filesSupported = new List<string>();
            foreach (var file in files) // percorrer arquivos
            {
                foreach (var format in supportedFiles) // percorrer formatos suportados
                {
                    if (file.EndsWith(format)) // se o arquivo atual tiver extensão suportada
                    {
                        filesSupported.Add(file); // adicionar o arquivo
                    }
                }
            }
            PlayListFiles(filesSupported); // reproduzir lista de arquivos
        }

        public void PlayListFiles(List<string> files)
        {
            var playList = WindowsMediaPlayer.playlistCollection.newPlaylist("Lista de arquivos");

            foreach (var file in files) // percorrer arquivos
            {
                playList.appendItem(WindowsMediaPlayer.newMedia(file)); // adicionar arquivo na playlist
            }
            WindowsMediaPlayer.Ctlcontrols.play(); // iniciar lista de reprodução
            WindowsMediaPlayer.currentPlaylist = playList; // setar a playlist
            WindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(state); // Método
            // das ações que ocorrem no media player
            Speaker.Speak("reproduzindo lista de arquivos");

        }

        private void state(object s, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }
    }
}
