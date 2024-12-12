
using System.Drawing;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_XepLich));
            this.dgv_XepLich = new System.Windows.Forms.DataGridView();
            this.ofd_DocFile = new System.Windows.Forms.OpenFileDialog();
            this.txt_Diem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_XepLai = new System.Windows.Forms.Button();
            this.txt_DiemDotBien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ToiUu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_XuatFileExcell = new System.Windows.Forms.Button();
            this.btn_XepLich = new System.Windows.Forms.Button();
            this.btn_LoadLichThi = new System.Windows.Forms.Button();
            this.btn_LoadGiangVien = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XepLich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_XepLich
            // 
            this.dgv_XepLich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_XepLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_XepLich.Location = new System.Drawing.Point(438, 252);
            this.dgv_XepLich.MultiSelect = false;
            this.dgv_XepLich.Name = "dgv_XepLich";
            this.dgv_XepLich.ReadOnly = true;
            this.dgv_XepLich.RowHeadersWidth = 51;
            this.dgv_XepLich.RowTemplate.Height = 24;
            this.dgv_XepLich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_XepLich.Size = new System.Drawing.Size(1348, 584);
            this.dgv_XepLich.TabIndex = 4;
            // 
            // ofd_DocFile
            // 
            this.ofd_DocFile.FileName = "openFileDialog1";
            // 
            // txt_Diem
            // 
            this.txt_Diem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_Diem.Enabled = false;
            this.txt_Diem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Diem.Location = new System.Drawing.Point(456, 909);
            this.txt_Diem.Name = "txt_Diem";
            this.txt_Diem.Size = new System.Drawing.Size(222, 38);
            this.txt_Diem.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(456, 865);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Điểm xếp lịch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(547, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(978, 96);
            this.label2.TabIndex = 9;
            this.label2.Text = "TRƯỜNG ĐẠI HỌC CÔNG THƯƠNG TP. HỒ CHÍ MINH\r\n                   KHOA CÔNG NGHỆ THÔ" +
    "NG TIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(904, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 44);
            this.label3.TabIndex = 10;
            this.label3.Text = "XẾP LỊCH GÁC THI";
            // 
            // btn_XepLai
            // 
            this.btn_XepLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XepLai.Location = new System.Drawing.Point(1606, 888);
            this.btn_XepLai.Name = "btn_XepLai";
            this.btn_XepLai.Size = new System.Drawing.Size(180, 59);
            this.btn_XepLai.TabIndex = 11;
            this.btn_XepLai.Text = "Xếp lại";
            this.btn_XepLai.UseVisualStyleBackColor = true;
            this.btn_XepLai.Click += new System.EventHandler(this.btn_XepLai_Click);
            // 
            // txt_DiemDotBien
            // 
            this.txt_DiemDotBien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_DiemDotBien.Enabled = false;
            this.txt_DiemDotBien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DiemDotBien.Location = new System.Drawing.Point(787, 909);
            this.txt_DiemDotBien.Name = "txt_DiemDotBien";
            this.txt_DiemDotBien.Size = new System.Drawing.Size(222, 38);
            this.txt_DiemDotBien.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(787, 864);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Điểm sau tối ưu";
            // 
            // btn_ToiUu
            // 
            this.btn_ToiUu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ToiUu.Location = new System.Drawing.Point(1362, 888);
            this.btn_ToiUu.Name = "btn_ToiUu";
            this.btn_ToiUu.Size = new System.Drawing.Size(180, 59);
            this.btn_ToiUu.TabIndex = 14;
            this.btn_ToiUu.Text = "Tối ưu hoá";
            this.btn_ToiUu.UseVisualStyleBackColor = true;
            this.btn_ToiUu.Click += new System.EventHandler(this.btn_ToiUu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(97, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_XuatFileExcell
            // 
            this.btn_XuatFileExcell.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_XuatFileExcell.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatFileExcell.Image = ((System.Drawing.Image)(resources.GetObject("btn_XuatFileExcell.Image")));
            this.btn_XuatFileExcell.Location = new System.Drawing.Point(46, 738);
            this.btn_XuatFileExcell.Name = "btn_XuatFileExcell";
            this.btn_XuatFileExcell.Size = new System.Drawing.Size(284, 98);
            this.btn_XuatFileExcell.TabIndex = 6;
            this.btn_XuatFileExcell.Text = "Xuất File";
            this.btn_XuatFileExcell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_XuatFileExcell.UseVisualStyleBackColor = true;
            this.btn_XuatFileExcell.Click += new System.EventHandler(this.btn_XuatFileExcell_Click);
            // 
            // btn_XepLich
            // 
            this.btn_XepLich.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XepLich.Image = ((System.Drawing.Image)(resources.GetObject("btn_XepLich.Image")));
            this.btn_XepLich.Location = new System.Drawing.Point(46, 584);
            this.btn_XepLich.Name = "btn_XepLich";
            this.btn_XepLich.Size = new System.Drawing.Size(284, 98);
            this.btn_XepLich.TabIndex = 2;
            this.btn_XepLich.Text = "Xếp Lịch";
            this.btn_XepLich.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_XepLich.UseVisualStyleBackColor = true;
            this.btn_XepLich.Click += new System.EventHandler(this.btn_XepLich_Click);
            // 
            // btn_LoadLichThi
            // 
            this.btn_LoadLichThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadLichThi.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoadLichThi.Image")));
            this.btn_LoadLichThi.Location = new System.Drawing.Point(46, 430);
            this.btn_LoadLichThi.Name = "btn_LoadLichThi";
            this.btn_LoadLichThi.Size = new System.Drawing.Size(284, 98);
            this.btn_LoadLichThi.TabIndex = 1;
            this.btn_LoadLichThi.Text = "Load Lịch Thi";
            this.btn_LoadLichThi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_LoadLichThi.UseVisualStyleBackColor = true;
            this.btn_LoadLichThi.Click += new System.EventHandler(this.btn_LoadLichThi_Click);
            // 
            // btn_LoadGiangVien
            // 
            this.btn_LoadGiangVien.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_LoadGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadGiangVien.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoadGiangVien.Image")));
            this.btn_LoadGiangVien.Location = new System.Drawing.Point(46, 276);
            this.btn_LoadGiangVien.Name = "btn_LoadGiangVien";
            this.btn_LoadGiangVien.Size = new System.Drawing.Size(284, 98);
            this.btn_LoadGiangVien.TabIndex = 0;
            this.btn_LoadGiangVien.Text = "Load Giảng Viên";
            this.btn_LoadGiangVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_LoadGiangVien.UseVisualStyleBackColor = true;
            this.btn_LoadGiangVien.Click += new System.EventHandler(this.btn_LoadGiangVien_Click);
            // 
            // frm_XepLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1819, 975);
            this.Controls.Add(this.btn_ToiUu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_DiemDotBien);
            this.Controls.Add(this.btn_XepLai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_XuatFileExcell);
            this.Controls.Add(this.txt_Diem);
            this.Controls.Add(this.dgv_XepLich);
            this.Controls.Add(this.btn_XepLich);
            this.Controls.Add(this.btn_LoadLichThi);
            this.Controls.Add(this.btn_LoadGiangVien);
            this.Name = "frm_XepLich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_XepLich";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_XepLich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XepLich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadGiangVien;
        private System.Windows.Forms.Button btn_LoadLichThi;
        private System.Windows.Forms.Button btn_XepLich;
        private System.Windows.Forms.DataGridView dgv_XepLich;
        private System.Windows.Forms.OpenFileDialog ofd_DocFile;
        private System.Windows.Forms.TextBox txt_Diem;
        private System.Windows.Forms.Button btn_XuatFileExcell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_XepLai;
        private System.Windows.Forms.TextBox txt_DiemDotBien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ToiUu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}