namespace _2984_Installation
{
    partial class install_window
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
            this.btn_browse = new System.Windows.Forms.Button();
            this.txtbx_installfolder = new System.Windows.Forms.TextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_destFold = new System.Windows.Forms.Label();
            this.btn_install = new System.Windows.Forms.Button();
            this.chkBx_dskShrt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(321, 83);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "Browse...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txtbx_installfolder
            // 
            this.txtbx_installfolder.Location = new System.Drawing.Point(12, 83);
            this.txtbx_installfolder.Name = "txtbx_installfolder";
            this.txtbx_installfolder.Size = new System.Drawing.Size(303, 20);
            this.txtbx_installfolder.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(122, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(165, 31);
            this.lbl_title.TabIndex = 2;
            this.lbl_title.Text = "Install 2984";
            // 
            // lbl_destFold
            // 
            this.lbl_destFold.AutoSize = true;
            this.lbl_destFold.Location = new System.Drawing.Point(13, 64);
            this.lbl_destFold.Name = "lbl_destFold";
            this.lbl_destFold.Size = new System.Drawing.Size(63, 13);
            this.lbl_destFold.TabIndex = 3;
            this.lbl_destFold.Text = "Install folder";
            // 
            // btn_install
            // 
            this.btn_install.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_install.Location = new System.Drawing.Point(12, 146);
            this.btn_install.Name = "btn_install";
            this.btn_install.Size = new System.Drawing.Size(384, 65);
            this.btn_install.TabIndex = 4;
            this.btn_install.Text = "Install 2984";
            this.btn_install.UseVisualStyleBackColor = true;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // chkBx_dskShrt
            // 
            this.chkBx_dskShrt.AutoSize = true;
            this.chkBx_dskShrt.Location = new System.Drawing.Point(16, 110);
            this.chkBx_dskShrt.Name = "chkBx_dskShrt";
            this.chkBx_dskShrt.Size = new System.Drawing.Size(139, 17);
            this.chkBx_dskShrt.TabIndex = 5;
            this.chkBx_dskShrt.Text = "Create desktop shortcut";
            this.chkBx_dskShrt.UseVisualStyleBackColor = true;
            // 
            // install_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 223);
            this.Controls.Add(this.chkBx_dskShrt);
            this.Controls.Add(this.btn_install);
            this.Controls.Add(this.lbl_destFold);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.txtbx_installfolder);
            this.Controls.Add(this.btn_browse);
            this.Name = "install_window";
            this.Text = "2984 Installation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txtbx_installfolder;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_destFold;
        private System.Windows.Forms.Button btn_install;
        private System.Windows.Forms.CheckBox chkBx_dskShrt;
    }
}

