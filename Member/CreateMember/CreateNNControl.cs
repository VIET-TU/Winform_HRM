using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.CreateMember
{
    public partial class CreateNNControl : UserControl
    {
        public CreateNNControl()
        {
            InitializeComponent();
        }

        private void CreateNNControl_Load(object sender, EventArgs e)
        {
            List<HSNV> list_hsnv = Connection.db.HSNVs.ToList();

            list_hsnv.ForEach(g =>
            {
                comboBox_mnv.Items.Add(g.ho_ten + " (" + g.ma_nv + ")");
            });

            List<NGOAI_NGU> list_nn = Connection.db.NGOAI_NGU.ToList();
            list_nn.ForEach(g =>
            {
                guna2ComboBox_nn.Items.Add(g.ten_ngoai_ngu + " (" + g.ma_ngoai_ngu + ")");
            });

            List<XEP_LOAI> list_xl = Connection.db.XEP_LOAI.ToList();

            list_xl.ForEach(g =>
            {
                guna2ComboBox_mxl.Items.Add(g.ten_xep_loai + " (" + g.ma_xep_loai + ")");
            });
        }

        private void guna2ComboBox_nn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string splitString(string str)
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            Match match = regex.Match(str);
            return match.Groups[1].Value;

        }

        public bool CreateNN()
        {
            var mnn = splitString(guna2ComboBox_nn.Text);
            var mnv = splitString(comboBox_mnv.Text);
            var mxl = splitString(guna2ComboBox_mxl.Text);

            if (!Validate()) return false;

            // echeck exits
            var exits = Connection.db.NV_NGOAI_NGU.FirstOrDefault(x => x.ma_nv.Equals(mnv) && x.ma_ngoai_ngu.Equals(mnn));

            if (exits == null)
            {
                NV_NGOAI_NGU nvnn = new NV_NGOAI_NGU()
                {
                    ma_ngoai_ngu = mnn,
                    ma_nv = mnv,
                    ma_xep_loai = mxl
                };

                Connection.db.NV_NGOAI_NGU.Add(nvnn);
                Connection.db.SaveChanges();

                return true;
            } else
            {
                MessageBox.Show("Ngoai ngu da ton tai");

                return false;
            }

        }

        public bool Validate()
        {
            var mnn = comboBox_mnv.Text;
            var mnv = comboBox_mnv.Text;
            var mxl = guna2ComboBox_mxl.Text;

            if(string.IsNullOrEmpty(mnn) || string.IsNullOrEmpty(mxl) ||  string.IsNullOrEmpty(mnv))
            {
                MessageBox.Show("Nhap thieu thong tin");
                return false;
            }

            return true;

        }
    }
}
