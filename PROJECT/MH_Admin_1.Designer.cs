
namespace PROJECT
{
    partial class MH_Admin_1
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
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaiTròToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 19);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(390, 233);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(704, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menu";
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ngườiDùngToolStripMenuItem,
            this.vaiTròToolStripMenuItem});
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            // 
            // ngườiDùngToolStripMenuItem
            // 
            this.ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            this.ngườiDùngToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ngườiDùngToolStripMenuItem.Text = "Người dùng";
            // 
            // vaiTròToolStripMenuItem
            // 
            this.vaiTròToolStripMenuItem.Name = "vaiTròToolStripMenuItem";
            this.vaiTròToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.vaiTròToolStripMenuItem.Text = "Vai trò";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(6, 14);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(391, 138);
            this.dgv2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài khoản: ";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(114, 23);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(150, 20);
            this.tb1.TabIndex = 3;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(114, 49);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(150, 20);
            this.tb2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu: ";
            // 
            // bt_them
            // 
            this.bt_them.Location = new System.Drawing.Point(50, 103);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(85, 38);
            this.bt_them.TabIndex = 6;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Location = new System.Drawing.Point(50, 161);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(85, 38);
            this.bt_sua.TabIndex = 6;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Location = new System.Drawing.Point(179, 103);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(85, 38);
            this.bt_xoa.TabIndex = 6;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_khoa
            // 
            this.bt_khoa.Location = new System.Drawing.Point(179, 161);
            this.bt_khoa.Name = "bt_khoa";
            this.bt_khoa.Size = new System.Drawing.Size(85, 38);
            this.bt_khoa.TabIndex = 6;
            this.bt_khoa.Text = "Khóa";
            this.bt_khoa.UseVisualStyleBackColor = true;
            this.bt_khoa.Click += new System.EventHandler(this.bt_khoa_Click);
            // 
            // bt_capquyenuser
            // 
            this.bt_capquyenuser.Location = new System.Drawing.Point(50, 104);
            this.bt_capquyenuser.Name = "bt_capquyenuser";
            this.bt_capquyenuser.Size = new System.Drawing.Size(85, 38);
            this.bt_capquyenuser.TabIndex = 7;
            this.bt_capquyenuser.Text = "Cấp quyền";
            this.bt_capquyenuser.UseVisualStyleBackColor = true;
            // 
            // bt_thuquyenuser
            // 
            this.bt_thuquyenuser.Location = new System.Drawing.Point(179, 104);
            this.bt_thuquyenuser.Name = "bt_thuquyenuser";
            this.bt_thuquyenuser.Size = new System.Drawing.Size(85, 38);
            this.bt_thuquyenuser.TabIndex = 7;
            this.bt_thuquyenuser.Text = "Thu quyền";
            this.bt_thuquyenuser.UseVisualStyleBackColor = true;
            // 
            // cb_quyen
            // 
            this.cb_quyen.FormattingEnabled = true;
            this.cb_quyen.Items.AddRange(new object[] {
            "SELECT",
            "UPDATE",
            "INSERT",
            "DELETE"});
            this.cb_quyen.Location = new System.Drawing.Point(27, 28);
            this.cb_quyen.Name = "cb_quyen";
            this.cb_quyen.Size = new System.Drawing.Size(108, 21);
            this.cb_quyen.TabIndex = 8;
            this.cb_quyen.Text = "Tên quyền";
            // 
            // cb_bang
            // 
            this.cb_bang.FormattingEnabled = true;
            this.cb_bang.Items.AddRange(new object[] {
            "HSBA",
            "HSBA_DV",
            "BỆNHNHÂN",
            "CSYT",
            "NHÂNVIÊN"});
            this.cb_bang.Location = new System.Drawing.Point(158, 28);
            this.cb_bang.Name = "cb_bang";
            this.cb_bang.Size = new System.Drawing.Size(108, 21);
            this.cb_bang.TabIndex = 9;
            this.cb_bang.Text = "Tên bảng";
            // 
            // checkBox
            // 
            this.checkBox.AccessibleDescription = "";
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(158, 64);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(140, 17);
            this.checkBox.TabIndex = 10;
            this.checkBox.Text = "WITH GRANT OPTION";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(75, 27);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(170, 23);
            this.label.TabIndex = 11;
            this.label.Text = "USER MANAGER";
            // 
            // cb_cot
            // 
            this.cb_cot.FormattingEnabled = true;
            this.cb_cot.Location = new System.Drawing.Point(27, 62);
            this.cb_cot.Name = "cb_cot";
            this.cb_cot.Size = new System.Drawing.Size(108, 21);
            this.cb_cot.TabIndex = 12;
            this.cb_cot.Text = "Tên cột";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv2);
            this.groupBox1.Location = new System.Drawing.Point(307, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin về quyền của người dùng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv1);
            this.groupBox2.Location = new System.Drawing.Point(308, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 252);
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
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 226);
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
            this.panel2.Location = new System.Drawing.Point(0, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 152);
            this.panel2.TabIndex = 16;
            // 
            // MH_Admin_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 439);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MH_Admin_1";
            this.Text = "Phân quyền người dùng";
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
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaiTròToolStripMenuItem;
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
    }
}

