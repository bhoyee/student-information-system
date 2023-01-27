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

namespace StudentInformationSystem.UI
{
    public partial class FrmCourseEnrollment : Form
    {
        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }


        StudentBLL studentbll = new StudentBLL();
        StudentDTO studentdto = new StudentDTO();
        ProgramDTO programdto = new ProgramDTO();
        ProgramBLL programbll = new ProgramBLL();
        ModuleDTO moduledto = new ModuleDTO();
        ModuleBLL modulebll = new ModuleBLL();
        AssessmentBLL assessmentbll = new AssessmentBLL();
        AssessmentDTO assessmentdto = new AssessmentDTO();

        CourseEnrollmentBLL courseenrollbill = new CourseEnrollmentBLL();
        CourseEnrollmentDTO cdto = new CourseEnrollmentDTO();



        private void btnFind_Click_1(object sender, EventArgs e)
        {

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
                    textBox1.Text = (item.ProgramID).ToString();

                    txxCohort.Text = item.CohortID.ToString();
                    label3.Text = item.CohortID.ToString();
                    textBox2.Text = item.ProgramDuration;
                    moduledto = modulebll.Select();
                    List<ModuleDetailsDTO> modulelist = moduledto.Modules;
                    modulelist = modulelist.Where(x => x.PrgoramName == txtProgram.Text && (x.ModuleType == "Optional")).ToList();

                    comboBox1.DataSource = modulelist;
                    comboBox1.DisplayMember = "Title";
                    comboBox1.ValueMember = "Id";
                    comboBox1.SelectedIndex = -1;


                }

                //dataGridView1.DataSource = list;
                //  txtStudentID.Clear();
                // populate check box with available module base on student program

            }
            else
            {
                MessageBox.Show("Student doesn't exist");
                txtStudentID.Clear();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            if (txtStudentID.Text.Trim() == "")
            {
                MessageBox.Show("Please provide Student ID");
            }
            else
            {


                programdto = programbll.Select();
                List<ProgramDetailsDTO> list = programdto.Programs;
                list = list.Where(x => x.Title == (txtProgram.Text)).ToList();

                int totoalnumberofmodules;
                foreach (var item in list)
                {
                    label6.Text = (item.NumberofModule).ToString();
                }

                totoalnumberofmodules = Convert.ToInt32(label6.Text);

                cdto = courseenrollbill.Select();
                List<CourseEnrollmentDetailsDTO> courselist = cdto.CourseEnrollments;

                //find distinct value
                //  courselist = courselist.GroupBy(x => x.StudentID).Select(x => x.First()).Where(x => x.StudentID.ToString()== (txtProgram.Text)).ToList();
                courselist = courselist.Where(x => x.StudentID == Convert.ToInt32(txtStudentID.Text)).GroupBy(x => x.ModuleID).Select(x => x.First()).ToList();

                int modulealreadyenrolled = courselist.Count();



                if (modulealreadyenrolled > totoalnumberofmodules)
                {
                    MessageBox.Show("Required Number of student already added");
                }
                else
                {
                    
                        assessmentdto = assessmentbll.Select();
                        List<AssessmentDetailsDTO> assessmentlist = assessmentdto.Assessments;
                        assessmentlist = assessmentlist.Where(x => x.ModuleID == Convert.ToInt32(comboBox1.SelectedValue) && (x.programName == (txtProgram.Text))).ToList();
                   
               
                        foreach (var item in assessmentlist)
                        {

                            CourseEnrollmentDetailsDTO course_enrollment = new CourseEnrollmentDetailsDTO();

                            course_enrollment.CohortID = Convert.ToInt32(txxCohort.Text);
                            course_enrollment.ProgramID = Convert.ToInt32(textBox1.Text);
                            course_enrollment.StudentID = Convert.ToInt32(txtStudentID.Text);
                            course_enrollment.ModuleID = Convert.ToInt32(comboBox1.SelectedValue);
                            course_enrollment.AssessmentID = item.Id;
                            course_enrollment.Mark = 0;

                            courseenrollbill.Insert(course_enrollment);
                        }
                      //  MessageBox.Show("You re here" + " nunber of already enroll " + modulealreadyenrolled);

             

                }


            }



        }
    }
}



