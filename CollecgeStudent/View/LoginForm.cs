using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollecgeStudent.DAL;
using CollecgeStudent.Models;
using CollecgeStudent.View;

namespace CollecgeStudent
{
    public partial class LoginForm : Form
    {
        Dal dAL;
        public LoginForm(Dal dal)
        {
            InitializeComponent();
            dAL = dal;
        }

        private void textBox_IdentityNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_IdentityNum.Text))
            {
                MessageBox.Show("הכנס תעודת זהות");
                return;
            }
            Student student = dAL.GetStudentByID(textBox_IdentityNum.Text);
            new StudentForm(dAL, student).Show();
            this.Hide();
        }
    }
}
