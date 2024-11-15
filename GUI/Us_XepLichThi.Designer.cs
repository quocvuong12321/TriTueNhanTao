
namespace GUI
{
    partial class Us_XepLichThi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_XepLich = new System.Windows.Forms.DataGridView();
            this.btn_LoadGiangVien = new System.Windows.Forms.Button();
            this.btn_LoadLichThi = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.ofd_DocFile = new System.Windows.Forms.OpenFileDialog();
            this.btn_XepLich = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XepLich)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_XepLich
            // 
            this.dgv_XepLich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_XepLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_XepLich.Location = new System.Drawing.Point(239, 83);
            this.dgv_XepLich.MultiSelect = false;
            this.dgv_XepLich.Name = "dgv_XepLich";
            this.dgv_XepLich.ReadOnly = true;
            this.dgv_XepLich.RowHeadersWidth = 51;
            this.dgv_XepLich.RowTemplate.Height = 24;
            this.dgv_XepLich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_XepLich.Size = new System.Drawing.Size(1375, 682);
            this.dgv_XepLich.TabIndex = 0;
            // 
            // btn_LoadGiangVien
            // 
            this.btn_LoadGiangVien.Location = new System.Drawing.Point(31, 84);
            this.btn_LoadGiangVien.Name = "btn_LoadGiangVien";
            this.btn_LoadGiangVien.Size = new System.Drawing.Size(146, 49);
            this.btn_LoadGiangVien.TabIndex = 1;
            this.btn_LoadGiangVien.Text = "load giảng viên";
            this.btn_LoadGiangVien.UseVisualStyleBackColor = true;
            this.btn_LoadGiangVien.Click += new System.EventHandler(this.btn_LoadGiangVien_Click);
            // 
            // btn_LoadLichThi
            // 
            this.btn_LoadLichThi.Location = new System.Drawing.Point(31, 163);
            this.btn_LoadLichThi.Name = "btn_LoadLichThi";
            this.btn_LoadLichThi.Size = new System.Drawing.Size(146, 49);
            this.btn_LoadLichThi.TabIndex = 2;
            this.btn_LoadLichThi.Text = "Load lịch thi";
            this.btn_LoadLichThi.UseVisualStyleBackColor = true;
            this.btn_LoadLichThi.Click += new System.EventHandler(this.btn_LoadLichThi_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(239, 45);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(211, 22);
            this.txt_path.TabIndex = 3;
            this.txt_path.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ofd_DocFile
            // 
            this.ofd_DocFile.FileName = "openFileDialog1";
            // 
            // btn_XepLich
            // 
            this.btn_XepLich.Location = new System.Drawing.Point(31, 242);
            this.btn_XepLich.Name = "btn_XepLich";
            this.btn_XepLich.Size = new System.Drawing.Size(146, 49);
            this.btn_XepLich.TabIndex = 4;
            this.btn_XepLich.Text = "Xếp lịch";
            this.btn_XepLich.UseVisualStyleBackColor = true;
            this.btn_XepLich.Click += new System.EventHandler(this.btn_XepLich_Click);
            // 
            // Us_XepLichThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_XepLich);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.btn_LoadLichThi);
            this.Controls.Add(this.btn_LoadGiangVien);
            this.Controls.Add(this.dgv_XepLich);
            this.Name = "Us_XepLichThi";
            this.Size = new System.Drawing.Size(1544, 768);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XepLich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_XepLich;
        private System.Windows.Forms.Button btn_LoadGiangVien;
        private System.Windows.Forms.Button btn_LoadLichThi;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.OpenFileDialog ofd_DocFile;
        private System.Windows.Forms.Button btn_XepLich;
    }
}
