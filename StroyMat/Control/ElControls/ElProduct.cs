using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using StroyMat.Form;

namespace StroyMat.Control.ElControls
{
    public partial class ElProduct : UserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public ElProduct()
        {
            InitializeComponent();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Product] WHERE Id='" + this.NameProduct.Text + "'", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                InfoProductControl infoproductControl = new InfoProductControl();
                if (Home.Instance.PnlLableUser.Visible == true) { infoproductControl.gunaAdvenceButton1.Visible = true; }
                Home.Instance.PnlContainer.Controls.Add(infoproductControl);
                if (Home.Instance.PnlLableUser.Visible == true) { infoproductControl.gunaAdvenceButton1.Visible = true; }
                infoproductControl.gunaPictureBox1.Image = this.gunaPictureBox1.Image;

                while (reader.Read())
                {
                    infoproductControl.gunaLabel1.Text = reader["Name"].ToString(); // название товара
                    infoproductControl.gunaLabel2.Text = reader["Category"].ToString(); // категория
                    infoproductControl.gunaLabel3.Text = reader["Brand"].ToString(); // бренд
                    infoproductControl.gunaLabel5.Text = reader["Id"].ToString(); // №
                    infoproductControl.gunaLabel6.Text = reader["Quantity"].ToString(); // количество
                    infoproductControl.gunaLabel7.Text = reader["Description"].ToString(); // описание товара
                    infoproductControl.gunaLabel12.Text = reader["Price"] + " руб."; // цена
                }
                
                infoproductControl.Dock = DockStyle.Fill;
                Home.Instance.PnlContainer.Controls["InfoProductControl"].BringToFront();
                reader.Close();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }
    }
}
