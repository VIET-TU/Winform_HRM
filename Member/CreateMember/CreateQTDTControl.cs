using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace HRM_Desktop.Member
{
    public partial class CreateQTDTControl : UserControl
    {
        public CreateQTDTControl()
        {
            InitializeComponent();
            guna2DateTimePicker_tu_ngay.Value = DateTime.Now;
            guna2DateTimePicker_den_ngay.Value = DateTime.Now ;



        }

        public static string IncrementMaQTDT(string maQTDT)
        {
            string numberPart = maQTDT.Substring(4);

            if (int.TryParse(numberPart, out int number))
            {
                number++;

                string newMaNV = $"{maQTDT.Substring(0, 4)}{number:D3}";

                return newMaNV;
            }

            // Trả về mã nhân viên ban đầu nếu không thể tăng giá trị
            return maQTDT;
        }

        private void CreateQTDTControl_Load(object sender, EventArgs e)
        {
            var lastRow = Connection.db.QTDTs
              .OrderByDescending(x => x.ma_qua_trinh_dt)  // Thay Id bằng khóa chính của bảng
              .FirstOrDefault();

            if (lastRow != null)
            {
                textBox_qtdt.Text = IncrementMaQTDT(lastRow.ma_qua_trinh_dt);

            } else
            {
                textBox_qtdt.Text = "QTDT001";

            }

            textBox_qtdt.ReadOnly = true;

            List<HSNV> list_hsnv = Connection.db.HSNVs.ToList();

            list_hsnv.ForEach(g =>
            {
                comboBox_mnv.Items.Add(g.ho_ten + " (" + g.ma_nv + ")");
            });

            List<TRUONG_DT> list_tdt = Connection.db.TRUONG_DT.ToList();

            list_tdt.ForEach(g =>
            {
                guna2ComboBox_mtdt.Items.Add(g.ten_truong_dt + " (" + g.ma_truong_dt + ")");
            });

            List<HINH_THUC> list_ht = Connection.db.HINH_THUC.ToList();

            list_ht.ForEach(g =>
            {
                guna2ComboBox_mht.Items.Add(g.ten_hinh_thuc + " (" + g.ma_hinh_thuc + ")");
            });

            List<NGANH_DT> list_ndt = Connection.db.NGANH_DT.ToList();

            list_ndt.ForEach(g =>
            {
                guna2ComboBox_mndt.Items.Add(g.ten_nganh_dt + " (" + g.ma_nganh_dt + ")");
            });

            List<XEP_LOAI> list_xl = Connection.db.XEP_LOAI.ToList();

            list_xl.ForEach(g =>
            {
                guna2ComboBox_mxl.Items.Add(g.ten_xep_loai + " (" + g.ma_xep_loai + ")");
            });

            guna2ComboBox_mxl.Enabled = false;

        }

        public bool CreateQTDT ()
        {
            var ma_qtdt = textBox_qtdt.Text;
            var ma_nv = splitString(comboBox_mnv.Text);
            var ma_tdt = splitString(guna2ComboBox_mtdt.Text);
            var ma_ht = splitString(guna2ComboBox_mht.Text);
            var ma_ndt = splitString(guna2ComboBox_mndt.Text);
            var ma_xl = splitString(guna2ComboBox_mxl.Text);
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            var den_ngay = guna2DateTimePicker_den_ngay.Value;

            if(ValidateInput())
            {

                // check exit
                var exits = Connection.db.QTDTs.FirstOrDefault(x => x.ma_nv.Equals(ma_nv) && x.ma_truong_dt.Equals(ma_tdt) && x.ma_nganh_dt.Equals(ma_ndt));

                if(exits != null)
                {
                    MessageBox.Show("Nganh dao dao tao da ton tai");
                    return false;
                }

                QTDT qTDT = new QTDT()
                {
                    ma_qua_trinh_dt = ma_qtdt,
                    ma_nv = ma_nv,
                    ma_truong_dt = ma_tdt,
                    ma_hinh_thuc = ma_ht,
                    ma_nganh_dt = ma_ndt,
                    tu_ngay = tu_ngay,
                    den_ngay = den_ngay,
                };
                Connection.db.QTDTs.Add(qTDT);
                Connection.db.SaveChanges();
                return true;
            }

            return false;
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
            var ma_nv = splitString(comboBox_mnv.Text);
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

            if (string.IsNullOrWhiteSpace(ma_tdt))
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

           


            DateTime ngayHienTai = DateTime.Now;

            if (tu_ngay.Date < ngayHienTai.Date)
            {
                guna2HtmlLabel_tungay.Text = "Từ ngày (không thể nhỏ hơn ngày hiện tại)";
                guna2HtmlLabel_tungay.ForeColor = Color.Red;
                isValid = false; 
            }

            if (den_ngay.Date <= tu_ngay.Date || den_ngay.Date < ngayHienTai.Date)
            {
                guna2HtmlLabel_denngay.Text = "Đến ngày (Ngày kết thúc phải lớn hơn ngày bắt đầu.)";
                guna2HtmlLabel_denngay.ForeColor = Color.Red;
                isValid = false;
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

        private void comboBox_mnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            setOriginLabel();
        }

        private void guna2ComboBox_mtdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            setOriginLabel();
        }

        private void guna2ComboBox_mht_SelectedIndexChanged(object sender, EventArgs e)
        {
            setOriginLabel();
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            switch (splitString(guna2ComboBox_mht.Text))
            {
                case "HT001":
                    guna2DateTimePicker_den_ngay.Value = tu_ngay.AddYears(4);
                    break;
                case "HT002":
                    guna2DateTimePicker_den_ngay.Value = tu_ngay.AddYears(2);
                    break;
                case "HT003":
                    guna2DateTimePicker_den_ngay.Value = tu_ngay.AddYears(3);
                    break;
                case "HT004":
                    guna2DateTimePicker_den_ngay.Value = tu_ngay.AddYears(4);
                    break;
                case "HT005":
                    guna2DateTimePicker_den_ngay.Value = tu_ngay.AddYears(2);
                    break;
            }
        }

        private void guna2ComboBox_mndt_SelectedIndexChanged(object sender, EventArgs e)
        {
            setOriginLabel();
        }

        private void guna2DateTimePicker_tu_ngay_ValueChanged(object sender, EventArgs e)
        {
            setOriginLabel();

            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;

            // Thêm 4 năm vào ngày hiện tại
            guna2DateTimePicker_den_ngay.Value = tu_ngay.AddYears(4);
        }

        private void guna2DateTimePicker_den_ngay_ValueChanged(object sender, EventArgs e)
        {
            setOriginLabel();
        }
    }
}


/*textBox_qtdt
comboBox_nv
guna2ComboBox_mtdt
guna2ComboBox_mht
guna2ComboBox_mndt
guna2ComboBox_mxl
guna2DateTimePicker_tu_ngay
guna2DateTimePicker_den_ngay*/

// Chinh quy: 4
// Tai chuc : 2
// lien thong: 3
// vawn bang 2: 2.5 nawm