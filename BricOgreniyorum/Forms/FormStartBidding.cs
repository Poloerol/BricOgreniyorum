using System;
using System.Windows.Forms;
using System.Linq;
using BricOgreniyorum.Class;

namespace BricOgreniyorum.Forms
{
    public partial class FormStartBidding : Form
    {
        public enum BiddingChoice
        {
            BidForContract,
            SpecifyContract,
            RotateHands,
            NextDeal,
            Abandon
        }

        public BiddingChoice Result { get; private set; } = BiddingChoice.Abandon;

        public FormStartBidding()
        {
            InitializeComponent();
        }

        private void BtnBid_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.BidForContract;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnSpecify_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.SpecifyContract;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.RotateHands;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.NextDeal;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnAbandon_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.Abandon;
            // Orijinal davranış: sadece dialog sonucunu ayarla ve kapat
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
