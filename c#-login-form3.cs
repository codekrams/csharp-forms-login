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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool name = benutzernamePruefen(textBox1.Text);

            bool passwort = passwortPruefen();

            if (name == true && passwort == true)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
                datenSpeichern(textBox1.Text, textBox3.Text);
            }
            else {
                MessageBox.Show("Benutzernamen oder Passwort falsch. \nBitte Eingaben ändern");
            }
        }



    private bool benutzernamePruefen(string name) {

            int pruef=0;

            FileStream fs = new FileStream("geheim.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);


            while (sr.Peek() != -1)
            {
                if (sr.ReadLine() == name)
                {
                    label4.Text = "Benutzername vergeben";
                    pruef=0;
                    break;
                }
                else {
                    label4.Text = "Benutzername verfügbar";
                    pruef =1;
                }
            }

            sr.Close();
            fs.Close();

            if (pruef == 0)
            {
                return false;
            }
            else {
                return true;
            }

    }

    private bool passwortPruefen()
    {


            if (String.IsNullOrEmpty(textBox2.Text))
            {
                return false;
            }
            else if (textBox2.Text == textBox3.Text)
            {
                label5.Text = "Passwort stimmt überein";
                return true;
            }
            else
            {
                label5.Text = "Passwort stimmt nicht überein";
                return false;
            }
     }            
        

    private void datenSpeichern(string name, string eingabe) {

            string passwort = passwortVerschluesseln(eingabe);
            

            FileStream fs = new FileStream("geheim.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);

            sr.WriteLine(name);
            sr.WriteLine(passwort);

            sr.Close();
            fs.Close();
        }

    private string passwortVerschluesseln(string eingabe)
        {
            char[] passwortarr = eingabe.ToCharArray();


            for (int i = 0; i < passwortarr.Length; i++)
            {
                int wert = Convert.ToInt32(passwortarr[i]) + 1;
                passwortarr[i] = Convert.ToChar(wert);
            }

            string passwort = new string(passwortarr);
            return passwort;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }
    }

  
}
