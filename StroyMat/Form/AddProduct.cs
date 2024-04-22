using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroyMat.Form
{
    public partial class AddProduct : System.Windows.Forms.Form
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public AddProduct()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog efd = new OpenFileDialog();
                if (efd.ShowDialog() == DialogResult.OK)
                    PictureBox.Image = Image.FromFile(efd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                MemoryStream memoryStream = new MemoryStream();
                PictureBox.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Photo = memoryStream.ToArray();

                SqlCommand cmd = new SqlCommand("INSERT INTO Product (Name, Category, Brand, Quantity, Photo, Price, Description) VALUES (@Name, @Category, @Brand, @Quantity, @Photo, @Price, @Description)", connection);
                cmd.Parameters.AddWithValue("@Name", TextBoxName.Text);
                cmd.Parameters.AddWithValue("@Category", BoxCategory.Text);
                cmd.Parameters.AddWithValue("@Brand", TextBoxBrand.Text);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(TextBoxAge.Text));
                cmd.Parameters.AddWithValue("@Photo", Photo);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(TextBoxPrice.Text));
                cmd.Parameters.AddWithValue("@Description", TextBoxDescription.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
