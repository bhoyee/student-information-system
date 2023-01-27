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
    public partial class FrmAssessment : Form
    {
        public FrmAssessment()
        {
            InitializeComponent();
        }

       
        ProgramDTO programdto = new ProgramDTO();
        ModuleDTO moduledto = new ModuleDTO();


        AssessmentBLL assessmentbll = new AssessmentBLL();
        AssessmentDTO assessmentdto = new AssessmentDTO();
        private void FrmAssessment_Load(object sender, EventArgs e)
        {
             assessmentdto = assessmentbll.Select();

            cmbProgram.DataSource = assessmentdto.Programs;
            cmbProgram.DisplayMember = "Title";
            cmbProgram.ValueMember = "Id";
            cmbProgram.SelectedIndex = -1;



            dataGridView1.DataSource = assessmentdto.Assessments;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Assessment Title";

            dataGridView1.Columns[2].HeaderText = "Maximum Mark";
            dataGridView1.Columns[6].HeaderText = "Program";
            dataGridView1.Columns[7].HeaderText = "Module";
      
            
            //   dataGridView1.Columns[3].HeaderText = "Academy Year";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show(" this can't is empty");
            }
            else
            {
                AssessmentDetailsDTO assessment = new AssessmentDetailsDTO();

                assessment.title = txtTitle.Text;
                assessment.maxMark = Convert.ToInt32(txtMark.Text);
                assessment.grade = "A";
                assessment.ProgramID = Convert.ToInt32(cmbProgram.SelectedValue);
                assessment.ModuleID = Convert.ToInt32(cmbModule.SelectedValue);

                if (assessmentbll.Insert(assessment))
                {
                    MessageBox.Show("Assessment was added");

                    //clear the textbox and combo box
                    txtMark.Clear();
                    txtTitle.Clear();
                    cmbModule.Text = "";
                    cmbProgram.Text = "";



                    //update the gridviw after insertation
                    assessmentdto = assessmentbll.Select();
                    dataGridView1.DataSource = assessmentdto.Assessments;


                }

            }





        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ModuleDetailsDTO> list = assessmentdto.Modules;
            list = list.Where(x => x.PrgoramName == (cmbProgram.Text)).ToList();
            // dataGridView1.DataSource = list;

            cmbModule.DataSource = list;
            cmbModule.DisplayMember = "Title";
            cmbModule.ValueMember = "Id";
            cmbModule.SelectedIndex = -1;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString();
            txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMark.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbProgram.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbModule.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<AssessmentDetailsDTO> list = assessmentdto.Assessments;
            list = list.Where(x => x.title.Contains(txtSearch.Text) ||
            x.programName.Contains(txtSearch.Text) ||
            x.moduleName.Contains(txtSearch.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        public AssessmentDetailsDTO assessmentdetails = new AssessmentDetailsDTO();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            assessmentdetails.Id = Convert.ToInt32(txtID.Text);
            assessmentdetails.title = txtTitle.Text;
            assessmentdetails.maxMark = Convert.ToInt32(txtMark.Text);
            assessmentdetails.ProgramID = Convert.ToInt32(cmbProgram.SelectedValue);
            assessmentdetails.programName = cmbProgram.Text;
            assessmentdetails.moduleName = cmbModule.Text;
            assessmentdetails.ModuleID = Convert.ToInt32(cmbModule.SelectedValue);
            assessmentdetails.grade = "A";

            if (assessmentbll.Update(assessmentdetails))
            {
                MessageBox.Show("Assessment was Updated");
                Clear();

            }

            assessmentdto = assessmentbll.Select();
           
            dataGridView1.DataSource = assessmentdto.Assessments;
        }
        private void Clear()
        {
            txtTitle.Clear();
            txtMark.Clear();
            cmbModule.Text = "";
            cmbProgram.Text = "";
            txtID.Clear();
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            assessmentdetails.Id = int.Parse(txtID.Text);
           
            // students.id = int.Parse(txtStudent_id.Text);

            // boolean value to check whether the module deleted or not 

            if (assessmentdetails.Id == 0)
                MessageBox.Show("Please Select an Assessment from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure ?", "Warning!!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (assessmentbll.Delete(assessmentdetails))
                    {
                        MessageBox.Show("Module was deleted");
                       assessmentbll = new AssessmentBLL();
                        assessmentdto = assessmentbll.Select();
                        dataGridView1.DataSource = assessmentdto.Assessments;

                        Clear();
                    }

                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
