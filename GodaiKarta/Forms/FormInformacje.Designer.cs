namespace GodaiKarta
{
    partial class FormInformacje
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformacje));
            this.groupBoxInformacje = new System.Windows.Forms.GroupBox();
            this.linkLabelAktualizuj = new System.Windows.Forms.LinkLabel();
            this.labelGitHub = new System.Windows.Forms.Label();
            this.pictureBoxGitHub = new System.Windows.Forms.PictureBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.pictureBoxMail = new System.Windows.Forms.PictureBox();
            this.labelDiscord = new System.Windows.Forms.Label();
            this.pictureBoxDiscord = new System.Windows.Forms.PictureBox();
            this.labelInformacje = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.podpowiedz = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxInformacje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGitHub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDiscord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInformacje
            // 
            this.groupBoxInformacje.Controls.Add(this.linkLabelAktualizuj);
            this.groupBoxInformacje.Controls.Add(this.labelGitHub);
            this.groupBoxInformacje.Controls.Add(this.pictureBoxGitHub);
            this.groupBoxInformacje.Controls.Add(this.labelMail);
            this.groupBoxInformacje.Controls.Add(this.pictureBoxMail);
            this.groupBoxInformacje.Controls.Add(this.labelDiscord);
            this.groupBoxInformacje.Controls.Add(this.pictureBoxDiscord);
            this.groupBoxInformacje.Controls.Add(this.labelInformacje);
            this.groupBoxInformacje.Controls.Add(this.pictureBoxLogo);
            this.groupBoxInformacje.Font = new System.Drawing.Font("Century", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxInformacje.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInformacje.Name = "groupBoxInformacje";
            this.groupBoxInformacje.Size = new System.Drawing.Size(610, 337);
            this.groupBoxInformacje.TabIndex = 0;
            this.groupBoxInformacje.TabStop = false;
            this.groupBoxInformacje.Text = "Godai - Karta postaci";
            // 
            // linkLabelAktualizuj
            // 
            this.linkLabelAktualizuj.AutoSize = true;
            this.linkLabelAktualizuj.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelAktualizuj.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelAktualizuj.Location = new System.Drawing.Point(53, 272);
            this.linkLabelAktualizuj.Name = "linkLabelAktualizuj";
            this.linkLabelAktualizuj.Size = new System.Drawing.Size(157, 18);
            this.linkLabelAktualizuj.TabIndex = 9;
            this.linkLabelAktualizuj.TabStop = true;
            this.linkLabelAktualizuj.Text = "Sprawdź aktualizacje";
            this.linkLabelAktualizuj.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAktualizuj_LinkClicked);
            // 
            // labelGitHub
            // 
            this.labelGitHub.AutoSize = true;
            this.labelGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGitHub.Location = new System.Drawing.Point(336, 159);
            this.labelGitHub.Name = "labelGitHub";
            this.labelGitHub.Size = new System.Drawing.Size(127, 23);
            this.labelGitHub.TabIndex = 7;
            this.labelGitHub.Text = "FilipZawisza";
            this.labelGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.podpowiedz.SetToolTip(this.labelGitHub, "https://github.com/FilipZawisza");
            this.labelGitHub.Click += new System.EventHandler(this.GitHub_Click);
            // 
            // pictureBoxGitHub
            // 
            this.pictureBoxGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGitHub.Image = global::GodaiKarta.Properties.Resources.github_icon;
            this.pictureBoxGitHub.Location = new System.Drawing.Point(273, 146);
            this.pictureBoxGitHub.Name = "pictureBoxGitHub";
            this.pictureBoxGitHub.Size = new System.Drawing.Size(57, 48);
            this.pictureBoxGitHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGitHub.TabIndex = 6;
            this.pictureBoxGitHub.TabStop = false;
            this.podpowiedz.SetToolTip(this.pictureBoxGitHub, "GitHub");
            this.pictureBoxGitHub.Click += new System.EventHandler(this.GitHub_Click);
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMail.Location = new System.Drawing.Point(336, 213);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(231, 23);
            this.labelMail.TabIndex = 5;
            this.labelMail.Text = "filipzawisza@icloud.com";
            this.labelMail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.podpowiedz.SetToolTip(this.labelMail, "filipzawisza@icloud.com");
            this.labelMail.Click += new System.EventHandler(this.Mail_Click);
            // 
            // pictureBoxMail
            // 
            this.pictureBoxMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMail.Image = global::GodaiKarta.Properties.Resources.mail_icon;
            this.pictureBoxMail.Location = new System.Drawing.Point(273, 200);
            this.pictureBoxMail.Name = "pictureBoxMail";
            this.pictureBoxMail.Size = new System.Drawing.Size(57, 48);
            this.pictureBoxMail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMail.TabIndex = 4;
            this.pictureBoxMail.TabStop = false;
            this.podpowiedz.SetToolTip(this.pictureBoxMail, "E-mail");
            this.pictureBoxMail.Click += new System.EventHandler(this.Mail_Click);
            // 
            // labelDiscord
            // 
            this.labelDiscord.AutoSize = true;
            this.labelDiscord.Location = new System.Drawing.Point(336, 105);
            this.labelDiscord.Name = "labelDiscord";
            this.labelDiscord.Size = new System.Drawing.Size(103, 23);
            this.labelDiscord.TabIndex = 3;
            this.labelDiscord.Text = "@sniacy__";
            this.labelDiscord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.podpowiedz.SetToolTip(this.labelDiscord, "@sniacy__");
            // 
            // pictureBoxDiscord
            // 
            this.pictureBoxDiscord.Image = global::GodaiKarta.Properties.Resources.discord_icon;
            this.pictureBoxDiscord.Location = new System.Drawing.Point(273, 92);
            this.pictureBoxDiscord.Name = "pictureBoxDiscord";
            this.pictureBoxDiscord.Size = new System.Drawing.Size(57, 48);
            this.pictureBoxDiscord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDiscord.TabIndex = 2;
            this.pictureBoxDiscord.TabStop = false;
            this.podpowiedz.SetToolTip(this.pictureBoxDiscord, "Discord");
            // 
            // labelInformacje
            // 
            this.labelInformacje.AutoSize = true;
            this.labelInformacje.Location = new System.Drawing.Point(64, 208);
            this.labelInformacje.Name = "labelInformacje";
            this.labelInformacje.Size = new System.Drawing.Size(133, 46);
            this.labelInformacje.TabIndex = 1;
            this.labelInformacje.Text = "Filip Zawisza\r\nWersja 1.4";
            this.labelInformacje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::GodaiKarta.Properties.Resources.icon_image;
            this.pictureBoxLogo.Location = new System.Drawing.Point(66, 56);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(129, 139);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // FormInformacje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.groupBoxInformacje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInformacje";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informacje";
            this.groupBoxInformacje.ResumeLayout(false);
            this.groupBoxInformacje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGitHub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDiscord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInformacje;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelInformacje;
        private System.Windows.Forms.ToolTip podpowiedz;
        private System.Windows.Forms.Label labelDiscord;
        private System.Windows.Forms.PictureBox pictureBoxDiscord;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.PictureBox pictureBoxMail;
        private System.Windows.Forms.Label labelGitHub;
        private System.Windows.Forms.PictureBox pictureBoxGitHub;
        private System.Windows.Forms.LinkLabel linkLabelAktualizuj;
    }
}