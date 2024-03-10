using Guna.UI2.WinForms;
using HRM_Desktop.Member.DetailMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member
{
    public partial class MemberDetailControl : UserControl
    {
        public HSNV hSNV { set; get; }
        public Panel Panel { get; }

        public MemberDetailControl(HSNV hSNV, Panel panel)
        {
            InitializeComponent();
            this.hSNV = hSNV;
            this.Panel = panel;

        }

        private void guna2Panel_detail_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel_detai_header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox_avatar_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_cm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_hv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel20_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_cv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_pb_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox_tg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel26_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_dt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel27_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel28_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_ns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_gt_SelectedIndexChanged(object sender, EventArgs e)
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

        private void MemberDetailControl_Load(object sender, EventArgs e)
        {
            

            TTNVControl tTNVControl = new TTNVControl(hSNV);

            tTNVControl.Dock = DockStyle.Fill;
            guna2Panel_memberdetail.Controls.Clear();
            guna2Panel_memberdetail.Controls.Add(tTNVControl);
            tTNVControl.BringToFront();




        }

        private void guna2Button_backtomembercontrol_Click(object sender, EventArgs e)
        {
            MemberControl memberControl = new MemberControl(this.Panel);

            memberControl.Dock = DockStyle.Fill;
            this.Panel.Controls.Clear();
            this.Panel.Controls.Add(memberControl);
            memberControl.BringToFront();
        }

        private void guna2Panel_memberdetail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button_ttnv_Click(object sender, EventArgs e)
        {
            TTNVControl tTNVControl = new TTNVControl(hSNV);

            tTNVControl.Dock = DockStyle.Fill;
            guna2Panel_memberdetail.Controls.Clear();
            guna2Panel_memberdetail.Controls.Add(tTNVControl);
            tTNVControl.BringToFront();
        }

        private void guna2Button_qtdt_Click(object sender, EventArgs e)
        {
            var count = Connection.db.QTDTs.Where(x => x.ma_nv.Equals(hSNV.ma_nv)).Count();
            if(count > 0)
            {
                QTDTControl qTDTControl = new QTDTControl(hSNV.ma_nv, this.Panel);
                qTDTControl.Dock = DockStyle.Fill;
                guna2Panel_memberdetail.Controls.Clear();
                guna2Panel_memberdetail.Controls.Add(qTDTControl);
                qTDTControl.BringToFront();
            } else
            {
                MessageBox.Show("Nhân viên này không có quá trình đào tạo");
            }
            
        }

        private void guna2Button_qtct_Click(object sender, EventArgs e)
        {
            var count = Connection.db.QTCTs.Where(x => x.ma_nv.Equals(hSNV.ma_nv)).Count();
            if (count > 0)
            {
                QTCTControl qTCTControl = new QTCTControl(hSNV.ma_nv, this.Panel);
                qTCTControl.Dock = DockStyle.Fill;
                guna2Panel_memberdetail.Controls.Clear();
                guna2Panel_memberdetail.Controls.Add(qTCTControl);
                qTCTControl.BringToFront();
            }
            else
            {
                MessageBox.Show("Nhân viên này không có quá trình công tác");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var count = Connection.db.NV_NGOAI_NGU.Where(x => x.ma_nv.Equals(hSNV.ma_nv)).Count();
            if (count != null)
            {
                NNControl nNControl = new NNControl(hSNV.ma_nv, this.Panel);
                nNControl.Dock = DockStyle.Fill;
                guna2Panel_memberdetail.Controls.Clear();
                guna2Panel_memberdetail.Controls.Add(nNControl);
                nNControl.BringToFront();
            }
            else
            {
                MessageBox.Show("Nhân viên này không có ngoại ngữ");
            }
        }
    }
}
