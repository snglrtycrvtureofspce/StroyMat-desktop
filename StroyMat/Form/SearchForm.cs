using System.Data;
using System.Windows.Forms;
using System;

namespace StroyMat.Form
{
    public partial class SearchForm : System.Windows.Forms.Form
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings
            ["connectionString"].ConnectionString;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem == null) return;
            var bs = (BindingSource)productDataGridView.DataSource;
            var dv = (DataView)bs.List;
            var selectedText = cbFilter.SelectedItem.ToString().ToLower();
            if (dv.Table.Columns[selectedText].DataType == typeof(Int32) || dv.Table.Columns[selectedText].DataType == typeof(decimal))
            {
                dv.RowFilter = $"CONVERT({selectedText}, 'System.String') LIKE '%{tbFilter.Text.ToLower()}%'";
            }
            else
            {
                dv.RowFilter = $"{selectedText} LIKE '%{tbFilter.Text.ToLower()}%'";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem == null) return;
            var bs = (BindingSource)productDataGridView.DataSource;
            var dv = (DataView)bs.List;
            var selectedText = cbFilter.SelectedItem.ToString().ToLower();
            if (dv.Table.Columns[selectedText].DataType == typeof(Int32) || dv.Table.Columns[selectedText].DataType == typeof(decimal))
            {
                dv.RowFilter = $"CONVERT({selectedText}, 'System.String') LIKE '%{tbFilter.Text.ToLower()}%'";
            }
            else
            {
                dv.RowFilter = $"{selectedText} LIKE '%{tbFilter.Text.ToLower()}%'";
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.productBindingSource.EndEdit();
                this.productTableAdapter.Update(this.stroyMatDataSet.Product);
                MessageBox.Show("Запись сохранена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены что хотите удалить?", "Подтверждение", MessageBoxButtons.YesNo))
            {
                productBindingSource.RemoveCurrent();
            }
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stroyMatDataSet);
        }

        private void SearchForm_Load_1(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.stroyMatDataSet.Product);
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Home.Instance.Show();
        }
    }
}
