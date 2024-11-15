
namespace GUI
{
    partial class frm_XepLich
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
            this.btn_LoadGiangVien = new System.Windows.Forms.Button();
            this.btn_LoadLichThi = new System.Windows.Forms.Button();
            this.btn_XepLich = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.dgv_XepLich = new System.Windows.Forms.DataGridView();
            this.ofd_DocFile = new System.Windows.Forms.OpenFileDialog();
            this.txt_Diem = new System.Windows.Forms.TextBox();
            this.btn_XuatFileExcell = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XepLich)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoadGiangVien
            // 
            this.btn_LoadGiangVien.Location = new System.Drawing.Point(12, 99);
            this.btn_LoadGiangVien.Name = "btn_LoadGiangVien";
            this.btn_LoadGiangVien.Size = new System.Drawing.Size(124, 45);
            this.btn_LoadGiangVien.TabIndex = 0;
            this.btn_LoadGiangVien.Text = "Load giảng viên";
            this.btn_LoadGiangVien.UseVisualStyleBackColor = true;
            this.btn_LoadGiangVien.Click += new System.EventHandler(this.btn_LoadGiangVien_Click);
            // 
            // btn_LoadLichThi
            // 
            this.btn_LoadLichThi.Location = new System.Drawing.Point(12, 184);
            this.btn_LoadLichThi.Name = "btn_LoadLichThi";
            this.btn_LoadLichThi.Size = new System.Drawing.Size(124, 45);
            this.btn_LoadLichThi.TabIndex = 1;
            this.btn_LoadLichThi.Text = "Load lịch thi";
            this.btn_LoadLichThi.UseVisualStyleBackColor = true;
            this.btn_LoadLichThi.Click += new System.EventHandler(this.btn_LoadLichThi_Click);
            // 
            // btn_XepLich
            // 
            this.btn_XepLich.Location = new System.Drawing.Point(12, 269);
            this.btn_XepLich.Name = "btn_XepLich";
            this.btn_XepLich.Size = new System.Drawing.Size(124, 45);
            this.btn_XepLich.TabIndex = 2;
            this.btn_XepLich.Text = "Xếp lịch";
            this.btn_XepLich.UseVisualStyleBackColor = true;
            this.btn_XepLich.Click += new System.EventHandler(this.btn_XepLich_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(164, 30);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(195, 22);
            this.txt_Path.TabIndex = 3;
            // 
            // dgv_XepLich
            // 
            this.dgv_XepLich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_XepLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_XepLich.Location = new System.Drawing.Point(164, 88);
            this.dgv_XepLich.MultiSelect = false;
            this.dgv_XepLich.Name = "dgv_XepLich";
            this.dgv_XepLich.ReadOnly = true;
            this.dgv_XepLich.RowHeadersWidth = 51;
            this.dgv_XepLich.RowTemplate.Height = 24;
            this.dgv_XepLich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_XepLich.Size = new System.Drawing.Size(1652, 693);
            this.dgv_XepLich.TabIndex = 4;
            // 
            // ofd_DocFile
            // 
            this.ofd_DocFile.FileName = "openFileDialog1";
            // 
            // txt_Diem
            // 
            this.txt_Diem.Location = new System.Drawing.Point(164, 834);
            this.txt_Diem.Name = "txt_Diem";
            this.txt_Diem.Size = new System.Drawing.Size(195, 22);
            this.txt_Diem.TabIndex = 5;
            // 
            // btn_XuatFileExcell
            // 
            this.btn_XuatFileExcell.Location = new System.Drawing.Point(1599, 834);
            this.btn_XuatFileExcell.Name = "btn_XuatFileExcell";
            this.btn_XuatFileExcell.Size = new System.Drawing.Size(171, 67);
            this.btn_XuatFileExcell.TabIndex = 6;
            this.btn_XuatFileExcell.Text = "Xuất File";
            this.btn_XuatFileExcell.UseVisualStyleBackColor = true;
            this.btn_XuatFileExcell.Click += new System.EventHandler(this.btn_XuatFileExcell_Click);
            // 
            // frm_XepLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 959);
            this.Controls.Add(this.btn_XuatFileExcell);
            this.Controls.Add(this.txt_Diem);
            this.Controls.Add(this.dgv_XepLich);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.btn_XepLich);
            this.Controls.Add(this.btn_LoadLichThi);
            this.Controls.Add(this.btn_LoadGiangVien);
            this.Name = "frm_XepLich";
            this.Text = "frm_XepLich";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_XepLich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XepLich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadGiangVien;
        private System.Windows.Forms.Button btn_LoadLichThi;
        private System.Windows.Forms.Button btn_XepLich;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.DataGridView dgv_XepLich;
        private System.Windows.Forms.OpenFileDialog ofd_DocFile;
        private System.Windows.Forms.TextBox txt_Diem;
        private System.Windows.Forms.Button btn_XuatFileExcell;
    }
}