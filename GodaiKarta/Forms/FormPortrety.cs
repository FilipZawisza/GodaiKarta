using System;
using System.Drawing;
using System.Windows.Forms;

namespace GodaiKarta
{
    public partial class FormPortrety : Form
    {
        private bool firstLoad = true;
        private FormKarta formKarta;

        public FormPortrety(FormKarta arg)
        {
            InitializeComponent();
            formKarta = arg;

            firstLoad = true;

            if (formKarta.selectedImage == "portret_transparent")
            {
                radio1.Checked = true;
            }
            else if (formKarta.selectedImage == "niestandardowy")
            {
                picture2.Image = formKarta.pictureBoxPortret.Image;
                radio2.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_mnich_1")
            {
                radio3.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_mnich_2")
            {
                radio4.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_mnich_3")
            {
                radio5.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_mnich_4")
            {
                radio6.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_mnich_5")
            {
                radio7.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_samuraj_1")
            {
                radio8.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_samuraj_2")
            {
                radio9.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_samuraj_3")
            {
                radio10.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_ronin_1")
            {
                radio11.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_ronin_2")
            {
                radio12.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_strzelec_1")
            {
                radio13.Checked = true;
            }
            else if (formKarta.selectedImage == "portret_ninja_1")
            {
                radio14.Checked = true;
            }
        }

        private void radio_Click(object sender, EventArgs e)
        {
            // Rzutowanie sender na RadioButton
            RadioButton radio = sender as RadioButton;

            if (radio.Name == "radio1")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_transparent;
                formKarta.selectedImage = "portret_transparent";
            }
            else if (radio.Name == "radio2")
            {
                if (firstLoad == false)
                {
                    addImage();
                }
                else
                {
                    firstLoad = false;
                }
            }
            else if (radio.Name == "radio3")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_mnich_1;
                formKarta.selectedImage = "portret_mnich_1";
            }
            else if (radio.Name == "radio4")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_mnich_2;
                formKarta.selectedImage = "portret_mnich_2";
            }
            else if (radio.Name == "radio5")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_mnich_3;
                formKarta.selectedImage = "portret_mnich_3";
            }
            else if (radio.Name == "radio6")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_mnich_4;
                formKarta.selectedImage = "portret_mnich_4";
            }
            else if (radio.Name == "radio7")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_mnich_5;
                formKarta.selectedImage = "portret_mnich_5";
            }
            else if (radio.Name == "radio8")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_samuraj_1;
                formKarta.selectedImage = "portret_samuraj_1";
            }
            else if (radio.Name == "radio9")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_samuraj_2;
                formKarta.selectedImage = "portret_samuraj_2";
            }
            else if (radio.Name == "radio10")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_samuraj_3;
                formKarta.selectedImage = "portret_samuraj_3";
            }
            else if (radio.Name == "radio11")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_ronin_1;
                formKarta.selectedImage = "portret_ronin_1";
            }
            else if (radio.Name == "radio12")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_ronin_2;
                formKarta.selectedImage = "portret_ronin_2";
            }
            else if (radio.Name == "radio13")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_strzelec_1;
                formKarta.selectedImage = "portret_strzelec_1";
            }
            else if (radio.Name == "radio14")
            {
                formKarta.pictureBoxPortret.Image = Properties.Resources.portret_ninja_1;
                formKarta.selectedImage = "portret_ninja_1";
            }

            if (radio.Name != "radio2")
            {
                if (firstLoad == false)
                {
                    picture2.Image = Properties.Resources.add_icon;
                    formKarta.isModified = true;
                    formKarta.UpdateTitle();
                }
            }

            firstLoad = false;
        }

        private void picture_Click(object sender, EventArgs e)
        {
            // Rzutowanie sender na PictureBox
            PictureBox picture = sender as PictureBox;

            if (picture.Name == "picture1")
            {
                radio1.Checked = true;
                radio1.PerformClick();
            }
            else if (picture.Name == "picture2")
            {
                radio2.Checked = true;
                radio2.PerformClick();
            }
            else if (picture.Name == "picture3")
            {
                radio3.Checked = true;
                radio3.PerformClick();
            }
            else if (picture.Name == "picture4")
            {
                radio4.Checked = true;
                radio4.PerformClick();
            }
            else if (picture.Name == "picture5")
            {
                radio5.Checked = true;
                radio5.PerformClick();
            }
            else if (picture.Name == "picture6")
            {
                radio6.Checked = true;
                radio6.PerformClick();
            }
            else if (picture.Name == "picture7")
            {
                radio7.Checked = true;
                radio7.PerformClick();
            }
            else if (picture.Name == "picture8")
            {
                radio8.Checked = true;
                radio8.PerformClick();
            }
            else if (picture.Name == "picture9")
            {
                radio9.Checked = true;
                radio9.PerformClick();
            }
            else if (picture.Name == "picture10")
            {
                radio10.Checked = true;
                radio10.PerformClick();
            }
            else if (picture.Name == "picture11")
            {
                radio11.Checked = true;
                radio11.PerformClick();
            }
            else if (picture.Name == "picture12")
            {
                radio12.Checked = true;
                radio12.PerformClick();
            }
            else if (picture.Name == "picture13")
            {
                radio13.Checked = true;
                radio13.PerformClick();
            }
            else if (picture.Name == "picture14")
            {
                radio14.Checked = true;
                radio14.PerformClick();
            }
        }

        private void addImage()
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Obrazy (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        // Przypisanie ścieżki obrazu do ImageLocation
                        formKarta.pictureBoxPortret.ImageLocation = dialog.FileName;
                        // Opcjonalnie: Ustawienie obrazu z tej ścieżki
                        formKarta.pictureBoxPortret.Image = Image.FromFile(dialog.FileName);
                        picture2.Image = Image.FromFile(dialog.FileName);
                        formKarta.selectedImage = "niestandardowy";
                        formKarta.isModified = true;
                        formKarta.UpdateTitle();
                    }
                    else
                    {
                        picture2.Image = Properties.Resources.add_icon;
                        radio1.PerformClick();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nie udało się załadować obrazu. Upewnij się, że plik istnieje i nie jest uszkodzony.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picture2.Image = Properties.Resources.add_icon;
                radio1.PerformClick();
            }
        }
    }
}