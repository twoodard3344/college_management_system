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
    public partial class TeacherSearch : Form
    {
        private CONNECT conn = new CONNECT();

        public TeacherSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT * FROM newteacher WHERE teacher_id='" + textBoxFirstName.Text.ToUpper() + "';";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void TeacherSearch_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT newteacher.fname as First_Name, newteacher.lname as Last_name, newteacher.class_type as Class_Type, newteacher.dob as DOB, newteacher.teacher_id as TeacherID, newteacher.dream_vacay as Dream_Vacay,newteacher.fav_book as Fav_Book, newteacher.fav_meal as Fav_Meal, newteacher.fav_team as Fav_Team, newteacher.fav_app as Fav_App FROM newteacher;";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

        }
    }
}
