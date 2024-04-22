using System;
using System.Windows.Forms;
using StroyMat.Form;

namespace StroyMat.Control
{
    public partial class AdminControl : UserControl
    {
        public AdminControl()
        {
            InitializeComponent();
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }
    }
}
