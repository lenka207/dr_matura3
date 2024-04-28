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
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.LinkLabel;


namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        //refresh dugme u formi 1 - top
        // smerovi opsti itd - top
        // cuvanje i prolaz kroz ucenike - radi sem dugmica > - top

        List<List<string>> templateovi;
        List<List<string>> templateovi1;
        public string imedat = @"C:\Users\Bane\Downloads\OOP\oop.txt";
        public bool b = false;
        public bool a = false;
        public int linija = 0;

        public Form1()
        {
            InitializeComponent();
            templateovi1 = UcitajTemplateovi1(@"C:\Users\Bane\Downloads\OOP\oops.txt");

        }
        private void UT(List<List<string>> r)
        {
            foreach (var red in r)
            {
                try
                {
                    cb1.Items.Add(red[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ostecen fajl");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2(this);
            Form2.Show();
        }

        private void cb1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            comboBox2.Text = templateovi[cb.SelectedIndex][1];
            comboBox3.Text = templateovi[cb.SelectedIndex][2];
            comboBox1.Text = templateovi[cb.SelectedIndex][3];
            comboBox4.Text = templateovi[cb.SelectedIndex][4];
            comboBox5.Text = templateovi[cb.SelectedIndex][5];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            templateovi.Clear();
            File.Delete(imedat);
            cb1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cb1.Items.Clear();
            if (File.Exists(imedat))
            {
                templateovi = CSVcitac.Ucitaj(imedat);
                UT(templateovi);
            }
            else
            {
                MessageBox.Show("File not found: " + imedat);
            }
            templateovi1 = UcitajTemplateovi1(@"C:\Users\Bane\Downloads\OOP\oops.txt");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadTextFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {

                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    comboBox1.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox4.SelectedIndex;

            comboBox1.Items.Clear();

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

        private List<string> proveriniz()
        {
            List<string> r = new List<string>();
            r.Add(cb1.Text);
            r.Add(comboBox1.Text);
            r.Add(comboBox2.Text);
            r.Add(comboBox3.Text);
            r.Add(comboBox4.Text);
            r.Add(comboBox5.Text);
            r.Add(textBox1.Text);
            r.Add(textBox2.Text);
            r.Add(textBox3.Text);
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


        private void button8_Click(object sender, EventArgs e)
        {
            List<string> podaci = proveriniz();
            if (podaci.Count == 0)
                return;
            Form1.Snimi1(podaci, @"C:\Users\Bane\Downloads\OOP\oops.txt");
           templateovi1 = UcitajTemplateovi1(@"C:\Users\Bane\Downloads\OOP\oops.txt");
            MessageBox.Show("gotovo");
        }
        private void UU(List<List<string>> r)
        {
            
            int index = 0;
            bool c = false;
            if (linija != 0)
            {
                index = linija - 1; // Postavljamo indeks na trenutnu liniju
            }
            if (b == true)
            {
                var red = templateovi1.Last();
                
                comboBox1.Text = red[1];
                comboBox2.Text = red[2];
                comboBox3.Text = red[3];
                comboBox4.Text = red[4];
                comboBox5.Text = red[5];
                textBox1.Text = red[6];
                textBox2.Text = red[7];
                textBox3.Text = red[8];
                c = true;
                //b = false;
                
                index = templateovi1.Last().Count;

            }
            
            if (index >= 0 && index < r.Count && c == false)
            {
                var red = r[index];

                comboBox1.Text = red[1];
                comboBox2.Text = red[2];
                comboBox3.Text = red[3];
                comboBox4.Text = red[4];
                comboBox5.Text = red[5];
                textBox1.Text = red[6];
                textBox2.Text = red[7];
                textBox3.Text = red[8];
                
            }
            else
            {
                
                MessageBox.Show("Nema više podataka za prikaz.");
                linija = templateovi1.Count;
                
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                linija++;
                UU(templateovi1);
            }
               
            
            
        }
            
        private void button4_Click(object sender, EventArgs e)
        {
            b = false;
            linija = 1;
            UU(templateovi1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
            comboBox5.Text = string.Empty;
            
            cb1.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (linija == 1)
            {
                UU(templateovi1);
            }
            else
            {
                b = false;
                linija--;
                UU(templateovi1);
            }
              
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            b = true;
            UU(templateovi1);
        }
        private List<List<string>> UcitajTemplateovi1(string filePath)
        {
            List<List<string>> templateovi1 = new List<List<string>>();

            if (File.Exists(filePath))
            {
                templateovi1 = CSVcitac1.Ucitaj1(filePath);
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }

            return templateovi1;
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selectedIndex = comboBox4.SelectedIndex;
            
            comboBox1.Items.Clear();
            if (comboBox4.Text == "opšta matura")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop0.txt"); }
            if (comboBox4.Text == "poljoprivreda,proizvodnja i prerada hrane")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop1.txt"); }
            if (comboBox4.Text == "šumarstvo i obrada drveta")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop2.txt"); }
            if (comboBox4.Text == "geologija, rudarstvo i metalurgija")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop3.txt"); }
            if (comboBox4.Text == "mašinstvo i obrada metala")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop4.txt"); }

            if (comboBox4.Text == "elektrotehnika")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop5.txt"); }
            if (comboBox4.Text == "hemija, nemetali i grafičarstvo")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop6.txt"); }
            if (comboBox4.Text == "tekstilstvo i kožarstvo")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop7.txt"); }
            if (comboBox4.Text == "geodezija i građevinarstvo")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop8.txt"); }
            if (comboBox4.Text == "saobraćaj")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop9.txt"); }
            if (comboBox4.Text == "trgovina, ugostiteljstvo i turizam")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop10.txt"); }
            if (comboBox4.Text == "ekonomija, pravo i administracija")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop11.txt"); }
            if (comboBox4.Text == "zdravstvo i socijalna zaštita")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop12.txt"); }
            if (comboBox4.Text == "lične usluge")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop13.txt"); }
            if (comboBox4.Text == "umetnička matura")
            { LoadTextFromFile(@"C:\Users\Bane\Downloads\OOP\oop14.txt"); }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
