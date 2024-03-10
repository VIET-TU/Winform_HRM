using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.DetailMember
{
    public partial class TTNVControl : UserControl
    {
        public HSNV hSNV { get; set; }
        public TTNVControl(HSNV hSNV)
        {
            InitializeComponent();
            this.hSNV = hSNV;
        }

        private void guna2Panel_detail_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox_cm_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_hv_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_pb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_cv_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_tg_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_dt_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_ns_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox_gt_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel20_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel21_Click(object sender, EventArgs e)
        {

        }

        private void textBox_con_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel22_Click(object sender, EventArgs e)
        {

        }

        private void textBox_vo_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel23_Click(object sender, EventArgs e)
        {

        }

        private void textBox_diachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel25_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel26_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel27_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel28_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker_ngay_sinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel29_Click(object sender, EventArgs e)
        {

        }

        private void textBox_sccd_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel30_Click(object sender, EventArgs e)
        {

        }

        private void textBox_quequan_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel31_Click(object sender, EventArgs e)
        {

        }

        private void textBox_dienthoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel32_Click(object sender, EventArgs e)
        {

        }

        private void textBox_hoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel33_Click(object sender, EventArgs e)
        {

        }

        private void textBox_mnv_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel34_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox_avatar_Click(object sender, EventArgs e)
        {

        }

        private void TTNVControl_Load(object sender, EventArgs e)
        {
            textBox_mnv.Text = hSNV.ma_nv;
            textBox_hoten.Text = hSNV.ho_ten;
            textBox_dienthoai.Text = hSNV.dien_thoai;
            textBox_quequan.Text = hSNV.que_quan;
            textBox_sccd.Text = hSNV.so_cccd;
            guna2DateTimePicker_ngay_sinh.Value = hSNV.ngay_sinh;
            guna2TextBox_gt.Text = hSNV.GIOI_TINH.ten_gioi_tinh;
            guna2TextBox_dt.Text = hSNV.DAN_TOC.ten_dan_toc;
            guna2TextBox_ns.Text = hSNV.NOI_SINH.ten_noi_sinh;
            guna2TextBox_tg.Text = hSNV.TON_GIAO.ma_ton_giao;
            textBox_diachi.Text = hSNV.dia_chi;
            textBox_vo.Text = hSNV.vo_chong;
            textBox_con.Text = hSNV.con;
            guna2TextBox_pb.Text = hSNV.PHONG_BAN.ten_phong_ban;
            guna2TextBox_cv.Text = hSNV.CHUC_VU.ten_chuc_vu;
            guna2TextBox_hv.Text = hSNV.HOC_VAN.ten_hoc_van;
            guna2TextBox_cm.Text = hSNV.CHUYEN_MON.ten_chuyen_mon;

            guna2CirclePictureBox_avatar.Image = Image.FromFile(hSNV.avatar);
        }
    }
}
