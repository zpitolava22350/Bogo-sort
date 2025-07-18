namespace bogosort {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            glControl1 = new OpenTK.GLControl.GLControl();
            label1 = new Label();
            label2 = new Label();
            lbl_Iterations = new Label();
            lbx_PreviousSorts = new ListBox();
            lbl_Items = new Label();
            label4 = new Label();
            glControl2 = new OpenTK.GLControl.GLControl();
            label3 = new Label();
            label5 = new Label();
            lbl_PointsOff = new Label();
            lbl_WhenBestIteration = new Label();
            pbx_Slop = new PictureBox();
            lbl_SortTime = new Label();
            ((System.ComponentModel.ISupportInitialize)pbx_Slop).BeginInit();
            SuspendLayout();
            // 
            // glControl1
            // 
            glControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl1.APIVersion = new Version(3, 3, 0, 0);
            glControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl1.IsEventDriven = true;
            glControl1.Location = new Point(572, 249);
            glControl1.Name = "glControl1";
            glControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glControl1.SharedContext = null;
            glControl1.Size = new Size(1000, 600);
            glControl1.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(567, 244);
            label1.Name = "label1";
            label1.Size = new Size(1010, 610);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.Black;
            label2.Font = new Font("Verdana", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 238);
            label2.Name = "label2";
            label2.Size = new Size(549, 87);
            label2.TabIndex = 2;
            label2.Text = "Previous sorts";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Iterations
            // 
            lbl_Iterations.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Iterations.ForeColor = Color.White;
            lbl_Iterations.Location = new Point(567, 179);
            lbl_Iterations.Name = "lbl_Iterations";
            lbl_Iterations.Size = new Size(545, 65);
            lbl_Iterations.TabIndex = 3;
            lbl_Iterations.Text = "0";
            // 
            // lbx_PreviousSorts
            // 
            lbx_PreviousSorts.BackColor = Color.FromArgb(64, 64, 64);
            lbx_PreviousSorts.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbx_PreviousSorts.ForeColor = Color.White;
            lbx_PreviousSorts.FormattingEnabled = true;
            lbx_PreviousSorts.ItemHeight = 29;
            lbx_PreviousSorts.Location = new Point(12, 329);
            lbx_PreviousSorts.Name = "lbx_PreviousSorts";
            lbx_PreviousSorts.SelectionMode = SelectionMode.None;
            lbx_PreviousSorts.Size = new Size(549, 526);
            lbx_PreviousSorts.TabIndex = 4;
            // 
            // lbl_Items
            // 
            lbl_Items.Font = new Font("Verdana", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Items.ForeColor = Color.White;
            lbl_Items.Location = new Point(567, 12);
            lbl_Items.Name = "lbl_Items";
            lbl_Items.Size = new Size(333, 38);
            lbl_Items.TabIndex = 5;
            lbl_Items.Text = "Sorting 0 items";
            // 
            // label4
            // 
            label4.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1216, 204);
            label4.Name = "label4";
            label4.Size = new Size(361, 31);
            label4.TabIndex = 7;
            label4.Text = "~950 iterations / sec";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // glControl2
            // 
            glControl2.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl2.APIVersion = new Version(3, 3, 0, 0);
            glControl2.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl2.IsEventDriven = true;
            glControl2.Location = new Point(1272, 12);
            glControl2.Name = "glControl2";
            glControl2.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glControl2.SharedContext = null;
            glControl2.Size = new Size(300, 180);
            glControl2.TabIndex = 8;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(1267, 7);
            label3.Name = "label3";
            label3.Size = new Size(310, 190);
            label3.TabIndex = 9;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(900, 7);
            label5.Name = "label5";
            label5.Size = new Size(361, 31);
            label5.TabIndex = 10;
            label5.Text = "Best iteration >";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_PointsOff
            // 
            lbl_PointsOff.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_PointsOff.ForeColor = Color.White;
            lbl_PointsOff.Location = new Point(900, 38);
            lbl_PointsOff.Name = "lbl_PointsOff";
            lbl_PointsOff.Size = new Size(361, 31);
            lbl_PointsOff.TabIndex = 11;
            lbl_PointsOff.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_WhenBestIteration
            // 
            lbl_WhenBestIteration.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_WhenBestIteration.ForeColor = Color.White;
            lbl_WhenBestIteration.Location = new Point(842, 69);
            lbl_WhenBestIteration.Name = "lbl_WhenBestIteration";
            lbl_WhenBestIteration.Size = new Size(419, 31);
            lbl_WhenBestIteration.TabIndex = 12;
            lbl_WhenBestIteration.TextAlign = ContentAlignment.TopRight;
            // 
            // pbx_Slop
            // 
            pbx_Slop.InitialImage = null;
            pbx_Slop.Location = new Point(12, 12);
            pbx_Slop.Name = "pbx_Slop";
            pbx_Slop.Size = new Size(549, 232);
            pbx_Slop.SizeMode = PictureBoxSizeMode.StretchImage;
            pbx_Slop.TabIndex = 13;
            pbx_Slop.TabStop = false;
            // 
            // lbl_SortTime
            // 
            lbl_SortTime.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_SortTime.ForeColor = Color.White;
            lbl_SortTime.Location = new Point(567, 160);
            lbl_SortTime.Name = "lbl_SortTime";
            lbl_SortTime.Size = new Size(374, 29);
            lbl_SortTime.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1584, 861);
            Controls.Add(lbl_SortTime);
            Controls.Add(pbx_Slop);
            Controls.Add(lbl_WhenBestIteration);
            Controls.Add(lbl_PointsOff);
            Controls.Add(label5);
            Controls.Add(glControl2);
            Controls.Add(label4);
            Controls.Add(lbl_Items);
            Controls.Add(lbx_PreviousSorts);
            Controls.Add(lbl_Iterations);
            Controls.Add(label2);
            Controls.Add(glControl1);
            Controls.Add(label1);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bogo Sort";
            ((System.ComponentModel.ISupportInitialize)pbx_Slop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenTK.GLControl.GLControl glControl1;
        private Label label1;
        private Label label2;
        private Label lbl_Iterations;
        private ListBox lbx_PreviousSorts;
        private Label lbl_Items;
        private Label label4;
        private OpenTK.GLControl.GLControl glControl2;
        private Label label3;
        private Label label5;
        private Label lbl_PointsOff;
        private Label lbl_WhenBestIteration;
        private PictureBox pbx_Slop;
        private Label lbl_SortTime;
    }
}
