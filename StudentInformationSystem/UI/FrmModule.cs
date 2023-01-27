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
    public partial class FrmModule : Form
    {
        public FrmModule()
        {
            InitializeComponent();
        }
        ModuleBLL modulebll = new ModuleBLL();
        ModuleDTO moduledto = new ModuleDTO();

        public ModuleDetailsDTO moduledetails = new ModuleDetailsDTO();

        private void FrmModule_Load(object sender, EventArgs e)
        {
            moduledto = modulebll.Select();
            cmbProgram.DataSource = moduledto.Programs;
            cmbProgram.DisplayMember = "Title";
            cmbProgram.ValueMember = "Id";
            cmbProgram.SelectedIndex = -1;



            dataGridView1.DataSource = moduledto.Modules;
            dataGridView1.Columns[0].HeaderText = "Module ID";
         //   dataGridView1.Columns[3].HeaderText = "Academy Year";
            dataGridView1.Columns[5].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
                MessageBox.Show("Module Name is empty");
            else if (cmbModuleType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Module Type");
            }
            else if (cmbProgram.Text == "")
            {
                MessageBox.Show("Please Select Program");

            }
            else
            {
                ModuleDetailsDTO module = new ModuleDetailsDTO();

                //generate 6 random digit for Program ID
                Random r = new Random();
                int module_id = r.Next(100000, 500000);

                module.Id = module_id;
                module.Title = txtTitle.Text;
                module.ModuleType = cmbModuleType.Text;
                module.MaxMark = int.Parse(txtMaxMark.Text);
                module.ProgramID = Convert.ToInt32(cmbProgram.SelectedValue);

                // check if module name exit or not
                List<ModuleDetailsDTO> list = moduledto.Modules;
                list = list.Where(x => x.Title.Contains(txtTitle.Text)).ToList();
               if(list.Count > 0)
                {
                    // module exit 
                    MessageBox.Show("Module Title already exist");
                }
                else
                {
                    if (modulebll.Insert(module))
                    {
                        MessageBox.Show("Module  was added");

                        //clear the textbox and combo box
                        txtMaxMark.Clear();
                        txtTitle.Clear();
                        cmbProgram.Text = "";
                        cmbModuleType.Text = "";


                        //update the gridviw after insertation
                        moduledto = modulebll.Select();
                        dataGridView1.DataSource = moduledto.Modules;
                        //  dataGridView1.Columns[0].HeaderText = "Program ID";
                        //  dataGridView1.Columns[3].HeaderText = "Academy Year";

                    }
                }
              
               
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<ModuleDetailsDTO> list = moduledto.Modules;
            list = list.Where(x => x.Title.Contains(txtSearch.Text) ||
            x.Id.ToString().Contains(txtSearch.Text) || 
            x.PrgoramName.Contains(txtSearch.Text) || x.ModuleType.Contains(txtSearch.Text)
            ).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            moduledetails.Id = int.Parse(txtModuleID.Text);
            moduledetails.Title = txtTitle.Text;
            moduledetails.ModuleType = cmbModuleType.Text;
            moduledetails.PrgoramName = cmbProgram.Text;
            moduledetails.ProgramID = Convert.ToInt32(cmbProgram.SelectedValue);
            moduledetails.MaxMark = int.Parse(txtMaxMark.Text);
        
            if (modulebll.Update(moduledetails))
            {
                MessageBox.Show("Module was Updated");

            }

            moduledto = modulebll.Select();
            dataGridView1.DataSource = moduledto.Modules;

            Clear();
        }
        private void Clear()
        {
            txtModuleID.Text = "";
            txtMaxMark.Text = "";
            txtTitle.Text = "";
            cmbModuleType.Text = "";
            cmbProgram.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtModuleID.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString();
          txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           cmbModuleType.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           cmbProgram.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMaxMark.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            moduledetails.Id = int.Parse(txtModuleID.Text);
           
            // students.id = int.Parse(txtStudent_id.Text);

            // boolean value to check whether the module deleted or not 

            if (moduledetails.Id == 0)
                MessageBox.Show("Please Select a Module from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure ?", "Warning!!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (modulebll.Delete(moduledetails))
                    {
                        MessageBox.Show("Module was deleted");
                        modulebll = new ModuleBLL();
                        moduledto = modulebll.Select();
                        dataGridView1.DataSource = moduledto.Modules;

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
