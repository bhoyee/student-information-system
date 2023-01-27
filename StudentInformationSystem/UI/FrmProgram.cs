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
    public partial class FrmProgram : Form
    {
        public FrmProgram()
        {
            InitializeComponent();
        }
        ProgramBLL bll = new ProgramBLL();
        ProgramDTO dto = new ProgramDTO();

        public ProgramDetailsDTO programdetails = new ProgramDetailsDTO();

        private void FrmProgram_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCohort.DataSource = dto.Cohorts;
            cmbCohort.DisplayMember = "a_year";
            cmbCohort.ValueMember = "ID";
            cmbCohort.SelectedIndex = -1;


            dataGridView1.DataSource = dto.Programs;
            dataGridView1.Columns[0].HeaderText = "Program ID";
            dataGridView1.Columns[3].HeaderText = "No Of Module";
            dataGridView1.Columns[4].HeaderText = "Cohort";
            dataGridView1.Columns[5].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProgramName.Text.Trim() == "")
                MessageBox.Show("Program Name is empty");
            else if(cmbProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Program");
            }
            else if(cmbCohort.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Academy Year");

            }
            else if (txtNumModules.Text == "")
            {
                MessageBox.Show("Number of Modules can't be empty");
            }
            else
            {
                ProgramDetailsDTO program = new ProgramDetailsDTO();

                //generate 6 random digit for Program ID
                Random r = new Random();
                int program_id = r.Next(100000, 500000);

                program.Id = program_id;
                program.Title = txtProgramName.Text;
                program.Duration = cmbProgram.Text;
                program.NumberofModule = Convert.ToInt32(txtNumModules.Text);
                program.CohortID = Convert.ToInt32(cmbCohort.SelectedValue);
                if (bll.Insert(program))
                {
                    MessageBox.Show("Program  was added");

                    //clear the textbox and combo box
                    txtProgramName.Clear();
                    cmbProgram.SelectedItem = -1;
                    cmbCohort.SelectedItem = -1;
                    cmbCohort.Text = "";
                    cmbProgram.Text = "";
                    txtNumModules.Clear();

                    //update the gridviw after insertation
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Programs;
                  //  dataGridView1.Columns[0].HeaderText = "Program ID";
                  //  dataGridView1.Columns[3].HeaderText = "Academy Year";

                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<ProgramDetailsDTO> list = dto.Programs;
            list = list.Where(x => x.Title.Contains(txtSearch.Text) || x.Id.ToString().Contains(txtSearch.Text)).ToList();
            dataGridView1.DataSource = list;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            programdetails.Id = int.Parse(txtProgramID.Text);
            programdetails.Title = txtProgramName.Text;
            programdetails.Duration = cmbProgram.Text;
            programdetails.CohortID = Convert.ToInt32(cmbCohort.SelectedValue);
            programdetails.a_year = cmbCohort.Text;
            programdetails.NumberofModule = Convert.ToInt32(txtNumModules.Text);


            if (bll.Update(programdetails))
            {
                MessageBox.Show("Program was Updated");

            }

            dto = bll.Select();
            dataGridView1.DataSource = dto.Programs;

            Clear();
        }
        private void Clear()
        {
            txtProgramID.Text="";
            txtProgramName.Text = "";
            cmbCohort.Text = "";
            cmbProgram.Text = "";
            txtNumModules.Clear();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtProgramID.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString();
           txtProgramName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           cmbProgram.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //  cmbProgramDuration.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
          cmbCohort.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNumModules.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            programdetails.Id = int.Parse(txtProgramID.Text);
    

            if (programdetails.Id == 0)
                MessageBox.Show("Please Select a program from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure ?", "Warning!!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(programdetails))
                    {
                        MessageBox.Show("Program was deleted");
                        bll = new ProgramBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Programs;

                        Clear();
                    }

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
