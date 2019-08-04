namespace testingOCR
{
    partial class F_main
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
            this.OPF_image = new System.Windows.Forms.OpenFileDialog();
            this.BTN_analyze = new System.Windows.Forms.Button();
            this.LL_uploadImage = new System.Windows.Forms.LinkLabel();
            this.PB_image = new System.Windows.Forms.PictureBox();
            this.RTB_response = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_image)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_analyze
            // 
            this.BTN_analyze.Location = new System.Drawing.Point(111, 39);
            this.BTN_analyze.Name = "BTN_analyze";
            this.BTN_analyze.Size = new System.Drawing.Size(116, 47);
            this.BTN_analyze.TabIndex = 0;
            this.BTN_analyze.Text = "Analyze";
            this.BTN_analyze.UseVisualStyleBackColor = true;
            this.BTN_analyze.Click += new System.EventHandler(this.BTN_analyze_Click);
            // 
            // LL_uploadImage
            // 
            this.LL_uploadImage.AutoSize = true;
            this.LL_uploadImage.Location = new System.Drawing.Point(32, 56);
            this.LL_uploadImage.Name = "LL_uploadImage";
            this.LL_uploadImage.Size = new System.Drawing.Size(73, 13);
            this.LL_uploadImage.TabIndex = 1;
            this.LL_uploadImage.TabStop = true;
            this.LL_uploadImage.Text = "Upload Image";
            this.LL_uploadImage.Click += new System.EventHandler(this.LL_uploadImage_Click);
            // 
            // PB_image
            // 
            this.PB_image.Location = new System.Drawing.Point(12, 103);
            this.PB_image.Name = "PB_image";
            this.PB_image.Size = new System.Drawing.Size(232, 237);
            this.PB_image.TabIndex = 2;
            this.PB_image.TabStop = false;
            // 
            // RTB_response
            // 
            this.RTB_response.Location = new System.Drawing.Point(253, 12);
            this.RTB_response.Name = "RTB_response";
            this.RTB_response.Size = new System.Drawing.Size(228, 329);
            this.RTB_response.TabIndex = 3;
            this.RTB_response.Text = "";
            // 
            // F_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 353);
            this.Controls.Add(this.RTB_response);
            this.Controls.Add(this.PB_image);
            this.Controls.Add(this.LL_uploadImage);
            this.Controls.Add(this.BTN_analyze);
            this.Name = "F_main";
            this.Text = "Testing OCR";
            ((System.ComponentModel.ISupportInitialize)(this.PB_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OPF_image;
        private System.Windows.Forms.Button BTN_analyze;
        private System.Windows.Forms.LinkLabel LL_uploadImage;
        private System.Windows.Forms.PictureBox PB_image;
        private System.Windows.Forms.RichTextBox RTB_response;
    }
}

