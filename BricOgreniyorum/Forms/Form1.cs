using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BricOgreniyorum.Class;

namespace BricOgreniyorum.Forms
{
    public partial class Form1 : Form
    {
        private readonly GameManager _gameManager;

        public Form1(GameManager gameManager)
        {
            InitializeComponent();
            _gameManager = gameManager;
            this.WindowState = FormWindowState.Maximized;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Oyun formu açıldığında önce StartBidding penceresini gösterelim
            FormStartBidding startBiddingForm = new FormStartBidding();
            if (startBiddingForm.ShowDialog() == DialogResult.OK)
            {
                switch (startBiddingForm.Result)
                {
                    case FormStartBidding.BiddingChoice.BidForContract:
                        // Oyun formu zaten açık, bidding formunu bunun üzerinde açalım
                        FormBidding biddingForm = new FormBidding
                        {
                            Owner = this // Bidding formunun Form1'in önünde kalmasını sağlar
                        };
                        biddingForm.InitBidding(_gameManager);
                        biddingForm.StartBiddingCheck();
                        biddingForm.Show();
                        break;
                    case FormStartBidding.BiddingChoice.SpecifyContract:
                        MessageBox.Show("Kontrat belirleme özelliği yakında eklenecek.");
                        break;
                    case FormStartBidding.BiddingChoice.RotateHands:
                        _gameManager.StartNewGame();
                        UpdateUI();
                        // Yeniden seçim ekranını göster
                        Form1_Load_1(sender, e);
                        break;
                    case FormStartBidding.BiddingChoice.NextDeal:
                        _gameManager.StartNewGame();
                        UpdateUI();
                        // Yeniden seçim ekranını göster
                        Form1_Load_1(sender, e);
                        break;
                    case FormStartBidding.BiddingChoice.Abandon:
                        Application.Exit();
                        break;
                }
            }
            else
            {
                // Kullanıcı pencereyi kapattıysa ana menüye dön
                this.Close();
                Application.OpenForms["FormMainMenu"]?.Show();
            }
            UpdateUI();
        }


        private void UpdateUI()
        {
            lblStatus.Text = $"Sıra: {_gameManager.GetCurrentPlayer().Name}";
            lblTrump.Text = $"Koz: {(_gameManager.TrumpSuit != null ? _gameManager.TrumpSuit.ToString() : "Belirlenmedi")}";

            if (_gameManager.CurrentPhase == GamePhase.Playing)
            {
                panelCenter.Visible = true;
                flowLayoutPanelHand.Visible = true;
                RenderHand();
            }

            if (_gameManager.GetCurrentPlayer().IsAI)
            {
                System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ =>
                {
                    if (!this.IsDisposed && this.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            SimulateAIPlay();
                        });
                    }
                });
            }
        }

        private void RenderHand()
        {
            flowLayoutPanelHand.Controls.Clear();
            Player user = _gameManager.Players.Find(p => !p.IsAI);

            if (user == null) return;

            foreach (var card in user.Hand.Cards)
            {
                Button cardBtn = new Button
                {
                    Text = card.ToString(),
                    Size = new Size(60, 90),
                    Tag = card
                };
                cardBtn.Click += Card_Click;
                flowLayoutPanelHand.Controls.Add(cardBtn);
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Card card = (Card)btn.Tag;
            Player user = _gameManager.Players.Find(p => !p.IsAI);

            if (_gameManager.GetCurrentPlayer() != user)
            {
                MessageBox.Show("Sıra sizde değil!");
                return;
            }

            if (!_gameManager.IsValidMove(user, card))
            {
                MessageBox.Show("Bu kartı şu an oynayamazsınız (Renk kuralı)!");
                return;
            }

            PlayCard(user, card);
        }

        private void PlayCard(Player player, Card card)
        {
            _gameManager.TrickManager.PlayCard(player, card);
            player.Hand.PlayCard(card);

            Label cardLabel = new Label
            {
                Text = card.ToString(),
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(_gameManager.TrickManager.PlayedCards.Count * 70, 150)
            };
            panelCenter.Controls.Add(cardLabel);

            _gameManager.MoveToNextPlayer();
            UpdateUI();

            if (_gameManager.TrickManager.PlayedCards.Count == 4)
            {
                EndTrick();
            }
            else if (_gameManager.GetCurrentPlayer().IsAI)
            {
                System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ =>
                {
                    this.Invoke((MethodInvoker)delegate {
                        SimulateAIPlay();
                    });
                });
            }
        }

        private void SimulateAIPlay()
        {
            Player ai = _gameManager.GetCurrentPlayer();
            Card validCard = ai.Hand.Cards.FirstOrDefault(c => _gameManager.IsValidMove(ai, c));

            if (validCard != null)
            {
                PlayCard(ai, validCard);
            }
        }

        private void EndTrick()
        {
            Player winner = _gameManager.TrickManager.DetermineWinner();
            _gameManager.ScoreKeeper.AddTrick(winner);

            MessageBox.Show($"Turu Kazanan: {winner.Name}");

            panelCenter.Controls.Clear();
            _gameManager.TrickManager.ClearTrick();

            UpdateUI();
        }
    }
}
