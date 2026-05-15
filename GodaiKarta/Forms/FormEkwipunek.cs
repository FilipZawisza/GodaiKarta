using System;
using System.Windows.Forms;

namespace GodaiKarta
{
    public partial class FormEkwipunek : Form
    {
        private bool _isResizing = false;

        public FormEkwipunek()
        {
            InitializeComponent();

            //Optymalizacja podczas zmiany rozmiaru formularza
            this.ResizeBegin += Form_ResizeBegin;
            this.ResizeEnd += Form_ResizeEnd;
        }

        private void Form_ResizeBegin(object sender, EventArgs e)
        {
            _isResizing = true;
            ToggleControls(false); //Ukrywa wszystkie elementy podczas zmiany rozmiaru
        }

        private void Form_ResizeEnd(object sender, EventArgs e)
        {
            _isResizing = false;
            ToggleControls(true); //Pokazuje wszystkie elementy po zakończeniu zmiany rozmiaru
        }

        private void ToggleControls(bool visible)
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Visible = visible;
        }
    }
}