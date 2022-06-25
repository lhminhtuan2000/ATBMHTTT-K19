
namespace PROJECT
{
    partial class MH_Admin_User
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tùyChọnTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiDùngTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.vaiTròTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CSYTTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoátTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_them = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_khoa = new System.Windows.Forms.Button();
            this.bt_capquyenuser = new System.Windows.Forms.Button();
            this.bt_thuquyenuser = new System.Windows.Forms.Button();
            this.cb_quyen = new System.Windows.Forms.ComboBox();
            this.cb_bang = new System.Windows.Forms.ComboBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.cb_cot = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 26);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(530, 226);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnTSMI,
            this.ThoátTSMI});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(844, 28);
            this.menu.TabIndex = 1;
            this.menu.Text = "menu";
            // 
            // tùyChọnTSMI
            // 
            this.tùyChọnTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ngườiDùngTSMI,
            this.vaiTròTSMI,
            this.CSYTTSMI,
            this.nhânViênTSMI});
            this.tùyChọnTSMI.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tùyChọnTSMI.Name = "tùyChọnTSMI";
            this.tùyChọnTSMI.Size = new System.Drawing.Size(80, 24);
            this.tùyChọnTSMI.Text = "Tùy chọn";
            this.tùyChọnTSMI.Click += new System.EventHandler(this.tùyChọnTSMI_Click);
            // 
            // ngườiDùngTSMI
            // 
            this.ngườiDùngTSMI.Checked = true;
            this.ngườiDùngTSMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ngườiDùngTSMI.Name = "ngườiDùngTSMI";
            this.ngườiDùngTSMI.Size = new System.Drawing.Size(158, 24);
            this.ngườiDùngTSMI.Text = "Người dùng";
            // 
            // vaiTròTSMI
            // 
            this.vaiTròTSMI.Name = "vaiTròTSMI";
            this.vaiTròTSMI.Size = new System.Drawing.Size(158, 24);
            this.vaiTròTSMI.Text = "Vai trò";
            this.vaiTròTSMI.Click += new System.EventHandler(this.vaiTròTSMI_Click);
            // 
            // CSYTTSMI
            // 
            this.CSYTTSMI.Name = "CSYTTSMI";
            this.CSYTTSMI.Size = new System.Drawing.Size(158, 24);
            this.CSYTTSMI.Text = "Cơ sở y tế";
            this.CSYTTSMI.Click += new System.EventHandler(this.CSYTTSMI_Click);
            // 
            // nhânViênTSMI
            // 
            this.nhânViênTSMI.Name = "nhânViênTSMI";
            this.nhânViênTSMI.Size = new System.Drawing.Size(158, 24);
            this.nhânViênTSMI.Text = "Nhân viên";
            this.nhânViênTSMI.Click += new System.EventHandler(this.nhânViênTSMI_Click);
            // 
            // ThoátTSMI
            // 
            this.ThoátTSMI.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ThoátTSMI.Name = "ThoátTSMI";
            this.ThoátTSMI.Size = new System.Drawing.Size(59, 24);
            this.ThoátTSMI.Text = "Thoát";
            this.ThoátTSMI.Click += new System.EventHandler(this.ThoátTSMI_Click);
            // 
            // dgv2
            // 
            this.dgv2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(6, 19);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(531, 152);
            this.dgv2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài khoản: ";
            // 
            // tb1
            // 
            this.tb1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(114, 23);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(150, 24);
            this.tb1.TabIndex = 3;
            // 
            // tb2
            // 
            this.tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb2.Location = new System.Drawing.Point(114, 53);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(150, 24);
            this.tb2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu: ";
            // 
            // bt_them
            // 
            this.bt_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_them.Location = new System.Drawing.Point(30, 103);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(95, 38);
            this.bt_them.TabIndex = 6;
            this.bt_them.Text = "THÊM";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sua.Location = new System.Drawing.Point(30, 161);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(95, 38);
            this.bt_sua.TabIndex = 6;
            this.bt_sua.Text = "SỬA";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xoa.Location = new System.Drawing.Point(159, 103);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(95, 38);
            this.bt_xoa.TabIndex = 6;
            this.bt_xoa.Text = "XÓA";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_khoa
            // 
            this.bt_khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_khoa.Location = new System.Drawing.Point(159, 161);
            this.bt_khoa.Name = "bt_khoa";
            this.bt_khoa.Size = new System.Drawing.Size(95, 38);
            this.bt_khoa.TabIndex = 6;
            this.bt_khoa.Text = "KHÓA";
            this.bt_khoa.UseVisualStyleBackColor = true;
            this.bt_khoa.Click += new System.EventHandler(this.bt_khoa_Click);
            // 
            // bt_capquyenuser
            // 
            this.bt_capquyenuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_capquyenuser.Location = new System.Drawing.Point(159, 16);
            this.bt_capquyenuser.Name = "bt_capquyenuser";
            this.bt_capquyenuser.Size = new System.Drawing.Size(105, 40);
            this.bt_capquyenuser.TabIndex = 7;
            this.bt_capquyenuser.Text = "CẤP QUYỀN";
            this.bt_capquyenuser.UseVisualStyleBackColor = true;
            this.bt_capquyenuser.Click += new System.EventHandler(this.bt_capquyenuser_Click);
            // 
            // bt_thuquyenuser
            // 
            this.bt_thuquyenuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thuquyenuser.Location = new System.Drawing.Point(159, 72);
            this.bt_thuquyenuser.Name = "bt_thuquyenuser";
            this.bt_thuquyenuser.Size = new System.Drawing.Size(105, 41);
            this.bt_thuquyenuser.TabIndex = 7;
            this.bt_thuquyenuser.Text = "THU QUYỀN";
            this.bt_thuquyenuser.UseVisualStyleBackColor = true;
            // 
            // cb_quyen
            // 
            this.cb_quyen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_quyen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_quyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_quyen.FormattingEnabled = true;
            this.cb_quyen.Items.AddRange(new object[] {
            "SELECT",
            "UPDATE",
            "INSERT",
            "DELETE"});
            this.cb_quyen.Location = new System.Drawing.Point(27, 16);
            this.cb_quyen.Name = "cb_quyen";
            this.cb_quyen.Size = new System.Drawing.Size(108, 26);
            this.cb_quyen.TabIndex = 8;
            this.cb_quyen.Text = "Tên quyền";
            // 
            // cb_bang
            // 
            this.cb_bang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_bang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_bang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_bang.FormattingEnabled = true;
            this.cb_bang.Items.AddRange(new object[] {
            "HSBA",
            "HSBA_DV",
            "BỆNHNHÂN",
            "CSYT",
            "NHÂNVIÊN"});
            this.cb_bang.Location = new System.Drawing.Point(27, 51);
            this.cb_bang.Name = "cb_bang";
            this.cb_bang.Size = new System.Drawing.Size(108, 26);
            this.cb_bang.TabIndex = 9;
            this.cb_bang.Text = "Tên bảng";
            this.cb_bang.SelectedValueChanged += new System.EventHandler(this.cb_bang_SelectedValueChanged);
            // 
            // checkBox
            // 
            this.checkBox.AccessibleDescription = "";
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.Location = new System.Drawing.Point(27, 125);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(182, 22);
            this.checkBox.TabIndex = 10;
            this.checkBox.Text = "WITH GRANT OPTION";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(7, 28);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(284, 26);
            this.label.TabIndex = 11;
            this.label.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // cb_cot
            // 
            this.cb_cot.Enabled = false;
            this.cb_cot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cot.FormattingEnabled = true;
            this.cb_cot.Location = new System.Drawing.Point(27, 89);
            this.cb_cot.Name = "cb_cot";
            this.cb_cot.Size = new System.Drawing.Size(108, 26);
            this.cb_cot.TabIndex = 12;
            this.cb_cot.Text = "Tên cột";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(299, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 178);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin về quyền của người dùng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(299, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 252);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách các người dùng";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_them);
            this.panel1.Controls.Add(this.bt_sua);
            this.panel1.Controls.Add(this.bt_khoa);
            this.panel1.Controls.Add(this.bt_xoa);
            this.panel1.Location = new System.Drawing.Point(3, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 226);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bt_thuquyenuser);
            this.panel2.Controls.Add(this.bt_capquyenuser);
            this.panel2.Controls.Add(this.cb_quyen);
            this.panel2.Controls.Add(this.cb_cot);
            this.panel2.Controls.Add(this.cb_bang);
            this.panel2.Controls.Add(this.checkBox);
            this.panel2.Location = new System.Drawing.Point(3, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 152);
            this.panel2.TabIndex = 16;
            // 
            // MH_Admin_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menu);
            this.Location = new System.Drawing.Point(80, 60);
            this.MainMenuStrip = this.menu;
            this.Name = "MH_Admin_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MH_Admin_User";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnTSMI;
        private System.Windows.Forms.ToolStripMenuItem ngườiDùngTSMI;
        private System.Windows.Forms.ToolStripMenuItem vaiTròTSMI;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_khoa;
        private System.Windows.Forms.Button bt_capquyenuser;
        private System.Windows.Forms.Button bt_thuquyenuser;
        private System.Windows.Forms.ComboBox cb_quyen;
        private System.Windows.Forms.ComboBox cb_bang;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cb_cot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem CSYTTSMI;
        private System.Windows.Forms.ToolStripMenuItem nhânViênTSMI;
        private System.Windows.Forms.ToolStripMenuItem ThoátTSMI;
    }
}

