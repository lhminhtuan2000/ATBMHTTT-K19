
namespace PROJECT
{
    partial class MH_Login
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bt_dangki = new System.Windows.Forms.Button();
            this.bt_login = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb3);
            this.panel2.Controls.Add(this.tb2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tb1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(203, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 150);
            this.panel2.TabIndex = 1;
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.Location = new System.Drawing.Point(273, 121);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(116, 19);
            this.lb3.TabIndex = 11;
            this.lb3.Text = "Quên mật khẩu?";
            // 
            // tb2
            // 
            this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb2.Location = new System.Drawing.Point(161, 80);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(228, 38);
            this.tb2.TabIndex = 10;
            this.tb2.Text = "1";
            this.tb2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tài khoản";
            // 
            // tb1
            // 
            this.tb1.AutoCompleteCustomSource.AddRange(new string[] {
            "qlbv_dba",
            "nv",
            "nvql",
            "bs",
            "nc",
            "bn",
            "boss",
            "tt"});
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(161, 36);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(228, 38);
            this.tb1.TabIndex = 8;
            this.tb1.Text = "qlbv_dba";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật khẩu";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bt_dangki);
            this.panel3.Controls.Add(this.bt_login);
            this.panel3.Location = new System.Drawing.Point(203, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(408, 59);
            this.panel3.TabIndex = 2;
            // 
            // bt_dangki
            // 
            this.bt_dangki.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_dangki.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_dangki.Location = new System.Drawing.Point(35, 11);
            this.bt_dangki.Name = "bt_dangki";
            this.bt_dangki.Size = new System.Drawing.Size(129, 38);
            this.bt_dangki.TabIndex = 11;
            this.bt_dangki.Text = "ĐĂNG KÝ";
            this.bt_dangki.UseVisualStyleBackColor = false;
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_login.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_login.Location = new System.Drawing.Point(243, 11);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(126, 38);
            this.bt_login.TabIndex = 12;
            this.bt_login.Text = "ĐĂNG NHẬP";
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PROJECT.Properties.Resources.hospital_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 215);
            this.panel1.TabIndex = 0;
            // 
            // MH_Login
            // 
            this.AcceptButton = this.bt_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 229);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(200, 150);
            this.Name = "MH_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ATBMCQ-03";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_dangki;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Label lb3;
    }
}