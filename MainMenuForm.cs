using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace HRM_Desktop
{
    public partial class MainMenuForm : Form
    {
        public readonly NGUUOI_DUNG user;

        public MainMenuForm()
        {
            InitializeComponent();
            

            DashboardControl dashboardControl = new DashboardControl();
            dashboardControl.Dock = DockStyle.Fill;
            guna2Panel4.Controls.Clear();
            guna2Panel4.Controls.Add(dashboardControl);
            dashboardControl.BringToFront();



        }

        private void addMemberControl(MemberControl memberControl)
        {
            memberControl.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Clear();
            guna2Panel3.Controls.Add(memberControl);
            memberControl.BringToFront();
        }

        private void HRM_Label_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void LeftMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnMember_Click(object sender, EventArgs e)
        {
            MemberControl memberControl = new MemberControl(guna2Panel3);
            addMemberControl(memberControl);
        }


        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardControl dashboardControl = new DashboardControl();
            dashboardControl.Dock = DockStyle.Fill;
            guna2Panel4.Controls.Clear();
            guna2Panel4.Controls.Add(dashboardControl);
            dashboardControl.BringToFront();
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
