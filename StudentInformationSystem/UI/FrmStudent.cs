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
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        StudentBLL studentbll = new StudentBLL();
        StudentDTO studentdto = new StudentDTO();
        ProgramDTO programdto = new ProgramDTO();
        ModuleDTO moduledto = new ModuleDTO();
        ModuleBLL modulebll = new ModuleBLL();

        AssessmentBLL assessmentbll = new AssessmentBLL();
        AssessmentDTO assessmentdto = new AssessmentDTO();
        
        CourseEnrollmentBLL courseenrollbill = new CourseEnrollmentBLL();


        int student_id;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text.Trim() == "")
                MessageBox.Show("Student Full Name is empty");
            else if (cmbProgramDuration.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Program Duration");
            }
            else if (cmbProgram.Text == "")
            {
                MessageBox.Show("Please Select Program");

            }
            else
            {
                
                    StudentDetailsDTO student = new StudentDetailsDTO();

                    //generate 6 random digit for Program ID
                    Random r = new Random();
                    int sixDigit = r.Next(100000, 500000);

                    student.name = txtStudentName.Text;
                    student.ProgramID = Convert.ToInt32(cmbProgram.SelectedValue);
                    student.CohortID = Convert.ToInt32(cmbAYear.SelectedValue);
                    student.ProgramDuration = cmbProgramDuration.Text;

                     student_id = int.Parse(cmbAYear.Text + sixDigit);
                     student.Id = student_id;

               
                moduledto = modulebll.Select();
                List<ModuleDetailsDTO> modulelist = moduledto.Modules;
                 modulelist = modulelist.Where(x => x.PrgoramName == cmbProgram.Text && (x.ModuleType == "Compulsory")).ToList();
             
            
                foreach (var items in modulelist)
                {
                    
                    assessmentdto = assessmentbll.Select();
                    List<AssessmentDetailsDTO> assessmentlist = assessmentdto.Assessments;
                    assessmentlist = assessmentlist.Where(x => x.ModuleID == items.Id && (x.ProgramID == Convert.ToInt32(cmbProgram.SelectedValue))).ToList();
                    foreach (var item in assessmentlist)
                    {

                        
                        CourseEnrollmentDetailsDTO course_enrollment = new CourseEnrollmentDetailsDTO();

                        course_enrollment.CohortID = Convert.ToInt32(cmbAYear.SelectedValue);
                        course_enrollment.ProgramID = items.ProgramID;
                        course_enrollment.StudentID = student_id;
                        course_enrollment.ModuleID = items.Id;
                        course_enrollment.AssessmentID = item.Id;
                        course_enrollment.Mark = 0;

                        courseenrollbill.Insert(course_enrollment);
                    }

                }


                if (studentbll.Insert(student))
                    {
                        MessageBox.Show("Student was added");

                        //clear the textbox and combo box
                        txtStudentName.Clear();
                        cmbProgram.Text = "";
                        cmbAYear.Text = "";
                        cmbProgramDuration.Text = "";

                        //update the gridviw after insertation
                        studentdto = studentbll.Select();
                        dataGridView1.DataSource = studentdto.Students;

                    }
                           
               
            }
        }

        public StudentDetailsDTO studentdetails = new StudentDetailsDTO();
        public bool isUpdate = false;

        private void FrmStudent_Load(object sender, EventArgs e)
        {
         
            studentdto = studentbll.Select();
      
            List<ProgramDetailsDTO> list = studentdto.Programs;

           
            var lists = list.Select(o => o.Duration).Distinct();

            cmbProgramDuration.DataSource = lists.ToList();
            cmbProgramDuration.Text = "Duration";
           // cmbProgramDuration.ValueMember = "Id";
            cmbProgramDuration.SelectedIndex = -1;


            cmbAYear.DataSource = studentdto.Cohorts;
            cmbAYear.DisplayMember = "a_year";
            cmbAYear.ValueMember = "ID";
            cmbAYear.SelectedIndex = -1;



            dataGridView1.DataSource = studentdto.Students;
            dataGridView1.Columns[0].HeaderText = "Student ID";
            dataGridView1.Columns[1].HeaderText = "Student Name";
            dataGridView1.Columns[2].HeaderText = "Program";
            dataGridView1.Columns[3].HeaderText = "Duration";
            dataGridView1.Columns[4].HeaderText = "Cohort";
            //   dataGridView1.Columns[3].HeaderText = "Academy Year";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<StudentDetailsDTO> list = studentdto.Students;
            list = list.Where(x => x.name.Contains(txtSearch.Text) ||
            x.Id.ToString().Contains(txtSearch.Text) ||
            x.PrgoramName.Contains(txtSearch.Text) || x.ProgramDuration.Contains(txtSearch.Text)
            ).ToList();
            dataGridView1.DataSource = list;
        }

        
        private void cmbProgramDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ProgramDetailsDTO> list =  studentdto.Programs;
            list = list.Where(x => x.Duration == (cmbProgramDuration.Text)).ToList();
            // dataGridView1.DataSource = list;

            cmbProgram.DataSource = list;
            cmbProgram.DisplayMember = "Title";
            cmbProgram.ValueMember = "Id";
            cmbProgram.SelectedIndex = -1;
        }



  
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            studentdetails.Id = int.Parse(textBox1.Text);
           
                studentdetails.name = txtStudentName.Text;
                studentdetails.PrgoramName = cmbProgram.Text;
                studentdetails.ProgramDuration = cmbProgramDuration.Text;
                studentdetails.CohortName = cmbAYear.Text;
                studentdetails.ProgramID = Convert.ToInt32(cmbProgram.SelectedValue);
                studentdetails.CohortID = Convert.ToInt32(cmbAYear.SelectedValue);

                if (studentbll.Update(studentdetails))
                {
                    MessageBox.Show("Student was Updated");

                }

            studentdto = studentbll.Select();
            dataGridView1.DataSource = studentdto.Students;

            Clear();


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // studentdetails = new StudentDetailsDTO();
            textBox1.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString();
            txtStudentName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbProgram.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
          cmbProgramDuration.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           cmbAYear.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

         
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            studentdetails.Id = int.Parse(textBox1.Text);

            // boolean value to check whether the module deleted or not 
          
            if (studentdetails.Id == 0)
                MessageBox.Show("Please Select a Student from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure ?", "Warning!!", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes){
                    if (studentbll.Delete(studentdetails))
                    {
                        MessageBox.Show("Student was deleted");
                        studentbll = new StudentBLL();
                        studentdto = studentbll.Select();
                        dataGridView1.DataSource = studentdto.Students;

                        Clear();
                    }

                }
            }
        }
        private void Clear()
        {

            txtStudentName.Text = "";
            cmbProgram.Text = "";
            cmbProgramDuration.Text = "";
            cmbAYear.Text = "";
            textBox1.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
