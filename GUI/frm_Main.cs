using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e) { 

        }

        private void tsb_XuatBaoCao_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            //Us_XuatBaoCao us = new Us_XuatBaoCao(); ////Không nhớ thì cop cái này nha!!!!!!!!!!!!!
            //us.Dock = DockStyle.Fill;
            //panel1.Controls.Add(us);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsb_LichGacThi_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Us_LichGacThi us = new Us_LichGacThi();
            us.Dock = DockStyle.Fill;
            panel1.Controls.Add(us);
        }

        

        private void tsb_XepLich_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Us_XepLichThi us = new Us_XepLichThi();
            us.Dock = DockStyle.Fill;
            panel1.Controls.Add(us);
        }
    }
}
