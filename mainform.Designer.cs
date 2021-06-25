
namespace Barber
{
    partial class mainform
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSIGNUP = new System.Windows.Forms.Button();
            this.pnlREZERV = new System.Windows.Forms.Panel();
            this.btnMyRezerv = new System.Windows.Forms.Button();
            this.btnLOGIN = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnDATABASE = new System.Windows.Forms.Button();
            this.pnlDATABASE = new System.Windows.Forms.Panel();
            this.pnlOUR = new System.Windows.Forms.Panel();
            this.btnSERVICE = new System.Windows.Forms.Button();
            this.btnBARBERS = new System.Windows.Forms.Button();
            this.lbBARBER1 = new System.Windows.Forms.Label();
            this.lbBARBER2 = new System.Windows.Forms.Label();
            this.lbBARBER3 = new System.Windows.Forms.Label();
            this.pnlBARBESHOP = new System.Windows.Forms.Panel();
            this.pictureBARBER = new System.Windows.Forms.PictureBox();
            this.pnlREZERV.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlDATABASE.SuspendLayout();
            this.pnlOUR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBARBER)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSIGNUP
            // 
            this.btnSIGNUP.ForeColor = System.Drawing.Color.Red;
            this.btnSIGNUP.Location = new System.Drawing.Point(3, 3);
            this.btnSIGNUP.Name = "btnSIGNUP";
            this.btnSIGNUP.Size = new System.Drawing.Size(200, 35);
            this.btnSIGNUP.TabIndex = 3;
            this.btnSIGNUP.Text = "Zapisz się";
            this.btnSIGNUP.UseVisualStyleBackColor = true;
            this.btnSIGNUP.Click += new System.EventHandler(this.btnSIGNUP_Click);
            // 
            // pnlREZERV
            // 
            this.pnlREZERV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlREZERV.Controls.Add(this.btnSIGNUP);
            this.pnlREZERV.Controls.Add(this.btnMyRezerv);
            this.pnlREZERV.Location = new System.Drawing.Point(12, 121);
            this.pnlREZERV.Name = "pnlREZERV";
            this.pnlREZERV.Size = new System.Drawing.Size(208, 85);
            this.pnlREZERV.TabIndex = 2;
            // 
            // btnMyRezerv
            // 
            this.btnMyRezerv.Location = new System.Drawing.Point(4, 44);
            this.btnMyRezerv.Name = "btnMyRezerv";
            this.btnMyRezerv.Size = new System.Drawing.Size(200, 35);
            this.btnMyRezerv.TabIndex = 4;
            this.btnMyRezerv.Text = "Moje wizyty";
            this.btnMyRezerv.UseVisualStyleBackColor = true;
            this.btnMyRezerv.Click += new System.EventHandler(this.btnMyRezerv_Click);
            // 
            // btnLOGIN
            // 
            this.btnLOGIN.Location = new System.Drawing.Point(4, 3);
            this.btnLOGIN.Name = "btnLOGIN";
            this.btnLOGIN.Size = new System.Drawing.Size(200, 35);
            this.btnLOGIN.TabIndex = 0;
            this.btnLOGIN.Text = "Zaloguj się (ACCOUNT)";
            this.btnLOGIN.UseVisualStyleBackColor = true;
            this.btnLOGIN.Click += new System.EventHandler(this.btnLOGIN_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(4, 44);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 35);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Zarejestruj się";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.btnLOGIN);
            this.pnlLogin.Controls.Add(this.btnRegister);
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(208, 85);
            this.pnlLogin.TabIndex = 1;
            // 
            // btnDATABASE
            // 
            this.btnDATABASE.Location = new System.Drawing.Point(3, 3);
            this.btnDATABASE.Name = "btnDATABASE";
            this.btnDATABASE.Size = new System.Drawing.Size(200, 35);
            this.btnDATABASE.TabIndex = 5;
            this.btnDATABASE.Text = "Ładowanie danych xls";
            this.btnDATABASE.UseVisualStyleBackColor = true;
            this.btnDATABASE.Click += new System.EventHandler(this.btnDATABASE_Click);
            // 
            // pnlDATABASE
            // 
            this.pnlDATABASE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDATABASE.Controls.Add(this.btnDATABASE);
            this.pnlDATABASE.Location = new System.Drawing.Point(12, 566);
            this.pnlDATABASE.Name = "pnlDATABASE";
            this.pnlDATABASE.Size = new System.Drawing.Size(208, 42);
            this.pnlDATABASE.TabIndex = 6;
            // 
            // pnlOUR
            // 
            this.pnlOUR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOUR.Controls.Add(this.btnSERVICE);
            this.pnlOUR.Controls.Add(this.btnBARBERS);
            this.pnlOUR.Location = new System.Drawing.Point(12, 235);
            this.pnlOUR.Name = "pnlOUR";
            this.pnlOUR.Size = new System.Drawing.Size(208, 85);
            this.pnlOUR.TabIndex = 3;
            // 
            // btnSERVICE
            // 
            this.btnSERVICE.Location = new System.Drawing.Point(3, 44);
            this.btnSERVICE.Name = "btnSERVICE";
            this.btnSERVICE.Size = new System.Drawing.Size(200, 35);
            this.btnSERVICE.TabIndex = 6;
            this.btnSERVICE.Text = "Nasze usługi";
            this.btnSERVICE.UseVisualStyleBackColor = true;
            this.btnSERVICE.Click += new System.EventHandler(this.btnSERVICE_Click);
            // 
            // btnBARBERS
            // 
            this.btnBARBERS.Location = new System.Drawing.Point(3, 3);
            this.btnBARBERS.Name = "btnBARBERS";
            this.btnBARBERS.Size = new System.Drawing.Size(200, 35);
            this.btnBARBERS.TabIndex = 5;
            this.btnBARBERS.Text = "Nasi mistrzowie";
            this.btnBARBERS.UseVisualStyleBackColor = true;
            this.btnBARBERS.Click += new System.EventHandler(this.btnBARBERS_Click);
            // 
            // lbBARBER1
            // 
            this.lbBARBER1.AutoSize = true;
            this.lbBARBER1.Location = new System.Drawing.Point(242, 25);
            this.lbBARBER1.Name = "lbBARBER1";
            this.lbBARBER1.Size = new System.Drawing.Size(46, 17);
            this.lbBARBER1.TabIndex = 7;
            this.lbBARBER1.Text = "label1";
            // 
            // lbBARBER2
            // 
            this.lbBARBER2.AutoSize = true;
            this.lbBARBER2.Location = new System.Drawing.Point(242, 57);
            this.lbBARBER2.Name = "lbBARBER2";
            this.lbBARBER2.Size = new System.Drawing.Size(46, 17);
            this.lbBARBER2.TabIndex = 8;
            this.lbBARBER2.Text = "label1";
            // 
            // lbBARBER3
            // 
            this.lbBARBER3.AutoSize = true;
            this.lbBARBER3.Location = new System.Drawing.Point(242, 91);
            this.lbBARBER3.Name = "lbBARBER3";
            this.lbBARBER3.Size = new System.Drawing.Size(46, 17);
            this.lbBARBER3.TabIndex = 9;
            this.lbBARBER3.Text = "label1";
            // 
            // pnlBARBESHOP
            // 
            this.pnlBARBESHOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBARBESHOP.Location = new System.Drawing.Point(3, 8);
            this.pnlBARBESHOP.Name = "pnlBARBESHOP";
            this.pnlBARBESHOP.Size = new System.Drawing.Size(922, 610);
            this.pnlBARBESHOP.TabIndex = 10;
            // 
            // pictureBARBER
            // 
            this.pictureBARBER.Image = global::Barber.Properties.Resources.barber_foto;
            this.pictureBARBER.InitialImage = global::Barber.Properties.Resources.barber_foto;
            this.pictureBARBER.Location = new System.Drawing.Point(230, 12);
            this.pictureBARBER.Name = "pictureBARBER";
            this.pictureBARBER.Size = new System.Drawing.Size(687, 596);
            this.pictureBARBER.TabIndex = 1;
            this.pictureBARBER.TabStop = false;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 620);
            this.Controls.Add(this.lbBARBER3);
            this.Controls.Add(this.lbBARBER2);
            this.Controls.Add(this.lbBARBER1);
            this.Controls.Add(this.pnlOUR);
            this.Controls.Add(this.pnlDATABASE);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pictureBARBER);
            this.Controls.Add(this.pnlREZERV);
            this.Controls.Add(this.pnlBARBESHOP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarberShop \"Razor Blade\"";
            this.Activated += new System.EventHandler(this.mainform_Activated);
            this.Load += new System.EventHandler(this.mainform_Load);
            this.pnlREZERV.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlDATABASE.ResumeLayout(false);
            this.pnlOUR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBARBER)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSIGNUP;
        private System.Windows.Forms.PictureBox pictureBARBER;
        private System.Windows.Forms.Panel pnlREZERV;
        private System.Windows.Forms.Button btnMyRezerv;
        private System.Windows.Forms.Button btnLOGIN;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnDATABASE;
        private System.Windows.Forms.Panel pnlDATABASE;
        private System.Windows.Forms.Panel pnlOUR;
        private System.Windows.Forms.Button btnSERVICE;
        private System.Windows.Forms.Button btnBARBERS;
        private System.Windows.Forms.Label lbBARBER1;
        private System.Windows.Forms.Label lbBARBER2;
        private System.Windows.Forms.Label lbBARBER3;
        private System.Windows.Forms.Panel pnlBARBESHOP;
    }
}

