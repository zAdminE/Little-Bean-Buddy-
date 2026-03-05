using System;
using System.Drawing;
using System.Windows.Forms;

namespace coffee
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // ผูก Event ปุ่มเข้าสู่ระบบ
            guna2GradientButton1.Click += Guna2GradientButton1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // เคลียร์ข้อความเริ่มต้น
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox2.UseSystemPasswordChar = true; // ซ่อนรหัสผ่าน
        }

        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text.Trim();

            // ตรวจสอบข้อมูลที่กรอก
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และรหัสผ่านให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ ตัวอย่างบัญชีผู้ใช้จำลอง (ในระบบจริงจะมาจาก Database)
            string adminUser = "admin";
            string adminPass = "12345";

            string staffUser = "staff";
            string staffPass = "abc123";

            // ตรวจสอบชื่อผู้ใช้และรหัสผ่าน
            if (username == adminUser && password == adminPass)
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ (Admin)", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // เปิดฟอร์มหลักของระบบ
                pageshop main = new pageshop();
                main.Show();
                this.Hide();
            }
            else if (username == staffUser && password == staffPass)
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ (พนักงาน)", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pageshop main = new pageshop();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            RegisterForm main = new RegisterForm();
            main.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegisterForm main = new RegisterForm();
            main.Show();
            this.Hide();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.MediumPurple; // เปลี่ยนสีตอน hover
            label2.Font = new Font("Arial", 8.25f, FontStyle.Bold | FontStyle.Underline);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkViolet; // กลับสีเดิม
            label2.Font = new Font("Arial", 8.25f, FontStyle.Bold);
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            RegisterForm main = new RegisterForm();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton3_MouseClick(object sender, MouseEventArgs e)
        {
            director main = new director();
            main.Show();
            this.Hide();
        }
    }
}
