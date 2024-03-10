using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.DetailMember.QTCTDetial
{
    public partial class EditQTCTControl : UserControl
    {
        public string mqtdt;
        public Panel panel_body;
        public string mnv;
        public EditQTCTControl(string mnv,string mqtdt, Panel panel_body)
        {
            InitializeComponent();
            this.mqtdt = mqtdt;
            this.panel_body = panel_body;
            this.mnv = mnv;
        }

        private void EditQTCTControl_Load(object sender, EventArgs e)
        {
            var qtct = Connection.db.QTCTs.FirstOrDefault(x => x.ma_qtct.Equals(mqtdt));

            if(qtct != null)
            {
                textBox_qtct.Text = qtct.ma_qtct;
                guna2TextBox_mnv.Text = qtct.ma_nv;
                guna2TextBox_mpb.Text = qtct.ma_phong_ban;
                guna2TextBox_mcv.Text = qtct.ma_chuc_vu;
                guna2DateTimePicker_tu_ngay.Value = qtct.tu_ngay.Value;
                guna2DateTimePicker_den_ngay.Value = qtct.den_ngay.Value;
            }
        }

        private void guna2Button_thoat_Click(object sender, EventArgs e)
        {


            QTCTControl qTDTControl = new QTCTControl(mnv, panel_body);
            qTDTControl.Dock = DockStyle.Fill;
            panel_body.Controls.Clear();
            panel_body.Controls.Add(qTDTControl);
            qTDTControl.BringToFront();
        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            var ma_qtct = textBox_qtct.Text;
            var ma_nv = guna2TextBox_mnv.Text;
            var ma_pb = guna2TextBox_mpb.Text;
            var ma_cv = guna2TextBox_mcv.Text;
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            var den_ngay = guna2DateTimePicker_den_ngay.Value;

            QTCT qTCT = new QTCT()
            {
                ma_qtct = ma_qtct,
                ma_nv = ma_nv,
                ma_phong_ban = ma_pb,
                ma_chuc_vu = ma_cv,
                tu_ngay = tu_ngay,
                den_ngay = den_ngay
            };

            Connection.db.QTCTs.AddOrUpdate(qTCT);
            Connection.db.SaveChanges();

    


            QTCTControl qTDTControl = new QTCTControl(mnv, panel_body);
            qTDTControl.Dock = DockStyle.Fill;
            panel_body.Controls.Clear();
            panel_body.Controls.Add(qTDTControl);
            qTDTControl.BringToFront();
        }

       
    }
}
