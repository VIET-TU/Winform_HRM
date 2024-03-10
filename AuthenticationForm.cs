﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private void paneldangnhap_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim().Length == 0 || txtpassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng điền đẩy đủ thông tin", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                NGUUOI_DUNG eixtUser = Connection.db.NGUUOI_DUNG.First(u => u.tai_khoan == txtuser.Text.Trim());
                if (eixtUser != null)
                {
                    if (eixtUser.mat_khau == txtpassword.Text)
                    {
                        MainMenuForm mainForm = new MainMenuForm();
                        mainForm.Show();
                        this.Hide();
                        return;

                    }
                }

                MessageBox.Show("User hoặc password không đúng", "Login failse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
