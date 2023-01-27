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
    public partial class FrmGrade : Form
    {
        public FrmGrade()
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            studentdto = studentbll.Select();

            //step1: check if student exit
            List<StudentDetailsDTO> list = studentdto.Students;
            list = list.Where(x => x.Id.ToString().Contains(txtStudentID.Text)).ToList();

            foreach (var item in list)
            {
                txtProgram.Text = item.PrgoramName;
                txtCohort.Text = item.CohortName;
                
            }


            cdto = courseenrollbill.Select();
            List<CourseEnrollmentDetailsDTO> courselist = cdto.CourseEnrollments;
            //  courselist = courselist.GroupBy(x => x.StudentID).Select(x => x.First()).Where(x => x.StudentID.ToString()== (txtProgram.Text)).ToList();
            courselist = courselist.Where(x => x.StudentID == Convert.ToInt32(txtStudentID.Text)).GroupBy(x => x.ModuleTitle).Select(x => x.First()).ToList();

           
            comboBox1.DataSource = courselist;
            comboBox1.DisplayMember = "ModuleTitle";
            comboBox1.ValueMember = "ModuleID";
            comboBox1.SelectedIndex = -1;

          //  var t = courselist.AsEnumerable().Select(x => x.AssessmentMaxMark).Sum();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdto = courseenrollbill.Select();
            List<CourseEnrollmentDetailsDTO> courselist = cdto.CourseEnrollments;
           var courselists = courselist.Where(x => x.StudentID == Convert.ToInt32(txtStudentID.Text) && x.ModuleTitle.Contains(comboBox1.Text)).ToList();
            //dataGridView1.DataSource = courselist;
            var courselis = courselist.Where(x => x.StudentID == Convert.ToInt32(txtStudentID.Text) && x.ModuleTitle.Contains(comboBox1.Text) && x.Mark == 0).ToList();
            dataGridView1.DataSource = courselis;

            if(courselis.Count > 0)
            {
                textBox1.Text = "this Undefined";
                textBox2.Text = "Undefined";
            }
        
            else
            {
                var sumofMark = courselists.AsEnumerable().Select(x => x.Mark).Sum().ToString();
                int totalMark = Convert.ToInt32(sumofMark);
                textBox1.Text = totalMark.ToString();

                //  get distict number of module
                var moduleMark = courselists.AsEnumerable().Select(x => x.ModuleID).Distinct().Count().ToString();
                textBox2.Text = moduleMark;

                label7.Text = (int.Parse(textBox2.Text) * 100).ToString();
                
              
            }


        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
