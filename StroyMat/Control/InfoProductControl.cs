using Microsoft.VisualBasic.ApplicationServices;
using StroyMat.Form;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroyMat.Control
{
    public partial class InfoProductControl : UserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public InfoProductControl()
        {
            InitializeComponent();
        }

        bool changet3 = false;
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (changet3)
            {
                gunaAdvenceButton1.ForeColor = Color.Black;
                gunaAdvenceButton1.BackColor = SystemColors.Control;
                gunaAdvenceButton1.Text = "Добавить в корзину";
                gunaAdvenceButton1.ImageOffsetX = 0;
                DeleteBasketProduct();
            }
            else
            {
                gunaAdvenceButton1.ForeColor = Color.White;
                gunaAdvenceButton1.BackColor = Color.Black;
                gunaAdvenceButton1.Text = "Товар в корзине";
                gunaAdvenceButton1.ImageOffsetX = 10;
                int userId = GetUserIdByUsername(Home.Instance.PnlLableUser.Text);
                if (userId != -1)
                {
                    AddBasketProduct(userId);
                }
                else
                {
                    MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            changet3 = !changet3;
        }

        private int GetUserIdByUsername(string username)
        {
            int userId = -1;

            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                string query = "SELECT Id FROM People WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                connection.Open();
                userId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return userId;
        }

        private void AddBasketProduct(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    MemoryStream memoryStream = new MemoryStream();
                    gunaPictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] Photo = memoryStream.ToArray();

                    string priceText = gunaLabel12.Text.Replace(" руб.", "");
                    if (decimal.TryParse(priceText, out decimal price))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Basket (UserId, ProductId, Quantity, Name, Photo, Price) VALUES (@UserId, @ProductId, @Quantity, @Name, @Photo, @Price)", connection);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        if (int.TryParse(gunaLabel5.Text, out int productId) &&
                            int.TryParse(gunaLabel6.Text, out int quantity))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@Name", gunaLabel1.Text);
                            cmd.Parameters.AddWithValue("@Photo", Photo);
                            cmd.Parameters.AddWithValue("@Price", price);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат данных в одном из полей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат цены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteBasketProduct()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Basket WHERE Id='" + gunaLabel5.Text + "'", connection);
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
