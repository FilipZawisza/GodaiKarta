namespace GodaiKarta
{
    partial class FormDziennikZmian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDziennikZmian));
            this.groupBoxDziennikZmian = new System.Windows.Forms.GroupBox();
            this.labelOpisZmian = new System.Windows.Forms.Label();
            this.groupBoxDziennikZmian.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDziennikZmian
            // 
            this.groupBoxDziennikZmian.Controls.Add(this.labelOpisZmian);
            this.groupBoxDziennikZmian.Font = new System.Drawing.Font("Century", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxDziennikZmian.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDziennikZmian.Name = "groupBoxDziennikZmian";
            this.groupBoxDziennikZmian.Size = new System.Drawing.Size(610, 337);
            this.groupBoxDziennikZmian.TabIndex = 0;
            this.groupBoxDziennikZmian.TabStop = false;
            this.groupBoxDziennikZmian.Text = "Nowości w wersji 1.4";
            // 
            // labelOpisZmian
            // 
            this.labelOpisZmian.AutoSize = true;
            this.labelOpisZmian.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOpisZmian.Location = new System.Drawing.Point(39, 46);
            this.labelOpisZmian.Name = "labelOpisZmian";
            this.labelOpisZmian.Size = new System.Drawing.Size(232, 18);
            this.labelOpisZmian.TabIndex = 1;
            this.labelOpisZmian.Text = "- Oficjalne wydanie open-source";
            // 
            // FormDziennikZmian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.groupBoxDziennikZmian);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDziennikZmian";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dziennik zmian";
            this.groupBoxDziennikZmian.ResumeLayout(false);
            this.groupBoxDziennikZmian.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDziennikZmian;
        private System.Windows.Forms.Label labelOpisZmian;
    }
}