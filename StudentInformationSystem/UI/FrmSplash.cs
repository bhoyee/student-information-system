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
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
        int move = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // write the code to show loading animation 
            timer1.Interval = 20;
            panel2.Width += 5;

            move += 5;

            // if the loading is complete then display home  form and close this form 
            if(move == 640)
            {
                //stop the timer and close this form
                timer1.Stop();
                this.Hide();

                //display the home page
                FrmMain home = new FrmMain();
                home.Show();
            }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            // load the timer
            timer1.Start();
        }

    }
}
