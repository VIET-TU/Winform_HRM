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

namespace HRM_Desktop.Member
{
    public partial class EditMemberControl : UserControl
    {
        public Panel panel;
        public HSNV hSNV;
        public static string url_file = "";

        public EditMemberControl(HSNV hSNV,Panel panel)
        {
            InitializeComponent();
            this.panel = panel;
            this.hSNV = hSNV;
            guna2NumericUpDown_socon.Enabled = false;

        }

        private void EditMemberControl_Load(object sender, EventArgs e)
        {
            textBox_mnv.Text = hSNV.ma_nv;
            textBox_hoten.Text = hSNV.ho_ten;
            textBox_dienthoai.Text = hSNV.dien_thoai;
            textBox_quequan.Text = hSNV.que_quan;
            textBox_sccd.Text = hSNV.so_cccd;
            guna2DateTimePicker_ngay_sinh.Value = hSNV.ngay_sinh;
            textBox_vo.Text = hSNV.vo_chong;
            guna2NumericUpDown_socon.Text = hSNV.con;
            textBox_diachi.Text = hSNV.dia_chi;

            guna2CirclePictureBox_avatar.Image = Image.FromFile(hSNV.avatar);




            List<GIOI_TINH> gts = Connection.db.GIOI_TINH.ToList();

            int index = 0;
            string gt = hSNV.GIOI_TINH.ten_gioi_tinh + " (" + hSNV.ma_gioi_tinh + ")"; 
            gts.ForEach(g =>
            {
                comboBox_gt.Items.Add(g.ten_gioi_tinh + " (" + g.ma_gioi_tinh + ")");
                if (gt.Equals(g.ten_gioi_tinh + " (" + g.ma_gioi_tinh + ")"))
                {
                    comboBox_gt.SelectedIndex = index;
                }
                index++;
            });

            List<CHUC_VU> cvs = Connection.db.CHUC_VU.ToList();
            index = 0;
            string cv = hSNV.CHUC_VU.ten_chuc_vu + " (" + hSNV.ma_chuc_vu + ")";
            cvs.ForEach(g =>
            {
                comboBox_cv.Items.Add(g.ten_chuc_vu + " (" + g.ma_chuc_vu + ")");
                if (cv.Equals(g.ten_chuc_vu + " (" + g.ma_chuc_vu + ")"))
                {
                    comboBox_cv.SelectedIndex = index;
                }
                index++;
            });

            List<DAN_TOC> dts = Connection.db.DAN_TOC.ToList();
            index = 0;
            string dt = hSNV.DAN_TOC.ten_dan_toc + " (" + hSNV.ma_dan_toc + ")";
            dts.ForEach(g =>
            {
                comboBox_dt.Items.Add(g.ten_dan_toc + " (" + g.ma_dan_toc + ")");
                if (dt.Equals(g.ten_dan_toc + " (" + g.ma_dan_toc + ")"))
                {
                    comboBox_dt.SelectedIndex = index;
                }
                index++;
            });


            List<TON_GIAO> tgs = Connection.db.TON_GIAO.ToList();
            index = 0;
            string tg = hSNV.TON_GIAO.ten_ton_giao + " (" + hSNV.ma_ton_giao + ")";
            tgs.ForEach(g =>
            {
                comboBox_tg.Items.Add(g.ten_ton_giao + " (" + g.ma_ton_giao + ")");
                if (tg.Equals(g.ten_ton_giao + " (" + g.ma_ton_giao + ")"))
                {
                    comboBox_tg.SelectedIndex = index;
                }
                index++;
            });


            List<NOI_SINH> nss = Connection.db.NOI_SINH.ToList();
            index = 0;
            string ns = hSNV.NOI_SINH.ten_noi_sinh + " (" + hSNV.ma_noi_sinh + ")";
            nss.ForEach(g =>
            {
                comboBox_ns.Items.Add(g.ten_noi_sinh + " (" + g.ma_noi_sinh + ")");
                if (ns.Equals(g.ten_noi_sinh + " (" + g.ma_noi_sinh + ")"))
                {
                    comboBox_ns.SelectedIndex = index;
                }
                index++;
            });

            List<PHONG_BAN> pbs = Connection.db.PHONG_BAN.ToList();
            index = 0;
            string pb = hSNV.PHONG_BAN.ten_phong_ban + " (" + hSNV.ma_phong_ban + ")";
            pbs.ForEach(g =>
            {
                comboBox_pb.Items.Add(g.ten_phong_ban + " (" + g.ma_phong_ban + ")");
                if (pb.Equals(g.ten_phong_ban + " (" + g.ma_phong_ban + ")"))
                {
                    comboBox_pb.SelectedIndex = index;
                }
                index++;
            });

            List<HOC_VAN> hvs = Connection.db.HOC_VAN.ToList();
            index = 0;
            string hv = hSNV.HOC_VAN.ten_hoc_van + " (" + hSNV.ma_hoc_van + ")";
            hvs.ForEach(g =>
            {
                comboBox_hv.Items.Add(g.ten_hoc_van + " (" + g.ma_hoc_van + ")");
                if (hv.Equals(g.ten_hoc_van + " (" + g.ma_hoc_van + ")"))
                {
                    comboBox_hv.SelectedIndex = index;
                }
                index++;
            });

            List<CHUYEN_MON> cms = Connection.db.CHUYEN_MON.ToList();
            index = 0;
            string cm = hSNV.CHUYEN_MON.ten_chuyen_mon + " (" + hSNV.ma_chuyen_mon + ")";
            cms.ForEach(g =>
            {
                comboBox_cm.Items.Add(g.ten_chuyen_mon + " (" + g.ma_chuyen_mon + ")");
                if(cm.Equals(g.ten_chuyen_mon + " (" + g.ma_chuyen_mon + ")"))
                {
                    comboBox_cm.SelectedIndex = index;
                }
                index++;
            });
        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        public string splitString(string str)
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            Match match = regex.Match(str);
            return match.Groups[1].Value;

        }

