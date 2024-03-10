using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member
{
    public partial class CreateQTCTControl : UserControl
    {
        public CreateQTCTControl()
        {
            InitializeComponent();

            guna2DateTimePicker_tu_ngay.Value = DateTime.Now;
            guna2DateTimePicker_den_ngay.Value = DateTime.Now;

        }

        public static string IncrementMaQTCT(string maNV)
        {
            string numberPart = maNV.Substring(4);

            if (int.TryParse(numberPart, out int number))
            {
                number++;

                string newMaNV = $"{maNV.Substring(0, 4)}{number:D3}";

                return newMaNV;
            }

            // Trả về mã nhân viên ban đầu nếu không thể tăng giá trị
            return maNV;
        }

        private void CreateQTCTControl_Load(object sender, EventArgs e)
        {
                var lastRow = Connection.db.QTCTs
             .OrderByDescending(x => x.ma_qtct)  // Thay Id bằng khóa chính của bảng
             .FirstOrDefault();


            textBox_qtct.Text = IncrementMaQTCT(lastRow.ma_qtct);
            textBox_qtct.ReadOnly = true;

            List<HSNV> list_hsnv = Connection.db.HSNVs.ToList();

            list_hsnv.ForEach(g =>
            {
                comboBox_mnv.Items.Add(g.ho_ten + " (" + g.ma_nv + ")");
            });
        }

        public string splitString(string str)
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            Match match = regex.Match(str);
            return match.Groups[1].Value;
        }

        private void comboBox_mnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mnv = splitString(comboBox_mnv.Text);

            if (mnv.Trim().Length > 0)
            {
                HSNV hSNV = Connection.db.HSNVs
                 .Where(nv => nv.ma_nv.Equals(mnv))
                 .Include(nv => nv.CHUC_VU)
                 .Include(nv => nv.PHONG_BAN)  
                 .FirstOrDefault();

                if (hSNV != null)
                {
                    guna2ComboBox_mpb.Items.Add(hSNV.PHONG_BAN.ten_phong_ban + " (" + hSNV.PHONG_BAN.ma_phong_ban + ")");
                    guna2ComboBox_mpb.SelectedItem = hSNV.PHONG_BAN.ten_phong_ban + " (" + hSNV.PHONG_BAN.ma_phong_ban + ")";

                    guna2ComboBox_mcv.Items.Add(hSNV.CHUC_VU.ten_chuc_vu + " (" + hSNV.CHUC_VU.ma_chuc_vu + ")");
                    guna2ComboBox_mcv.SelectedItem = hSNV.CHUC_VU.ten_chuc_vu + " (" + hSNV.CHUC_VU.ma_chuc_vu + ")";

                }
            }
        }

        

        public bool CreateQTCT()
        {
            var ma_qtct = textBox_qtct.Text;
            var ma_nv = splitString(comboBox_mnv.Text);
            var ma_pb = splitString(guna2ComboBox_mpb.Text);
            var ma_cv = splitString(guna2ComboBox_mcv.Text);
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            var den_ngay = guna2DateTimePicker_den_ngay.Value;

           if(VailidateInput())
            {

                // check exits

                bool dung = DateTime.Now < tu_ngay;

                var exits = Connection.db.QTCTs.Where(x => x.ma_nv.Equals(ma_nv) && x.ma_chuc_vu.Equals(ma_cv) &&  x.den_ngay.Value > DateTime.Now).ToList();


                if (exits != null)
                {
                    MessageBox.Show("Chuc vu nay da ton tai");
                    return false;
                }

                QTCT qTCT = new QTCT()
                {
                    ma_qtct = ma_qtct,
                    ma_nv = ma_nv,
                    ma_phong_ban = ma_pb,
                    ma_chuc_vu = ma_cv,
                    tu_ngay = tu_ngay,
                    den_ngay = den_ngay
                };

                Connection.db.QTCTs.Add(qTCT);
                Connection.db.SaveChanges();
                return true;

            }

            return false;
        }


        public bool VailidateInput()
        {
            var ma_qtct = textBox_qtct.Text;
            var ma_nv = comboBox_mnv.Text;
            var ma_pb = guna2ComboBox_mpb.Text;
            var ma_cv = guna2ComboBox_mcv.Text;
            var tu_ngay = guna2DateTimePicker_tu_ngay.Value;
            var den_ngay = guna2DateTimePicker_den_ngay.Value;

            bool isVaild = true;

            if (string.IsNullOrWhiteSpace(ma_nv))
            {
                guna2HtmlLabel_mnv.Text = "Mã nhân viên (không được để trống)";
                guna2HtmlLabel_mnv.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_pb))
            {
                guna2HtmlLabel_pb.Text = "Phòng ban (không được để trống)";
                guna2HtmlLabel_pb.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_cv))
            {
                guna2HtmlLabel_cv.Text = "Chức vụ (không được để trống)";
                guna2HtmlLabel_cv.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_pb))
            {
                guna2HtmlLabel_pb.Text = "Phòng ban (không được để trống)";
                guna2HtmlLabel_pb.ForeColor = Color.Red;
            }

            DateTime ngayHienTai = DateTime.Now;

            if (tu_ngay.Date < ngayHienTai.Date)
            {
                guna2HtmlLabel_tu_ngay.Text = "Từ ngày (không thể nhỏ hơn ngày hiện tại)";
                guna2HtmlLabel_tu_ngay.ForeColor = Color.Red;
                isVaild = false;
            }

            if (den_ngay.Date <= tu_ngay.Date || den_ngay.Date < ngayHienTai.Date)
            {
                guna2HtmlLabel_den_ngay.Text = "Đến ngày (Ngày kết thúc phải lớn hơn ngày bắt đầu.)";
                guna2HtmlLabel_den_ngay.ForeColor = Color.Red;
                isVaild = false;
            }

            return isVaild;
        }
    }
}
