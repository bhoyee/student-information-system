namespace StudentInformationSystem.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnAssessment = new System.Windows.Forms.Button();
            this.btn_Student = new System.Windows.Forms.Button();
            this.btnModule = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::StudentInformationSystem.Properties.Resources.icons8_logout_rounded_100;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(791, 324);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(165, 143);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Image = global::StudentInformationSystem.Properties.Resources.icons8_report_64;
            this.btnRecord.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecord.Location = new System.Drawing.Point(272, 312);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(165, 143);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "Records";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnAssessment
            // 
            this.btnAssessment.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssessment.Image = global::StudentInformationSystem.Properties.Resources.icons8_test_100;
            this.btnAssessment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAssessment.Location = new System.Drawing.Point(12, 312);
            this.btnAssessment.Name = "btnAssessment";
            this.btnAssessment.Size = new System.Drawing.Size(165, 143);
            this.btnAssessment.TabIndex = 3;
            this.btnAssessment.Text = "Manage Assessments";
            this.btnAssessment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAssessment.UseVisualStyleBackColor = false;
            this.btnAssessment.Click += new System.EventHandler(this.btnAssessment_Click);
            // 
            // btn_Student
            // 
            this.btn_Student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Student.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Student.Image = global::StudentInformationSystem.Properties.Resources.icons8_student_center_100;
            this.btn_Student.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Student.Location = new System.Drawing.Point(538, 51);
            this.btn_Student.Name = "btn_Student";
            this.btn_Student.Size = new System.Drawing.Size(165, 143);
            this.btn_Student.TabIndex = 2;
            this.btn_Student.Text = "Manage Students";
            this.btn_Student.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Student.UseVisualStyleBackColor = false;
            this.btn_Student.Click += new System.EventHandler(this.btn_Student_Click);
            // 
            // btnModule
            // 
            this.btnModule.BackColor = System.Drawing.Color.Aqua;
            this.btnModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModule.Image = global::StudentInformationSystem.Properties.Resources.module;
            this.btnModule.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModule.Location = new System.Drawing.Point(272, 51);
            this.btnModule.Name = "btnModule";
            this.btnModule.Size = new System.Drawing.Size(165, 143);
            this.btnModule.TabIndex = 1;
            this.btnModule.Text = "Manage Modules";
            this.btnModule.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModule.UseVisualStyleBackColor = false;
            this.btnModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgram.Image = global::StudentInformationSystem.Properties.Resources.program;
            this.btnProgram.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProgram.Location = new System.Drawing.Point(12, 51);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(165, 143);
            this.btnProgram.TabIndex = 0;
            this.btnProgram.Text = "Manage Programs";
            this.btnProgram.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProgram.UseVisualStyleBackColor = false;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::StudentInformationSystem.Properties.Resources.module;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(780, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 143);
            this.button1.TabIndex = 6;
            this.button1.Text = "Course Enrollment";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SeaGreen;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::StudentInformationSystem.Properties.Resources.icons8_test_100;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(538, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 143);
            this.button2.TabIndex = 7;
            this.button2.Text = "Student Mark";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 562);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnAssessment);
            this.Controls.Add(this.btn_Student);
            this.Controls.Add(this.btnModule);
            this.Controls.Add(this.btnProgram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Information System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.Button btnModule;
        private System.Windows.Forms.Button btn_Student;
        private System.Windows.Forms.Button btnAssessment;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}