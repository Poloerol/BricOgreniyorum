namespace BricOgreniyorum.Forms
{
    partial class FormBidding
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentBid = new System.Windows.Forms.Label();
            this.flowLayoutPanelBids = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelSuits = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnConfirmBid = new System.Windows.Forms.Button();
            this.panelBidding = new System.Windows.Forms.Panel();
            this.panelBidding.SuspendLayout();
            this.flowLayoutPanelBids.SuspendLayout();
            this.flowLayoutPanelSuits.SuspendLayout();
            this.SuspendLayout();
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Durum";
            //
            // lblCurrentBid
            //
            this.lblCurrentBid.AutoSize = true;
            this.lblCurrentBid.Location = new System.Drawing.Point(150, 20);
            this.lblCurrentBid.Name = "lblCurrentBid";
            this.lblCurrentBid.Size = new System.Drawing.Size(100, 13);
            this.lblCurrentBid.TabIndex = 1;
            this.lblCurrentBid.Text = "Güncel Teklif: -";
            //
            // flowLayoutPanelBids
            //
            this.flowLayoutPanelBids.Location = new System.Drawing.Point(20, 50);
            this.flowLayoutPanelBids.Name = "flowLayoutPanelBids";
            this.flowLayoutPanelBids.Size = new System.Drawing.Size(360, 40);
            this.flowLayoutPanelBids.TabIndex = 2;
            //
            // flowLayoutPanelSuits
            //
            this.flowLayoutPanelSuits.Location = new System.Drawing.Point(20, 100);
            this.flowLayoutPanelSuits.Name = "flowLayoutPanelSuits";
            this.flowLayoutPanelSuits.Size = new System.Drawing.Size(360, 40);
            this.flowLayoutPanelSuits.TabIndex = 3;
            //
            // btnPass
            //
            this.btnPass.Location = new System.Drawing.Point(100, 200);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(90, 30);
            this.btnPass.TabIndex = 4;
            this.btnPass.Text = "PAS";
            this.btnPass.Click += new System.EventHandler(this.BtnPass_Click);
            //
            // btnConfirmBid
            //
            this.btnConfirmBid.Location = new System.Drawing.Point(210, 200);
            this.btnConfirmBid.Name = "btnConfirmBid";
            this.btnConfirmBid.Size = new System.Drawing.Size(110, 30);
            this.btnConfirmBid.TabIndex = 5;
            this.btnConfirmBid.Text = "Teklifi Onayla";
            this.btnConfirmBid.Click += new System.EventHandler(this.BtnConfirmBid_Click);
            //
            // panelBidding
            //
            this.panelBidding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBidding.Controls.Add(this.btnPass);
            this.panelBidding.Controls.Add(this.btnConfirmBid);
            this.panelBidding.Controls.Add(this.lblCurrentBid);
            this.panelBidding.Controls.Add(this.flowLayoutPanelBids);
            this.panelBidding.Controls.Add(this.flowLayoutPanelSuits);
            this.panelBidding.Location = new System.Drawing.Point(20, 20);
            this.panelBidding.Name = "panelBidding";
            this.panelBidding.Size = new System.Drawing.Size(400, 250);
            this.panelBidding.TabIndex = 6;
            //
            // FormBidding
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelBidding);
            this.Name = "FormBidding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deklarasyon Aşaması";
            this.panelBidding.ResumeLayout(false);
            this.flowLayoutPanelBids.ResumeLayout(false);
            this.flowLayoutPanelSuits.ResumeLayout(false);
            this.SuspendLayout();
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentBid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBids;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSuits;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnConfirmBid;
        private System.Windows.Forms.Panel panelBidding;
    }
}
