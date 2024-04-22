using StroyMat.Form;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StroyMat.Control
{
    public partial class BasketControl : UserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public BasketControl()
        {
            InitializeComponent();
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

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            int userId = GetUserIdByUsername(Home.Instance.PnlLableUser.Text);
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmdInsertOrder = new SqlCommand($"INSERT INTO [Order] (ClientId, Name, Phone, Address) VALUES (@ClientId, @Name, @Phone, @Address)", connection);
                cmdInsertOrder.Parameters.AddWithValue("@ClientId", userId);
                cmdInsertOrder.Parameters.AddWithValue("@Name", gunaTextBox1.Text);
                cmdInsertOrder.Parameters.AddWithValue("@Phone", gunaTextBox2.Text);
                cmdInsertOrder.Parameters.AddWithValue("@Address", gunaTextBox3.Text);

                SqlCommand cmdDeleteBasket = new SqlCommand("DELETE FROM Basket WHERE UserId = @UserId", connection);
                cmdDeleteBasket.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                cmdInsertOrder.ExecuteNonQuery();
                cmdDeleteBasket.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Заказ успешно оформлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
