using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.Filter
{
    public partial class FilterNVControl : UserControl
    {
        public FilterNVControl()
        {
            InitializeComponent();
        }

        private void FilterNVControl_Load(object sender, EventArgs e)
        {
            List<PHONG_BAN> pbs = Connection.db.PHONG_BAN.ToList();

            pbs.ForEach(g =>
            {
                comboBox_pb.Items.Add(g.ten_phong_ban + " (" + g.ma_phong_ban + ")");
            });

            List<CHUC_VU> cvs = Connection.db.CHUC_VU.ToList();

            cvs.ForEach(g =>
            {
                comboBox_cv.Items.Add(g.ten_chuc_vu + " (" + g.ma_chuc_vu + ")");
            });



            int yOffset = 20; // Khoảng cách giữa các CheckBox theo trục y


            foreach (var ngoaiNgu in Connection.db.NGOAI_NGU)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = ngoaiNgu.ten_ngoai_ngu;

                checkBox.Font = new Font("Arial", 10);
                checkBox.Width = 200;

                // Đặt vị trí cho CheckBox
                checkBox.Location = new Point(10, yOffset);
                checkBox.Location = new Point(10, yOffset);


                // Cài đặt các thuộc tính khác của CheckBox nếu cần thiết

                // Thêm CheckBox vào guna2GroupBox_ngoai_ngu
                groupBox_nn.Controls.Add(checkBox);

                yOffset += 30; // Tăng khoảng cách để tránh chồng lấn
            }
        }

        private void button_timkiem_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button_thoat_Click(object sender, EventArgs e)
        {

        }
    }

   
}
