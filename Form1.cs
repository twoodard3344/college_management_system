using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace college_management_system
{
    public partial class LoginPage : Form
    {
        private CONNECT conn = new CONNECT();

        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            menuStrip1.Visible = true;
            panel1.Visible = false;
            
        }

        private void newAdmissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSudentForm newSudentForm = new NewSudentForm();
            newSudentForm.Show();

        }

        private void feesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeesForm feesForm = new FeesForm();
            feesForm.Show();
        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentSearchForm searchForm = new StudentSearchForm();
            searchForm.Show();
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentDetail studentDetailForm = new StudentDetail();
            studentDetailForm.Show();
        }

        private void addInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTeacherForm addTeacherForm = new AddTeacherForm();
            addTeacherForm.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherSearch teacherSearch = new TeacherSearch();
            teacherSearch.Show();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteStudentFormcs deleteStudentForm = new DeleteStudentFormcs();
            deleteStudentForm.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs aboutUsForm = new AboutUs();
            aboutUsForm.Show();
        }

    }
}