        private void button_luu_Click(object sender, EventArgs e)
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
            if (vo_chong.Trim().Length < 0)
            {
                vo_chong = "Chưa kết hôn";
            }
            var con = guna2NumericUpDown_socon.Text ;
            string avatar = url_file == "" ? hSNV.avatar : url_file; // TÊN
            if(ValidateInput())
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

                Connection.db.HSNVs.AddOrUpdate(hSNV);
                Connection.db.SaveChanges();

                MemberControl memberControl = new MemberControl(this.panel);
                memberControl.Dock = DockStyle.Fill;
                this.panel.Controls.Clear();
                this.panel.Controls.Add(memberControl);
                memberControl.BringToFront();
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
                if (Regex.IsMatch(ho_ten, @"^[^\d]\p{L}{1,2}$"))
                {
                    guna2HtmlLabel_hvt.Text = "Họ và tên (Không hợp lệ)";
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
                string pattern = @"^0\d{8}$";
                if (Regex.IsMatch(dien_thoai, pattern))
                {
                    guna2HtmlLabel_dt.Text = "Điện thoại (không hợp lệ)";
                    guna2HtmlLabel_dt.ForeColor = Color.Red;
                    isValid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(que_quan))
            {
                guna2HtmlLabel_qq.Text = "Quê quán (không được để trống)";
                guna2HtmlLabel_qq.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(so_cccd))
            {
                guna2HtmlLabel_cccd.Text = "Số căn cước công dân (không được để trống)";
                guna2HtmlLabel_cccd.ForeColor = Color.Red;
            }
            else
            {
                string pattern = @"^\d{12}$";

                if (Regex.IsMatch(so_cccd, pattern))
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

        private void guna2Button_thoat_Click(object sender, EventArgs e)
        {
            MemberControl memberControl = new MemberControl(this.panel);

            memberControl.Dock = DockStyle.Fill;
            this.panel.Controls.Clear();
            this.panel.Controls.Add(memberControl);
            memberControl.BringToFront();
        }

        private void guna2NumericUpDown_socon_ValueChanged(object sender, EventArgs e)
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

        private void textBox_vo_TextChanged(object sender, EventArgs e)
        {
            setLabelOrigin();
            if (textBox_vo.Text.Trim().Length > 0)
            {
                guna2NumericUpDown_socon.Enabled = true;
            }
            else
            {
                guna2NumericUpDown_socon.Value = 0;
                guna2NumericUpDown_socon.Enabled = false;

            }
        }
    }
}
