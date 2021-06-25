
namespace Barber
{
    partial class DataBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkBARBERS = new System.Windows.Forms.CheckBox();
            this.chkSERVICE = new System.Windows.Forms.CheckBox();
            this.chkPRICE = new System.Windows.Forms.CheckBox();
            this.chkSCHEDULE = new System.Windows.Forms.CheckBox();
            this.btnDATABASE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkBARBERS
            // 
            this.chkBARBERS.AutoSize = true;
            this.chkBARBERS.Location = new System.Drawing.Point(29, 39);
            this.chkBARBERS.Name = "chkBARBERS";
            this.chkBARBERS.Size = new System.Drawing.Size(95, 21);
            this.chkBARBERS.TabIndex = 0;
            this.chkBARBERS.Text = "BARBERS";
            this.chkBARBERS.UseVisualStyleBackColor = true;
            // 
            // chkSERVICE
            // 
            this.chkSERVICE.AutoSize = true;
            this.chkSERVICE.Location = new System.Drawing.Point(29, 66);
            this.chkSERVICE.Name = "chkSERVICE";
            this.chkSERVICE.Size = new System.Drawing.Size(88, 21);
            this.chkSERVICE.TabIndex = 1;
            this.chkSERVICE.Text = "SERVICE";
            this.chkSERVICE.UseVisualStyleBackColor = true;
            // 
            // chkPRICE
            // 
            this.chkPRICE.AutoSize = true;
            this.chkPRICE.Location = new System.Drawing.Point(29, 93);
            this.chkPRICE.Name = "chkPRICE";
            this.chkPRICE.Size = new System.Drawing.Size(70, 21);
            this.chkPRICE.TabIndex = 2;
            this.chkPRICE.Text = "PRICE";
            this.chkPRICE.UseVisualStyleBackColor = true;
            // 
            // chkSCHEDULE
            // 
            this.chkSCHEDULE.AutoSize = true;
            this.chkSCHEDULE.Location = new System.Drawing.Point(29, 120);
            this.chkSCHEDULE.Name = "chkSCHEDULE";
            this.chkSCHEDULE.Size = new System.Drawing.Size(104, 21);
            this.chkSCHEDULE.TabIndex = 3;
            this.chkSCHEDULE.Text = "SCHEDULE";
            this.chkSCHEDULE.UseVisualStyleBackColor = true;
            // 
            // btnDATABASE
            // 
            this.btnDATABASE.Location = new System.Drawing.Point(243, 39);
            this.btnDATABASE.Name = "btnDATABASE";
            this.btnDATABASE.Size = new System.Drawing.Size(105, 49);
            this.btnDATABASE.TabIndex = 4;
            this.btnDATABASE.Text = "Load DATABASE";
            this.btnDATABASE.UseVisualStyleBackColor = true;
            this.btnDATABASE.Click += new System.EventHandler(this.btnDATABASE_Click);
            // 
            // DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 205);
            this.Controls.Add(this.btnDATABASE);
            this.Controls.Add(this.chkSCHEDULE);
            this.Controls.Add(this.chkPRICE);
            this.Controls.Add(this.chkSERVICE);
            this.Controls.Add(this.chkBARBERS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBARBERS;
        private System.Windows.Forms.CheckBox chkSERVICE;
        private System.Windows.Forms.CheckBox chkPRICE;
        private System.Windows.Forms.CheckBox chkSCHEDULE;
        private System.Windows.Forms.Button btnDATABASE;
    }
}