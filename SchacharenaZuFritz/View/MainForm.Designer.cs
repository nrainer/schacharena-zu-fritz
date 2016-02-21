namespace SchacharenaZuFritz.View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbx_Schacharena = new System.Windows.Forms.TextBox();
            this.tbx_Fritz = new System.Windows.Forms.TextBox();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Paste = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_ConvertAfterPasting = new System.Windows.Forms.Button();
            this.btn_do_all = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_Schacharena
            // 
            this.tbx_Schacharena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Schacharena.Location = new System.Drawing.Point(14, 12);
            this.tbx_Schacharena.Multiline = true;
            this.tbx_Schacharena.Name = "tbx_Schacharena";
            this.tbx_Schacharena.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Schacharena.Size = new System.Drawing.Size(911, 218);
            this.tbx_Schacharena.TabIndex = 0;
            this.tbx_Schacharena.TextChanged += new System.EventHandler(this.tbx_Schacharena_TextChanged);
            this.tbx_Schacharena.MouseEnter += new System.EventHandler(this.tbx_Schacharena_MouseEnter);
            // 
            // tbx_Fritz
            // 
            this.tbx_Fritz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Fritz.Location = new System.Drawing.Point(14, 275);
            this.tbx_Fritz.Multiline = true;
            this.tbx_Fritz.Name = "tbx_Fritz";
            this.tbx_Fritz.ReadOnly = true;
            this.tbx_Fritz.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Fritz.Size = new System.Drawing.Size(911, 304);
            this.tbx_Fritz.TabIndex = 1;
            this.tbx_Fritz.TextChanged += new System.EventHandler(this.tbx_Fritz_TextChanged);
            this.tbx_Fritz.MouseEnter += new System.EventHandler(this.tbx_Fritz_MouseEnter);
            // 
            // btn_Convert
            // 
            this.btn_Convert.Enabled = false;
            this.btn_Convert.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Convert.Location = new System.Drawing.Point(14, 236);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(331, 33);
            this.btn_Convert.TabIndex = 2;
            this.btn_Convert.Text = "für Fritz umwandeln";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.Image = ((System.Drawing.Image)(resources.GetObject("btn_Copy.Image")));
            this.btn_Copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Copy.Location = new System.Drawing.Point(666, 333);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(210, 61);
            this.btn_Copy.TabIndex = 3;
            this.btn_Copy.Text = "kopieren";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Visible = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Paste
            // 
            this.btn_Paste.Image = ((System.Drawing.Image)(resources.GetObject("btn_Paste.Image")));
            this.btn_Paste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Paste.Location = new System.Drawing.Point(666, 51);
            this.btn_Paste.Name = "btn_Paste";
            this.btn_Paste.Size = new System.Drawing.Size(210, 61);
            this.btn_Paste.TabIndex = 4;
            this.btn_Paste.Text = "einfügen";
            this.btn_Paste.UseVisualStyleBackColor = true;
            this.btn_Paste.Visible = false;
            this.btn_Paste.Click += new System.EventHandler(this.btn_Paste_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_Clear.Image")));
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(666, 118);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(210, 61);
            this.btn_Clear.TabIndex = 5;
            this.btn_Clear.Text = "leeren";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Visible = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(666, 410);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(210, 61);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "in Datei speichern";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Visible = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pgn";
            this.saveFileDialog1.Filter = "PGN-Dateien|*.pgn";
            this.saveFileDialog1.Title = "Speichern unter...";
            // 
            // btn_ConvertAfterPasting
            // 
            this.btn_ConvertAfterPasting.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConvertAfterPasting.Location = new System.Drawing.Point(351, 236);
            this.btn_ConvertAfterPasting.Name = "btn_ConvertAfterPasting";
            this.btn_ConvertAfterPasting.Size = new System.Drawing.Size(331, 33);
            this.btn_ConvertAfterPasting.TabIndex = 7;
            this.btn_ConvertAfterPasting.Text = "einfügen, für Fritz umwandeln, kopieren";
            this.btn_ConvertAfterPasting.UseVisualStyleBackColor = true;
            this.btn_ConvertAfterPasting.Click += new System.EventHandler(this.btn_ConvertAfterPasting_Click);
            // 
            // btn_do_all
            // 
            this.btn_do_all.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_do_all.Location = new System.Drawing.Point(688, 236);
            this.btn_do_all.Name = "btn_do_all";
            this.btn_do_all.Size = new System.Drawing.Size(237, 33);
            this.btn_do_all.TabIndex = 8;
            this.btn_do_all.Text = "... und schließen";
            this.btn_do_all.UseVisualStyleBackColor = true;
            this.btn_do_all.Click += new System.EventHandler(this.btn_do_all_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_Convert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 591);
            this.Controls.Add(this.btn_do_all);
            this.Controls.Add(this.btn_ConvertAfterPasting);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Paste);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.tbx_Fritz);
            this.Controls.Add(this.tbx_Schacharena);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Schacharena -> Fritz";
            this.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_Schacharena;
        private System.Windows.Forms.TextBox tbx_Fritz;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Paste;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_ConvertAfterPasting;
        private System.Windows.Forms.Button btn_do_all;
    }
}

