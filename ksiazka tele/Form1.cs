using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace ksiazka_tele
{
    public partial class MainClass : Form
    {
        private List<Person> listOfPeople = new List<Person>();
        private List<string> zapasowa = new List<string>();
        private int forParsing = 0;

        public MainClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pepePic.Visible == false) //jak zmienilem tutaj i w designerze visible na enabled to nie dziala, idk why
                pepePic.Visible = true;
            else
            {
                pepePic.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool whiteSpaceInside1 = textBox1.Text.Contains(" ");
            bool whiteSpaceInside2 = textBox2.Text.Contains(" ");
            bool suchPersonExists = listBox1.Items.Contains(textBox2.Text + " " + textBox1.Text);
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && int.TryParse(textBox3.Text, out forParsing))
            {
                if(whiteSpaceInside1 || whiteSpaceInside2)
                {
                    MessageBox.Show("imie albo nazwisko ze spacja wtf");
                    return;
                }
                if (suchPersonExists)
                {
                    MessageBox.Show("Błąd! Taka osoba już istnieje.", "Error");
                    return;
                }
                else
                {
                    Person osoba = new Person();
                    osoba.Name = textBox1.Text;
                    osoba.Surname = textBox2.Text;
                    osoba.TelNum = forParsing;
                    listOfPeople.Add(osoba);

                    listBox1.Items.Add(osoba.Surname + " " + osoba.Name);
                    zapasowa.Add(osoba.Surname + " " + osoba.Name);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Błąd! Złe dane.", "Error");
                return;
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Char delimiter = ' ';
                String[] substrings = listBox1.SelectedItem.ToString().Split(delimiter);

                textBox2.Text = substrings[0];
                foreach (Person jacek in listOfPeople)
                {
                    if (jacek.Surname.Equals(substrings[0]) && jacek.Name.Equals(substrings[1]))
                    {
                        textBox1.Text = jacek.Name;
                        textBox3.Text = jacek.TelNum.ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("jakis tutorial tutaj moglbym dac, ale chuj, dacie se rade", "Help");
        }

        private void findBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            List<string> temp = new List<string>();
            foreach (string s in zapasowa)
            {
                if (s.ToLower().Contains(findBox.Text.ToLower()))
                {
                    temp.Add(s);
                }
            }
            foreach (string s in temp)
            {
                listBox1.Items.Add(s);
            }
        }

        private void deleteButton(object sender, EventArgs e)
        {
            List<int> temp = new List<int>();
            foreach (string s in listBox1.SelectedItems)
            {
                temp.Add(listBox1.Items.IndexOf(s));
            }

            if (listBox1.SelectedIndex != -1)
            {
                //listOfPeople.RemoveAt(listBox1.SelectedIndex);
                //zapasowa.RemoveAt(listBox1.SelectedIndex);
                //listBox1.Items.Remove(listBox1.SelectedItem);
                //listBox1.Update();

                listOfPeople.RemoveAll(p => temp.Contains(listOfPeople.IndexOf(p)));
                zapasowa.RemoveAll(x => temp.Contains(zapasowa.IndexOf(x)));
                int koniec = listBox1.SelectedItems.Count;

                for (int i = 0; i < koniec; i++)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
            }
        }

        private void findBox_Click(object sender, EventArgs e)
        {
            findBox.SelectAll();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            //tworzymy kolekcje stringow ktore beda vcf'ami
            List<string> listaKontaktow = new List<string>();
            StringBuilder temp = new StringBuilder();
            foreach (Person per in listOfPeople)
            {
                string N = per.Surname + " " + per.Name;
                temp.Append("BEGIN:VCARD" + System.Environment.NewLine);
                temp.Append("VERSION:2.1" + System.Environment.NewLine);
                temp.Append("N:" + N.Replace(" ", ";") + ";" + System.Environment.NewLine);
                temp.Append("FN:" + N + System.Environment.NewLine);
                temp.Append("TEL;CELL:" + per.TelNum + System.Environment.NewLine);
                temp.Append("END:VCARD" + System.Environment.NewLine);
                listaKontaktow.Add(temp.ToString());
                temp.Clear();
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //int j = 0;
            //foreach (string s in listaKontaktow)
            //{
            //    int poczatek = s.IndexOf("FN:");
            //    int koniec = s.IndexOf("\r\nT");
            //    string fileName = s.Substring(poczatek + 3, koniec - poczatek - 3); //+ "\r\nT".Length
            //    File.WriteAllText(path + "\\"+fileName+j.ToString()+".vcf", s.ToString());
            //    j++;
            //}
            

            int i = 0;
            do
            {
                if (!File.Exists(path + "\\archiwum_z_programu_puczka" + i.ToString() + ".zip"))
                {
                    ZipArchive zip = ZipFile.Open(path + "\\archiwum_z_programu_puczka" + i.ToString() + ".zip", ZipArchiveMode.Create);
                    foreach (string file in listaKontaktow)
                    {
                        int poczatek = file.IndexOf("FN:");
                        int koniec = file.IndexOf("\r\nT");
                        string fileName = file.Substring(poczatek + 3, koniec - poczatek - 3); //+ "\r\nT".Length

                        ZipArchiveEntry readmeEntry = zip.CreateEntry(fileName + ".vcf");
                        using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                        {
                            writer.Write(file);
                        } 
                    }
                        zip.Dispose();
                        break;

                    }
                    i++;
                } while (true) ;
            
            }
        //http://www.codeguru.com/csharp/.net/zip-and-unzip-files-programmatically-in-c.htm
    

public class Person
{
    private string name;
    private string surname;
    private int telNum;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Surname
    {
        get
        {
            return surname;
        }

        set
        {
            surname = value;
        }
    }

    public int TelNum
    {
        get
        {
            return telNum;
        }

        set
        {
            telNum = value;
        }
    }
}
}
}