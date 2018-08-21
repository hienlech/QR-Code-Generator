using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace QR_Code_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEnCrypt_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrgen = new QRCodeGenerator();
            QRCodeData qrData = qrgen.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qrData);
            Bitmap qrresult = qRCode.GetGraphic(20);
            pictureBox1.Image = qrresult;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image!=null)
            {
                saveFileDialog.Filter = "JPeg Image|*.jpg";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();
                string s = saveFileDialog.FileName;
                if (s != "")
                {
                    pictureBox1.Image.Save(s);
                    MessageBox.Show("Đã Lưu", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Chưa được Lưu", "Thông Báo");
                }
            }
            
            //Cái gì đó đã bị sửa đổi
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pictureBox1.Image = null;
        }
    }
}
