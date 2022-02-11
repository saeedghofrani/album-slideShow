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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace album_project
{
    public partial class Form1 : Form
    {
        public formMode selectionResult;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectionResult = formMode.Open;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectionResult = formMode.New;
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            selectionResult = formMode.Open;
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            selectionResult = formMode.New;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectionResult = formMode.slideshow;
            this.Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }

    public enum formMode
    {
        New,
        Open,
        slideshow
    }
}
