using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BricOgreniyorum.Class;

namespace BricOgreniyorum.Forms
{
    public partial class FormBidding : Form
    {
        private GameManager _gameManager;
        private int _selectedTrick = 1;
        private Suit? _selectedSuit = null;

        public FormBidding()
        {
            InitializeComponent();
        }

        public void InitBidding(GameManager gameManager)
        {
            _gameManager = gameManager;
            UpdateUI();
            SetupBiddingUI();
        }

        private void UpdateUI()
        {
            lblStatus.Text = $"Sıra: {_gameManager.GetCurrentPlayer().Name}";
            lblCurrentBid.Text = $"Güncel Teklif: {(_gameManager.CurrentBid?.ToString() ?? "Yok")}";

            if (_gameManager.GetCurrentPlayer().IsAI)
            {
                System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ =>
                {
                    if (!this.IsDisposed && this.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            SimulateAIBidding();
                        });
                    }
                });
            }
        }

        private void SetupBiddingUI()
        {
            flowLayoutPanelBids.Controls.Clear();
            flowLayoutPanelSuits.Controls.Clear();

            for (int i = 1; i <= 7; i++)
            {
                Button btn = new Button { Text = i.ToString(), Size = new Size(40, 30), Tag = i };
                btn.Click += (s, e) => { _selectedTrick = (int)btn.Tag; UpdateBiddingSelection(); };
                flowLayoutPanelBids.Controls.Add(btn);
            }

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                Button btn = new Button { Text = suit.ToString(), Size = new Size(80, 30), Tag = suit };
                btn.Click += (s, e) => { _selectedSuit = (Suit)btn.Tag; UpdateBiddingSelection(); };
                flowLayoutPanelSuits.Controls.Add(btn);
            }

            Button btnNoTrump = new Button { Text = "NT", Size = new Size(80, 30), Tag = "NT" };
            btnNoTrump.Click += (s, e) => { _selectedSuit = null; UpdateBiddingSelection(); };
            flowLayoutPanelSuits.Controls.Add(btnNoTrump);
        }

        private void UpdateBiddingSelection()
        {
            foreach (Control c in flowLayoutPanelBids.Controls)
                c.BackColor = (int)c.Tag == _selectedTrick ? Color.LightBlue : Color.White;

            foreach (Control c in flowLayoutPanelSuits.Controls)
            {
                if (c.Tag is Suit suit && suit == _selectedSuit) c.BackColor = Color.LightBlue;
                else if (c.Tag?.ToString() == "NT" && _selectedSuit == null) c.BackColor = Color.LightBlue;
                else c.BackColor = Color.White;
            }
        }

        private void BtnPass_Click(object sender, EventArgs e)
        {
            Player user = _gameManager.Players.Find(p => !p.IsAI);
            if (_gameManager.GetCurrentPlayer() != user) return;

            _gameManager.Pass(user);
            UpdateUI();
        }

        private void BtnConfirmBid_Click(object sender, EventArgs e)
        {
            Player user = _gameManager.Players.Find(p => !p.IsAI);
            Bid bid = new Bid(_selectedTrick, _selectedSuit);

            try
            {
                _gameManager.MakeBid(user, bid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateUI();
        }

        private void SimulateAIBidding()
        {
            Player ai = _gameManager.GetCurrentPlayer();
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0 || _gameManager.CurrentBid == null && rnd.Next(0, 3) == 0)
            {
                _gameManager.Pass(ai);
            }
            else
            {
                int newCount = (_gameManager.CurrentBid?.TrickCount ?? 1) + 1;
                if (newCount <= 7)
                {
                    Suit randomSuit = (Suit)rnd.Next(0, 4);
                    _gameManager.MakeBid(ai, new Bid(newCount, randomSuit));
                }
                else
                {
                    _gameManager.Pass(ai);
                }
            }
            UpdateUI();
        }

        // Bu metod Bidding bittiğinde çağrılacak
        public void OnBiddingComplete(Action onComplete)
        {
            if (_gameManager.CurrentPhase == GamePhase.Playing)
            {
                onComplete?.Invoke();
            }
        }

        // Polling mechanism to check if bidding ended
        public void StartBiddingCheck()
        {
            var timer = new System.Windows.Forms.Timer
            {
                Interval = 500
            };
            timer.Tick += (s, e) => {
                if (_gameManager.CurrentPhase == GamePhase.Playing)
                {
                    timer.Stop();
                    OnBiddingComplete(() => {
                        Form1 gameForm = new Form1(_gameManager);
                        gameForm.Show();
                        this.Close();
                    });
                }
            };
            timer.Start();
        }
    }
}
