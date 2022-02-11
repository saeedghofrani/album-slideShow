using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace album_project
{
    public class PictureAlbum
    {
        public PictureAlbum()
        {
            ImageInfos = new List<Imageinfo> { };
            _creation = DateTime.Now;
            Name = "Untitled";
            Creator = "Unknown";
            Describtion = "explain about the picture";
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        private DateTime _creation;
        public DateTime Creationdate
        {
            get { return _creation; }
        }
        public string Describtion { get; set; }
        public List<Imageinfo> ImageInfos { get; set; }
        public string Password { get; set; }
        public void save(string filename)
        {
            string result = Path.GetTempPath();
            string foldername = "albumapp";
            string path = result + foldername;
            // If directory does not exist, create it. 
            if (Directory.Exists(path))
            {
                // idk
                Directory.Delete(path, true);
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            for (int i = 0; i < ImageInfos.Count; i++)
            {
                var img = ImageInfos[i];
                Copy(img.location, path + "\\" + (i + 1) + ".png");
            }
            writeSettingFile(path + "\\settings.txt");
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = Password;
                zip.AddDirectory(path);
                zip.Save(filename);
            }
        }

        public void open(string filename)
        {
            string result = Path.GetTempPath();
            string foldername = "albumapp";
            string path = result + foldername;
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (ZipFile zip = ZipFile.Read(filename))
            {
                foreach (ZipEntry e in zip)
                {
                    if (Password != null)
                        e.ExtractWithPassword(path, Password);
                    else
                        e.Extract(path);
                }
            }
            using (StreamReader file = new StreamReader(path+"\\settings.txt"))
            {
                Name = file.ReadLine();
                Creator = file.ReadLine();
                _creation = Convert.ToDateTime(file.ReadLine());
                Describtion = file.ReadLine();
                Password = file.ReadLine();
                int counter = 0;
                while (true)
                {
                    var line = file.ReadLine();
                    if (line == null || line == "")
                        break;
                    counter++;
                    Imageinfo img = new Imageinfo();
                    img.location = line;
                    using (var bmpTemp = new Bitmap(path + "\\" + (counter) + ".png"))
                    {
                        img.picture = new Bitmap(bmpTemp);
                    }
                    ImageInfos.Add(img);
                }
            }
        }

        private void writeSettingFile(string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(Name);
                file.WriteLine(Creator);
                file.WriteLine(Creationdate);
                file.WriteLine(Describtion);
                file.WriteLine(Password);
                for (int i = 0; i < ImageInfos.Count; i++)
                {
                    var sim = ImageInfos[i];
                    file.WriteLine(sim.location);
                }
            }
        }
        private void Copy(string source, string destination)
        {
            File.Copy(source, destination, true);
        }
    }
}

