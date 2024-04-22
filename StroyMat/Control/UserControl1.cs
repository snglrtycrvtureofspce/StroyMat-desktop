using System;
using System.Windows.Forms;
using StroyMat.Form;

namespace StroyMat.Control
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void ButtonSignIN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home.Instance.Hide();
            SIGNin sIGNin = new SIGNin();
            sIGNin.Show();
        }

        private void ButtonSignUP_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home.Instance.Hide();
            SIGNup sIGNup = new SIGNup();
            sIGNup.ShowDialog();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
