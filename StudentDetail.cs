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
    public partial class StudentDetail : Form
    {
        private CONNECT conn = new CONNECT();

        public StudentDetail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn.getConnection();

            command.CommandText = "SELECT * FROM newadmission WHERE student_id='"+textBoxFirstName.Text+"'";

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            label14.Text = dataSet.Tables[0].Rows[0][1].ToString();
            label15.Text = dataSet.Tables[0].Rows[0][2].ToString();
            label16.Text = dataSet.Tables[0].Rows[0][4].ToString();
            label17.Text = dataSet.Tables[0].Rows[0][5].ToString();
            label18.Text = dataSet.Tables[0].Rows[0][0].ToString();
            label19.Text = dataSet.Tables[0].Rows[0][10].ToString();
            label20.Text = dataSet.Tables[0].Rows[0][9].ToString();
            label21.Text = dataSet.Tables[0].Rows[0][8].ToString();
            label22.Text = dataSet.Tables[0].Rows[0][7].ToString();
            label23.Text = dataSet.Tables[0].Rows[0][6].ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            label14.Text = "----------";
            label15.Text = "----------";
            label16.Text = "----------";
            label17.Text = "----------";
            label18.Text = "----------";
            label19.Text = "----------";
            label20.Text = "----------";
            label21.Text = "----------";
            label22.Text = "----------";
            label23.Text = "----------";

            textBoxFirstName.Text = "";

        }
    }
}
