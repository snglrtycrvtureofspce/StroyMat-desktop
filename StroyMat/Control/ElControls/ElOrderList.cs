using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroyMat.Control.ElControls
{
    public partial class ElOrderList : UserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public ElOrderList()
        {
            InitializeComponent();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            /*SqlConnection connection = new SqlConnection(_connectionString);

            Random rand = new Random();

            if (this.Height == 36) { this.Height += 46; }
            else { this.Height = 36; }

            SqlCommand cmd = new SqlCommand($"SELECT Name, Photo, Price FROM [Product] WHERE Key = {rand.Next(1,7)}", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            flowLayoutPanel1.Controls.Clear();
            while (reader.Read())
            {
                ElBasketList Item = new ElBasketList();
                Item.ButtonDeleteProduct.Visible = false;
                Item.Size = new Size(706, 46);
                Item.Dock = DockStyle.Top;
                Item.gunaLabel1.Text = reader["Name"].ToString();
                Item.gunaLabel2.Text = reader["Price"] + " руб.";

                byte[] Photo = (byte[])(reader["Photo"]);
                MemoryStream memoryStream = new MemoryStream(Photo);
                Item.gunaCirclePictureBox1.Image = Image.FromStream(memoryStream);

                flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            connection.Close();*/
        }
    }
}
