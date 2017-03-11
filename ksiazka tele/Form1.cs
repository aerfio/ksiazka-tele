using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ksiazka_tele
{


    public partial class MainClass : Form
    {

        List<Person> listOfPeople = new List<Person>();
        List<string> zapasowa = new List<string>();
        int forParsing = 0;

        public MainClass()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pepePic.Visible ==false) //jak zmienilem tutaj i w designerze visible na enabled to nie dziala, idk why
                pepePic.Visible = true;
            else
            {
                pepePic.Visible= false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Person osoba = new Person();
            osoba.Name = textBox1.Text;
            osoba.Surname = textBox2.Text;

            if(!int.TryParse(textBox3.Text, out forParsing)){
                MessageBox.Show("Podaj nr telefonu, czyli liczbe!","Błąd");
                return;
            }
            osoba.TelNum = forParsing;
            listOfPeople.Add(osoba);
 
            listBox1.Items.Add(osoba.Surname);
            zapasowa.Add(osoba.Surname);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox2.Text = listBox1.SelectedItem.ToString();
                foreach (Person jacek in listOfPeople)
                {
                    if (jacek.Surname.Equals(listBox1.SelectedItem.ToString()))
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
            listBox1.Items.Clear();
            foreach (string s in temp)
            {
                listBox1.Items.Add(s);
            }
        }

        private void deleteButton(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listOfPeople.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.Update();
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