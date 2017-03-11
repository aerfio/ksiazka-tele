﻿using System;
using System.Collections.Generic;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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
            bool suchPersonExists = listBox1.Items.Contains(textBox2.Text + " " + textBox1.Text);
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && int.TryParse(textBox3.Text, out forParsing))
            {
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void findBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string g in zapasowa)
            {
                listBox1.Items.Add(g);
            }

            List<string> temp = new List<string>();
            foreach (string s in listBox1.Items)
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
            StringBuilder temp = new StringBuilder();
            foreach (Person jacek in listOfPeople)

            {
            }
        }
    }

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