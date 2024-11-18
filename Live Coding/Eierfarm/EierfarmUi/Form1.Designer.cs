namespace EierfarmUi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxTiere = new ComboBox();
            this.btnNeuesHuhn = new Button();
            this.btnNeueGans = new Button();
            this.pgdTier = new PropertyGrid();
            this.btnEiLegen = new Button();
            this.btnFuettern = new Button();
            this.btnSpeichern = new Button();
            this.btnLaden = new Button();
            this.btnSchnabeltier = new Button();
            this.SuspendLayout();
            // 
            // cbxTiere
            // 
            this.cbxTiere.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cbxTiere.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxTiere.FormattingEnabled = true;
            this.cbxTiere.Location = new Point(66, 10);
            this.cbxTiere.Margin = new Padding(3, 2, 3, 2);
            this.cbxTiere.Name = "cbxTiere";
            this.cbxTiere.Size = new Size(155, 23);
            this.cbxTiere.TabIndex = 0;
            this.cbxTiere.SelectedIndexChanged += this.cbxTiere_SelectedIndexChanged;
            // 
            // btnNeuesHuhn
            // 
            this.btnNeuesHuhn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnNeuesHuhn.Location = new Point(227, 35);
            this.btnNeuesHuhn.Margin = new Padding(3, 2, 3, 2);
            this.btnNeuesHuhn.Name = "btnNeuesHuhn";
            this.btnNeuesHuhn.Size = new Size(82, 22);
            this.btnNeuesHuhn.TabIndex = 1;
            this.btnNeuesHuhn.Text = "Huhn";
            this.btnNeuesHuhn.UseVisualStyleBackColor = true;
            this.btnNeuesHuhn.Click += this.btnNeuesHuhn_Click;
            // 
            // btnNeueGans
            // 
            this.btnNeueGans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnNeueGans.Location = new Point(227, 9);
            this.btnNeueGans.Margin = new Padding(3, 2, 3, 2);
            this.btnNeueGans.Name = "btnNeueGans";
            this.btnNeueGans.Size = new Size(82, 22);
            this.btnNeueGans.TabIndex = 2;
            this.btnNeueGans.Text = "Gans";
            this.btnNeueGans.UseVisualStyleBackColor = true;
            this.btnNeueGans.Click += this.btnNeueGans_Click;
            // 
            // pgdTier
            // 
            this.pgdTier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.pgdTier.HelpVisible = false;
            this.pgdTier.Location = new Point(66, 35);
            this.pgdTier.Margin = new Padding(3, 2, 3, 2);
            this.pgdTier.Name = "pgdTier";
            this.pgdTier.Size = new Size(155, 217);
            this.pgdTier.TabIndex = 3;
            // 
            // btnEiLegen
            // 
            this.btnEiLegen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnEiLegen.Location = new Point(227, 159);
            this.btnEiLegen.Margin = new Padding(3, 2, 3, 2);
            this.btnEiLegen.Name = "btnEiLegen";
            this.btnEiLegen.Size = new Size(82, 22);
            this.btnEiLegen.TabIndex = 4;
            this.btnEiLegen.Text = "Ei legen";
            this.btnEiLegen.UseVisualStyleBackColor = true;
            this.btnEiLegen.Click += this.btnEiLegen_Click;
            // 
            // btnFuettern
            // 
            this.btnFuettern.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnFuettern.Location = new Point(227, 132);
            this.btnFuettern.Margin = new Padding(3, 2, 3, 2);
            this.btnFuettern.Name = "btnFuettern";
            this.btnFuettern.Size = new Size(82, 22);
            this.btnFuettern.TabIndex = 5;
            this.btnFuettern.Text = "Füttern";
            this.btnFuettern.UseVisualStyleBackColor = true;
            this.btnFuettern.Click += this.btnFuettern_Click;
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new Point(232, 228);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new Size(75, 23);
            this.btnSpeichern.TabIndex = 6;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += this.btnSpeichern_Click;
            // 
            // btnLaden
            // 
            this.btnLaden.Location = new Point(232, 199);
            this.btnLaden.Name = "btnLaden";
            this.btnLaden.Size = new Size(75, 23);
            this.btnLaden.TabIndex = 7;
            this.btnLaden.Text = "Laden";
            this.btnLaden.UseVisualStyleBackColor = true;
            this.btnLaden.Click += this.btnLaden_Click;
            // 
            // btnSchnabeltier
            // 
            this.btnSchnabeltier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSchnabeltier.Location = new Point(227, 61);
            this.btnSchnabeltier.Margin = new Padding(3, 2, 3, 2);
            this.btnSchnabeltier.Name = "btnSchnabeltier";
            this.btnSchnabeltier.Size = new Size(82, 22);
            this.btnSchnabeltier.TabIndex = 8;
            this.btnSchnabeltier.Text = "Schnabeltier";
            this.btnSchnabeltier.UseVisualStyleBackColor = true;
            this.btnSchnabeltier.Click += this.btnSchnabeltier_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(319, 273);
            this.Controls.Add(this.btnSchnabeltier);
            this.Controls.Add(this.btnLaden);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.btnFuettern);
            this.Controls.Add(this.btnEiLegen);
            this.Controls.Add(this.pgdTier);
            this.Controls.Add(this.btnNeueGans);
            this.Controls.Add(this.btnNeuesHuhn);
            this.Controls.Add(this.cbxTiere);
            this.Margin = new Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private ComboBox cbxTiere;
        private Button btnNeuesHuhn;
        private Button btnNeueGans;
        private PropertyGrid pgdTier;
        private Button btnEiLegen;
        private Button btnFuettern;
        private Button btnSpeichern;
        private Button btnLaden;
        private Button btnSchnabeltier;
    }
}
