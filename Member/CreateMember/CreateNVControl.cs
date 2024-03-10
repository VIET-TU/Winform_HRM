using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member
{
    public partial class CreateNVControl : UserControl
    {

        public static string url_file = "";
        public CreateNVControl()
        {
            InitializeComponent();
            guna2NumericUpDown_socon.Enabled = false;

        }

        public static string IncrementMaNV(string maNV)
        {
            string numberPart = maNV.Substring(2);

            if (int.TryParse(numberPart, out int number))
            {
                number++;

                string newMaNV = $"{maNV.Substring(0, 2)}{number:D3}";

                return newMaNV;
            }

            // Trả về mã nhân viên ban đầu nếu không thể tăng giá trị
            return maNV;
        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox_avatar.Image = Image.FromFile(ofd.FileName);
                url_file = ofd.FileName;
            }
        }

        private void CreateNVControl_Load(object sender, EventArgs e)
        {
            var lastRow = Connection.db.HSNVs
              .OrderByDescending(x => x.ma_nv)  // Thay Id bằng khóa chính của bảng
              .FirstOrDefault();



            textBox_mnv.Text = IncrementMaNV(lastRow.ma_nv);
            textBox_mnv.ReadOnly = true;

            List<GIOI_TINH> gts = Connection.db.GIOI_TINH.ToList();

            gts.ForEach(g =>
            {
                comboBox_gt.Items.Add(g.ten_gioi_tinh + " (" + g.ma_gioi_tinh + ")");
            });

            List<CHUC_VU> cvs = Connection.db.CHUC_VU.ToList();

            cvs.ForEach(g =>
            {
                comboBox_cv.Items.Add(g.ten_chuc_vu + " (" + g.ma_chuc_vu + ")");
            });

            List<DAN_TOC> dts = Connection.db.DAN_TOC.ToList();

            dts.ForEach(g =>
            {
                comboBox_dt.Items.Add(g.ten_dan_toc + " (" + g.ma_dan_toc + ")");
            });


            List<TON_GIAO> tgs = Connection.db.TON_GIAO.ToList();

            tgs.ForEach(g =>
            {
                comboBox_tg.Items.Add(g.ten_ton_giao + " (" + g.ma_ton_giao + ")");
            });


            List<NOI_SINH> nss = Connection.db.NOI_SINH.ToList();

            nss.ForEach(g =>
            {
                comboBox_ns.Items.Add(g.ten_noi_sinh + " (" + g.ma_noi_sinh + ")");
            });

            List<PHONG_BAN> pbs = Connection.db.PHONG_BAN.ToList();

            pbs.ForEach(g =>
            {
                comboBox_pb.Items.Add(g.ten_phong_ban + " (" + g.ma_phong_ban + ")");
            });

            List<HOC_VAN> hvs = Connection.db.HOC_VAN.ToList();

            hvs.ForEach(g =>
            {
                comboBox_hv.Items.Add(g.ten_hoc_van + " (" + g.ma_hoc_van + ")");
            });

            List<CHUYEN_MON> cms = Connection.db.CHUYEN_MON.ToList();

            cms.ForEach(g =>
            {
                comboBox_cm.Items.Add(g.ten_chuyen_mon + " (" + g.ma_chuyen_mon + ")");
            });
        }


        public bool createNV()
        {
            var ma_nv = textBox_mnv.Text;
            var ho_ten = textBox_hoten.Text;
            var ma_gioi_tinh = splitString(comboBox_gt.Text);
            var ma_chuc_vu = splitString(comboBox_cv.Text);
            var ma_dan_toc = splitString(comboBox_dt.Text);
            var ma_ton_giao = splitString(comboBox_tg.Text);
            DateTime ngay_sinh = guna2DateTimePicker_ngay_sinh.Value;
            var que_quan = textBox_quequan.Text;
            var ma_noi_sinh = splitString(comboBox_ns.Text);
            var dia_chi = textBox_diachi.Text;
            var dien_thoai = textBox_dienthoai.Text;
            var so_cccd = textBox_sccd.Text;
            var ma_phong_ban = splitString(comboBox_pb.Text);
            var ma_hoc_van = splitString(comboBox_hv.Text);
            var ma_chuyen_mon = splitString(comboBox_cm.Text);
            var vo_chong = textBox_vo.Text;
            if(vo_chong.Trim().Length < 0)
            {
                vo_chong = "Chưa kết hôn";
            }
            var con = guna2NumericUpDown_socon.Text;

            string avatar = url_file.Trim().Length > 0 ? url_file : ma_gioi_tinh.Equals("GT001")
                ? "D:\\LTTQ-2023-CNNT3\\Project__HRM-ha\\Images\\user_male.jpg" : "D:\\LTTQ-2023-CNNT3\\Project__HRM-ha\\Images\\user_female.jpg";

            if (!ValidateInput()) return false;

            if (checExitNV(ma_nv,so_cccd))
            {

                HSNV hSNV = new HSNV()
                {
                    ma_nv = ma_nv,
                    ho_ten = ho_ten,
                    ma_gioi_tinh = ma_gioi_tinh,
                    ma_chuc_vu = ma_chuc_vu,
                    ma_dan_toc = ma_dan_toc,
                    ma_ton_giao = ma_ton_giao,
                    ngay_sinh = ngay_sinh,
                    que_quan = que_quan,
                    ma_noi_sinh = ma_noi_sinh,
                    dia_chi = dia_chi,
                    dien_thoai = dien_thoai,
                    so_cccd = so_cccd,
                    ma_phong_ban = ma_phong_ban,
                    ma_hoc_van = ma_hoc_van,
                    ma_chuyen_mon = ma_chuyen_mon,
                    vo_chong = vo_chong,
                    con = con,
                    avatar = avatar,
                };

                Connection.db.HSNVs.Add(hSNV);
                Connection.db.SaveChanges();
                return true;
            } else
            {
                MessageBox.Show("Căn cước công dân đã tồn tại");
                return false;
            }

        }

        private bool ValidateInput()
        {
            setLabelOrigin();

            var ma_nv = textBox_mnv.Text;
            var ho_ten = textBox_hoten.Text;
            var ma_gioi_tinh = splitString(comboBox_gt.Text);
            var ma_chuc_vu = splitString(comboBox_cv.Text);
            var ma_dan_toc = splitString(comboBox_dt.Text);
            var ma_ton_giao = splitString(comboBox_tg.Text);
            DateTime ngay_sinh = guna2DateTimePicker_ngay_sinh.Value;
            var que_quan = textBox_quequan.Text;
            var ma_noi_sinh = splitString(comboBox_ns.Text);
            var dia_chi = textBox_diachi.Text;
            var dien_thoai = textBox_dienthoai.Text;
            var so_cccd = textBox_sccd.Text;
            var ma_phong_ban = splitString(comboBox_pb.Text);
            var ma_hoc_van = splitString(comboBox_hv.Text);
            var ma_chuyen_mon = splitString(comboBox_cm.Text);
            var vo_chong = textBox_vo.Text;
            var con = guna2NumericUpDown_socon.Text;

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(ho_ten))
            {
                guna2HtmlLabel_hvt.Text = "Họ và tên (không được để trống)";
                guna2HtmlLabel_hvt.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                if (!Regex.IsMatch(ho_ten, @"^[a-zA-Z]+ [a-zA-Z]+$"))
                {
                    guna2HtmlLabel_hvt.Text = "Họ và tên (Không hợp lệ)";
                    guna2HtmlLabel_hvt.ForeColor = Color.Red;
                    isValid = false;
                }

            }

            if (!string.IsNullOrWhiteSpace(vo_chong))
            {
                if (!Regex.IsMatch(ho_ten, @"^[a-zA-Z]+ [a-zA-Z]+$"))
                {
                    guna2HtmlLabel_hvt.Text = "Vợ/Chồng (Không hợp lệ)";
                    guna2HtmlLabel_hvt.ForeColor = Color.Red;
                    isValid = false;
                }
            }
            

            if (string.IsNullOrWhiteSpace(dien_thoai))
            {
                guna2HtmlLabel_dt.Text = "Điện thoại (không được để trống)";
                guna2HtmlLabel_dt.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                string pattern = @"^(09|03|07|08|05)\d{8}$";
                if (!Regex.IsMatch(dien_thoai, pattern))
                {
                    guna2HtmlLabel_dt.Text = "Điện thoại (không hợp lệ)";
                    guna2HtmlLabel_dt.ForeColor = Color.Red;
                    isValid = false;
                }
            }

            if(string.IsNullOrWhiteSpace(que_quan))
            {
                guna2HtmlLabel_qq.Text = "Quê quán (không được để trống)";
                guna2HtmlLabel_qq.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(so_cccd))
            {
                guna2HtmlLabel_cccd.Text = "Số căn cước công dân (không được để trống)";
                guna2HtmlLabel_cccd.ForeColor = Color.Red;
            } else
            {
                string pattern = @"^\d{12}$";

                if (!Regex.IsMatch(so_cccd, pattern))
                {
                    guna2HtmlLabel_cccd.Text = "Số căn cước công dân (không hop le)";
                    guna2HtmlLabel_cccd.ForeColor = Color.Red;
                }
            }

            // validation ngay sinh
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngay_sinh.Year;
            if (tuoi < 20)
            {
                guna2HtmlLabel_ns.Text = "Ngày sinh (tối thiểu là 18 tuổi)";
                guna2HtmlLabel_ns.ForeColor = Color.Red;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(ma_gioi_tinh))
            {
                guna2HtmlLabel_gt.Text = "Giới tính (không được để trống)";
                guna2HtmlLabel_gt.ForeColor = Color.Red;
            }


            if (string.IsNullOrWhiteSpace(ma_gioi_tinh))
            {
                guna2HtmlLabel_noisinh.Text = "Nơi sinh (không được để trống)";
                guna2HtmlLabel_noisinh.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_dan_toc))
            {
                guna2HtmlLabel_dantoc.Text = "Dân tộc (không được để trống)";
                guna2HtmlLabel_dantoc.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_ton_giao))
            {
                guna2HtmlLabel_tg.Text = "Tôn giáo (không được để trống)";
                guna2HtmlLabel_tg.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(dia_chi))
            {
                guna2HtmlLabel_dc.Text = "Địa chỉ (không được để trống)";
                guna2HtmlLabel_dc.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_phong_ban))
            {
                guna2HtmlLabel_pb.Text = "Phòng ban (không được để trống)";
                guna2HtmlLabel_pb.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_chuc_vu))
            {
                guna2HtmlLabel_cv.Text = "Chức vụ (không được để trống)";
                guna2HtmlLabel_cv.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_hoc_van))
            {
                guna2HtmlLabel_hv.Text = "Học vấn (không được để trống)";
                guna2HtmlLabel_hv.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(ma_chuyen_mon))
            {
                guna2HtmlLabel_cm.Text = "Chuyên môn (không được để trống)";
                guna2HtmlLabel_cm.ForeColor = Color.Red;
            }

            return isValid;
        }

        public void setLabelOrigin()
        {
            guna2HtmlLabel_hvt.Text = "Họ và tên";
            guna2HtmlLabel_dt.Text = "Điện thoại";
            guna2HtmlLabel_qq.Text = "Quê quán";
            guna2HtmlLabel_cccd.Text = "Số căn";
            guna2HtmlLabel_ns.Text = "Ngày sinh";
            guna2HtmlLabel_gt.Text = "Giới tính";
            guna2HtmlLabel_noisinh.Text = "Nơi sinh";
            guna2HtmlLabel_dantoc.Text = "Dân tộc";
            guna2HtmlLabel_tg.Text = "Tôn giáo";
            guna2HtmlLabel_dc.Text = "Địa chỉ";
            guna2HtmlLabel_pb.Text = "Phòng ban";
            guna2HtmlLabel_cv.Text = "Chức vụ";
            guna2HtmlLabel_hv.Text = "Học vấn";
            guna2HtmlLabel_cm.Text = "Chuyên môn";

            guna2HtmlLabel_hvt.ForeColor = Color.Black;
            guna2HtmlLabel_hvt.ForeColor = Color.Black;
            guna2HtmlLabel_dt.ForeColor = Color.Black;
            guna2HtmlLabel_dt.ForeColor = Color.Black;
            guna2HtmlLabel_qq.ForeColor = Color.Black;
            guna2HtmlLabel_cccd.ForeColor = Color.Black;
            guna2HtmlLabel_cccd.ForeColor = Color.Black;
            guna2HtmlLabel_ns.ForeColor = Color.Black;
            guna2HtmlLabel_gt.ForeColor = Color.Black;
            guna2HtmlLabel_noisinh.ForeColor = Color.Black;
            guna2HtmlLabel_dantoc.ForeColor = Color.Black;
            guna2HtmlLabel_tg.ForeColor = Color.Black;
            guna2HtmlLabel_dc.ForeColor = Color.Black;
            guna2HtmlLabel_pb.ForeColor = Color.Black;
            guna2HtmlLabel_cv.ForeColor = Color.Black;
            guna2HtmlLabel_hv.ForeColor = Color.Black;
            guna2HtmlLabel_cm.ForeColor = Color.Black;
        }

        private bool checExitNV(string mnv, string sccd)
        {
            var exitsNV = Connection.db.HSNVs.Where(nv => nv.ma_nv.Equals(mnv) || nv.so_cccd.Equals(sccd)).FirstOrDefault();
            if (exitsNV != null)
            {
                return false;
            }
            return true;
        }

        public string splitString(string str)
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            Match match = regex.Match(str);
            return match.Groups[1].Value;

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {


        }

        private void textBox_hoten_TextChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
        }

        private void textBox_dienthoai_TextChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
        }

        private void textBox_quequan_TextChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
        }

        private void textBox_sccd_TextChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
        }

        private void guna2DateTimePicker_ngay_sinh_ValueChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
        }

        private void textBox_vo_TextChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
            if(textBox_vo.Text.Trim().Length > 0)
            {
                guna2NumericUpDown_socon.Enabled = true;
            } else
            {
                guna2NumericUpDown_socon.Value = 0;
                guna2NumericUpDown_socon.Enabled = false;

            }

        }
    }
}
