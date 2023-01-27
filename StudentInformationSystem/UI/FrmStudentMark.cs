using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentInformationSystem.BLL;
using StudentInformationSystem.DAL.DTO;
using StudentInformationSystem.DAL;

namespace StudentInformationSystem.UI
{
    public partial class FrmStudentMark : Form
    {
        public FrmStudentMark()
        {
            InitializeComponent();
        }

        StudentBLL studentbll = new StudentBLL();
        StudentDTO studentdto = new StudentDTO();
        ProgramDTO programdto = new ProgramDTO();
        ModuleDTO moduledto = new ModuleDTO();
        ModuleBLL modulebll = new ModuleBLL();

        CourseEnrollmentDTO course_enrollmentdto = new CourseEnrollmentDTO();
        CourseEnrollmentBLL course_enrollmentbll = new CourseEnrollmentBLL();
        AssessmentDTO assessmentdto = new AssessmentDTO();
        AssessmentBLL assessmentbll = new AssessmentBLL();

        public CourseEnrollmentDetailsDTO course_enrollment_detailsdto = new CourseEnrollmentDetailsDTO();
        private void btnFind_Click(object sender, EventArgs e)
        {
            // studentdto is an instant of StudentDTO class mean Student Data Transfer Object
            studentdto = studentbll.Select();

            //step1: check if student exit
            List<StudentDetailsDTO> list = studentdto.Students;
            list = list.Where(x => x.Id.ToString().Contains(txtStudentID.Text)).ToList();

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    StudentDetailsDTO dto = new StudentDetailsDTO();
                    txtProgram.Text = item.PrgoramName;
                    txtProgramID.Text = item.ProgramID.ToString();
                    txtcohort.Text = item.CohortID.ToString();
                 
                    course_enrollmentdto = course_enrollmentbll.Select();
                     List<CourseEnrollmentDetailsDTO> enrollmentList = course_enrollmentdto.CourseEnrollments;
                     enrollmentList = enrollmentList.GroupBy(x => x.ModuleTitle).Select(x => x.First()).Where(x => x.PrgoramName.Contains(txtProgram.Text)).Distinct().ToList();


                    cmbModule.DataSource = enrollmentList.ToList();
                    cmbModule.DisplayMember = "ModuleTitle";
                    cmbModule.ValueMember = "ModuleId";
                    cmbModule.SelectedIndex = -1;

                }
            }
            else
            {
                MessageBox.Show("No such User");
            }
        }

        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            assessmentdto = assessmentbll.Select();
            List<AssessmentDetailsDTO> assessmentlist = assessmentdto.Assessments;
            assessmentlist = assessmentlist.Where(x => x.moduleName == (cmbModule.Text)).ToList();
            cmbAssessment.DataSource = assessmentlist;
            cmbAssessment.DisplayMember = "Title";
            cmbAssessment.ValueMember = "Id";
            cmbAssessment.SelectedIndex = -1;

            foreach (var item in assessmentlist)
            {
                label7.Text = item.maxMark.ToString();
            }

  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtScore.Text) > int.Parse(label7.Text))
            {
                MessageBox.Show("Score is more than total assessment score" + label7.Text);
            }
            else
            {
                course_enrollment_detailsdto.StudentID = Convert.ToInt32(txtStudentID.Text);
                course_enrollment_detailsdto.ProgramID = Convert.ToInt32(txtProgramID.Text);
                course_enrollment_detailsdto.PrgoramName = txtProgram.Text;
                course_enrollment_detailsdto.ModuleID = Convert.ToInt32(cmbModule.SelectedValue);
                course_enrollment_detailsdto.ModuleTitle = cmbModule.Text;
                course_enrollment_detailsdto.AssessmentID = Convert.ToInt32(cmbAssessment.SelectedValue);
                course_enrollment_detailsdto.AssessmentTitle = cmbAssessment.Text;
                course_enrollment_detailsdto.Mark = Convert.ToInt32(txtScore.Text);
                course_enrollment_detailsdto.CohortID = Convert.ToInt32(txtcohort.Text);


                if (course_enrollmentbll.Update(course_enrollment_detailsdto))
                {
                    MessageBox.Show("Record Updated Successfully" + label7.Text);


                    Clear();

                    course_enrollmentdto = course_enrollmentbll.Select();
                    dataGridView1.DataSource = course_enrollmentdto.CourseEnrollments;
                    dataGridView1.Columns[1].HeaderText = "Student ID";
                    dataGridView1.Columns[2].Visible = false;
                    ////dataGridView1.Columns[2].HeaderText = "Mark";
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].HeaderText = "Programme";
                    dataGridView1.Columns[6].HeaderText = "Cohort";
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].HeaderText = "Module";
                    dataGridView1.Columns[9].Visible = false;
                    ////dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    //dataGridView1.Columns[12].HeaderText = "Assessment Title";
                    dataGridView1.Columns[12].HeaderText = "Assessment Title";
                    dataGridView1.Columns[13].HeaderText = "Maximum Mark";

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }





        }

        private void Clear()
        {
            txtProgram.Clear();
            txtProgramID.Clear();
            txtScore.Clear();
            txtStudentID.Clear();
            cmbModule.Text = "";
            cmbAssessment.Text = "";
        }
    }
}
