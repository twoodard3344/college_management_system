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
    public partial class DeleteStudentFormcs : Form
    {
        private CONNECT conn = new CONNECT();

        public DeleteStudentFormcs()
        {
            InitializeComponent();
        }

        private void DeleteStudentFormcs_Load(object sender, EventArgs e)
        {
            
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT * FROM newadmission;";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete your data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)==DialogResult.OK)
            {

                
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn.getConnection();

                string deleteQuery = "DELETE FROM newadmission WHERE student_id='" + textBoxFirstName.Text.ToUpper() + "';";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                MessageBox.Show("Data deleted successfully.", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
