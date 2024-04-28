using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;

namespace WindowsFormsApp8
{
    public static class CSVcitac
    {
        public static List<List<string>> Ucitaj(string imedatoteke)
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

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
