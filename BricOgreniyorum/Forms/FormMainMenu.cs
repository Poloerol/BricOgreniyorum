using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BricOgreniyorum.Class;

namespace BricOgreniyorum.Forms
{
    public partial class FormMainMenu : Form
    {
        // Ana menü butonları
        private Button anaButon1;
        private Button anaButon2;
        private Button anaButon3;
        private Button anaButon4;
        // Orta butonlar
        private Button ortaButon1;
        private Button ortaButon2;
        private Button ortaButon3;
        private int lastMainIndex = -1;

        public FormMainMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Arka plan resmini ayarla (proje kökünden veya çıktı dizininden bulunmaya çalış)
            string fileName = "AnaCover.png";
            string relativePath = Path.Combine("Images", "Backgrounds", fileName);

            string foundPath = null;
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            // Yukarı doğru projede resmin bulunduğu klasörü arıyoruz (çalışma dizini bin\Debug vb. olabilir)
            for (int i = 0; i < 8 && dir != null; i++)
            {
                string candidate = Path.Combine(dir, relativePath);
                if (File.Exists(candidate))
                {
                    foundPath = candidate;
                    break;
                }
                DirectoryInfo parent = Directory.GetParent(dir);
                dir = parent?.FullName;
            }

            if (foundPath != null)
            {
                // Resmi yükle
                this.BackgroundImage = Image.FromFile(foundPath);
                // Resmi tam ekran olacak şekilde uzat
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                // Eğer dosya bulunamazsa arka planı standart bir renk yap
                this.BackColor = Color.DarkGreen;
            }

            // Menü butonlarını oluştur
            CreateMainButtons();
            // Yeniden boyutlandırıldığında butonları yeniden konumla
            this.Resize += (s, e) => PositionMainButtons();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewGameMenuItem_Click(object sender, EventArgs e)
        {
            GameManager gameManager = new GameManager();
            gameManager.StartNewGame();

            // Artık direkt oyun formunu açıyoruz, bidding işlemini oyun formu yönetecek
            Form1 gameForm = new Form1(gameManager);
            gameForm.Show();
            this.Hide();
        }

        private void NewGameToolItem_Click(object sender, EventArgs e)
        {
            NewGameMenuItem_Click(sender, e);
        }

        private void CreateMainButtons()
        {
            // Temel boyut ve stil
            Size btnSize = new Size(200, 50);

            anaButon1 = new Button() { Name = "anaButon1", Text = "Oyna", Size = btnSize, BackColor = Color.FromArgb(220, Color.White), FlatStyle = FlatStyle.Flat };
            anaButon2 = new Button() { Name = "anaButon2", Text = "Pratik", Size = btnSize, BackColor = Color.FromArgb(220, Color.White), FlatStyle = FlatStyle.Flat };
            anaButon3 = new Button() { Name = "anaButon3", Text = "Yarışma", Size = btnSize, BackColor = Color.FromArgb(220, Color.White), FlatStyle = FlatStyle.Flat };
            anaButon4 = new Button() { Name = "anaButon4", Text = "Araçlar", Size = btnSize, BackColor = Color.FromArgb(220, Color.White), FlatStyle = FlatStyle.Flat };

            // Click handler: hangi ana butona tıklandığını ilet
            anaButon1.Click += (s, e) => OnMainButtonClicked(1);
            anaButon2.Click += (s, e) => OnMainButtonClicked(2);
            anaButon3.Click += (s, e) => OnMainButtonClicked(3);
            anaButon4.Click += (s, e) => OnMainButtonClicked(4);

            this.Controls.AddRange(new Control[] { anaButon1, anaButon2, anaButon3, anaButon4 });

            // Orta butonları oluştur, başlangıçta görünmez
            CreateMiddleButtons(btnSize);

            // İlk konumlama
            PositionMainButtons();
        }

        private void PositionMainButtons()
        {
            if (anaButon1 == null) return;

            int btnW = anaButon1.Width;
            int btnH = anaButon1.Height;
            int hSpacing = 20;
            int vSpacing = 20;

            // Eski davranışı koruyarak önce tek sütun için topY hesapla (böylece anaButon4'ün y konumu aynı kalacak)
            int singleColumnTotalHeight = btnH * 4 + vSpacing * 3;
            int bottomGapFromStatus = 150;
            int topY;
            if (this.statusStrip1 != null)
            {
                int statusTop = this.statusStrip1.Top;
                topY = statusTop - bottomGapFromStatus - singleColumnTotalHeight;
            }
            else
            {
                topY = (this.ClientSize.Height - singleColumnTotalHeight) / 2;
            }

            int minTop = (this.menuStrip1?.Bottom ?? 0) + 20;
            if (topY < minTop) topY = minTop;

            // İki butonu yatayda tam ortala
            int totalWidth = btnW * 2 + hSpacing;
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int leftX = startX;
            int rightX = startX + btnW + hSpacing;

            // Alt satır Y konumu (anaButon4'ün Y'si)
            int bottomRowY = topY + (btnH + vSpacing) * 3;
            int topRowY = bottomRowY - (btnH + vSpacing);

            // Yerleştirme: iki sütun, iki satır
            anaButon1.Location = new Point(leftX, topRowY);
            anaButon2.Location = new Point(rightX, topRowY);
            anaButon3.Location = new Point(leftX, bottomRowY);
            anaButon4.Location = new Point(rightX, bottomRowY);

            // Orta butonların konumunu güncelle
            PositionMiddleButtons(topRowY);
        }

