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
    public partial class NewSudentForm : Form
    {
        private CONNECT conn = new CONNECT();

        public NewSudentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBoxFirstName.Text;
            string lname = textBoxLastName.Text;
            string student_status = "";
            bool isNSChecked = radioButtonNew.Checked;
            bool isCSChecked = radioButtonCStudent.Checked;
            bool isFSChecked = radioButtonFormer.Checked;
            if (isNSChecked)
            {
                student_status = "New Student";
            }
            if(isCSChecked)
            {
                student_status = "Continuing Student";
            }
            if(isFSChecked)
            {
                student_status = "Former Student";
            }
            if(!isNSChecked && !isCSChecked && !isFSChecked)
            {
                MessageBox.Show("Please choose your student status.", "Student Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            DateTime Dtdob = dateTimePickerDOB.Value;

            string dob = Dtdob.ToString();

            if (DateTime.Compare(Dtdob.Date, DateTime.Now.Date) > 0)
            {
                MessageBox.Show("Please choose a valid date for your birthday.", "Valid Date Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool accAge = (DateTime.Now - Dtdob).TotalDays> 6570;

            if(!accAge)
            {
                MessageBox.Show("Please choose a valid age for your birthday.", "Age Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Int64 mobileNo = Int64.Parse(textBoxMbileNo.Text);
            string student_id = textboxStudentID.Text;
            string semester = comboBoxSemester.Text;
            string program = comboBoxProgramming.Text;
            string major = textBoxMajor.Text;
            string address = richTextBox1.Text;

            CONNECT conn = new CONNECT();
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();
            command.CommandText = "INSERT INTO newadmission (fname, lname, student_status,dob,mobile,student_id,semester,prog,major,address) VALUES('" + fname + "','" + lname + "','" + student_status + "','" + dob + "','" + mobileNo + "','" + student_id + "','" + semester + "','" + program + "','" + major + "','"+address +"');";

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            

            MessageBox.Show("Data saved. Please remember your registration ID and Student ID", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.Close();
            LoginPage.ActiveForm.Show();

        }

        private void NewSudentForm_Load(object sender, EventArgs e)
        {
            RANDOM random = new RANDOM();
            Random randomTwo = new Random();

            string randomGenerator = random.RandomString(6, false);
            textboxStudentID.Text = randomGenerator + randomTwo.Next(85);


           
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();
            command.CommandText = "SELECT max(registration_id) FROM newadmission;";

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            Int64 regId = Convert.ToInt64(dataSet.Tables[0].Rows[0][0]);
            label13.Text = (regId +1).ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxMajor.Clear();
            textBoxMbileNo.Clear();
            textboxStudentID.Clear();
            richTextBox1.Clear();
            radioButtonCStudent.Checked = false;
            radioButtonFormer.Checked = false;
            radioButtonNew.Checked = false;
            dateTimePickerDOB.Text = DateTime.Now.ToString();
        }
    }
}
