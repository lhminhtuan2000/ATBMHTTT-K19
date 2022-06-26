
namespace PROJECT
{
    partial class MH_NghienCuu_HSBA
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_timHSBA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tùyChọnTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.infoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HSBATSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoátTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_timHSBA);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb1);
            this.panel1.Location = new System.Drawing.Point(386, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 35);
            this.panel1.TabIndex = 40;
            // 
            // bt_timHSBA
            // 
            this.bt_timHSBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_timHSBA.Image = global::PROJECT.Properties.Resources.Search_button;
            this.bt_timHSBA.Location = new System.Drawing.Point(287, 2);
            this.bt_timHSBA.Name = "bt_timHSBA";
            this.bt_timHSBA.Size = new System.Drawing.Size(31, 26);
            this.bt_timHSBA.TabIndex = 7;
            this.bt_timHSBA.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã HSBA: ";
            // 
            // tb1
            // 
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(115, 3);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(152, 24);
            this.tb1.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(12, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(360, 31);
            this.label.TabIndex = 37;
            this.label.Text = "TRA CỨU HỒ SƠ BỆNH ÁN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 161);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin về dịch vụ của hồ sơ bệnh án";
            // 
            // dgv2
            // 
            this.dgv2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(6, 23);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(719, 131);
            this.dgv2.TabIndex = 0;
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 30);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(719, 206);
            this.dgv1.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnTSMI,
            this.ThoátTSMI});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(746, 28);
            this.menu.TabIndex = 41;
            this.menu.Text = "menu";
            // 
            // tùyChọnTSMI
            // 
            this.tùyChọnTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoTSMI,
            this.HSBATSMI});
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
            // HSBATSMI
            // 
            this.HSBATSMI.Checked = true;
            this.HSBATSMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HSBATSMI.Name = "HSBATSMI";
            this.HSBATSMI.Size = new System.Drawing.Size(196, 24);
            this.HSBATSMI.Text = "Hồ sơ bệnh án";
            // 
            // ThoátTSMI
            // 
            this.ThoátTSMI.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ThoátTSMI.Name = "ThoátTSMI";
            this.ThoátTSMI.Size = new System.Drawing.Size(59, 24);
            this.ThoátTSMI.Text = "Thoát";
            this.ThoátTSMI.Click += new System.EventHandler(this.ThoátTSMI_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 242);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách các hồ sơ bệnh án";
            // 
            // MH_NghienCuu_HSBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(80, 60);
            this.Name = "MH_NghienCuu_HSBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MH_NghienCuu_HSBA";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_timHSBA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnTSMI;
        private System.Windows.Forms.ToolStripMenuItem infoTSMI;
        private System.Windows.Forms.ToolStripMenuItem HSBATSMI;
        private System.Windows.Forms.ToolStripMenuItem ThoátTSMI;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}