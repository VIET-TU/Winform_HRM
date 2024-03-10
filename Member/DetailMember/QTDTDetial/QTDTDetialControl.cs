using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.DetailMember.QTDTDetial
{
    public partial class QTDTDetialControl : UserControl
    {
        public QTDT qTDT;
        public Panel panel;

        public QTDTDetialControl(QTDT qTDT, Panel panel)
        {
            InitializeComponent();
            this.qTDT = qTDT;
            this.panel = panel;
        }

        private void QTDTDetialControl_Load(object sender, EventArgs e)
        {
            if(qTDT != null)
            {
                textBox_qtdt.Text = qTDT.ma_qua_trinh_dt;
                guna2TextBox_mnv.Text = qTDT.ma_nv;
                guna2TextBox_tdt.Text = qTDT.TRUONG_DT.ten_truong_dt;
                guna2TextBox_ht.Text = qTDT.HINH_THUC.ten_hinh_thuc;
                guna2TextBox_ndt.Text = qTDT.NGANH_DT.ten_nganh_dt;
                guna2TextBox_xl.Text = qTDT.ma_xep_loai != null ? qTDT.XEP_LOAI.ten_xep_loai : "Chưa xếp loại";
                guna2DateTimePicker_tu_ngay.Value = (DateTime)qTDT.tu_ngay;
                guna2DateTimePicker_den_ngay.Value = (DateTime)qTDT.den_ngay;
            }
        }

        private void guna2Button_backtomembercontrol_Click(object sender, EventArgs e)
        {
            var qTDTs = Connection.db.QTDTs.Where(x => x.ma_nv.Equals(qTDT.ma_nv)).FirstOrDefault();
         
            
                QTDTControl qTDTControl = new QTDTControl(qTDT.ma_nv, panel);
                qTDTControl.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(qTDTControl);
                qTDTControl.BringToFront();
            
           
        }
    }
}
