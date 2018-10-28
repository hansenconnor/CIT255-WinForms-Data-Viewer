using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_WinForms_FlintstonesViewer
{
    public partial class DetailForm : Form
    {
        // Character _person = new Character();

        MediumPublication _publication = new MediumPublication();

        public DetailForm(MediumPublication publication)
        {
            InitializeComponent();
            _publication = publication;
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            lbl_FullName.Text = _publication.name;
            lbl_Age.Text = "Id: " + _publication.Id;
            lbl_Gender.Text = "url:" + _publication.url;
            lbl_Description.Text = _publication.description;
            if (_publication.imageUrl != null)
            {

                WebRequest req = WebRequest.Create(_publication.imageUrl);

                WebResponse res = req.GetResponse();

                Stream imgStream = res.GetResponseStream();

                //picBox_Photo.Image = Image.FromFile(@"Images/" + _publication.imageUrl);
                picBox_Photo.Image = Image.FromStream(imgStream);

                imgStream.Close();
            }
        }

        //public DetailForm(Character person)
        //{
        //    InitializeComponent();
        //    _person = person;
        //}

        //private void DetailForm_Load(object sender, EventArgs e)
        //{
        //    lbl_FullName.Text = _person.FullName();
        //    lbl_Age.Text = "Age: " + _person.Age.ToString();
        //    lbl_Gender.Text = "Gender:" + _person.Gender.ToString();
        //    lbl_Description.Text = _person.Description;
        //    if (_person.ImageFileName != null)
        //    {
        //        picBox_Photo.Image = Image.FromFile(@"Images/" + _person.ImageFileName);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
