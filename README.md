☕ Little Bean Buddy — ระบบจัดการร้านกาแฟ

Small beans, big friendship sharing the warmth of every roast.


📋 รายละเอียดโปรเจกต์
Little Bean Buddy คือระบบจัดการร้านกาแฟแบบครบวงจร พัฒนาด้วย C# Windows Forms โดยแบ่งการทำงานออกเป็น 2 ส่วนหลัก ได้แก่ ระบบหน้าร้านสำหรับลูกค้า และระบบหลังร้านสำหรับผู้ดูแลระบบ (Admin)

✨ ฟีเจอร์หลัก
🛍️ ระบบหน้าร้าน (Customer)

สมัครสมาชิก / เข้าสู่ระบบ
ดูสินค้าเมล็ดกาแฟพร้อมราคาและสต็อก
ค้นหาสินค้า
เพิ่มสินค้าลงตะกร้า / ปรับจำนวน / ลบสินค้า
ส่วนลดอัตโนมัติ 5% เมื่อซื้อครบ 10 ชิ้น
กรอกข้อมูลการจัดส่งและยืนยันคำสั่งซื้อ
ออกใบเสร็จพร้อม VAT 7% อัตโนมัติ

🔧 ระบบหลังร้าน (Admin)

จัดการสินค้า (เพิ่ม / แก้ไข / ลบ)
จัดการผู้ใช้งาน (เพิ่ม / แก้ไข / ลบ / ค้นหา)
จัดการออเดอร์ทั้งหมด
ดูยอดขายตามวันที่ / รายเดือน / สินค้าขายดี


🗃️ โครงสร้างฐานข้อมูล
ฐานข้อมูล: coffee_shop (MySQL / InnoDB)
ตารางคำอธิบายจำนวน Rowsusersข้อมูลบัญชีผู้ใช้งาน1+productsข้อมูลสินค้าเมล็ดกาแฟ5ordersคำสั่งซื้อของลูกค้า9+order_itemsรายการสินค้าในแต่ละออเดอร์24+
ความสัมพันธ์ระหว่างตาราง:
users (1) ──── (N) orders (1) ──── (N) order_items (N) ──── (1) products

🛠️ เทคโนโลยีที่ใช้
ส่วนเทคโนโลยีภาษาโปรแกรมC#UI FrameworkWindows Forms (.NET)ฐานข้อมูลMySQLเครื่องมือจัดการ DBphpMyAdminServerXAMPP (localhost)

🚀 วิธีติดตั้งและใช้งาน
ความต้องการของระบบ

Windows 10 ขึ้นไป
.NET Framework 4.7.2+
XAMPP (MySQL + Apache)

ขั้นตอนการติดตั้ง

Clone โปรเจกต์

bash   git clone https://github.com/username/little-bean-buddy.git

ตั้งค่าฐานข้อมูล

เปิด XAMPP แล้วสตาร์ท MySQL
เข้า phpMyAdmin (http://localhost/phpmyadmin)
สร้างฐานข้อมูลชื่อ coffee_shop
Import ไฟล์ coffee_shop.sql ที่อยู่ในโฟลเดอร์ database/


แก้ไข Connection String

เปิดไฟล์ DBConnection.cs หรือ App.config
แก้ไข Host, Username, Password ให้ตรงกับเครื่องของคุณ


รันโปรแกรม

เปิดไฟล์ .sln ด้วย Visual Studio
กด F5 หรือคลิกปุ่ม Run



บัญชีเริ่มต้น (Default Account)
RoleUsernamePasswordAdminadmin1111

📁 โครงสร้างโฟลเดอร์
little-bean-buddy/
├── Forms/
│   ├── Form1.cs          # หน้า Login
│   ├── Form2.cs          # หน้าสมัครสมาชิก
│   ├── pageshop.cs       # หน้าร้านค้า
│   └── ...
├── database/
│   └── coffee_shop.sql   # ไฟล์ SQL สำหรับ Import
├── Resources/            # รูปภาพและ Assets
└── README.md

👨‍💻 ผู้พัฒนา
พัฒนาโดยนักศึกษาเพื่อการศึกษา

📄 License
This project is for educational purposes only.
