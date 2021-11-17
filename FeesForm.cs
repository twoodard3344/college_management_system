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
    public partial class FeesForm : Form
    {
        private CONNECT conn = new CONNECT();

        public FeesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT * FROM fees WHERE student_id='" + textBox3.Text + "' ";

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if(dataSet.Tables[0].Rows.Count == 0)
            {
               
                MySqlCommand commandTwo = new MySqlCommand();
                commandTwo.Connection = conn.getConnection();

                commandTwo.CommandText = "INSERT INTO fees (student_id,fees) VALUES ('" + textBox3.Text + "','" + textBox4.Text + "')";
                MySqlDataAdapter dataAdapterTwo = new MySqlDataAdapter(commandTwo);
                DataSet dataSetTwo = new DataSet();
                dataAdapterTwo.Fill(dataSetTwo);

                if (MessageBox.Show("Fees Submission Submitted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    textBoxRegID.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }

            else
            {
                MessageBox.Show("Fees have already been submitted", "Duplicate Fee Submission", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxRegID.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }


            
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
           

            if (textBoxRegID.Text != "")
            {

               
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn.getConnection();

                command.CommandText = "SELECT fname, lname, student_id FROM newadmission WHERE registration_id=" + textBoxRegID.Text + ";";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                if(dataSet.Tables[0].Rows.Count != 0)
                {
                    textBox1.Text = dataSet.Tables[0].Rows[0][0].ToString();
                    textBox2.Text = dataSet.Tables[0].Rows[0][1].ToString();
                    textBox3.Text = dataSet.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }


               

            }

            

        }
    }
}
