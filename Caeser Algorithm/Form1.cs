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

namespace Caeser_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Tất cả tệp tin|*.*");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string []k = textBox1.Text.Split('.');
            int dodai = k.Length;
            string xau = "File dinh dang:" + k[dodai - 1] + "|*." + k[dodai - 1];
            saveFileDialog1.Filter = (xau);
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            FileStream mo = new FileStream(textBox1.Text, FileMode.Open);
            FileStream dong = new FileStream(textBox2.Text, FileMode.Create);
            string s = textBox3.Text;
            
            
            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show("Bạn đang để trống số k", "Lỗi");
                return;
            }
            int k = int.Parse(textBox3.Text);
            if(k < 0 || k > 26)
            {
                MessageBox.Show("K không hợp lệ, không trong khoảng từ 1->26", "Lỗi");
                return;
            }
            try
            {
                long status = mo.Length;
                long tong = 0;
                progressBar1.Maximum = 100;
                progressBar1.Minimum = 0;
                
                while (status >= tong)
                { 
                    int ascii = mo.ReadByte();
                    ascii = (ascii + k) % 256;
                    dong.WriteByte((byte)ascii);
                    tong++;
                    int bar = (int)(tong / status) * 100;
                    
                    progressBar1.Value = bar;
                    
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Có lỗi trong việc đọc file hoặc ghi File","Thông báo");
                mo.Close();
                dong.Close();
            }
            mo.Close();
            dong.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream mo = new FileStream(textBox1.Text, FileMode.Open);
            FileStream dong = new FileStream(textBox2.Text, FileMode.Create);
            string s = textBox3.Text;
           
            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show("Bạn đang để trống số k", "Lỗi");
                return;
            }
            int k = int.Parse(textBox3.Text);
            if (k < 0 || k > 26)
            {
                MessageBox.Show("K không hợp lệ, không trong khoảng từ 1->26", "Lỗi");
                return;
            }

           
            try
            {
                long status = mo.Length;
                long tong = 0;
                progressBar1.Maximum = 100;
                progressBar1.Minimum = 0;
               
                while (status >= tong)
                {
                    int ascii = mo.ReadByte();
                    ascii -= k;
                    if (ascii < 0) ascii += 256;
                    dong.WriteByte((byte)ascii);
                    tong++;
                    int bar = (int)(tong / status) * 100;

                    progressBar1.Value = bar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                mo.Close();
                dong.Close();
            }
            mo.Close();
            dong.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sh = textBox3.Text;
            
            if (string.IsNullOrEmpty(sh))
            {
                MessageBox.Show("Bạn đang để trống số k", "Lỗi");
                return;
            }
            int k = int.Parse(textBox3.Text);
            if (k < 0 || k > 26)
            {
                MessageBox.Show("K không hợp lệ, không trong khoảng từ 1->26", "Lỗi");
                return;
            }

           
            StringBuilder toanbo = new StringBuilder(richTextBox1.Text);
            
            try
            {
                for(int i = 0; i < toanbo.Length;i++)
                {
                    toanbo[i] = (char)((toanbo[i] + k) % 256);
               
                }
                richTextBox2.Text = toanbo.ToString();
                MessageBox.Show("Đã mã hóa thành công", "Thông báo");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sh = textBox3.Text;

            if (string.IsNullOrEmpty(sh))
            {
                MessageBox.Show("Bạn đang để trống số k", "Lỗi");
                return;
            }
            int k = int.Parse(textBox3.Text);
            if (k < 0 || k > 26)
            {
                MessageBox.Show("K không hợp lệ, không trong khoảng từ 1->26", "Lỗi");
                return;
            }


            StringBuilder toanbo = new StringBuilder(richTextBox2.Text);

            try
            {
                for (int i = 0; i < toanbo.Length; i++)
                {
                    int h = toanbo[i] - k;
                    if (h < 0) h += 256;
                    toanbo[i] = (char)(h);

                }
                richTextBox1.Text = toanbo.ToString();
                MessageBox.Show("Đã giải mã thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
