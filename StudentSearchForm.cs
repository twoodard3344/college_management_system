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
    public partial class StudentSearchForm : Form
    {
        private CONNECT conn = new CONNECT();

        public StudentSearchForm()
        {
            InitializeComponent();
        }

        private void StudentSearchForm_Load(object sender, EventArgs e)
        {
           
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT newadmission.student_id as StudentID,newadmission.registration_id as RegID, newadmission.fname as FirstName, newadmission.lname as LastName,newadmission.dob as DOB, newadmission.mobile as MobileNo, newadmission.prog as Program, newadmission.major as Major, fees.fees as Fees FROM newadmission inner join fees on newadmission.student_id=fees.student_id;";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT * FROM newadmission WHERE student_id='" + textBoxFirstName.Text.ToUpper() + "';";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }

}