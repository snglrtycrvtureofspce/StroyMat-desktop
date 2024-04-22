using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace StroyMat.Control.ElControls
{
    public partial class ElUserList : UserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public ElUserList()
        {
            InitializeComponent();
        }

        private void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                string userText = gunaLabel5.Text.Replace("№", "");
                SqlCommand cmd = new SqlCommand("DELETE FROM People WHERE Id='" + int.Parse(userText) + "'", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                this.Hide();

                MessageBox.Show("Пользователь удалён!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
