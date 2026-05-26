using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BricOgreniyorum.Class;

namespace BricOgreniyorum.Forms
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Arka plan resmini ayarla
            string imagePath = @"C:\Users\egokm\source\repos\BricOgreniyorum\BricOgreniyorum\Images\Backgrounds\AnaCover.png";

            if (System.IO.File.Exists(imagePath))
            {
                // Resmi yükle
                this.BackgroundImage = Image.FromFile(imagePath);
                // Resmi tam ekran olacak şekilde uzat
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                // Eğer dosya bulunamazsa arka planı standart bir renk yapabilirsin
                this.BackColor = Color.DarkGreen;
            }
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
    }
}