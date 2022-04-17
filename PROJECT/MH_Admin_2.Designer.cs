
namespace PROJECT
{
    partial class MH_Admin_2
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
            this.bt_thuquyenrole = new System.Windows.Forms.Button();
            this.bt_capquyenrole = new System.Windows.Forms.Button();
            this.cb_quyen = new System.Windows.Forms.ComboBox();
            this.cb_cot = new System.Windows.Forms.ComboBox();
            this.cb_bang = new System.Windows.Forms.ComboBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.vaiTròToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_them = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_thuquyen = new System.Windows.Forms.Button();
            this.bt_capquyen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv3 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bt_thuquyenrole);
            this.panel2.Controls.Add(this.bt_capquyenrole);
            this.panel2.Controls.Add(this.cb_quyen);
            this.panel2.Controls.Add(this.cb_cot);
            this.panel2.Controls.Add(this.cb_bang);
            this.panel2.Controls.Add(this.checkBox);
            this.panel2.Location = new System.Drawing.Point(12, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 293);
            this.panel2.TabIndex = 22;
            // 
            // bt_thuquyenrole
            // 
            this.bt_thuquyenrole.Location = new System.Drawing.Point(179, 217);
            this.bt_thuquyenrole.Name = "bt_thuquyenrole";
            this.bt_thuquyenrole.Size = new System.Drawing.Size(85, 38);
            this.bt_thuquyenrole.TabIndex = 7;
            this.bt_thuquyenrole.Text = "Thu quyền";
            this.bt_thuquyenrole.UseVisualStyleBackColor = true;
            // 
            // bt_capquyenrole
            // 
            this.bt_capquyenrole.Location = new System.Drawing.Point(41, 217);
            this.bt_capquyenrole.Name = "bt_capquyenrole";
            this.bt_capquyenrole.Size = new System.Drawing.Size(85, 38);
            this.bt_capquyenrole.TabIndex = 7;
            this.bt_capquyenrole.Text = "Cấp quyền";
            this.bt_capquyenrole.UseVisualStyleBackColor = true;
            // 
            // cb_quyen
            // 
            this.cb_quyen.FormattingEnabled = true;
            this.cb_quyen.Items.AddRange(new object[] {
            "SELECT",
            "UPDATE",
            "INSERT",
            "DELETE"});
            this.cb_quyen.Location = new System.Drawing.Point(18, 16);
            this.cb_quyen.Name = "cb_quyen";
            this.cb_quyen.Size = new System.Drawing.Size(191, 21);
            this.cb_quyen.TabIndex = 8;
            this.cb_quyen.Text = "Tên quyền";
            // 
            // cb_cot
            // 
            this.cb_cot.FormattingEnabled = true;
            this.cb_cot.Location = new System.Drawing.Point(18, 106);
            this.cb_cot.Name = "cb_cot";
            this.cb_cot.Size = new System.Drawing.Size(191, 21);
            this.cb_cot.TabIndex = 12;
            this.cb_cot.Text = "Tên cột";
            this.cb_cot.SelectedIndexChanged += new System.EventHandler(this.cb_cot_SelectedIndexChanged);
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
            this.cb_bang.Location = new System.Drawing.Point(18, 60);
            this.cb_bang.Name = "cb_bang";
            this.cb_bang.Size = new System.Drawing.Size(191, 21);
            this.cb_bang.TabIndex = 9;
            this.cb_bang.Text = "Tên bảng";
            // 
            // checkBox
            // 
            this.checkBox.AccessibleDescription = "";
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(18, 157);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(140, 17);
            this.checkBox.TabIndex = 10;
            this.checkBox.Text = "WITH GRANT OPTION";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv1);
            this.groupBox2.Location = new System.Drawing.Point(308, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 252);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách các vai trò";
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 26);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(741, 226);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv2);
            this.groupBox1.Location = new System.Drawing.Point(307, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 307);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin về quyền của vai trò";
            // 
            // dgv2
            // 
            this.dgv2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(6, 14);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(342, 293);
            this.dgv2.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(75, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(174, 23);
            this.label.TabIndex = 18;
            this.label.Text = "ROLE MANAGER";
            // 
            // vaiTròToolStripMenuItem
            // 
            this.vaiTròToolStripMenuItem.Name = "vaiTròToolStripMenuItem";
            this.vaiTròToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.vaiTròToolStripMenuItem.Text = "Vai trò";
            // 
            // ngườiDùngToolStripMenuItem
            // 
            this.ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            this.ngườiDùngToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ngườiDùngToolStripMenuItem.Text = "Người dùng";
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
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1073, 24);
            this.menu.TabIndex = 17;
            this.menu.Text = "menu";
            // 
            // bt_xoa
            // 
            this.bt_xoa.Location = new System.Drawing.Point(179, 61);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(85, 38);
            this.bt_xoa.TabIndex = 6;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_them
            // 
            this.bt_them.Location = new System.Drawing.Point(41, 61);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(85, 38);
            this.bt_them.TabIndex = 6;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên người dùng: ";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(114, 23);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(150, 20);
            this.tb1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên vai trò: ";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(114, 122);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(150, 20);
            this.tb2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_thuquyen);
            this.panel1.Controls.Add(this.bt_capquyen);
            this.panel1.Controls.Add(this.tb2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_them);
            this.panel1.Controls.Add(this.bt_xoa);
            this.panel1.Location = new System.Drawing.Point(12, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 226);
            this.panel1.TabIndex = 21;
            // 
            // bt_thuquyen
            // 
            this.bt_thuquyen.Location = new System.Drawing.Point(179, 163);
            this.bt_thuquyen.Name = "bt_thuquyen";
            this.bt_thuquyen.Size = new System.Drawing.Size(85, 38);
            this.bt_thuquyen.TabIndex = 7;
            this.bt_thuquyen.Text = "Thu quyền";
            this.bt_thuquyen.UseVisualStyleBackColor = true;
            // 
            // bt_capquyen
            // 
            this.bt_capquyen.Location = new System.Drawing.Point(41, 163);
            this.bt_capquyen.Name = "bt_capquyen";
            this.bt_capquyen.Size = new System.Drawing.Size(85, 38);
            this.bt_capquyen.TabIndex = 7;
            this.bt_capquyen.Text = "Cấp quyền";
            this.bt_capquyen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv3);
            this.groupBox3.Location = new System.Drawing.Point(668, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 307);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách người dùng";
            // 
            // dgv3
            // 
            this.dgv3.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv3.Location = new System.Drawing.Point(7, 14);
            this.dgv3.Name = "dgv3";
            this.dgv3.Size = new System.Drawing.Size(380, 293);
            this.dgv3.TabIndex = 0;
            this.dgv3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv3_CellContentClick);
            // 
            // MH_Admin_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 611);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Name = "MH_Admin_2";
            this.Text = "MH_Admin_2";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_thuquyenrole;
        private System.Windows.Forms.Button bt_capquyenrole;
        private System.Windows.Forms.ComboBox cb_quyen;
        private System.Windows.Forms.ComboBox cb_cot;
        private System.Windows.Forms.ComboBox cb_bang;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ToolStripMenuItem vaiTròToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_thuquyen;
        private System.Windows.Forms.Button bt_capquyen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv3;
    }
}