
namespace Barber
{
    partial class Barbers
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
            this.richBARBERS = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMASTERS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richBARBERS
            // 
            this.richBARBERS.BackColor = System.Drawing.SystemColors.Control;
            this.richBARBERS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richBARBERS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richBARBERS.Location = new System.Drawing.Point(12, 36);
            this.richBARBERS.Name = "richBARBERS";
            this.richBARBERS.ReadOnly = true;
            this.richBARBERS.Size = new System.Drawing.Size(287, 264);
            this.richBARBERS.TabIndex = 0;
            this.richBARBERS.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(158, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 53);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMASTERS
            // 
            this.lblMASTERS.AutoSize = true;
            this.lblMASTERS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMASTERS.Location = new System.Drawing.Point(8, 9);
            this.lblMASTERS.Name = "lblMASTERS";
            this.lblMASTERS.Size = new System.Drawing.Size(53, 20);
            this.lblMASTERS.TabIndex = 2;
            this.lblMASTERS.Text = "label1";
            // 
            // Barbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 392);
            this.Controls.Add(this.lblMASTERS);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.richBARBERS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Barbers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barbers";
            this.Load += new System.EventHandler(this.Barbers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richBARBERS;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMASTERS;
    }
}