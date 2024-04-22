using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StroyMat.Control;
using StroyMat.Control.ElControls;

namespace StroyMat.Form
{
    public partial class Home : System.Windows.Forms.Form
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public Home()
        {
            InitializeComponent();
            _obj = this;
            this.ActiveControl = logo;
        }

        static Home _obj;
        public static Home Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Home();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return InfoPanel; }
            set { InfoPanel = value; }
        }

        public Guna.UI.WinForms.GunaPanel pnlAdmin
        {
            get { return AdminPanel; }
            set { AdminPanel = value; }
        }

        public Guna.UI.WinForms.GunaLabel PnlLableUser
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public Guna.UI.WinForms.GunaPanel pnlBasket
        {
            get { return gunaPanel1; }
            set { gunaPanel1 = value; }
        }

        Point lastPoint;
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = logo;
            lastPoint = new Point(e.X, e.Y);
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        //-------------------------------- Admin
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            AdminControl adminControl1 = new AdminControl();
            InfoPanel.Controls.Add(adminControl1);
            adminControl1.Dock = DockStyle.Fill;
            adminControl1.BringToFront();

            PrintListUserAdmin(adminControl1);
            PrintListProductAdmin(adminControl1);
            PrintStatisticAdmin(adminControl1);
        }

        private void PrintStatisticAdmin(AdminControl adminControl1)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Product", connection);
            connection.Open();
            adminControl1.CountProducts.Text = "0" + cmd.ExecuteScalar().ToString();
            connection.Close();

            cmd = new SqlCommand("SELECT COUNT(*) FROM People", connection);
            connection.Open();
            adminControl1.CountUsers.Text = "0" + cmd.ExecuteScalar().ToString();
            connection.Close();

            cmd = new SqlCommand("SELECT COUNT(*) FROM [Order]", connection);
            connection.Open();
            adminControl1.CountBuyProducts.Text = "0" + cmd.ExecuteScalar().ToString();
            connection.Close();
        }

        private void PrintListProductAdmin(AdminControl adminControl1)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM [Product]", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            adminControl1.flowLayoutPanel1.Controls.Clear();

            while (reader.Read())
            {
                ElProductList Item = new ElProductList();

                byte[] photoBytes = (byte[])reader["Photo"];
                MemoryStream memoryStream = new MemoryStream(photoBytes);
                Item.gunaCirclePictureBox1.Image = Image.FromStream(memoryStream);

                Item.gunaLabel1.Text = reader["Name"].ToString();
                Item.gunaLabel3.Text = reader["Category"].ToString();
                Item.gunaLabel4.Text += reader["Id"].ToString();

                adminControl1.flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            connection.Close();
        }

        private void PrintListUserAdmin(AdminControl adminControl1)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM [People]", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            adminControl1.flowLayoutPanel3.Controls.Clear();

            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader["Id"]);
                int orderCount = GetOrderCountByUserId(userId);

                ElUserList Item = new ElUserList();
                Item.gunaLabel1.Text += reader["Name"].ToString();
                Item.gunaLabel3.Text += reader["Surname"].ToString();
                Item.gunaLabel4.Text += reader["Username"].ToString();
                Item.gunaLabel5.Text += userId;
                Item.gunaLabel2.Text += orderCount.ToString();

                adminControl1.flowLayoutPanel3.Controls.Add(Item);
            }
            reader.Close();
            connection.Close();
        }

        private int GetOrderCountByUserId(int userId)
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Order] WHERE ClientId = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                orderCount = (int)cmd.ExecuteScalar();
            }

            return orderCount;
        }

        //--------------------------------- Заказы
        private void btnOrder_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            OrderControl orderControl = new OrderControl();
            InfoPanel.Controls.Add(orderControl);
            orderControl.Dock = DockStyle.Fill;
            orderControl.BringToFront();
            PrintOrder(orderControl);
        }

        private void PrintOrder(OrderControl orderControl)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM [Order]", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            orderControl.flowLayoutPanel1.Controls.Clear();
            while (reader.Read())
            {
                ElOrderList Item = new ElOrderList();
                Item.gunaLabel1.Text = reader["ClientId"].ToString();
                Item.gunaLabel2.Text = reader["Name"].ToString();
                Item.gunaLabel6.Text = reader["Phone"].ToString();
                Item.gunaLabel4.Text = reader["Id"].ToString();
                Item.Size = new Size(709, 36);

                orderControl.flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            connection.Close();
        }

        //-------------------------------- Товары
        private void PrintProduct(ProductControl productControl, string str)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM Product", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (str == reader["Category"].ToString())
                {
                    ElProduct Item = new ElProduct();

                    byte[] photoBytes = (byte[])reader["Photo"];
                    MemoryStream memoryStream = new MemoryStream(photoBytes);
                    Item.gunaPictureBox1.Image = Image.FromStream(memoryStream);
                    Item.NameProduct.Text = reader["Id"].ToString();

                    productControl.flowLayoutPanel1.Controls.Add(Item);
                }
            }
            reader.Close();
            connection.Close();
        }

        private void ButtonBuildingMaterials_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            ProductControl productControl = new ProductControl();
            InfoPanel.Controls.Add(productControl);
            productControl.Dock = DockStyle.Fill;
            productControl.BringToFront();

            PrintProduct(productControl, "Строительные материалы");
        }

        private void ButtonEquipment_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            ProductControl productControl = new ProductControl();
            InfoPanel.Controls.Add(productControl);
            productControl.Dock = DockStyle.Fill;
            productControl.BringToFront();

            PrintProduct(productControl, "Оборудование");
        }

        private void ButtonFinishingMaterials_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            ProductControl productControl = new ProductControl();
            InfoPanel.Controls.Add(productControl);
            productControl.Dock = DockStyle.Fill;
            productControl.BringToFront();

            PrintProduct(productControl, "Материалы для отделки");
        }

        private void ButtonPlumbing_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            ProductControl productControl = new ProductControl();
            InfoPanel.Controls.Add(productControl);
            productControl.Dock = DockStyle.Fill;
            productControl.BringToFront();

            PrintProduct(productControl, "Сантехника");
        }

        private void ButtonWaterSupply_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            ProductControl productControl = new ProductControl();
            InfoPanel.Controls.Add(productControl);
            productControl.Dock = DockStyle.Fill;
            productControl.BringToFront();

            PrintProduct(productControl, "Водоснабжение");
        }

        private void ButtonSecuritySystems_Click(object sender, EventArgs e)
        {
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            ProductControl productControl = new ProductControl();
            InfoPanel.Controls.Add(productControl);
            productControl.Dock = DockStyle.Fill;
            productControl.BringToFront();

            PrintProduct(productControl, "Системы безопасности");
        }

        //------------------------------------------ Корзина
        private void btnBasket_Click(object sender, EventArgs e)
        {

            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BasketControl basketControl = new BasketControl();
            InfoPanel.Controls.Add(basketControl);
            basketControl.Dock = DockStyle.Fill;
            basketControl.BringToFront();

            PrintBasket(basketControl);
            CountBasket(basketControl);
        }

        private void CountBasket(BasketControl basketControl)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(Price) FROM Basket", connection);
                connection.Open();
                var totalPrice = cmd.ExecuteScalar();
                basketControl.gunaLabel6.Text = $"{totalPrice} руб.";
                basketControl.gunaLabel7.Text = $"{totalPrice} руб.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void PrintBasket(BasketControl basketControl)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM Basket", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ElBasketList Item = new ElBasketList();

                byte[] Photo = (byte[])(reader["Photo"]);
                MemoryStream memoryStream = new MemoryStream(Photo);
                Item.gunaCirclePictureBox1.Image = Image.FromStream(memoryStream);
                Item.gunaLabel1.Text = reader["Name"].ToString();
                Item.gunaLabel2.Text = reader["Price"] + " руб.".ToString();
                Item.gunaLabel3.Text = reader["Id"].ToString();
                basketControl.flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            connection.Close();
        }

        private void UserPicture_Click(object sender, EventArgs e)
        {
            UserControl1 userControl1 = new UserControl1();
            InfoPanel.Controls.Add(userControl1);

            if (UserName.Text != "Имя")
            {
                userControl1.PanelLogReg.Visible = false;
                userControl1.Size = new Size(134, 45);
            }

            userControl1.Location = new Point(626, 0);
            userControl1.BringToFront();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Basket]", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