        private void CreateMiddleButtons(Size btnSize)
        {
            ortaButon1 = new Button() { Name = "ortaButon1", Text = "orta1", Size = btnSize, BackColor = Color.FromArgb(220, Color.LightGray), FlatStyle = FlatStyle.Flat, Visible = false };
            ortaButon2 = new Button() { Name = "ortaButon2", Text = "orta2", Size = btnSize, BackColor = Color.FromArgb(220, Color.LightGray), FlatStyle = FlatStyle.Flat, Visible = false };
            ortaButon3 = new Button() { Name = "ortaButon3", Text = "orta3", Size = btnSize, BackColor = Color.FromArgb(220, Color.LightGray), FlatStyle = FlatStyle.Flat, Visible = false };

            ortaButon1.Click += (s, e) => OnMiddleButtonClicked(1);
            ortaButon2.Click += (s, e) => OnMiddleButtonClicked(2);
            ortaButon3.Click += (s, e) => OnMiddleButtonClicked(3);

            this.Controls.AddRange(new Control[] { ortaButon1, ortaButon2, ortaButon3 });
        }

        private void PositionMiddleButtons(int topRowY)
        {
            if (ortaButon1 == null) return;

            int btnW = ortaButon1.Width;
            int btnH = ortaButon1.Height;
            int hSpacing = 20;

            // Orta butonlar üst satırın hemen üstünde yer alacak
            int ortaY = topRowY - btnH - 10; // 10px ekstra boşluk

            int totalOrtaWidth = btnW * 3 + hSpacing * 2;
            int startOrtaX = (this.ClientSize.Width - totalOrtaWidth) / 2;

            ortaButon1.Location = new Point(startOrtaX, ortaY);
            ortaButon2.Location = new Point(startOrtaX + btnW + hSpacing, ortaY);
            ortaButon3.Location = new Point(startOrtaX + (btnW + hSpacing) * 2, ortaY);
        }

        private void OnMainButtonClicked(int index)
        {
            lastMainIndex = index;
            // Eğer anaButon1 tıklandıysa orta butonları göster ve metinlerini ayarla
            if (index == 1)
            {
                // Konumları güncelle
                PositionMainButtons();

                if (ortaButon1 != null)
                {
                    ortaButon1.Text = "Briç Oyna";
                    ortaButon2.Text = "BBO";
                    ortaButon3.Text = "Geri";

                    ortaButon1.Visible = true;
                    ortaButon2.Visible = true;
                    ortaButon3.Visible = true;
                }

                anaButon1.Enabled = false;
                anaButon2.Enabled = false;
                anaButon3.Enabled = false;
                anaButon4.Enabled = false;

                return;
            }

            // Diğer ana buton davranışları için varsayılan: orta butonları göster
            PositionMainButtons();
            if (ortaButon1 != null)
            {
                ortaButon1.Visible = true;
                ortaButon2.Visible = true;
                ortaButon3.Visible = true;
            }

            anaButon1.Enabled = false;
            anaButon2.Enabled = false;
            anaButon3.Enabled = false;
            anaButon4.Enabled = false;
        }

        private void OnMiddleButtonClicked(int ortaIndex)
        {
            // Orta butonlardan biri tıklandığında davranış
            if (ortaIndex == 1)
            {
                // Briç Oyna seçildi -> yeni oyun başlat
                GameManager gameManager = new GameManager();
                gameManager.StartNewGame();

                Form1 gameForm = new Form1(gameManager);
                gameForm.Show();
                this.Hide();
                return;
            }

            if (ortaIndex == 3)
            {
                // Geri seçildi: orta butonları gizle ve ana butonları aktif et
                if (ortaButon1 != null)
                {
                    ortaButon1.Visible = false;
                    ortaButon2.Visible = false;
                    ortaButon3.Visible = false;
                }

                anaButon1.Enabled = true;
                anaButon2.Enabled = true;
                anaButon3.Enabled = true;
                anaButon4.Enabled = true;
            }
        }
    }
}