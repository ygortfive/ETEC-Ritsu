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
//using System.Threading.Tasks;

namespace RITSU
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }


        private void Notepad_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }        

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseNotepad();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFont();
        }
    
    
        //Metodos

        public void OpenFile()
        {
            try
            {
                OpenFileDialog arq = new OpenFileDialog();

                if (arq.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = new StreamReader(arq.FileName);
                    richNotepad.Text = reader.ReadToEnd();
                    
                }
            }
            catch (Exception ex)
            {
                Speaker.Speak("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public void SaveFile()
        {
            try
            {
                SaveFileDialog sarq = new SaveFileDialog();

                if (sarq.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(sarq.FileName + ".txt");

                    if (!string.IsNullOrEmpty(richNotepad.Text)) //Se o arquivo não estiver vazio que iremos salvar
                    {
                        writer.Write(richNotepad.Text);
                        writer.Close();
                        Speaker.Speak("Arquivo salvo com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                Speaker.Speak("Ocorreu o seguinte erro: " + ex.Message);
            }

        }

        public void OpenFont()
        {
            FontDialog fontes = new FontDialog();

            if (fontes.ShowDialog() == DialogResult.OK)
            {
                this.richNotepad.Font = fontes.Font;
            }
        }

        public void CloseNotepad()
        {
            this.Close();
        }

        //Adicionar texto

        //Para ir para o form1 tem que ser static, mas para atribuir a richNotepad.Text não pode ser static
        
        
        private void richNotepad_TextChanged(object sender, EventArgs e)
        {
            
        }       
     
    
    }
}
