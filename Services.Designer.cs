
namespace Barber
{
    partial class Services
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
            this.richSERVICES = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richSERVICES
            // 
            this.richSERVICES.BackColor = System.Drawing.SystemColors.Control;
            this.richSERVICES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richSERVICES.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richSERVICES.Location = new System.Drawing.Point(24, 18);
            this.richSERVICES.Name = "richSERVICES";
            this.richSERVICES.Size = new System.Drawing.Size(291, 258);
            this.richSERVICES.TabIndex = 0;
            this.richSERVICES.Text = "";
            this.richSERVICES.TextChanged += new System.EventHandler(this.richSERVICES_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richSERVICES);
            this.Name = "Services";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Services";
            this.Load += new System.EventHandler(this.Services_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richSERVICES;
        private System.Windows.Forms.Button button1;
    }
}