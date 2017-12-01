﻿using System;
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
    public partial class HelpCommands : Form
    {
        string path;
        
        public HelpCommands()
        {
            InitializeComponent();            
        }

        private void comandosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listCommands.Items.Clear();
            path = "choices\\cProcess.txt";
            string[] cmds = File.ReadAllLines(path, Encoding.UTF8);
            listCommands.Visible = true;            
            foreach (string x in cmds)
            {
                listCommands.Items.Add(x);                
            }
        }

        private void softwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listCommands.Items.Clear();
            path = "choices\\cCommands.txt";
            string[] cmds = File.ReadAllLines(path, Encoding.UTF8);
            listCommands.Visible = true;
            foreach (string x in cmds)
            {               
                listCommands.Items.Add(x);
            }
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listCommands.Items.Clear();
            path = "choices\\cEmail.txt";
            string[] cmds = File.ReadAllLines(path, Encoding.UTF8);
            listCommands.Visible = true;
            foreach (string x in cmds)
            {
                listCommands.Items.Add(x);
            }
        }
       
    }
}
