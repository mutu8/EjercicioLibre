using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioLibre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Comentario realizado por Steven");
            using (OpenFileDialog open = new OpenFileDialog() { Multiselect = true, Filter = "MP3|*.mp3|MP4|*.mp4" }) 
            {
                if (open.ShowDialog() == DialogResult.OK) 
                {
                    List<string> archivos = new List<string>();
                    foreach(string nombreArchivo in open.FileNames) 
                    {
                        FileInfo f = new FileInfo(nombreArchivo);
                        archivos.Add(f.FullName + "\n");
                    }
                    listBox1.DataSource = archivos;
                }
            }

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 1) 
            {
                if(listBox1.SelectedIndex != listBox1.Items.Count - 1) 
                {
                    BeginInvoke(new Action(()=>{ listBox1.SelectedIndex = listBox1.SelectedIndex + 1; })); 
                }
                else 
                {
                    BeginInvoke(new Action(() => { listBox1.SelectedIndex = listBox1.SelectedIndex + 1; }));
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = listBox1.Items[listBox1.SelectedIndex].ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
