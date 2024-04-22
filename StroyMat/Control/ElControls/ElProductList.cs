using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StroyMat.Control.ElControls
{
    public partial class ElProductList : UserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public ElProductList()
        {
            InitializeComponent();
        }

        private void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Username='" + gunaLabel4.Text + "'", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                this.Hide();

                MessageBox.Show("Товар удалён!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
