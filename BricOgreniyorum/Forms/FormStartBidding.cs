using System;
using System.Windows.Forms;
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

        private void btnBid_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.BidForContract;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSpecify_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.SpecifyContract;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.RotateHands;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.NextDeal;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAbandon_Click(object sender, EventArgs e)
        {
            Result = BiddingChoice.Abandon;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
