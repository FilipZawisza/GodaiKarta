using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GodaiKarta
{
    public partial class FormInformacje : Form
    {
        private int clicks = 0;

        public FormInformacje()
        {
            InitializeComponent();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            clicks++;

            if (clicks == 29)
            {
                pictureBoxLogo.Image = Properties.Resources.minich;
            }
        }

        private void linkLabelAktualizuj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/FilipZawisza/Godai/releases") { UseShellExecute = true });
        }

        private void GitHub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/FilipZawisza") { UseShellExecute = true });
        }

        private void Mail_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:filipzawisza@icloud.com");
        }
    }
}