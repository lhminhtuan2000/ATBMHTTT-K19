﻿
namespace PROJECT
{
    partial class MH_ThanhTra
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
            this.bt_xem = new System.Windows.Forms.Button();
            this.cb_bang = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tùyChọnTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.infoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.đọcDữLiệuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoátTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bt_xem);
            this.panel2.Controls.Add(this.cb_bang);
            this.panel2.Location = new System.Drawing.Point(10, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 203);
            this.panel2.TabIndex = 22;
            // 
            // bt_xem
            // 
            this.bt_xem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xem.Location = new System.Drawing.Point(58, 112);
            this.bt_xem.Name = "bt_xem";
            this.bt_xem.Size = new System.Drawing.Size(85, 50);
            this.bt_xem.TabIndex = 7;
            this.bt_xem.Text = "XEM";
            this.bt_xem.UseVisualStyleBackColor = true;
            this.bt_xem.Click += new System.EventHandler(this.bt_xem_Click);
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
            "BENHNHAN",
            "CSYT",
            "NHANVIEN"});
            this.cb_bang.Location = new System.Drawing.Point(33, 44);
            this.cb_bang.Name = "cb_bang";
            this.cb_bang.Size = new System.Drawing.Size(133, 26);
            this.cb_bang.TabIndex = 9;
            this.cb_bang.Text = "Tên bảng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(218, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 278);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 22);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(602, 246);
            this.dgv1.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(38, 31);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(154, 62);
            this.label.TabIndex = 18;
            this.label.Text = "KẾT XUẤT\r\n BÁO CÁO";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnTSMI,
            this.ThoátTSMI});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(844, 28);
            this.menu.TabIndex = 44;
            this.menu.Text = "menu";
            // 
            // tùyChọnTSMI
            // 
            this.tùyChọnTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoTSMI,
            this.đọcDữLiệuTSMI});
            this.tùyChọnTSMI.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tùyChọnTSMI.Name = "tùyChọnTSMI";
            this.tùyChọnTSMI.Size = new System.Drawing.Size(80, 24);
            this.tùyChọnTSMI.Text = "Tùy chọn";
            // 
            // infoTSMI
            // 
            this.infoTSMI.Name = "infoTSMI";
            this.infoTSMI.Size = new System.Drawing.Size(196, 24);
            this.infoTSMI.Text = "Thông tin cá nhân";
            this.infoTSMI.Click += new System.EventHandler(this.infoTSMI_Click);
            // 
            // đọcDữLiệuTSMI
            // 
            this.đọcDữLiệuTSMI.Checked = true;
            this.đọcDữLiệuTSMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.đọcDữLiệuTSMI.Name = "đọcDữLiệuTSMI";
            this.đọcDữLiệuTSMI.Size = new System.Drawing.Size(196, 24);
            this.đọcDữLiệuTSMI.Text = "Đọc dữ liệu";
            // 
            // ThoátTSMI
            // 
            this.ThoátTSMI.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ThoátTSMI.Name = "ThoátTSMI";
            this.ThoátTSMI.Size = new System.Drawing.Size(59, 24);
            this.ThoátTSMI.Text = "Thoát";
            this.ThoátTSMI.Click += new System.EventHandler(this.ThoátTSMI_Click);
            // 
            // MH_ThanhTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 311);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label);
            this.Location = new System.Drawing.Point(80, 60);
            this.Name = "MH_ThanhTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ATBMCQ-03";
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_xem;
        private System.Windows.Forms.ComboBox cb_bang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnTSMI;
        private System.Windows.Forms.ToolStripMenuItem infoTSMI;
        private System.Windows.Forms.ToolStripMenuItem đọcDữLiệuTSMI;
        private System.Windows.Forms.ToolStripMenuItem ThoátTSMI;
    }
}