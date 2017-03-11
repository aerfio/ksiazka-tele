using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ksiazka_tele
{


    public partial class MainClass : Form
    {

        List<Person> listOfPeople = new List<Person>();
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
            foreach (Person jacek in listOfPeople)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Clear();
        }

        private void findBox_Click(object sender, EventArgs e)
        {
            findBox.SelectAll();
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