﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using StroyMat.Form;

namespace StroyMat
{
    public partial class SIGNin : System.Windows.Forms.Form
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public SIGNin()
        {
            InitializeComponent();
            this.ActiveControl = Label;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home.Instance.Show();
        }

        private void TextBoxUser_Enter(object sender, EventArgs e)
        {
            if(TextBoxUser.Text == "Имя пользователя")
            {
                TextBoxUser.Text = "";
                TextBoxUser.ForeColor = Color.Black;
            }
        }

        private void TextBoxUser_Leave(object sender, EventArgs e)
        {
            if(TextBoxUser.Text == "")
            {
                TextBoxUser.Text = "Имя пользователя";
                TextBoxUser.ForeColor = Color.Gray;
            }
        }

        private void TextBoxPassword_Enter(object sender, EventArgs e)
        {
            if(TextBoxPassword.Text == "Пароль")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.ForeColor = Color.Black;
            }
        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            if(TextBoxPassword.Text == "")
            {
                TextBoxPassword.Text = "Пароль";
                TextBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void ButtonSignIN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                if (TextBoxUser.Text != "Имя пользователя" && TextBoxPassword.Text != "Пароль")
                {
                    string query = "SELECT * FROM People WHERE Username = @user AND Password = @pass";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@user", TextBoxUser.Text);
                    cmd.Parameters.AddWithValue("@pass", TextBoxPassword.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count != 1)
                    {
                        ErrorPanel.Visible = true;
                        Message.ForeColor = Color.Red;
                        Message.Text = "Пользователь не найден!";
                    }
                    else
                    {
                        DataRow row = dt.Rows[0];
                        int userId = Convert.ToInt32(row["Id"]); // Получаем UserId из результата запроса

                        if (TextBoxUser.Text == "manager" && TextBoxPassword.Text == "manager")
                        {
                            Home.Instance.pnlAdmin.Visible = true;
                        }
                        Home.Instance.PnlLableUser.Text = TextBoxUser.Text;
                        Home.Instance.PnlLableUser.Visible = true;
                        Home.Instance.pnlBasket.Visible = true;
                        Home.Instance.Show();
                        this.Hide();
                    }
                }
                else
                {
                    if (TextBoxPassword.Text == "Пароль")
                        TextBoxPassword.BorderColor = Color.Red;
                    if (TextBoxUser.Text == "Имя пользователя")
                        TextBoxUser.BorderColor = Color.Red;
                    ErrorPanel.Visible = true;
                    Message.ForeColor = Color.Red;
                    Message.Text = "Есть пустые поля!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void ButtonSignUP_Click(object sender, EventArgs e)
        {
            this.Hide();
            SIGNup sIGNup = new SIGNup();
            sIGNup.Show();
        }
    }
}
