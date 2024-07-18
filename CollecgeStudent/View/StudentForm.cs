using CollecgeStudent.DAL;
using CollecgeStudent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollecgeStudent.View
{
    public partial class StudentForm : Form
    {
        Dal dal;
        Student student;
        List<CourseCycle> cycleList;
        List<CourseCycle> cycleListById;
        List<Payment> payments;

        public StudentForm(Dal dal, Student student)
        {
            InitializeComponent();
            this.dal = dal;
            this.student = student;

            LoadAll();

        }

        private void LoadAll()
        {
            label_identityNum.Text = student.IdentityNumber;
            label_Name.Text = $"{student.FirstName} {student.LastName}";
            textBox_phone.Text = student.Phone;
            label_balance.Text = student.Balance.ToString();
            cycleList = dal.GetCourseCycleList();
            dataGridView_allCorses.DataSource = cycleList;

            cycleListById = dal.GetCourseCycleListByID(student.ID);
            dataGridView_myCorses.DataSource = cycleListById;

            payments = dal.GetPaymentList(student.ID);
            dataGridView_payments.DataSource = payments;

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void button_payment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_chooseCourse.Text) || string.IsNullOrEmpty(textBox_payment.Text))
            {
                MessageBox.Show("הכנס פרטים");
                return;
            }
            int cid = int.Parse(textBox_chooseCourse.Text.ToString());
            double pay = double.Parse(textBox_payment.Text.ToString());
            dal.InsertPayment(student.ID, cid, pay);
            student = dal.GetStudentByID(student.IdentityNumber);
            label_balance.Text = student.Balance.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_CycleID.Text))
                {
                    MessageBox.Show("הכנס פרטים");
                    return;
                }
                int cid = int.Parse(textBox_CycleID.Text.ToString());
                dal.InsertStudentToCourse(student.ID, cid);
                MessageBox.Show("נרשם בהצלחה");
                LoadAll();
            }
            catch (Exception)
            {
                MessageBox.Show("כבר רשום");
            }

        }

        private void labal5_Click(object sender, EventArgs e)
        {

        }
    }
}
