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
            if (pepePic.Visible == false)
                pepePic.Visible = true;
            else
            {
                pepePic.Visible = false;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
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
            
            listOfPeople.Add(osoba);
 
            listBox1.Items.Add(osoba.Surname);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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