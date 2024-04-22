namespace StroyMat.Control.ElControls
{
    partial class ElBasketList
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElBasketList));
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.ButtonDeleteProduct = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDeleteProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(68, 7);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(270, 31);
            this.gunaLabel1.TabIndex = 1;
            this.gunaLabel1.Text = "gunaLabel1dfgdfgdsgdsgdsgdsgdsgdsgdsgdsgdsgdsd";
            this.gunaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gunaLabel2.Location = new System.Drawing.Point(378, 15);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 15);
            this.gunaLabel2.TabIndex = 2;
            this.gunaLabel2.Text = "19.5 руб.";
            this.gunaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonDeleteProduct
            // 
            this.ButtonDeleteProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteProduct.BaseColor = System.Drawing.Color.White;
            this.ButtonDeleteProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeleteProduct.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteProduct.Image")));
            this.ButtonDeleteProduct.Location = new System.Drawing.Point(477, 15);
            this.ButtonDeleteProduct.Name = "ButtonDeleteProduct";
            this.ButtonDeleteProduct.Size = new System.Drawing.Size(17, 17);
            this.ButtonDeleteProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ButtonDeleteProduct.TabIndex = 11;
            this.ButtonDeleteProduct.TabStop = false;
            this.ButtonDeleteProduct.Click += new System.EventHandler(this.ButtonDeleteProduct_Click);
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(19, 3);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(40, 40);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox1.TabIndex = 0;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gunaLabel3.Location = new System.Drawing.Point(344, 15);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(21, 15);
            this.gunaLabel3.TabIndex = 12;
            this.gunaLabel3.Text = "№";
            this.gunaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gunaLabel3.Visible = false;
            // 
            // ElBasketList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.ButtonDeleteProduct);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.gunaCirclePictureBox1);
            this.Name = "ElBasketList";
            this.Size = new System.Drawing.Size(510, 46);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDeleteProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI.WinForms.GunaPictureBox ButtonDeleteProduct;
        public Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        public Guna.UI.WinForms.GunaLabel gunaLabel1;
        public Guna.UI.WinForms.GunaLabel gunaLabel2;
        public Guna.UI.WinForms.GunaLabel gunaLabel3;
    }
}
