namespace StroyMat.Control.ElControls
{
    partial class ElUserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElUserList));
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.btnDeleteSoonFilm = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSoonFilm)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.Black;
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(28, 3);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(28, 28);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox1.TabIndex = 0;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(87, 10);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(45, 15);
            this.gunaLabel1.TabIndex = 1;
            this.gunaLabel1.Text = "Name: ";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(536, 10);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(107, 15);
            this.gunaLabel2.TabIndex = 2;
            this.gunaLabel2.Text = "Куплено товаров: ";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.Location = new System.Drawing.Point(226, 10);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(60, 15);
            this.gunaLabel3.TabIndex = 3;
            this.gunaLabel3.Text = "Surname: ";
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.Location = new System.Drawing.Point(379, 10);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(66, 15);
            this.gunaLabel4.TabIndex = 4;
            this.gunaLabel4.Text = "Username: ";
            // 
            // btnDeleteSoonFilm
            // 
            this.btnDeleteSoonFilm.BaseColor = System.Drawing.Color.White;
            this.btnDeleteSoonFilm.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSoonFilm.Image")));
            this.btnDeleteSoonFilm.Location = new System.Drawing.Point(689, 10);
            this.btnDeleteSoonFilm.Name = "btnDeleteSoonFilm";
            this.btnDeleteSoonFilm.Size = new System.Drawing.Size(15, 15);
            this.btnDeleteSoonFilm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteSoonFilm.TabIndex = 11;
            this.btnDeleteSoonFilm.TabStop = false;
            this.btnDeleteSoonFilm.Click += new System.EventHandler(this.ButtonDeleteUser_Click);
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel5.Location = new System.Drawing.Point(147, 10);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(20, 15);
            this.gunaLabel5.TabIndex = 12;
            this.gunaLabel5.Text = "№";
            this.gunaLabel5.Visible = false;
            // 
            // ElUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaLabel5);
            this.Controls.Add(this.btnDeleteSoonFilm);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.gunaCirclePictureBox1);
            this.Name = "ElUserList";
            this.Size = new System.Drawing.Size(716, 34);
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSoonFilm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        public Guna.UI.WinForms.GunaLabel gunaLabel1;
        public Guna.UI.WinForms.GunaLabel gunaLabel2;
        public Guna.UI.WinForms.GunaLabel gunaLabel3;
        public Guna.UI.WinForms.GunaLabel gunaLabel4;
        public Guna.UI.WinForms.GunaPictureBox btnDeleteSoonFilm;
        public Guna.UI.WinForms.GunaLabel gunaLabel5;
    }
}
