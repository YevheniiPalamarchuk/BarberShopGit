
namespace Barber
{
    partial class Rezerv
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
            this.btnREZERV = new System.Windows.Forms.Button();
            this.lbBARBER = new System.Windows.Forms.Label();
            this.richSERVICE = new System.Windows.Forms.RichTextBox();
            this.pnlBARBER = new System.Windows.Forms.Panel();
            this.pnlBARBER.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnREZERV
            // 
            this.btnREZERV.Location = new System.Drawing.Point(182, 332);
            this.btnREZERV.Name = "btnREZERV";
            this.btnREZERV.Size = new System.Drawing.Size(154, 41);
            this.btnREZERV.TabIndex = 0;
            this.btnREZERV.Text = "Zapisz się";
            this.btnREZERV.UseVisualStyleBackColor = true;
            this.btnREZERV.Click += new System.EventHandler(this.btnREZERV_Click);
            // 
            // lbBARBER
            // 
            this.lbBARBER.AutoSize = true;
            this.lbBARBER.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBARBER.Location = new System.Drawing.Point(3, 9);
            this.lbBARBER.Name = "lbBARBER";
            this.lbBARBER.Size = new System.Drawing.Size(100, 20);
            this.lbBARBER.TabIndex = 1;
            this.lbBARBER.Text = "lbBARBER";
            // 
            // richSERVICE
            // 
            this.richSERVICE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richSERVICE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richSERVICE.Location = new System.Drawing.Point(30, 99);
            this.richSERVICE.Name = "richSERVICE";
            this.richSERVICE.ReadOnly = true;
            this.richSERVICE.Size = new System.Drawing.Size(306, 227);
            this.richSERVICE.TabIndex = 4;
            this.richSERVICE.Text = "";
            // 
            // pnlBARBER
            // 
            this.pnlBARBER.AutoScroll = true;
            this.pnlBARBER.Controls.Add(this.lbBARBER);
            this.pnlBARBER.Location = new System.Drawing.Point(30, 12);
            this.pnlBARBER.Name = "pnlBARBER";
            this.pnlBARBER.Size = new System.Drawing.Size(306, 81);
            this.pnlBARBER.TabIndex = 5;
            // 
            // Rezerv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 385);
            this.Controls.Add(this.pnlBARBER);
            this.Controls.Add(this.richSERVICE);
            this.Controls.Add(this.btnREZERV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Rezerv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Umówić się";
            this.Load += new System.EventHandler(this.Rezerv_Load);
            this.pnlBARBER.ResumeLayout(false);
            this.pnlBARBER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnREZERV;
        private System.Windows.Forms.Label lbBARBER;
        private System.Windows.Forms.RichTextBox richSERVICE;
        private System.Windows.Forms.Panel pnlBARBER;
    }
}