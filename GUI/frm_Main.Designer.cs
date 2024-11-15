
namespace GUI
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_XepLich = new System.Windows.Forms.ToolStripButton();
            this.tsb_LichGacThi = new System.Windows.Forms.ToolStripButton();
            this.tsb_XuatBaoCao = new System.Windows.Forms.ToolStripButton();
            this.tsb_Thoat = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(1220, 657);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_XepLich,
            this.tsb_LichGacThi,
            this.tsb_XuatBaoCao,
            this.tsb_Thoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1245, 91);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_XepLich
            // 
            this.tsb_XepLich.AutoSize = false;
            this.tsb_XepLich.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_XepLich.Image = ((System.Drawing.Image)(resources.GetObject("tsb_XepLich.Image")));
            this.tsb_XepLich.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_XepLich.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_XepLich.Name = "tsb_XepLich";
            this.tsb_XepLich.Size = new System.Drawing.Size(197, 88);
            this.tsb_XepLich.Text = "Xếp lịch";
            this.tsb_XepLich.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_XepLich.Click += new System.EventHandler(this.tsb_XepLich_Click);
            // 
            // tsb_LichGacThi
            // 
            this.tsb_LichGacThi.AutoSize = false;
            this.tsb_LichGacThi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_LichGacThi.Image = ((System.Drawing.Image)(resources.GetObject("tsb_LichGacThi.Image")));
            this.tsb_LichGacThi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_LichGacThi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_LichGacThi.Name = "tsb_LichGacThi";
            this.tsb_LichGacThi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsb_LichGacThi.Size = new System.Drawing.Size(197, 88);
            this.tsb_LichGacThi.Text = "Lịch gác thi";
            this.tsb_LichGacThi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_LichGacThi.Click += new System.EventHandler(this.tsb_LichGacThi_Click);
            // 
            // tsb_XuatBaoCao
            // 
            this.tsb_XuatBaoCao.AutoSize = false;
            this.tsb_XuatBaoCao.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_XuatBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("tsb_XuatBaoCao.Image")));
            this.tsb_XuatBaoCao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_XuatBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_XuatBaoCao.Name = "tsb_XuatBaoCao";
            this.tsb_XuatBaoCao.Size = new System.Drawing.Size(197, 88);
            this.tsb_XuatBaoCao.Text = "Xuất báo cáo";
            this.tsb_XuatBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_XuatBaoCao.Click += new System.EventHandler(this.tsb_XuatBaoCao_Click);
            // 
            // tsb_Thoat
            // 
            this.tsb_Thoat.AutoSize = false;
            this.tsb_Thoat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_Thoat.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Thoat.Image")));
            this.tsb_Thoat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_Thoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Thoat.Name = "tsb_Thoat";
            this.tsb_Thoat.Size = new System.Drawing.Size(197, 88);
            this.tsb_Thoat.Text = "Thoát";
            this.tsb_Thoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1245, 657);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 748);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xếp lịch gác thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_XepLich;
        private System.Windows.Forms.ToolStripButton tsb_XuatBaoCao;
        private System.Windows.Forms.ToolStripButton tsb_LichGacThi;
        private System.Windows.Forms.ToolStripButton tsb_Thoat;
        private System.Windows.Forms.Panel panel1;
    }
}

