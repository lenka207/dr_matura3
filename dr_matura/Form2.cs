using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        Form1 pocetnaForma;
        public Form2(Form1 pocetnaForma)
        {
            this.pocetnaForma = pocetnaForma;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> podaci = proveriniz();
            if (podaci.Count == 0)
                return;
            Form2.Snimi1(podaci, @"C:\Users\Bane\Downloads\OOP\oop.txt");
            MessageBox.Show("gotovo");
        }

        private List<string> proveriniz()
        {
            List<string> r = new List<string>();
            r.Add(textBox1.Text);
            r.Add(comboBox1.Text);
            r.Add(comboBox2.Text);
            r.Add(comboBox3.Text); 
            r.Add(comboBox4.Text); 
            r.Add(comboBox5.Text); 
            foreach (string elem in r)
            {
                if (string.IsNullOrWhiteSpace(elem))
                {
                    MessageBox.Show("Unesite tekst koji želite spremiti u Notepad.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<string>();
                }
            }

            return r;
        }

        public static void Snimi1(List<string> tx, string imeDatoteke)
        {
            StringBuilder csv = new StringBuilder();
            // List: [ime1 nesto zdravo]
            foreach (string elem in tx)
            {
                csv.Append("\"");
                csv.Append(elem);
                csv.Append("\"");
                csv.Append(",");
            }
            // csv: "ime1","nesto","zdravo",
            csv.Replace(",", "\n", csv.Length - 1, 1);
            try
            {
                File.AppendAllText(imeDatoteke, csv.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom spremanja datoteke: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int selectedIndex = comboBox4.SelectedIndex;

            comboBox3.Items.Clear();

            switch (selectedIndex)
            {
                case 0:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop0.txt");
                    break;
                case 1:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop1.txt");
                    break;
                case 2:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop2.txt");
                    break;
                case 3:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop3.txt");
                    break;
                case 4:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop4.txt");
                    break;
                case 5:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop5.txt");
                    break;
                case 6:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop6.txt");
                    break;
                case 7:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop7.txt");
                    break;
                case 8:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop8.txt");
                    break;
                case 9:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop9.txt");
                    break;
                case 10:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop10.txt");
                    break;
                case 11:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop11.txt");
                    break;
                case 12:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop12.txt");
                    break;
                case 13:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop13.txt");
                    break;
                case 14:
                    LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop14.txt");
                    break;
            }
        }
        public static class CSVcitac1
        {
            public static List<List<string>> Ucitaj1(string imedatoteke)
            {
                var r = new List<List<string>>();
                using (var MyReader = new TextFieldParser(imedatoteke))
                {
                    MyReader.TextFieldType = FieldType.Delimited;
                    MyReader.SetDelimiters(",");
                    while (!MyReader.EndOfData)
                    {
                        var red = new List<string>();
                        string[] fields = MyReader.ReadFields();
                        foreach (string elem in fields)
                        {
                            red.Add(elem);
                        }
                        r.Add(red);
                    }
                }
                return r;
            }
        }
        private void LoadTextFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    comboBox3.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
