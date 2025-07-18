namespace ImageUploader {
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
            tbx_IP = new TextBox();
            tbx_Port = new TextBox();
            btn_Connect = new Button();
            pbx_Image = new PictureBox();
            btn_Upload = new Button();
            ((System.ComponentModel.ISupportInitialize)pbx_Image).BeginInit();
            SuspendLayout();
            // 
            // tbx_IP
            // 
            tbx_IP.Location = new Point(12, 12);
            tbx_IP.Name = "tbx_IP";
            tbx_IP.PlaceholderText = "IP";
            tbx_IP.Size = new Size(100, 23);
            tbx_IP.TabIndex = 0;
            tbx_IP.Text = "localhost";
            // 
            // tbx_Port
            // 
            tbx_Port.Location = new Point(118, 12);
            tbx_Port.Name = "tbx_Port";
            tbx_Port.PlaceholderText = "Port";
            tbx_Port.Size = new Size(100, 23);
            tbx_Port.TabIndex = 1;
            tbx_Port.Text = "25566";
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(224, 12);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(75, 23);
            btn_Connect.TabIndex = 2;
            btn_Connect.Text = "Connect";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // pbx_Image
            // 
            pbx_Image.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbx_Image.Location = new Point(12, 41);
            pbx_Image.Name = "pbx_Image";
            pbx_Image.Size = new Size(286, 150);
            pbx_Image.SizeMode = PictureBoxSizeMode.StretchImage;
            pbx_Image.TabIndex = 3;
            pbx_Image.TabStop = false;
            pbx_Image.DragDrop += pbx_Image_DragDrop;
            pbx_Image.DragEnter += pbx_Image_DragEnter;
            // 
            // btn_Upload
            // 
            btn_Upload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Upload.Enabled = false;
            btn_Upload.Location = new Point(118, 197);
            btn_Upload.Name = "btn_Upload";
            btn_Upload.Size = new Size(78, 24);
            btn_Upload.TabIndex = 4;
            btn_Upload.Text = "UPLOAF";
            btn_Upload.UseVisualStyleBackColor = true;
            btn_Upload.Click += btn_Upload_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 227);
            Controls.Add(btn_Upload);
            Controls.Add(pbx_Image);
            Controls.Add(btn_Connect);
            Controls.Add(tbx_Port);
            Controls.Add(tbx_IP);
            MinimumSize = new Size(326, 266);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbx_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbx_IP;
        private TextBox tbx_Port;
        private Button btn_Connect;
        private PictureBox pbx_Image;
        private Button btn_Upload;
    }
}
