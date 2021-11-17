using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace college_management_system
{
    public partial class AddTeacherForm : Form
    {
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            DateTime Dtdob = dateTimePicker1.Value;
            string dob = Dtdob.ToString();
            string classType = "";
            bool onlineIsChecked = radioButton1.Checked;
            bool FtfIsChecked = radioButton2.Checked;
            string dreamVacay = textBox5.Text;
            string favBook = textBox6.Text;
            string favMeal = textBox7.Text;
            string favTeam = textBox7.Text;
            string favApp = textBox9.Text;

            if (onlineIsChecked)
            {
                classType = "Online";
            }
            else if (FtfIsChecked)
            {
                classType = "Traditional";
            }
            else if (!onlineIsChecked && !FtfIsChecked)
            {
                MessageBox.Show("Please choose a class type", "Class Type Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter first name","First Name Not Entered",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

             if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter last name", "Last Name Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
             if(string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please enter dream vacation", "Dream Vacation Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please enter favorite book", "Favorite Book Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Please enter favorite meal", "Fave Meal Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             if(string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Please enter your favorite team", "Last Name Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Please enter favorite app", "Fave App Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Compare(Dtdob.Date,DateTime.Now.Date)>0)
            {
                MessageBox.Show("Please choose a valid date for your birthday.", "Valid Date Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = 127.0.0.1; Port=3306;Database=college_management_system;Uid=root;Pwd=Laguna_101;";
            MySqlCommand command = new MySqlCommand();
            
            command.Connection = conn;
            command.CommandText = "INSERT INTO newteacher (fname,lname,class_type,dob,teacher_id,dream_vacay,fav_book,fav_meal,fav_team,fav_app) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "','" + classType + "','" + dob + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "');";


            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            
            
                conn.Close();
                MessageBox.Show("Data Saved.", "New Teacher Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            





        }

        private void AddTeacherForm_Load(object sender, EventArgs e)
        {
            RANDOM random = new RANDOM();
            Random randomTwo = new Random();

            string randomGenerator = random.RandomString(5, false);
            textBox4.Text = randomGenerator + randomTwo.Next(85);

        }
    }
}
