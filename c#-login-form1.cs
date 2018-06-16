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

namespace FormsLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passwort = passwortImportieren(textBox1.Text);
            string eingabe = passwortVerschluesseln(textBox2.Text);

            bool vergleich = passwortVergleichen(eingabe, passwort);

            if (vergleich == true)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Passwort nicht korrekt");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private string passwortVerschluesseln(string eingabe)
        {
            char[] passwortarr = eingabe.ToCharArray();
            

            for (int i = 0; i < passwortarr.Length; i++) {
                int wert = Convert.ToInt32(passwortarr[i])+1;
                passwortarr[i] = Convert.ToChar(wert);
            }

            string passwort = new string(passwortarr);
            return passwort;
        }

        private string passwortImportieren(string benutzer)
        {
            string passwort= null;
            FileStream fs = new FileStream("geheim.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            
            while (sr.Peek() != -1) {
                if (sr.ReadLine() == benutzer) {
                    passwort = sr.ReadLine();
                }
            }

            sr.Close();
            fs.Close();
            return passwort;
        }

        private bool passwortVergleichen(string eingabe, string passwort) {

            if (eingabe == passwort)
            {
                return true;
            }
            else {
                return false;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*'; 
        }


    }
}
