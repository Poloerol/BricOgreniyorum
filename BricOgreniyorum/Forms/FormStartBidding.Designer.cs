namespace BricOgreniyorum.Forms
{
    partial class FormStartBidding
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnBid = new System.Windows.Forms.Button();
            this.btnSpecify = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAbandon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // btnBid
            //
            this.btnBid.Location = new System.Drawing.Point(12, 12);
            this.btnBid.Name = "btnBid";
            this.btnBid.Size = new System.Drawing.Size(260, 30);
            this.btnBid.TabIndex = 0;
            this.btnBid.Text = "Bid for the Contract";
            this.btnBid.UseVisualStyleBackColor = true;
            this.btnBid.Click += new System.EventHandler(this.btnBid_Click);
            //
            // btnSpecify
            //
            this.btnSpecify.Location = new System.Drawing.Point(12, 45);
            this.btnSpecify.Name = "btnSpecify";
            this.btnSpecify.Size = new System.Drawing.Size(260, 30);
            this.btnSpecify.TabIndex = 1;
            this.btnSpecify.Text = "Specify the Contract";
            this.btnSpecify.UseVisualStyleBackColor = true;
            this.btnSpecify.Click += new System.EventHandler(this.btnSpecify_Click);
            //
            // btnRotate
            //
            this.btnRotate.Location = new System.Drawing.Point(12, 78);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(260, 30);
            this.btnRotate.TabIndex = 2;
            this.btnRotate.Text = "Rotate the Hands";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            //
            // btnNext
            //
            this.btnNext.Location = new System.Drawing.Point(12, 111);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(260, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Advance to the Next Deal";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            //
            // btnAbandon
            //
            this.btnAbandon.Location = new System.Drawing.Point(12, 144);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(260, 30);
            this.btnAbandon.TabIndex = 4;
            this.btnAbandon.Text = "Abandon the Game";
            this.btnAbandon.UseVisualStyleBackColor = true;
            this.btnAbandon.Click += new System.EventHandler(this.btnAbandon_Click);
            //
            // FormStartBidding
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 185);
            this.Controls.Add(this.btnBid);
            this.Controls.Add(this.btnSpecify);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAbandon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStartBidding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Bidding";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnBid;
        private System.Windows.Forms.Button btnSpecify;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAbandon;
    }
}
