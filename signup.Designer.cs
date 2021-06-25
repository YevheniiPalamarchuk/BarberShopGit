
namespace Barber
{
    partial class signup
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
            this.date_beg = new System.Windows.Forms.DateTimePicker();
            this.date_end = new System.Windows.Forms.DateTimePicker();
            this.pnlSCHEDULE = new System.Windows.Forms.Panel();
            this.btnSCHEDULE = new System.Windows.Forms.Button();
            this.pnlSIGNUP = new System.Windows.Forms.Panel();
            this.pnlBARBERS = new System.Windows.Forms.Panel();
            this.pnlCATEGORY = new System.Windows.Forms.Panel();
            this.pnlSERVICE = new System.Windows.Forms.Panel();
            this.lbSeparDate = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.pnlLOGIN = new System.Windows.Forms.Panel();
            this.btnREGISTER = new System.Windows.Forms.Button();
            this.btnLOGIN = new System.Windows.Forms.Button();
            this.pnlMyRezerv = new System.Windows.Forms.Panel();
            this.btnMyRezerv = new System.Windows.Forms.Button();
            this.pnlFREE = new System.Windows.Forms.Panel();
            this.pnlFREE_NOTIME = new System.Windows.Forms.Panel();
            this.pnlBUSY_OUR = new System.Windows.Forms.Panel();
            this.pnlBUSY_OTHER = new System.Windows.Forms.Panel();
            this.lbFREE = new System.Windows.Forms.Label();
            this.lbFREE_NOTIME = new System.Windows.Forms.Label();
            this.lbBUSY_OUR = new System.Windows.Forms.Label();
            this.lbBUSY_OTHER = new System.Windows.Forms.Label();
            this.lbSIGNUP = new System.Windows.Forms.Label();
            this.lbKLIENT = new System.Windows.Forms.Label();
            this.pnlSIGNUP.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlLOGIN.SuspendLayout();
            this.pnlMyRezerv.SuspendLayout();
            this.SuspendLayout();
            // 
            // date_beg
            // 
            this.date_beg.Location = new System.Drawing.Point(3, 4);
            this.date_beg.Name = "date_beg";
            this.date_beg.Size = new System.Drawing.Size(200, 22);
            this.date_beg.TabIndex = 0;
            this.date_beg.Value = new System.DateTime(2021, 6, 1, 10, 29, 0, 0);
            this.date_beg.ValueChanged += new System.EventHandler(this.date_beg_ValueChanged);
            // 
            // date_end
            // 
            this.date_end.Location = new System.Drawing.Point(228, 4);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 22);
            this.date_end.TabIndex = 1;
            this.date_end.Value = new System.DateTime(2021, 6, 30, 11, 10, 0, 0);
            this.date_end.ValueChanged += new System.EventHandler(this.date_end_ValueChanged);
            // 
            // pnlSCHEDULE
            // 
            this.pnlSCHEDULE.AutoScroll = true;
            this.pnlSCHEDULE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSCHEDULE.Location = new System.Drawing.Point(3, 299);
            this.pnlSCHEDULE.Name = "pnlSCHEDULE";
            this.pnlSCHEDULE.Size = new System.Drawing.Size(1167, 342);
            this.pnlSCHEDULE.TabIndex = 6;
            // 
            // btnSCHEDULE
            // 
            this.btnSCHEDULE.Location = new System.Drawing.Point(433, 2);
            this.btnSCHEDULE.Name = "btnSCHEDULE";
            this.btnSCHEDULE.Size = new System.Drawing.Size(199, 27);
            this.btnSCHEDULE.TabIndex = 1;
            this.btnSCHEDULE.Text = "Aktualizuj";
            this.btnSCHEDULE.UseVisualStyleBackColor = true;
            this.btnSCHEDULE.Click += new System.EventHandler(this.btnSCHEDULE_Click);
            // 
            // pnlSIGNUP
            // 
            this.pnlSIGNUP.AutoScroll = true;
            this.pnlSIGNUP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSIGNUP.Controls.Add(this.pnlBARBERS);
            this.pnlSIGNUP.Controls.Add(this.pnlSCHEDULE);
            this.pnlSIGNUP.Controls.Add(this.pnlCATEGORY);
            this.pnlSIGNUP.Controls.Add(this.pnlSERVICE);
            this.pnlSIGNUP.Location = new System.Drawing.Point(29, 65);
            this.pnlSIGNUP.Name = "pnlSIGNUP";
            this.pnlSIGNUP.Size = new System.Drawing.Size(1177, 763);
            this.pnlSIGNUP.TabIndex = 4;
            // 
            // pnlBARBERS
            // 
            this.pnlBARBERS.AutoScroll = true;
            this.pnlBARBERS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBARBERS.Location = new System.Drawing.Point(694, 3);
            this.pnlBARBERS.Name = "pnlBARBERS";
            this.pnlBARBERS.Size = new System.Drawing.Size(477, 293);
            this.pnlBARBERS.TabIndex = 0;
            // 
            // pnlCATEGORY
            // 
            this.pnlCATEGORY.AutoScroll = true;
            this.pnlCATEGORY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCATEGORY.Location = new System.Drawing.Point(4, 3);
            this.pnlCATEGORY.Name = "pnlCATEGORY";
            this.pnlCATEGORY.Size = new System.Drawing.Size(168, 293);
            this.pnlCATEGORY.TabIndex = 0;
            // 
            // pnlSERVICE
            // 
            this.pnlSERVICE.AutoScroll = true;
            this.pnlSERVICE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSERVICE.Location = new System.Drawing.Point(176, 3);
            this.pnlSERVICE.Name = "pnlSERVICE";
            this.pnlSERVICE.Size = new System.Drawing.Size(514, 293);
            this.pnlSERVICE.TabIndex = 0;
            // 
            // lbSeparDate
            // 
            this.lbSeparDate.AutoSize = true;
            this.lbSeparDate.Location = new System.Drawing.Point(209, 4);
            this.lbSeparDate.Name = "lbSeparDate";
            this.lbSeparDate.Size = new System.Drawing.Size(13, 17);
            this.lbSeparDate.TabIndex = 5;
            this.lbSeparDate.Text = "-";
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.btnSCHEDULE);
            this.pnlDate.Controls.Add(this.date_end);
            this.pnlDate.Controls.Add(this.date_beg);
            this.pnlDate.Controls.Add(this.lbSeparDate);
            this.pnlDate.Location = new System.Drawing.Point(29, 22);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(636, 33);
            this.pnlDate.TabIndex = 7;
            // 
            // pnlLOGIN
            // 
            this.pnlLOGIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLOGIN.Controls.Add(this.btnREGISTER);
            this.pnlLOGIN.Controls.Add(this.btnLOGIN);
            this.pnlLOGIN.Location = new System.Drawing.Point(921, 21);
            this.pnlLOGIN.Name = "pnlLOGIN";
            this.pnlLOGIN.Size = new System.Drawing.Size(285, 34);
            this.pnlLOGIN.TabIndex = 8;
            // 
            // btnREGISTER
            // 
            this.btnREGISTER.Location = new System.Drawing.Point(113, 2);
            this.btnREGISTER.Name = "btnREGISTER";
            this.btnREGISTER.Size = new System.Drawing.Size(164, 27);
            this.btnREGISTER.TabIndex = 1;
            this.btnREGISTER.Text = "Zarejestrować się";
            this.btnREGISTER.UseVisualStyleBackColor = true;
            this.btnREGISTER.Click += new System.EventHandler(this.btnREGISTER_Click);
            // 
            // btnLOGIN
            // 
            this.btnLOGIN.Location = new System.Drawing.Point(3, 2);
            this.btnLOGIN.Name = "btnLOGIN";
            this.btnLOGIN.Size = new System.Drawing.Size(104, 27);
            this.btnLOGIN.TabIndex = 0;
            this.btnLOGIN.Text = "Login";
            this.btnLOGIN.UseVisualStyleBackColor = true;
            this.btnLOGIN.Click += new System.EventHandler(this.btnLOGIN_Click);
            // 
            // pnlMyRezerv
            // 
            this.pnlMyRezerv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMyRezerv.Controls.Add(this.btnMyRezerv);
            this.pnlMyRezerv.Location = new System.Drawing.Point(751, 21);
            this.pnlMyRezerv.Name = "pnlMyRezerv";
            this.pnlMyRezerv.Size = new System.Drawing.Size(166, 34);
            this.pnlMyRezerv.TabIndex = 9;
            // 
            // btnMyRezerv
            // 
            this.btnMyRezerv.Location = new System.Drawing.Point(2, 2);
            this.btnMyRezerv.Name = "btnMyRezerv";
            this.btnMyRezerv.Size = new System.Drawing.Size(160, 28);
            this.btnMyRezerv.TabIndex = 0;
            this.btnMyRezerv.Text = "Moje wizyty";
            this.btnMyRezerv.UseVisualStyleBackColor = true;
            this.btnMyRezerv.Click += new System.EventHandler(this.btnMyRezerv_Click);
            // 
            // pnlFREE
            // 
            this.pnlFREE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFREE.Location = new System.Drawing.Point(41, 718);
            this.pnlFREE.Name = "pnlFREE";
            this.pnlFREE.Size = new System.Drawing.Size(24, 20);
            this.pnlFREE.TabIndex = 10;
            // 
            // pnlFREE_NOTIME
            // 
            this.pnlFREE_NOTIME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFREE_NOTIME.Location = new System.Drawing.Point(41, 744);
            this.pnlFREE_NOTIME.Name = "pnlFREE_NOTIME";
            this.pnlFREE_NOTIME.Size = new System.Drawing.Size(24, 20);
            this.pnlFREE_NOTIME.TabIndex = 11;
            // 
            // pnlBUSY_OUR
            // 
            this.pnlBUSY_OUR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBUSY_OUR.Location = new System.Drawing.Point(41, 770);
            this.pnlBUSY_OUR.Name = "pnlBUSY_OUR";
            this.pnlBUSY_OUR.Size = new System.Drawing.Size(24, 20);
            this.pnlBUSY_OUR.TabIndex = 12;
            // 
            // pnlBUSY_OTHER
            // 
            this.pnlBUSY_OTHER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBUSY_OTHER.Location = new System.Drawing.Point(41, 796);
            this.pnlBUSY_OTHER.Name = "pnlBUSY_OTHER";
            this.pnlBUSY_OTHER.Size = new System.Drawing.Size(24, 20);
            this.pnlBUSY_OTHER.TabIndex = 13;
            // 
            // lbFREE
            // 
            this.lbFREE.AutoSize = true;
            this.lbFREE.Location = new System.Drawing.Point(87, 718);
            this.lbFREE.Name = "lbFREE";
            this.lbFREE.Size = new System.Drawing.Size(46, 17);
            this.lbFREE.TabIndex = 14;
            this.lbFREE.Text = "label1";
            // 
            // lbFREE_NOTIME
            // 
            this.lbFREE_NOTIME.AutoSize = true;
            this.lbFREE_NOTIME.Location = new System.Drawing.Point(87, 744);
            this.lbFREE_NOTIME.Name = "lbFREE_NOTIME";
            this.lbFREE_NOTIME.Size = new System.Drawing.Size(46, 17);
            this.lbFREE_NOTIME.TabIndex = 15;
            this.lbFREE_NOTIME.Text = "label1";
            // 
            // lbBUSY_OUR
            // 
            this.lbBUSY_OUR.AutoSize = true;
            this.lbBUSY_OUR.Location = new System.Drawing.Point(87, 770);
            this.lbBUSY_OUR.Name = "lbBUSY_OUR";
            this.lbBUSY_OUR.Size = new System.Drawing.Size(46, 17);
            this.lbBUSY_OUR.TabIndex = 16;
            this.lbBUSY_OUR.Text = "label1";
            // 
            // lbBUSY_OTHER
            // 
            this.lbBUSY_OTHER.AutoSize = true;
            this.lbBUSY_OTHER.Location = new System.Drawing.Point(87, 797);
            this.lbBUSY_OTHER.Name = "lbBUSY_OTHER";
            this.lbBUSY_OTHER.Size = new System.Drawing.Size(46, 17);
            this.lbBUSY_OTHER.TabIndex = 17;
            this.lbBUSY_OTHER.Text = "label1";
            // 
            // lbSIGNUP
            // 
            this.lbSIGNUP.AutoSize = true;
            this.lbSIGNUP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSIGNUP.Location = new System.Drawing.Point(30, 2);
            this.lbSIGNUP.Name = "lbSIGNUP";
            this.lbSIGNUP.Size = new System.Drawing.Size(72, 17);
            this.lbSIGNUP.TabIndex = 0;
            this.lbSIGNUP.Text = "Zapisz się";
            // 
            // lbKLIENT
            // 
            this.lbKLIENT.AutoSize = true;
            this.lbKLIENT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbKLIENT.Location = new System.Drawing.Point(751, 1);
            this.lbKLIENT.Name = "lbKLIENT";
            this.lbKLIENT.Size = new System.Drawing.Size(45, 17);
            this.lbKLIENT.TabIndex = 18;
            this.lbKLIENT.Text = "Konto";
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 850);
            this.Controls.Add(this.lbKLIENT);
            this.Controls.Add(this.lbSIGNUP);
            this.Controls.Add(this.lbBUSY_OTHER);
            this.Controls.Add(this.lbBUSY_OUR);
            this.Controls.Add(this.lbFREE_NOTIME);
            this.Controls.Add(this.lbFREE);
            this.Controls.Add(this.pnlBUSY_OTHER);
            this.Controls.Add(this.pnlBUSY_OUR);
            this.Controls.Add(this.pnlFREE_NOTIME);
            this.Controls.Add(this.pnlFREE);
            this.Controls.Add(this.pnlMyRezerv);
            this.Controls.Add(this.pnlLOGIN);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.pnlSIGNUP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGN UP";
            this.Activated += new System.EventHandler(this.signup_Activated);
            this.Load += new System.EventHandler(this.signup_Load);
            this.pnlSIGNUP.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlLOGIN.ResumeLayout(false);
            this.pnlMyRezerv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker date_beg;
        private System.Windows.Forms.DateTimePicker date_end;
        private System.Windows.Forms.Panel pnlSIGNUP;
        private System.Windows.Forms.Panel pnlSERVICE;
        private System.Windows.Forms.Panel pnlCATEGORY;
        private System.Windows.Forms.Label lbSeparDate;
        private System.Windows.Forms.Panel pnlSCHEDULE;
        private System.Windows.Forms.Button btnSCHEDULE;
        private System.Windows.Forms.Panel pnlBARBERS;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Panel pnlLOGIN;
        private System.Windows.Forms.Button btnREGISTER;
        private System.Windows.Forms.Button btnLOGIN;
        private System.Windows.Forms.Panel pnlMyRezerv;
        private System.Windows.Forms.Button btnMyRezerv;
        private System.Windows.Forms.Panel pnlFREE;
        private System.Windows.Forms.Panel pnlFREE_NOTIME;
        private System.Windows.Forms.Panel pnlBUSY_OUR;
        private System.Windows.Forms.Panel pnlBUSY_OTHER;
        private System.Windows.Forms.Label lbFREE;
        private System.Windows.Forms.Label lbFREE_NOTIME;
        private System.Windows.Forms.Label lbBUSY_OUR;
        private System.Windows.Forms.Label lbBUSY_OTHER;
        private System.Windows.Forms.Label lbSIGNUP;
        private System.Windows.Forms.Label lbKLIENT;
    }
}