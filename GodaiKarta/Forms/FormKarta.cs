using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GodaiKarta
{
    public partial class FormKarta : Form
    {
        private string currentFilePath = null; // Ścieżka otwartego pliku
        public bool isModified = false;        // Status czy plik został zmodyfikowany, ale nie zapisany
        public string selectedImage = "portret_transparent";  // Aktualnie wykorzystywany zasób portretu
        public string customImageLocation = "";  // Lokalizacja obrazka, jeśli selectedImage == "niestandardowy"
        List<Item> items;
        List<Armor> armors;

        public FormKarta()
        {
            InitializeComponent();

            // Lista broni i pancerzy
            InitializeData();

            // Zaktualizowanie tytułu okna
            UpdateTitle();

            // Ustawienie wartości na domyślne
            comboBoxArchetyp.SelectedIndex = 0;
            comboBoxBronieNazwa1.SelectedIndex = 0;
            comboBoxBronieNazwa2.SelectedIndex = 0;
            comboBoxBronieNazwa3.SelectedIndex = 0;
            comboBoxPancerzNazwa.SelectedIndex = 0;

            RegisterControlEvents(this);
        }

        private void InitializeData()
        {
            // Inicjalizacja listy przedmiotów
            items = new List<Item>
            {
                new Item { Nazwa = "", Obrazenia = "", Typ = "", Wartosc = "", Zasieg = "" },
                new Item { Nazwa = "Kij (2)(5)", Obrazenia = "1k6+4", Typ = "Kij", Wartosc = "50", Zasieg = "Wręcz" },
                new Item { Nazwa = "Tanto (6)", Obrazenia = "1k4+1", Typ = "Sztylet/Nóż", Wartosc = "70", Zasieg = "Wręcz" },
                new Item { Nazwa = "Wakizashi", Obrazenia = "1k6+2", Typ = "Krótki miecz", Wartosc = "150", Zasieg = "Wręcz" },
                new Item { Nazwa = "Maczuga kenabo (2)(5)", Obrazenia = "2k6+2", Typ = "Maczuga", Wartosc = "300", Zasieg = "Wręcz" },
                new Item { Nazwa = "Katana (4, krwawienie)", Obrazenia = "2k6", Typ = "Długi miecz", Wartosc = "400", Zasieg = "Wręcz" },
                new Item { Nazwa = "Tachi (4, krwawienie)", Obrazenia = "2k6+2", Typ = "Długi miecz", Wartosc = "500", Zasieg = "Wręcz" },
                new Item { Nazwa = "Nagamaki (2)", Obrazenia = "2k8", Typ = "Broń drzewcowa", Wartosc = "600", Zasieg = "Wręcz" },
                new Item { Nazwa = "O-dachi/No-dachi (2)", Obrazenia = "2k8", Typ = "Miecz oburęczny", Wartosc = "650", Zasieg = "Wręcz" },
                new Item { Nazwa = "Naginata", Obrazenia = "2k6+1k4", Typ = "Glewia", Wartosc = "700", Zasieg = "Wręcz" },
                new Item { Nazwa = "Yari (3)", Obrazenia = "1k10+1k4", Typ = "Włócznia", Wartosc = "750", Zasieg = "Wręcz" },

                new Item { Nazwa = "Shuriken", Obrazenia = "1k4+2", Typ = "Broń miotana", Wartosc = "30", Zasieg = "Siła" },
                new Item { Nazwa = "Kunai", Obrazenia = "1k6+1", Typ = "Broń miotana", Wartosc = "45", Zasieg = "Siła" },
                new Item { Nazwa = "Fukija (4, zatrucie)(6)", Obrazenia = "1", Typ = "Dmuchawka", Wartosc = "50", Zasieg = "20m" },
                new Item { Nazwa = "Krótki łuk (1)", Obrazenia = "1k8", Typ = "Łuk", Wartosc = "250", Zasieg = "100m" },
                new Item { Nazwa = "Pistolet", Obrazenia = "1k8+1", Typ = "Broń krótka", Wartosc = "400", Zasieg = "20m" },
                new Item { Nazwa = "Długi łuk (1)", Obrazenia = "1k12", Typ = "Łuk", Wartosc = "500", Zasieg = "200m" },
                new Item { Nazwa = "Strzelba (2)", Obrazenia = "4k6/1k6", Typ = "Strzelba", Wartosc = "600", Zasieg = "10m/20m" },
                new Item { Nazwa = "Rusznica (1)(3)", Obrazenia = "2k10", Typ = "Karabin", Wartosc = "900", Zasieg = "100m" },
            };

            armors = new List<Armor>
            {
                new Armor { Nazwa = "", WT = "", Typ = "", Wartosc = "" },
                new Armor { Nazwa = "Brak", WT = "0", Typ = "-", Wartosc = "-" },
                new Armor { Nazwa = "Kimono", WT = "1", Typ = "Ubiór", Wartosc = "30" },
                new Armor { Nazwa = "Usztywniane kimono", WT = "2", Typ = "Ubiór", Wartosc = "50" },
                new Armor { Nazwa = "Kimono wędrowca", WT = "3", Typ = "Ubiór", Wartosc = "80" },
                new Armor { Nazwa = "Lekka zbroja", WT = "4", Typ = "Zbroja", Wartosc = "300" },
                new Armor { Nazwa = "Zbroja Ashigaru", WT = "5*", Typ = "Zbroja", Wartosc = "400" },
                new Armor { Nazwa = "Lekka zbroja samuraja", WT = "6**", Typ = "Zbroja", Wartosc = "800" },
                new Armor { Nazwa = "Ciężka zbroja samuraja", WT = "7***", Typ = "Zbroja", Wartosc = "2000" },
            };
        }

        private void menuPlikNowy_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void menuPlikNoweOkno_Click(object sender, EventArgs e)
        {
            FormKarta formKarta = new FormKarta();
            formKarta.Show();
        }

        private void menuPlikOtworz_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void menuPlikZapisz_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void menuPlikZapiszJako_Click(object sender, EventArgs e)
        {
            SaveToFileAs();
        }

        private void menuPlikZakoncz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuOpcjeAutouzupelnianie_Click(object sender, EventArgs e)
        {
            if (menuOpcjeAutouzupelnianie.Checked)
            {
                textBoxPW.ReadOnly = true;
                textBoxODP.ReadOnly = true;
                textBoxMW.ReadOnly = true;
                textBoxMD.ReadOnly = true;
                textBoxI.ReadOnly = true;
                textBoxMana.ReadOnly = true;
            }
            else
            {
                textBoxPW.ReadOnly = false;
                textBoxODP.ReadOnly = false;
                textBoxMW.ReadOnly = false;
                textBoxMD.ReadOnly = false;
                textBoxI.ReadOnly = false;
                textBoxMana.ReadOnly = false;
            }
        }

        private void menuOpcjeZresetuj_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy chcesz zresetować kartę postaci?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClearAllControls(this); // Wyczyszczenie wszystkich kontrolek
                numericZdrowie.Value = 0;
                numericZdrowie.Maximum = 0;
                labelMaxZdrowie.Text = "0";
                numericMana.Value = 0;
                numericMana.Maximum = 0;
                labelMaxMana.Text = "0";

                pictureBoxPortret.Image = Properties.Resources.portret_transparent;
                selectedImage = "portret_transparent";
                customImageLocation = "";

                isModified = true; // Dane zmodyfikowane
                UpdateTitle(); // Zaktualizowanie tytułu okna
            }
            else
            {
                return;
            }
        }

        private void menuWprowadzenie_Click(object sender, EventArgs e)
        {
            FormWprowadzenie formWprowadzenie = new FormWprowadzenie();
            formWprowadzenie.ShowDialog();
        }

        private void menuDziennikZmian_Click(object sender, EventArgs e)
        {
            FormDziennikZmian formDziennikZmian = new FormDziennikZmian();
            formDziennikZmian.ShowDialog();
        }

        private void menuInformacje_Click(object sender, EventArgs e)
        {
            FormInformacje formInformacje = new FormInformacje();
            formInformacje.ShowDialog();
        }

        private void pictureBoxPortret_Click(object sender, EventArgs e)
        {
            FormPortrety formPortrety = new FormPortrety(this);
            formPortrety.ShowDialog();
        }

        private void cechyGlowne_TextChanged(object sender, EventArgs e)
        {
            if (menuOpcjeAutouzupelnianie.Checked)
            {
                try
                {
                    int SIL = 0, ZR = 0, KON = 0, UM = 0, SZ = 0, INT = 0, SZYB = 0, CHA = 0;

                    if (textBoxSila.Text != "")
                    {
                        SIL = Convert.ToInt32(textBoxSila.Text);
                    }
                    if (textBoxZrecznosc.Text != "")
                    {
                        ZR = Convert.ToInt32(textBoxZrecznosc.Text);
                    }
                    if (textBoxKondycja.Text != "")
                    {
                        KON = Convert.ToInt32(textBoxKondycja.Text);
                    }
                    if (textBoxUmiejetnosciMagiczne.Text != "")
                    {
                        UM = Convert.ToInt32(textBoxUmiejetnosciMagiczne.Text);
                    }
                    if (textBoxSzczescie.Text != "")
                    {
                        SZ = Convert.ToInt32(textBoxSzczescie.Text);
                    }
                    if (textBoxInteligencja.Text != "")
                    {
                        INT = Convert.ToInt32(textBoxInteligencja.Text);
                    }
                    if (textBoxSzybkosc.Text != "")
                    {
                        SZYB = Convert.ToInt32(textBoxSzybkosc.Text);
                    }
                    if (textBoxCharyzma.Text != "")
                    {
                        CHA = Convert.ToInt32(textBoxCharyzma.Text);
                    }

                    textBoxPW.Text = (SIL + KON).ToString();
                    textBoxODP.Text = (KON.ToString().Substring(0, 1));
                    textBoxMW.Text = ((SIL + SZYB) / 10).ToString();
                    textBoxMD.Text = ((ZR + SZYB) / 10).ToString();
                    textBoxI.Text = (SZYB + ZR).ToString();

                    if (UM > 0 && INT > 0)
                    {
                        textBoxMana.Text = ((UM + INT) / 2).ToString();
                    }
                    else
                    {
                        textBoxMana.Text = "0";
                    }
                }
                catch
                { }
            }
        }

        private void cechyPochodne_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int PW = 0, ODP = 0, MANA = 0;

                if (textBoxPW.Text != "")
                {
                    PW = Convert.ToInt32(textBoxPW.Text);
                }
                if (textBoxODP.Text != "")
                {
                    ODP = Convert.ToInt32(textBoxODP.Text);
                }
                if (textBoxMana.Text != "")
                {
                    MANA = Convert.ToInt32(textBoxMana.Text);
                }

                if (PW >= 0)
                {
                    labelMaxZdrowie.Text = PW.ToString();
                    numericZdrowie.Maximum = PW;
                    numericZdrowie.Value = PW;
                }
                if (ODP >= 0)
                {
                    labelMaxOdpornosc.Text = ODP.ToString();
                    numericOdpornosc.Maximum = ODP;
                    numericOdpornosc.Value = ODP;
                }
                if (MANA >= 0)
                {
                    labelMaxMana.Text = MANA.ToString();
                    numericMana.Maximum = MANA;
                    numericMana.Value = MANA;
                }
            }
            catch { }
        }

        private void postawy_Click(object sender, EventArgs e)
        {
            // Rzutowanie sender na Button
            RadioButton radio = sender as RadioButton;

            if (radio != null)
            {
                if (radio.Checked)
                {
                    radio.Checked = false;
                }
                else
                {
                    // Sprawdza czy inne RadioButton w tym samym kontenerze są zaznaczone
                    GroupBox parentGroup = radio.Parent as GroupBox;

                    if (parentGroup != null)
                    {
                        foreach (var control in parentGroup.Controls)
                        {
                            if (control is RadioButton otherRadio && otherRadio != radio)
                            {
                                otherRadio.Checked = false;
                            }
                        }
                    }
                    radio.Checked = true;
                }
            }
        }

        private void comboBoxArchetyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuOpcjeAutouzupelnianie.Checked)
            {
                if (comboBoxArchetyp.SelectedItem.ToString() == "")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "";

                    textBoxUmiejetnosc1.Text = "";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Samuraj")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Katana (4, krwawienie)";
                    comboBoxBronieNazwa2.SelectedItem = "Wakizashi";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Walka mieczem";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Ninja")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Tanto (6)";
                    comboBoxBronieNazwa2.SelectedItem = "Shuriken"; textBoxPrzedmiot1.Text = "Shuriken x10"; textBoxWartoscPrzedmiotu1.Text = "30";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Skradanie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Mag")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Kij (2)(5)";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Czarowanie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Ronin")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Naginata";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono wędrowca";

                    textBoxUmiejetnosc1.Text = "Walka glewią";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Uczony")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Tanto (6)";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Wysokie wykształcenie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Handlarz")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Strzelba (2)";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Wycena";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Strzelec")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Krótki łuk (1)";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Precyzyjny strzał";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Złodziej")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Kunai"; textBoxPrzedmiot1.Text = "Kunai x5"; textBoxWartoscPrzedmiotu1.Text = "45";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Złodziejstwo";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Alchemik")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Tanto (6)";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Alchemia";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Kaligraf")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Usztywniane kimono";

                    textBoxUmiejetnosc1.Text = "Fałszowanie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Rzemieślnik")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Dowolna (związana z rzemiosłem)";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Medyk")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Medycyna polowa";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Zwiadowca")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Krótki łuk (1)";
                    comboBoxBronieNazwa2.SelectedItem = "Tanto (6)";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono wędrowca";

                    textBoxUmiejetnosc1.Text = "Tropienie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Urzędnik")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Wakizashi";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Oczytanie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Szpieg cesarski")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Tanto (6)";
                    comboBoxBronieNazwa2.SelectedItem = "Kunai";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Ukrywanie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Najemnik")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Wakizashi";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Dowolna (jako specjalizacja)";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Tropiciel")
                {
                    comboBoxBronieNazwa1.SelectedItem = "Tanto (6)";
                    comboBoxBronieNazwa2.SelectedItem = "Kij (2)(5)";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono wędrowca";

                    textBoxUmiejetnosc1.Text = "Tropienie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Kapłan")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Dar przekonywania";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Inżynier")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Usztywniane kimono";

                    textBoxUmiejetnosc1.Text = "Wysokie wykształcenie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Flisak")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "Kimono";

                    textBoxUmiejetnosc1.Text = "Nurkowanie";
                }
                else if (comboBoxArchetyp.SelectedItem.ToString() == "Niestandardowy")
                {
                    comboBoxBronieNazwa1.SelectedItem = "";
                    comboBoxBronieNazwa2.SelectedItem = "";
                    comboBoxBronieNazwa3.SelectedItem = "";

                    comboBoxPancerzNazwa.SelectedItem = "";

                    textBoxUmiejetnosc1.Text = "";
                }

                if (comboBoxArchetyp.SelectedItem.ToString() != "Ninja" && textBoxPrzedmiot1.Text == "Shuriken x10")
                {
                    textBoxPrzedmiot1.Text = "";
                    textBoxWartoscPrzedmiotu1.Text = "";
                }
                if (comboBoxArchetyp.SelectedItem.ToString() != "Złodziej" && textBoxPrzedmiot1.Text == "Kunai x5")
                {
                    textBoxPrzedmiot1.Text = "";
                    textBoxWartoscPrzedmiotu1.Text = "";
                }
            }
        }

        private void comboBoxBronieNazwa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox selectedComboBox)
            {
                switch (selectedComboBox.Name)
                {
                    case "comboBoxBronieNazwa1":
                        // Pobiera nazwę wybraną z ComboBox
                        string selectedName1 = comboBoxBronieNazwa1.SelectedItem.ToString();

                        // Znajduje obiekt odpowiadający wybranej nazwie
                        Item selectedItem1 = items.FirstOrDefault(item => item.Nazwa == selectedName1);

                        if (selectedItem1 != null && menuOpcjeAutouzupelnianie.Checked)
                        {
                            // Aktualizuje wartości w polach tekstowych
                            textBoxObrazeniaBroni1.Text = selectedItem1.Obrazenia;
                            textBoxTypBroni1.Text = selectedItem1.Typ;
                            textBoxWartoscBroni1.Text = selectedItem1.Wartosc.ToString();
                            textBoxZasiegBroni1.Text = selectedItem1.Zasieg;
                        }

                        if (selectedName1 == "Niestandardowa")
                        {
                            textBoxBroniePodNazwa1.Enabled = true;
                            textBoxObrazeniaBroni1.Clear();
                            textBoxTypBroni1.Clear();
                            textBoxWartoscBroni1.Clear();
                            textBoxZasiegBroni1.Clear();
                        }
                        else
                        {
                            textBoxBroniePodNazwa1.Enabled = false;
                            textBoxBroniePodNazwa1.Clear();
                        }

                        if (selectedName1 == "")
                        {
                            textBoxObrazeniaBroni1.Enabled = false;
                            textBoxTypBroni1.Enabled = false;
                            textBoxWartoscBroni1.Enabled = false;
                            textBoxZasiegBroni1.Enabled = false;
                        }
                        else
                        {
                            textBoxObrazeniaBroni1.Enabled = true;
                            textBoxTypBroni1.Enabled = true;
                            textBoxWartoscBroni1.Enabled = true;
                            textBoxZasiegBroni1.Enabled = true;
                        }
                        break;

                    case "comboBoxBronieNazwa2":
                        // Pobiera nazwę wybraną z ComboBox
                        string selectedName2 = comboBoxBronieNazwa2.SelectedItem.ToString();

                        // Znajduje obiekt odpowiadający wybranej nazwie
                        Item selectedItem2 = items.FirstOrDefault(item => item.Nazwa == selectedName2);

                        if (selectedItem2 != null && menuOpcjeAutouzupelnianie.Checked)
                        {
                            // Aktualizuje wartości w polach tekstowych
                            textBoxObrazeniaBroni2.Text = selectedItem2.Obrazenia;
                            textBoxTypBroni2.Text = selectedItem2.Typ;
                            textBoxWartoscBroni2.Text = selectedItem2.Wartosc.ToString();
                            textBoxZasiegBroni2.Text = selectedItem2.Zasieg;
                        }

                        if (selectedName2 == "Niestandardowa")
                        {
                            textBoxBroniePodNazwa2.Enabled = true;
                            textBoxObrazeniaBroni2.Clear();
                            textBoxTypBroni2.Clear();
                            textBoxWartoscBroni2.Clear();
                            textBoxZasiegBroni2.Clear();
                        }
                        else
                        {
                            textBoxBroniePodNazwa2.Enabled = false;
                            textBoxBroniePodNazwa2.Clear();
                        }

                        if (selectedName2 == "" && menuOpcjeAutouzupelnianie.Checked)
                        {
                            textBoxObrazeniaBroni2.Enabled = false;
                            textBoxTypBroni2.Enabled = false;
                            textBoxWartoscBroni2.Enabled = false;
                            textBoxZasiegBroni2.Enabled = false;
                        }
                        else
                        {
                            textBoxObrazeniaBroni2.Enabled = true;
                            textBoxTypBroni2.Enabled = true;
                            textBoxWartoscBroni2.Enabled = true;
                            textBoxZasiegBroni2.Enabled = true;
                        }
                        break;

                    case "comboBoxBronieNazwa3":
                        // Pobiera nazwę wybraną z ComboBox
                        string selectedName3 = comboBoxBronieNazwa3.SelectedItem.ToString();

                        // Znajduje obiekt odpowiadający wybranej nazwie
                        Item selectedItem3 = items.FirstOrDefault(item => item.Nazwa == selectedName3);

                        if (selectedItem3 != null && menuOpcjeAutouzupelnianie.Checked)
                        {
                            // Aktualizuje wartości w polach tekstowych
                            textBoxObrazeniaBroni3.Text = selectedItem3.Obrazenia;
                            textBoxTypBroni3.Text = selectedItem3.Typ;
                            textBoxWartoscBroni3.Text = selectedItem3.Wartosc.ToString();
                            textBoxZasiegBroni3.Text = selectedItem3.Zasieg;
                        }

                        if (selectedName3 == "Niestandardowa")
                        {
                            textBoxBroniePodNazwa3.Enabled = true;
                            textBoxObrazeniaBroni3.Clear();
                            textBoxTypBroni3.Clear();
                            textBoxWartoscBroni3.Clear();
                            textBoxZasiegBroni3.Clear();
                        }
                        else
                        {
                            textBoxBroniePodNazwa3.Enabled = false;
                            textBoxBroniePodNazwa3.Clear();
                        }

                        if (selectedName3 == "")
                        {
                            textBoxObrazeniaBroni3.Enabled = false;
                            textBoxTypBroni3.Enabled = false;
                            textBoxWartoscBroni3.Enabled = false;
                            textBoxZasiegBroni3.Enabled = false;
                        }
                        else
                        {
                            textBoxObrazeniaBroni3.Enabled = true;
                            textBoxTypBroni3.Enabled = true;
                            textBoxWartoscBroni3.Enabled = true;
                            textBoxZasiegBroni3.Enabled = true;
                        }
                        break;
                }
            }

        }

        private void comboBoxPancerzNazwa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pobiera nazwę wybraną z ComboBox
            string selectedName = comboBoxPancerzNazwa.SelectedItem.ToString();

            // Znajduje obiekt odpowiadający wybranej nazwie
            Armor selectedArmor = armors.FirstOrDefault(Armor => Armor.Nazwa == selectedName);

            if (selectedArmor != null && menuOpcjeAutouzupelnianie.Checked)
            {
                // Aktualizacja wartości w polach tekstowych
                textBoxWTPancerza.Text = selectedArmor.WT;
                textBoxTypPancerza.Text = selectedArmor.Typ;
                textBoxWartoscPancerza.Text = selectedArmor.Wartosc.ToString();
            }

            if (selectedName == "Niestandardowy")
            {
                textBoxPancerzPodNazwa.Enabled = true;
                textBoxWTPancerza.Clear();
                textBoxTypPancerza.Clear();
                textBoxWartoscPancerza.Clear();
            }
            else
            {
                textBoxPancerzPodNazwa.Enabled = false;
                textBoxPancerzPodNazwa.Clear();
            }

            if (selectedName == "")
            {
                textBoxWTPancerza.Enabled = false;
                textBoxTypPancerza.Enabled = false;
                textBoxWartoscPancerza.Enabled = false;
            }
            else
            {
                textBoxWTPancerza.Enabled = true;
                textBoxTypPancerza.Enabled = true;
                textBoxWartoscPancerza.Enabled = true;
            }
        }

        private void FormKarta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisać zmiany przed zamknięciem aplikacji?", "Niezapisane zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SaveToFile(); // Zapisanie pliku
                    if (isModified)
                        e.Cancel = true; // Jeśli zapis się nie uda, anuluje zamknięcie
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Anuluje zamknięcie
                }
                // Jeśli użytkownik wybierze "Nie", zamykanie jest kontynuowane
            }
        }

        private void NewFile()
        {
            // Jeśli plik jest zmodyfikowany, zapytaj użytkownika
            if (isModified)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisać zmiany przed utworzeniem nowego pliku?", "Niezapisane zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SaveToFile(); // Zapisanie pliku
                    if (isModified)
                        return; // Jeśli zapisanie się nie udało, anuluje operację
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Anuluje operację tworzenia nowego pliku
                }
            }

            // Resetowanie stanu aplikacji
            currentFilePath = null; // Brak aktywnego pliku
            karty.SelectedTab = karty.TabPages["tabPagePostac"];
            ClearAllControls(this); // Wyczyszczenie wszystkich kontrolek
            numericZdrowie.Value = 0;
            numericZdrowie.Maximum = 0;
            labelMaxZdrowie.Text = "0";

            numericOdpornosc.Value = 0;
            numericOdpornosc.Maximum = 0;
            labelMaxOdpornosc.Text = "0";

            numericMana.Value = 0;
            numericMana.Maximum = 0;
            labelMaxMana.Text = "0";

            pictureBoxPortret.Image = Properties.Resources.portret_transparent;
            selectedImage = "portret_transparent";
            customImageLocation = "";

            textBoxPW.ReadOnly = true;
            textBoxODP.ReadOnly = true;
            textBoxMW.ReadOnly = true;
            textBoxMD.ReadOnly = true;
            textBoxI.ReadOnly = true;
            textBoxMana.ReadOnly = true;

            menuOpcjeAutouzupelnianie.Checked = true;
            isModified = false; // Dane niezmodyfikowane
            UpdateTitle(); // Zaktualizowanie tytułu okna
        }

        private void LoadFromFile()
        {
            //bool fastLoad = false;

            //if (args.Length > 0 && File.Exists(args[0]))
            //{
            //    fastLoad = true;
            //}

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Godai|*.godai";
                openFileDialog.Title = "Otwórz plik";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    bool niestandardowyPortret = false;
                    string nazwaZasobuPortretu = "";

                    using (StreamReader reader = new StreamReader(currentFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split('@');
                            if (parts.Length == 3)
                            {
                                string type = parts[0];
                                string name = parts[1];
                                string value = parts[2];

                                if (type == "Menu")
                                {
                                    if (name == "autouzupelnianie")
                                        menuOpcjeAutouzupelnianie.Checked = bool.Parse(value);
                                }

                                if (type == "Portret" && name == "selectedImage" && value == "niestandardowy")
                                {
                                    niestandardowyPortret = true;
                                }
                                else if (type == "Portret" && name == "selectedImage" && value != "niestandardowy")
                                {
                                    niestandardowyPortret = false;
                                    nazwaZasobuPortretu = value;
                                }

                                Control control = GetAllControls(this).FirstOrDefault(c => c.Name == name);
                                if (control != null)
                                {
                                    switch (type)
                                    {
                                        case "TextBox":
                                            if (control is TextBox textBox)
                                            {
                                                textBox.Text = value;
                                            }
                                            break;

                                        case "ComboBox":
                                            if (control is ComboBox comboBox)
                                            {
                                                comboBox.SelectedIndexChanged -= comboBoxBronieNazwa_SelectedIndexChanged;
                                                comboBox.SelectedItem = value;
                                                comboBox.SelectedIndexChanged += comboBoxBronieNazwa_SelectedIndexChanged;
                                            }
                                            break;

                                        case "RadioButton":
                                            if (control is RadioButton radioButton)
                                            {
                                                radioButton.Checked = bool.Parse(value);
                                            }
                                            break;

                                        case "NumericUpDown":
                                            if (control is NumericUpDown numericUpDown)
                                            {
                                                if (numericUpDown.Name == "numericMana" || numericUpDown.Name == "numericZdrowie" || numericUpDown.Name == "numericOdpornosc")
                                                {
                                                    numericUpDown.Maximum = Convert.ToInt32(value);
                                                    numericUpDown.Value = Convert.ToInt32(value);
                                                }
                                                else
                                                {
                                                    numericUpDown.Value = Convert.ToInt32(value);
                                                }
                                            }
                                            break;

                                        case "PictureBox":
                                            if (control is PictureBox pictureBox)
                                            {
                                                if (pictureBox.Name == "pictureBoxPortret")
                                                {
                                                    customImageLocation = value;
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    if (menuOpcjeAutouzupelnianie.Checked)
                    {

                        textBoxPW.ReadOnly = true;
                        textBoxODP.ReadOnly = true;
                        textBoxMW.ReadOnly = true;
                        textBoxMD.ReadOnly = true;
                        textBoxI.ReadOnly = true;
                        textBoxMana.ReadOnly = true;
                    }
                    else
                    {
                        textBoxPW.ReadOnly = false;
                        textBoxODP.ReadOnly = false;
                        textBoxMW.ReadOnly = false;
                        textBoxMD.ReadOnly = false;
                        textBoxI.ReadOnly = false;
                        textBoxMana.ReadOnly = false;
                    }

                    numericZdrowie.Maximum = Convert.ToInt32(labelMaxZdrowie.Text);
                    numericMana.Maximum = Convert.ToInt32(labelMaxMana.Text);

                    if (comboBoxBronieNazwa1.Text == "Niestandardowa")
                        textBoxBroniePodNazwa1.Enabled = true;
                    else
                        textBoxBroniePodNazwa1.Enabled = false;

                    if (comboBoxBronieNazwa2.Text == "Niestandardowa")
                        textBoxBroniePodNazwa2.Enabled = true;
                    else
                        textBoxBroniePodNazwa2.Enabled = false;

                    if (comboBoxBronieNazwa3.Text == "Niestandardowa")
                        textBoxBroniePodNazwa3.Enabled = true;
                    else
                        textBoxBroniePodNazwa3.Enabled = false;

                    if (comboBoxPancerzNazwa.Text == "Niestandardowy")
                        textBoxPancerzPodNazwa.Enabled = true;
                    else
                        textBoxPancerzPodNazwa.Enabled = false;


                    if (comboBoxBronieNazwa1.Text == "")
                    {
                        textBoxObrazeniaBroni1.Enabled = false;
                        textBoxTypBroni1.Enabled = false;
                        textBoxWartoscBroni1.Enabled = false;
                        textBoxZasiegBroni1.Enabled = false;
                    }
                    else
                    {
                        textBoxObrazeniaBroni1.Enabled = true;
                        textBoxTypBroni1.Enabled = true;
                        textBoxWartoscBroni1.Enabled = true;
                        textBoxZasiegBroni1.Enabled = true;
                    }

                    if (comboBoxBronieNazwa2.Text == "")
                    {
                        textBoxObrazeniaBroni2.Enabled = false;
                        textBoxTypBroni2.Enabled = false;
                        textBoxWartoscBroni2.Enabled = false;
                        textBoxZasiegBroni2.Enabled = false;
                    }
                    else
                    {
                        textBoxObrazeniaBroni2.Enabled = true;
                        textBoxTypBroni2.Enabled = true;
                        textBoxWartoscBroni2.Enabled = true;
                        textBoxZasiegBroni2.Enabled = true;
                    }

                    if (comboBoxBronieNazwa3.Text == "")
                    {
                        textBoxObrazeniaBroni3.Enabled = false;
                        textBoxTypBroni3.Enabled = false;
                        textBoxWartoscBroni3.Enabled = false;
                        textBoxZasiegBroni3.Enabled = false;
                    }
                    else
                    {
                        textBoxObrazeniaBroni3.Enabled = true;
                        textBoxTypBroni3.Enabled = true;
                        textBoxWartoscBroni3.Enabled = true;
                        textBoxZasiegBroni3.Enabled = true;
                    }

                    if (comboBoxPancerzNazwa.Text == "")
                    {
                        textBoxWTPancerza.Enabled = false;
                        textBoxTypPancerza.Enabled = false;
                        textBoxWartoscPancerza.Enabled = false;
                    }
                    else
                    {
                        textBoxWTPancerza.Enabled = true;
                        textBoxTypPancerza.Enabled = true;
                        textBoxWartoscPancerza.Enabled = true;
                    }

                    if (niestandardowyPortret)
                    {
                        pictureBoxPortret.ImageLocation = customImageLocation;
                        selectedImage = "niestandardowy";
                    }
                    else
                    {
                        if (nazwaZasobuPortretu == "portret_transparent")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_transparent;
                            selectedImage = "portret_transparent";
                        }

                        else if (nazwaZasobuPortretu == "portret_mnich_1")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_mnich_1;
                            selectedImage = "portret_mnich_1";
                        }
                        else if (nazwaZasobuPortretu == "portret_mnich_2")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_mnich_2;
                            selectedImage = "portret_mnich_2";
                        }
                        else if (nazwaZasobuPortretu == "portret_mnich_3")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_mnich_3;
                            selectedImage = "portret_mnich_3";
                        }
                        else if (nazwaZasobuPortretu == "portret_mnich_4")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_mnich_4;
                            selectedImage = "portret_mnich_4";
                        }
                        else if (nazwaZasobuPortretu == "portret_mnich_5")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_mnich_5;
                            selectedImage = "portret_mnich_5";
                        }

                        else if (nazwaZasobuPortretu == "portret_samuraj_1")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_samuraj_1;
                            selectedImage = "portret_samuraj_1";
                        }
                        else if (nazwaZasobuPortretu == "portret_samuraj_2")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_samuraj_2;
                            selectedImage = "portret_samuraj_2";
                        }
                        else if (nazwaZasobuPortretu == "portret_samuraj_3")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_samuraj_3;
                            selectedImage = "portret_samuraj_3";
                        }

                        else if (nazwaZasobuPortretu == "portret_ronin_1")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_ronin_1;
                            selectedImage = "portret_ronin_1";
                        }
                        else if (nazwaZasobuPortretu == "portret_ronin_2")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_ronin_2;
                            selectedImage = "portret_ronin_2";
                        }

                        else if (nazwaZasobuPortretu == "portret_strzelec_1")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_strzelec_1;
                            selectedImage = "portret_strzelec_1";
                        }

                        else if (nazwaZasobuPortretu == "portret_ninja_1")
                        {
                            pictureBoxPortret.Image = Properties.Resources.portret_ninja_1;
                            selectedImage = "portret_ninja_1";
                        }
                    }

                    isModified = false; // Resetowanie stanu modyfikacji
                    UpdateTitle();
                }
            }
        }

        private void SaveToFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Godai|*.godai";
                    saveFileDialog.Title = "Zapisz jako";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentFilePath))
            {
                using (StreamWriter writer = new StreamWriter(currentFilePath))
                {
                    writer.WriteLine($"Menu@autouzupelnianie@{menuOpcjeAutouzupelnianie.Checked}");
                    writer.WriteLine($"Portret@selectedImage@{selectedImage}");

                    foreach (Control control in GetAllControls(this))
                    {
                        if (control is TextBox textBox)
                        {
                            writer.WriteLine($"TextBox@{control.Name}@{textBox.Text}");
                        }
                        else if (control is ComboBox comboBox)
                        {
                            writer.WriteLine($"ComboBox@{control.Name}@{comboBox.SelectedItem}");
                        }
                        else if (control is RadioButton radioButton)
                        {
                            writer.WriteLine($"RadioButton@{control.Name}@{radioButton.Checked}");
                        }
                        else if (control is NumericUpDown numericUpDown)
                        {
                            writer.WriteLine($"NumericUpDown@{control.Name}@{numericUpDown.Value}");
                        }
                        else if (control is PictureBox pictureBox)
                        {
                            if (pictureBox.ImageLocation != null)
                                writer.WriteLine($"PictureBox@{control.Name}@{pictureBox.ImageLocation}");
                        }
                    }
                }

                isModified = false; // Resetowanie stanu modyfikacji
                UpdateTitle();
            }
        }

        private void SaveToFileAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Godai|*.godai";
                saveFileDialog.Title = "Zapisz jako";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(currentFilePath))
                    {
                        writer.WriteLine($"Menu@autouzupelnianie@{menuOpcjeAutouzupelnianie.Checked}");
                        writer.WriteLine($"Portret@selectedImage@{selectedImage}");

                        foreach (Control control in GetAllControls(this))
                        {
                            if (control is TextBox textBox)
                            {
                                writer.WriteLine($"TextBox@{control.Name}@{textBox.Text}");
                            }
                            else if (control is ComboBox comboBox)
                            {
                                writer.WriteLine($"ComboBox@{control.Name}@{comboBox.SelectedItem}");
                            }
                            else if (control is RadioButton radioButton)
                            {
                                writer.WriteLine($"RadioButton@{control.Name}@{radioButton.Checked}");
                            }
                            else if (control is NumericUpDown numericUpDown)
                            {
                                writer.WriteLine($"NumericUpDown@{control.Name}@{numericUpDown.Value}");
                            }
                            else if (control is PictureBox pictureBox)
                            {
                                if (pictureBox.ImageLocation != null)
                                    writer.WriteLine($"PictureBox@{control.Name}@{pictureBox.ImageLocation}");
                            }
                        }
                    }

                    isModified = false; // Resetowanie stanu modyfikacji
                    UpdateTitle();
                }
            }
        }

        public void UpdateTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "Bez tytułu" : Path.GetFileNameWithoutExtension(currentFilePath);
            string modifiedIndicator = isModified ? "*" : "";
            this.Text = $"{modifiedIndicator}{fileName} - Godai";
        }

        private void RegisterControlEvents(Control parent)
        {
            foreach (Control control in GetAllControls(parent))
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += (s, e) => { isModified = true; UpdateTitle(); };
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += (s, e) => { isModified = true; UpdateTitle(); };
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.ValueChanged += (s, e) => { isModified = true; UpdateTitle(); };
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += (s, e) => { isModified = true; UpdateTitle(); };
                }
            }
            menuOpcjeAutouzupelnianie.CheckedChanged += (s, e) => { isModified = true; UpdateTitle(); };
        }

        // Funkcja pomocnicza do rekursywnego przeszukiwania kontrolek
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;

                foreach (Control child in GetAllControls(control))
                {
                    yield return child;
                }
            }
        }

        // Funkcja czyszcząca wszystkie kontrolki na formularzu
        private void ClearAllControls(Control parent)
        {
            foreach (Control control in GetAllControls(parent))
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    if (numericUpDown.Name == "numericPoziom")
                    {
                        numericUpDown.Value = 1;
                    }
                    else
                    {
                        numericUpDown.Value = 0;
                    }
                }
                else if (control is PictureBox pictureBox)
                {
                    pictureBox.ImageLocation = null;
                    pictureBox.Image = null;
                }
            }
        }

        private void menuEkwipunek_Click(object sender, EventArgs e)
        {
            FormEkwipunek formEkwipunek = new FormEkwipunek();
            formEkwipunek.Show();
        }
    }
}