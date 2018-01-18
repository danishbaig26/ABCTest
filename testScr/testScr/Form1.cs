using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace testScr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string _filePath = @"C:\Users\Danish\Downloads\HeaderFooterSprite.png";

            //Image oImage = Image.FromFile(_filePath);

            //string resxFile = "CarResources.resx";
            //using (ResXResourceWriter resx = new ResXResourceWriter(resxFile))
            //{
            //    resx.AddResource("Title", oImage);
            //}

            //Image img = null;
            //using (ResXResourceReader resxReader = new ResXResourceReader(resxFile))
            //{
            //    foreach (DictionaryEntry entry in resxReader)
            //    {
            //        img = (Image)entry.Value;
            //    }
            //}
            

            //Bitmap image = new Bitmap(img);

            //this.ClientSize = new Size(image.Width, image.Height);

            //PictureBox pb = new PictureBox();
            //pb.Image = image;
            //pb.Dock = DockStyle.Fill;
            //this.Controls.Add(pb);
        }
    }
}
