using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.DetailMember.QTDTDetial
{
    public partial class EditQTDTControl : UserControl
    {
        public QTDT qTDT { get; set; }
        public Panel panel_body { get; set; }
        public EditQTDTControl(QTDT qTDT, Panel panel_body)
        {
            InitializeComponent();
            this.qTDT = qTDT;
            this.panel_body = panel_body;

        

            List<TRUONG_DT> list_tdt = Connection.db.TRUONG_DT.ToList();

            string tdt = qTDT.TRUONG_DT.ten_truong_dt + " (" + qTDT.ma_truong_dt + ")";
            int index = 0;
            list_tdt.ForEach(g =>
            {
                guna2ComboBox_mtdt.Items.Add(g.ten_truong_dt + " (" + g.ma_truong_dt + ")");
                if(tdt.Equals(g.ten_truong_dt + " (" + g.ma_truong_dt + ")"))
                {
                    guna2ComboBox_mtdt.SelectedIndex = index;
                }
                index++;
            });

            List<HINH_THUC> list_ht = Connection.db.HINH_THUC.ToList();
            index = 0;
            string ht = qTDT.HINH_THUC.ten_hinh_thuc + " (" + qTDT.ma_hinh_thuc + ")";
            list_ht.ForEach(g =>
            {
                guna2ComboBox_mht.Items.Add(g.ten_hinh_thuc + " (" + g.ma_hinh_thuc + ")");
                if (ht.Equals(g.ten_hinh_thuc + " (" + g.ma_hinh_thuc + ")"))
                {
                    guna2ComboBox_mht.SelectedIndex = index;
                }
                index++;

            });

            List<NGANH_DT> list_ndt = Connection.db.NGANH_DT.ToList();
            index = 0;
            string ndt = qTDT.NGANH_DT.ten_nganh_dt + " (" + qTDT.ma_nganh_dt + ")";
            list_ndt.ForEach(g =>
            {
                guna2ComboBox_mndt.Items.Add(g.ten_nganh_dt + " (" + g.ma_nganh_dt + ")");
                if (ndt.Equals(g.ten_nganh_dt + " (" + g.ma_nganh_dt + ")"))
                {
                    guna2ComboBox_mndt.SelectedIndex = index;
                }
                index++;

            });

            List<XEP_LOAI> list_xl = Connection.db.XEP_LOAI.ToList();
            index = 0;
            if (qTDT.ma_xep_loai != null)
            {
                string xl = qTDT.XEP_LOAI.ten_xep_loai + " (" + qTDT.ma_xep_loai + ")";
                list_xl.ForEach(g =>
                {
                    guna2ComboBox_mxl.Items.Add(g.ten_xep_loai + " (" + g.ma_xep_loai + ")");
                    if (xl.Equals(g.ten_xep_loai + " (" + g.ma_xep_loai + ")"))
                    {
                        guna2ComboBox_mxl.SelectedIndex = index;
                    }
                    index++;

                });
            } else
            {
                guna2ComboBox_mxl.Enabled = false;
            }
           

        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            var ma_qtdt = textBox_qtdt.Text;
            var ma_nv = (guna2TextBox_mnv.Text);
            var ma_tdt = splitString(guna2ComboBox_mtdt.Text);
            var ma_ht = splitString(guna2ComboBox_mht.Text);
            var ma_ndt = splitString(guna2ComboBox_mndt.Text);
            var ma_xl = splitString(guna2ComboBox_mxl.Text);
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            var den_ngay = guna2DateTimePicker_den_ngay.Value;

            if (ValidateInput())
            {
                // check exit
                var exits = Connection.db.QTDTs.FirstOrDefault(x => x.ma_nv.Equals(ma_nv) && x.ma_truong_dt.Equals(ma_tdt) && x.ma_nganh_dt.Equals(ma_ndt));

                if (exits != null)
                {
                    MessageBox.Show("Nganh dao dao tao da ton tai");
                    return ;
                }


                QTDT qTDT = new QTDT()
                {
                    ma_qua_trinh_dt = ma_qtdt,
                    ma_nv = ma_nv,
                    ma_truong_dt = ma_tdt,
                    ma_hinh_thuc = ma_ht,
                    ma_nganh_dt = ma_ndt,
                    ma_xep_loai = ma_xl,
                    tu_ngay = tu_ngay,
                    den_ngay = den_ngay,
                };
                Connection.db.QTDTs.AddOrUpdate(qTDT);
                Connection.db.SaveChanges();

                var qTDTs = Connection.db.QTDTs.Where(x => x.ma_nv.Equals(qTDT.ma_nv)).FirstOrDefault();


                QTDTControl qTDTControl = new QTDTControl(qTDT.ma_nv, panel_body);
                qTDTControl.Dock = DockStyle.Fill;
                panel_body.Controls.Clear();
                panel_body.Controls.Add(qTDTControl);
                qTDTControl.BringToFront();

            }

           
        }

        private void guna2Button_thoat_Click(object sender, EventArgs e)
        {
            var qTDTs = Connection.db.QTDTs.Where(x => x.ma_nv.Equals(qTDT.ma_nv)).FirstOrDefault();


            QTDTControl qTDTControl = new QTDTControl(qTDT.ma_nv, panel_body);
            qTDTControl.Dock = DockStyle.Fill;
            panel_body.Controls.Clear();
            panel_body.Controls.Add(qTDTControl);
            qTDTControl.BringToFront();
        }


       

        public string splitString(string str)
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            Match match = regex.Match(str);
            return match.Groups[1].Value;

        }

        private bool ValidateInput()
        {
            setOriginLabel();

            var ma_qtdt = textBox_qtdt.Text;
            var ma_nv = (guna2TextBox_mnv.Text);
            var ma_tdt = splitString(guna2ComboBox_mtdt.Text);
            var ma_ht = splitString(guna2ComboBox_mht.Text);
            var ma_ndt = splitString(guna2ComboBox_mndt.Text);
            var ma_xl = splitString(guna2ComboBox_mxl.Text);
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            var den_ngay = guna2DateTimePicker_den_ngay.Value;

            bool isValid = true;


            if (string.IsNullOrWhiteSpace(ma_nv))
            {
                guna2HtmlLabel_mnv.Text = "Mã nhân viên (không được để trống)";
                guna2HtmlLabel_mnv.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_nv))
            {
                guna2HtmlLabel_tdt.Text = "Trường đào tạo (không được để trống)";
                guna2HtmlLabel_tdt.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_ht))
            {
                guna2HtmlLabel_ht.Text = "Hình thức (không được để trống)";
                guna2HtmlLabel_ht.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_ndt))
            {
                guna2HtmlLabel_ndt.Text = "Ngành đào tạo (không được để trống)";
                guna2HtmlLabel_ndt.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_ndt))
            {
                guna2HtmlLabel_xl.Text = "Xếp loại (không được để trống)";
                guna2HtmlLabel_xl.ForeColor = Color.Red;
            }


           

            return isValid;
        }

        public void setOriginLabel()
        {

            guna2HtmlLabel_mnv.Text = "Mã nhân viên";
            guna2HtmlLabel_mnv.ForeColor = Color.Black;
            guna2HtmlLabel_tdt.Text = "Trường đào tạo";
            guna2HtmlLabel_tdt.ForeColor = Color.Black;
            guna2HtmlLabel_ht.Text = "Hình thức";
            guna2HtmlLabel_ht.ForeColor = Color.Black;
            guna2HtmlLabel_ndt.Text = "Ngành đào tạo";
            guna2HtmlLabel_ndt.ForeColor = Color.Black;
            guna2HtmlLabel_xl.Text = "Xếp loại";
            guna2HtmlLabel_xl.ForeColor = Color.Black;
            guna2HtmlLabel_tungay.Text = "Từ ngày";
            guna2HtmlLabel_tungay.ForeColor = Color.Black;
            guna2HtmlLabel_denngay.Text = "Đến ngày";
            guna2HtmlLabel_denngay.ForeColor = Color.Black;
        }

        private void EditQTDTControl_Load(object sender, EventArgs e)
        {
            if (qTDT != null)
            {
                textBox_qtdt.Text = qTDT.ma_qua_trinh_dt;
                guna2TextBox_mnv.Text = qTDT.ma_nv;

                List<TRUONG_DT> list_tdt = Connection.db.TRUONG_DT.ToList();
                switch(qTDT.TRUONG_DT.ten_truong_dt + " (" + qTDT.ma_truong_dt + ")")
                {

                }
                
                guna2DateTimePicker_tu_ngay.Value = (DateTime)qTDT.tu_ngay;
                guna2DateTimePicker_den_ngay.Value = (DateTime)qTDT.den_ngay;
            }
        }
    }
}
