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
using Ionic.Zip;

namespace album_project
{
    public partial class open : Form
    {
        PictureAlbum album;
        Imageinfo selectedImageInfo;
        PictureBox selectedPictureBox;
        string Dirpath;
        int imgindex;
        public open()
        {
            InitializeComponent();
            var frm = new Form1();
            frm.ShowDialog();
            if (frm.selectionResult == formMode.New)
                newForm();
            else
                openForm();
            UpdateFormFromClass();
        }
        private void UpdateFormFromClass()
        {
            textBox3.Text = album.Name;
            textBox1.Text = album.Describtion;
            textBox2.Text = album.Password;
            int n = album.ImageInfos.Count;
            for (int i = 0; i < n; i++)
            {
                var pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                //pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Size = new Size(100, 160);
                pic.Image = album.ImageInfos[i].picture;
                pic.Click += Pic_Click;
                pic.Tag = i;
                flowLayoutPanel2.Controls.Add(pic);
            }
        }
        private void slideshow()
        {
            tabControl1.SelectedIndex = 2;
            album = new PictureAlbum();
        }
        private void newForm()
        {
            tabControl1.SelectedIndex = 1;
            album = new PictureAlbum();
        }

        private void openForm()
        {
            tabControl1.SelectedIndex = 1;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.saeed)|*.saeed";
            if (open.ShowDialog() == DialogResult.OK)
            {
                album = new PictureAlbum();
                using (ZipFile zip = ZipFile.Read(open.FileName))
                {
                    foreach (var entry in zip.Entries)
                        if (entry.Encryption != EncryptionAlgorithm.None)
                        {
                            Form2 passwordForm = new Form2();
                            passwordForm.ShowDialog();
                            album.Password = passwordForm.pass;
                            break;
                        }
                        else
                            album.Password = null;
                }
                album.open(open.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                int n = open.FileNames.Length;
                for (int i = 0; i < n; i++)
                {
                    var pic = new PictureBox();
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    //pic.BorderStyle = BorderStyle.FixedSingle;
                    pic.Size = new Size(100, 160);
                    pic.Image = new Bitmap(open.FileNames[i]);
                    pic.Click += Pic_Click;
                    pic.Tag = album.ImageInfos.Count;
                    var data = new Imageinfo();
                    data.picture = pic.Image;
                    data.location = open.FileNames[i];
                    album.ImageInfos.Add(data);
                    flowLayoutPanel2.Controls.Add(pic);
                }
            }
        }
        private void Pic_Click(object sender, EventArgs e)
        {
            selectedPictureBox = (PictureBox)sender;
            int index = Convert.ToInt32(selectedPictureBox.Tag);
            selectedImageInfo = album.ImageInfos[index];
            pictureBox1.Image = selectedImageInfo.picture;
            textBox4.Text = selectedImageInfo.location;
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            album.Name = textBox3.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            album.Describtion = textBox1.Text;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 8;
            textBox2.PasswordChar = '*';
            textBox1.CharacterCasing = CharacterCasing.Lower;
            album.Password = textBox2.Text;


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"Images\a.bmp");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("please enter your password", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "project file|*.saeed";
            if (save.ShowDialog() == DialogResult.OK)
                album.save(save.FileName);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (selectedImageInfo == null) return;
            album.ImageInfos.Remove(selectedImageInfo);
            selectedImageInfo = null;
            flowLayoutPanel2.Controls.Remove(selectedPictureBox);
            selectedPictureBox = null;
            pictureBox1.Image = null;
            textBox4.Text = "";
            for (int i = 0; i < flowLayoutPanel2.Controls.Count; i++)
                flowLayoutPanel2.Controls[i].Tag = i;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 8;
            textBox2.PasswordChar = '*';
            textBox1.CharacterCasing = CharacterCasing.Lower;
            album.Password = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                int n = open.FileNames.Length;
                for (int i = 0; i < n; i++)
                {
                    var pic = new PictureBox();
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    //pic.BorderStyle = BorderStyle.FixedSingle;
                    pic.Size = new Size(100, 160);
                    pic.Image = new Bitmap(open.FileNames[i]);
                    pic.Click += Pic_Click;
                    pic.Tag = album.ImageInfos.Count;
                    var data = new Imageinfo();
                    data.picture = pic.Image;
                    data.location = open.FileNames[i];
                    album.ImageInfos.Add(data);
                    flowLayoutPanel2.Controls.Add(pic);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("please enter your password", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "project file|*.saeed";
            if (save.ShowDialog() == DialogResult.OK)
                album.save(save.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedImageInfo == null) return;
            album.ImageInfos.Remove(selectedImageInfo);
            selectedImageInfo = null;
            flowLayoutPanel2.Controls.Remove(selectedPictureBox);
            selectedPictureBox = null;
            pictureBox1.Image = null;
            textBox4.Text = "";
            for (int i = 0; i < flowLayoutPanel2.Controls.Count; i++)
                flowLayoutPanel2.Controls[i].Tag = i;
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void open_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                comboBox1.Items.Add(i);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Dirpath, "*.Jpg");

            foreach (string file in files)

            {

                int pos = file.LastIndexOf("||");

                string FName = file.Substring(pos + 1);


            }



            button3.Enabled = true;

            button5.Enabled = button5.Enabled = true;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (imgindex > 0)
            {
                imgindex -= 1;
                if (imgindex == 0)
                {
                    button3.Enabled = false;
                }
            }
        }




        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            button5.PerformClick();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (imgindex > 0)
            {
                imgindex -= 1;
                if (imgindex == 0)
                {
                    button3.Enabled = false;
                }


            }
        }

        int c = 0;
        private void timer1_Tick_2(object sender, EventArgs e)
        {
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            c++;
            if (c == album.ImageInfos.Count)
                c = 0;
            Pic_Click(flowLayoutPanel2.Controls[c], null);
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            c--;
            if (c < 0)
                c = album.ImageInfos.Count - 1;
            Pic_Click(flowLayoutPanel2.Controls[c], null);

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = trackBar1.Value  + "";
            toolStripProgressBar1.Maximum = trackBar1.Value;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value += 10;
            toolStripStatusLabel1.Text = toolStripProgressBar1.Value + "";
            if (toolStripProgressBar1.Value >= toolStripProgressBar1.Maximum-10)
            {
                if (album.ImageInfos.Count == 0) return;
                Pic_Click(flowLayoutPanel2.Controls[c], null);
                c++;
                toolStripProgressBar1.Value = 0;
                if (c == album.ImageInfos.Count)
                    c = 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}