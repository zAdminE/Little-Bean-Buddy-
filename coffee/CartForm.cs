using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace coffee
{
    public partial class CartForm : Form
    {
        // ✅ ส่งข้อมูลกลับไปยัง pageshop
        public event Action<int> CartUpdated;

        private List<CartItem> cartItems;
        private FlowLayoutPanel cartContainer;
        private Label totalLabel;
        private TextBox discountBox;
        private Button checkoutButton;

        public class CartItem
        {
            public pageshop.Product Product { get; set; }
            public int Quantity { get; set; }
        }

        public CartForm(List<pageshop.Product> cart)
        {
            InitializeComponent();
            cartItems = cart
                .GroupBy(p => p.Name)
                .Select(g => new CartItem { Product = g.First(), Quantity = g.Count() })
                .ToList();

            InitializeCart();
        }

        private void InitializeCart()
        {
            this.Text = "🛒 ตะกร้าสินค้า";
            this.Size = new Size(750, 550);
            this.BackColor = Color.White;

            cartContainer = new FlowLayoutPanel()
            {
                Location = new Point(20, 20),
                Size = new Size(700, 360),
                AutoScroll = true,
                WrapContents = true
            };
            this.Controls.Add(cartContainer);

            totalLabel = new Label()
            {
                Text = "รวมทั้งหมด: 0 บาท",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(20, 400),
                Size = new Size(350, 30)
            };
            this.Controls.Add(totalLabel);

            Label discountLabel = new Label()
            {
                Text = "โค้ดส่วนลด:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 440),
                Size = new Size(90, 25)
            };
            this.Controls.Add(discountLabel);

            discountBox = new TextBox()
            {
                Location = new Point(110, 440),
                Size = new Size(150, 25)
            };
            this.Controls.Add(discountBox);

            checkoutButton = new Button()
            {
                Text = "สั่งซื้อสินค้า",
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(580, 440),
                Size = new Size(120, 35)
            };
            checkoutButton.Click += Checkout_Click;
            this.Controls.Add(checkoutButton);

            DisplayCart();
        }

        private void DisplayCart()
        {
            cartContainer.Controls.Clear();
            decimal total = 0;
            int totalCount = 0;

            foreach (var item in cartItems.ToList())
            {
                Panel card = new Panel
                {
                    BackColor = Color.AliceBlue,
                    Size = new Size(670, 90),
                    Margin = new Padding(5)
                };

                PictureBox pic = new PictureBox
                {
                    Image = item.Product.Image,
                    Size = new Size(70, 70),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10)
                };

                Label name = new Label
                {
                    Text = item.Product.Name,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(90, 10),
                    Size = new Size(250, 25)
                };

                Label price = new Label
                {
                    Text = $"ราคา {item.Product.Price * item.Quantity} บาท",
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(90, 40),
                    Size = new Size(200, 25)
                };

                // ปุ่ม +1
                Button addBtn = new Button
                {
                    Text = "+1",
                    BackColor = Color.RoyalBlue,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(360, 30),
                    Size = new Size(45, 30)
                };

                // กล่องกรอกจำนวน
                TextBox qtyBox = new TextBox
                {
                    Text = item.Quantity.ToString(),
                    TextAlign = HorizontalAlignment.Center,
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(410, 33),
                    Size = new Size(50, 25)
                };

                // ปุ่ม -1
                Button removeBtn = new Button
                {
                    Text = "-1",
                    BackColor = Color.OrangeRed,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(465, 30),
                    Size = new Size(45, 30)
                };

                // ปุ่มลบสินค้า
                Button deleteBtn = new Button
                {
                    Text = "ลบสินค้า",
                    BackColor = Color.IndianRed,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(520, 30),
                    Size = new Size(90, 30)
                };

                // ✅ เพิ่มสินค้า
                addBtn.Click += (s, e) =>
                {
                    item.Quantity++;
                    DisplayCart();
                };

                // ✅ ลดสินค้า
                removeBtn.Click += (s, e) =>
                {
                    item.Quantity--;
                    if (item.Quantity <= 0)
                        cartItems.Remove(item);
                    DisplayCart();
                };

                // ✅ กรอกจำนวนแล้วกด Enter เพื่อยืนยัน
                qtyBox.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (int.TryParse(qtyBox.Text, out int val))
                        {
                            item.Quantity = Math.Max(1, val);
                            DisplayCart();
                        }
                        e.SuppressKeyPress = true;
                    }
                };

                // ✅ ลบสินค้าออกทั้งหมด
                deleteBtn.Click += (s, e) =>
                {
                    cartItems.Remove(item);
                    DisplayCart();
                };

                card.Controls.Add(pic);
                card.Controls.Add(name);
                card.Controls.Add(price);
                card.Controls.Add(addBtn);
                card.Controls.Add(qtyBox);
                card.Controls.Add(removeBtn);
                card.Controls.Add(deleteBtn);

                cartContainer.Controls.Add(card);

                total += item.Product.Price * item.Quantity;
                totalCount += item.Quantity;
            }

            totalLabel.Text = $"รวมทั้งหมด: {total} บาท";
            CartUpdated?.Invoke(totalCount);
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            decimal total = cartItems.Sum(i => i.Product.Price * i.Quantity);
            string code = discountBox.Text.Trim().ToUpper();
            decimal discount = 0;

            if (code == "SALE10") discount = total * 0.10m;
            else if (code == "COFFEE20") discount = total * 0.20m;

            decimal finalTotal = total - discount;

            string message = $"ยอดรวมสินค้า: {total} บาท\n" +
                             $"ส่วนลด: {discount} บาท\n" +
                             $"ยอดชำระทั้งหมด: {finalTotal} บาท\n\n" +
                             $"คุณต้องการยืนยันการสั่งซื้อหรือไม่?";

            DialogResult result = MessageBox.Show(message, "ยืนยันการสั่งซื้อ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("✅ สั่งซื้อสำเร็จ! ขอบคุณที่ใช้บริการร้าน CoffeeShop ☕",
                    "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cartItems.Clear();
                DisplayCart();
            }
        }
    }
}
