
namespace Barber
{
    partial class MyRezerv
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
            this.gridREZERV = new System.Windows.Forms.DataGridView();
            this.gridREZERV_SERVICES = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridREZERV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridREZERV_SERVICES)).BeginInit();
            this.SuspendLayout();
            // 
            // gridREZERV
            // 
            this.gridREZERV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridREZERV.Location = new System.Drawing.Point(12, 12);
            this.gridREZERV.Name = "gridREZERV";
            this.gridREZERV.RowHeadersWidth = 51;
            this.gridREZERV.RowTemplate.Height = 24;
            this.gridREZERV.Size = new System.Drawing.Size(721, 188);
            this.gridREZERV.TabIndex = 0;
            this.gridREZERV.SelectionChanged += new System.EventHandler(this.gridREZERV_SelectionChanged);
            // 
            // gridREZERV_SERVICES
            // 
            this.gridREZERV_SERVICES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridREZERV_SERVICES.Location = new System.Drawing.Point(12, 225);
            this.gridREZERV_SERVICES.Name = "gridREZERV_SERVICES";
            this.gridREZERV_SERVICES.RowHeadersWidth = 51;
            this.gridREZERV_SERVICES.RowTemplate.Height = 24;
            this.gridREZERV_SERVICES.Size = new System.Drawing.Size(721, 146);
            this.gridREZERV_SERVICES.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 396);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(162, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Anuluj";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MyRezerv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 446);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gridREZERV_SERVICES);
            this.Controls.Add(this.gridREZERV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MyRezerv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moje wizyty";
            this.Load += new System.EventHandler(this.MyRezerv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridREZERV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridREZERV_SERVICES)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridREZERV;
        private System.Windows.Forms.DataGridView gridREZERV_SERVICES;
        private System.Windows.Forms.Button btnDelete;
    }
}