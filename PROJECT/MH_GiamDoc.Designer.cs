
namespace PROJECT
{
    partial class MH_GiamDoc
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tùyChọnTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.infoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoátTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnTSMI,
            this.ThoátTSMI});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 28);
            this.menu.TabIndex = 43;
            this.menu.Text = "menu";
            // 
            // tùyChọnTSMI
            // 
            this.tùyChọnTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoTSMI,
            this.thôngBáoToolStripMenuItem});
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
            // thôngBáoToolStripMenuItem
            // 
            this.thôngBáoToolStripMenuItem.Checked = true;
            this.thôngBáoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.thôngBáoToolStripMenuItem.Name = "thôngBáoToolStripMenuItem";
            this.thôngBáoToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.thôngBáoToolStripMenuItem.Text = "Thông báo";
            // 
            // ThoátTSMI
            // 
            this.ThoátTSMI.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ThoátTSMI.Name = "ThoátTSMI";
            this.ThoátTSMI.Size = new System.Drawing.Size(59, 24);
            this.ThoátTSMI.Text = "Thoát";
            this.ThoátTSMI.Click += new System.EventHandler(this.ThoátTSMI_Click);
            // 
            // MH_GiamDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menu);
            this.Location = new System.Drawing.Point(80, 60);
            this.Name = "MH_GiamDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MH_GiamDoc";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnTSMI;
        private System.Windows.Forms.ToolStripMenuItem infoTSMI;
        private System.Windows.Forms.ToolStripMenuItem thôngBáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThoátTSMI;
    }
}