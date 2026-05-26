namespace BricOgreniyorum.Forms
{
    partial class Form1
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTrump = new System.Windows.Forms.Label();
            this.flowLayoutPanelHand = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.pnlNorthCards = new System.Windows.Forms.Panel();
            this.pnlEastCards = new System.Windows.Forms.Panel();
            this.pnlWestCards = new System.Windows.Forms.Panel();
            this.lblNorth = new System.Windows.Forms.Label();
            this.lblEast = new System.Windows.Forms.Label();
            this.lblWest = new System.Windows.Forms.Label();
            this.lblSouth = new System.Windows.Forms.Label();
            this.flowLayoutPanelHand.SuspendLayout();
            this.pnlNorthCards.SuspendLayout();
            this.pnlEastCards.SuspendLayout();
            this.pnlWestCards.SuspendLayout();
            this.SuspendLayout();
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Durum";
            //
            // lblTrump
            //
            this.lblTrump.AutoSize = true;
            this.lblTrump.ForeColor = System.Drawing.Color.White;
            this.lblTrump.Location = new System.Drawing.Point(700, 9);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(60, 13);
            this.lblTrump.TabIndex = 1;
            this.lblTrump.Text = "Koz: -";
            //
            // flowLayoutPanelHand
            //
            this.flowLayoutPanelHand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanelHand.Location = new System.Drawing.Point(100, 330);
            this.flowLayoutPanelHand.Name = "flowLayoutPanelHand";
            this.flowLayoutPanelHand.Size = new System.Drawing.Size(600, 100);
            this.flowLayoutPanelHand.TabIndex = 2;
            //
            // panelCenter
            //
            this.panelCenter.BackColor = System.Drawing.Color.FromArgb(0, 100, 0);
            this.panelCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCenter.Location = new System.Drawing.Point(200, 120);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(400, 180);
            this.panelCenter.TabIndex = 3;
            //
            // pnlNorthCards
            //
            this.pnlNorthCards.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlNorthCards.Location = new System.Drawing.Point(350, 30);
            this.pnlNorthCards.Name = "pnlNorthCards";
            this.pnlNorthCards.Size = new System.Drawing.Size(100, 60);
            this.pnlNorthCards.TabIndex = 8;
            //
            // pnlEastCards
            //
            this.pnlEastCards.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlEastCards.Location = new System.Drawing.Point(680, 150);
            this.pnlEastCards.Name = "pnlEastCards";
            this.pnlEastCards.Size = new System.Drawing.Size(60, 100);
            this.pnlEastCards.TabIndex = 9;
            //
            // pnlWestCards
            //
            this.pnlWestCards.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlWestCards.Location = new System.Drawing.Point(50, 150);
            this.pnlWestCards.Name = "pnlWestCards";
            this.pnlWestCards.Size = new System.Drawing.Size(60, 100);
            this.pnlWestCards.TabIndex = 10;
            //
            // lblNorth
            //
            this.lblNorth.AutoSize = true;
            this.lblNorth.ForeColor = System.Drawing.Color.White;
            this.lblNorth.Location = new System.Drawing.Point(375, 10);
            this.lblNorth.Name = "lblNorth";
            this.lblNorth.Size = new System.Drawing.Size(40, 13);
            this.lblNorth.TabIndex = 4;
            this.lblNorth.Text = "Kuzey";
            //
            // lblEast
            //
            this.lblEast.AutoSize = true;
            this.lblEast.ForeColor = System.Drawing.Color.White;
            this.lblEast.Location = new System.Drawing.Point(650, 130);
            this.lblEast.Name = "lblEast";
            this.lblEast.Size = new System.Drawing.Size(40, 13);
            this.lblEast.TabIndex = 5;
            this.lblEast.Text = "Doğu";
            //
            // lblWest
            //
            this.lblWest.AutoSize = true;
            this.lblWest.ForeColor = System.Drawing.Color.White;
            this.lblWest.Location = new System.Drawing.Point(80, 130);
            this.lblWest.Name = "lblWest";
            this.lblWest.Size = new System.Drawing.Size(40, 13);
            this.lblWest.TabIndex = 6;
            this.lblWest.Text = "Batı";
            //
            // lblSouth
            //
            this.lblSouth.AutoSize = true;
            this.lblSouth.ForeColor = System.Drawing.Color.White;
            this.lblSouth.Location = new System.Drawing.Point(375, 310);
            this.lblSouth.Name = "lblSouth";
            this.lblSouth.Size = new System.Drawing.Size(40, 13);
            this.lblSouth.TabIndex = 7;
            this.lblSouth.Text = "Güney (Siz)";
            //
            // Form1
            //
            this.BackColor = System.Drawing.Color.FromArgb(0, 128, 0);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.flowLayoutPanelHand);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.pnlNorthCards);
            this.Controls.Add(this.pnlEastCards);
            this.Controls.Add(this.pnlWestCards);
            this.Controls.Add(this.lblNorth);
            this.Controls.Add(this.lblEast);
            this.Controls.Add(this.lblWest);
            this.Controls.Add(this.lblSouth);
            this.Name = "Form1";
            this.Text = "BricOgreniyorum - Oyun Masası";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.flowLayoutPanelHand.ResumeLayout(false);
            this.pnlNorthCards.ResumeLayout(false);
            this.pnlEastCards.ResumeLayout(false);
            this.pnlWestCards.ResumeLayout(false);
            this.SuspendLayout();
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTrump;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHand;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel pnlNorthCards;
        private System.Windows.Forms.Panel pnlEastCards;
        private System.Windows.Forms.Panel pnlWestCards;
        private System.Windows.Forms.Label lblNorth;
        private System.Windows.Forms.Label lblEast;
        private System.Windows.Forms.Label lblWest;
        private System.Windows.Forms.Label lblSouth;
    }
}
