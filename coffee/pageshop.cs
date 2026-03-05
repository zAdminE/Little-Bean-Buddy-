using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace coffee
{
    public partial class pageshop : Form
    {
        // โครงสร้างข้อมูลสินค้า
        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public Image Image { get; set; }
        }

        // เก็บรายการสินค้า
        private List<Product> products = new List<Product>();
        // เก็บตะกร้าสินค้า
        private List<Product> cart = new List<Product>();

        // Panel สำหรับแสดงสินค้าแบบ Scroll ได้
        private FlowLayoutPanel productContainer;

        public pageshop()
        {
            InitializeComponent();
            InitializeShop();
            guna2PictureBox1.Click += (s, e) => OpenCartForm();
        }

        private void InitializeShop()
        {
            // สร้าง Panel สำหรับแสดงสินค้า
            productContainer = new FlowLayoutPanel()
            {
                Location = new Point(50, 320),
                Size = new Size(1000, 360),
                AutoScroll = true,
                WrapContents = true
            };
            this.Controls.Add(productContainer);

            // เพิ่มสินค้าเริ่มต้น
            products.Add(new Product { Name = "กาแฟอาราบิก้า", Description = "หอมละมุน มีความเปรี้ยวเล็กน้อย", Price = 300, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟโรบัสต้า", Description = "เข้มข้น กลิ่นช็อกโกแลต", Price = 250, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟผสม", Description = "กลมกล่อมลงตัว", Price = 280, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟคั่วพิเศษ", Description = "กลิ่นหอมโดดเด่น", Price = 350, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟคั่วพิเศษ", Description = "กลิ่นหอมโดดเด่น", Price = 350, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟคั่วพิเศษ", Description = "กลิ่นหอมโดดเด่น", Price = 350, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟคั่วพิเศษ", Description = "กลิ่นหอมโดดเด่น", Price = 350, Image = Properties.Resources.z1b34x });
            products.Add(new Product { Name = "กาแฟคั่วพิเศษ", Description = "กลิ่นหอมโดดเด่น", Price = 350, Image = Properties.Resources.z1b34x });

            // แสดงสินค้า
            DisplayProducts(products);

            // ผูกปุ่มค้นหา
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;

            // แก้ไข Label ตะกร้า
            label19.BackColor = Color.Transparent;
            UpdateCartLabel();
        }

        // ฟังก์ชันแสดงสินค้า
        private void DisplayProducts(List<Product> list)
        {
            productContainer.Controls.Clear();

            foreach (var item in list)
            {
                Panel card = new Panel
                {
                    BackColor = Color.White,
                    Size = new Size(220, 320),
                    Margin = new Padding(10)
                };

                PictureBox pic = new PictureBox
                {
                    Image = item.Image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(180, 150),
                    Location = new Point(20, 10)
                };

                Label name = new Label
                {
                    Text = item.Name,
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                    AutoSize = false,
                    Size = new Size(200, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(10, 170)
                };

                Label desc = new Label
                {
                    Text = item.Description,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    AutoSize = false,
                    Size = new Size(200, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(10, 200)
                };

                Label price = new Label
                {
                    Text = $"ราคา : {item.Price} บาท",
                    ForeColor = Color.Green,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    AutoSize = false,
                    Size = new Size(200, 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(10, 240)
                };

                Button addToCart = new Button
                {
                    Text = "🛒 เพิ่มลงตะกร้า",
                    BackColor = Color.LightCoral,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(160, 35),
                    Location = new Point(30, 270),

                };
                addToCart.Click += (s, e) => AddToCart(item);

                card.Controls.Add(pic);
                card.Controls.Add(name);
                card.Controls.Add(desc);
                card.Controls.Add(price);
                card.Controls.Add(addToCart);

                productContainer.Controls.Add(card);
            }
        }

        // เพิ่มสินค้าลงตะกร้า
        private void AddToCart(Product item)
        {
            cart.Add(item);
            UpdateCartLabel();
            label19.Text = cart.Count.ToString();
        }

        // อัปเดตจำนวนสินค้าในตะกร้า
        private void UpdateCartLabel()
        {
            label19.Text = cart.Count.ToString();
        }

        // เปิดหน้าต่างตะกร้า
        private void OpenCartForm()
        {
            CartForm cartForm = new CartForm(cart);

            // ✅ ผูก event ให้ CartForm ส่งข้อมูลกลับมาหลังอัปเดต
            cartForm.CartUpdated += (count) =>
            {
                label19.Text = count.ToString(); // อัปเดตจำนวนบน label19
            };

            cartForm.ShowDialog();
        }

        // ค้นหาสินค้า
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim().ToLower();
            var filtered = products.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            DisplayProducts(filtered);
        }

        // ออกจากระบบ
        private void guna2GradientButton2_MouseClick(object sender, MouseEventArgs e)
        {
            LoginForm main = new LoginForm();
            main.Show();
            this.Hide();
        }

        private void pageshop_Load(object sender, EventArgs e)
        {

        }
    }
}