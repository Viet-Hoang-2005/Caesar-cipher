using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaesarCypher
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string Encrypt(string s, string key)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                int keyShift = key[i % key.Length] - 'A';
                if (char.IsLower(s[i]))
                    res += (char)((s[i] - 'a' + keyShift) % 26 + 'a');
                else if (char.IsUpper(s[i]))
                    res += (char)((s[i] - 'A' + keyShift) % 26 + 'A');
                else
                    res += s[i];
            }
            return res;
        }
        static string Decrypt(string s, string key)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                int keyShift = key[i % key.Length] - 'A';
                if (char.IsLower(s[i]))
                    res += (char)((s[i] - 'a' - keyShift + 26) % 26 + 'a');
                else if (char.IsUpper(s[i]))
                    res += (char)((s[i] - 'A' - keyShift + 26) % 26 + 'A');
                else
                    res += s[i];
            }
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = Encrypt(textBox1.Text, textBox2.Text.ToUpper());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = Decrypt(textBox1.Text, textBox2.Text.ToUpper());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Text = "";
            for (int i = 0; i < 26; i++)
            {
                char key = (char)(i + 'A');
                textBox3.Text += "Key: " + key + Environment.NewLine + Decrypt(textBox1.Text, key.ToString()) + Environment.NewLine;
            }
        }
    }
}
