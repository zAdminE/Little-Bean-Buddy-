using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace coffee
{
    public partial class RegisterForm : Form
    {
        // ตัวอย่างเก็บข้อมูลผู้ใช้ในหน่วยความจำ
        private List<User> users = new List<User>();

        public RegisterForm()
        {
            InitializeComponent();

            // ผูก Event ให้ปุ่มสมัครสมาชิก
            guna2GradientButton1.Click += Guna2GradientButton1_Click;

            // ผูก Event ให้ปุ่มเข้าสู่ระบบ
            guna2GradientButton2.Click += Guna2GradientButton2_Click;
        }

        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text.Trim();
            string confirmPassword = guna2TextBox3.Text.Trim();
            string phone = guna2TextBox4.Text.Trim();
            string email = guna2TextBox5.Text.Trim();

            // ตรวจสอบช่องว่าง
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ตรวจสอบรหัสผ่านตรงกัน
            if (password != confirmPassword)
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ตรวจสอบเบอร์มือถือ 10 หลัก
            if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                MessageBox.Show("กรุณากรอกเบอร์มือถือ 10 หลัก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ตรวจสอบอีเมล
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("กรุณากรอกอีเมลให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ตรวจสอบชื่อผู้ใช้ซ้ำ
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    MessageBox.Show("ชื่อผู้ใช้นี้ถูกใช้แล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // เพิ่มผู้ใช้ใหม่
            User newUser = new User
            {
                Username = username,
                Password = password,
                Phone = phone,
                Email = email
            };

            users.Add(newUser);

            MessageBox.Show("สมัครสมาชิกสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ล้างฟอร์ม
            guna2TextBox1.Text = "กรอกชื่อผู้ใช้";
            guna2TextBox2.Text = "กรอกรหัสผ่าน";
            guna2TextBox3.Text = "กรอกรหัสผ่านอีกครั้ง";
            guna2TextBox4.Text = "กรอกเบอร์มือถือ";
            guna2TextBox5.Text = "กรอกอีเมลผู้ใช้งาน";
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void Guna2GradientButton2_Click(object sender, EventArgs e)
        {
            // เปิดหน้าต่าง LoginForm
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }

    // คลาส User สำหรับเก็บข้อมูลผู้ใช้
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
