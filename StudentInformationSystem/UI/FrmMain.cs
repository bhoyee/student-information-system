using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformationSystem.UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmProgram program = new FrmProgram();
            program.Show();
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmModule module = new FrmModule();
            module.Show();
        }

        private void btn_Student_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmStudent student = new FrmStudent();
            student.Show();
        }

        private void btnAssessment_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmAssessment assessment = new FrmAssessment();
            assessment.Show();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmGrade grade = new FrmGrade();
            grade.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmCourseEnrollment enrollment = new FrmCourseEnrollment();
            enrollment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open Manage Program page
            FrmStudentMark mark = new FrmStudentMark();
            mark.Show();
        }
    }
}
