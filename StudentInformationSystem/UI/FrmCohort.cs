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
    public partial class FrmCohort : Form
    {
        public FrmCohort()
        {
            InitializeComponent();
        }

        CohortBLL bll = new CohortBLL();

        CohortDTO dto = new CohortDTO();

        private void FrmCohort_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Cohorts;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Academy Year";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("Insert value");
            else
            {
                CohortDetailsDTO cohort = new CohortDetailsDTO();
                cohort.a_year = textBox1.Text;
                if (bll.Insert(cohort))
                {
                    MessageBox.Show("Insert successfully");
                    textBox1.Clear();


                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Cohorts;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Academy Year";
                }
            }
        }
    }
}
