namespace TabGenApp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dMajorBtn = new System.Windows.Forms.Button();
            this.cMajorBtn = new System.Windows.Forms.Button();
            this.aBluesBtn = new System.Windows.Forms.Button();
            this.generateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scaleLbl = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BackBtn = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.b = new System.Windows.Forms.Button();
            this.bb = new System.Windows.Forms.Button();
            this.bbb = new System.Windows.Forms.Button();
            this.min10chbx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dMajorBtn
            // 
            this.dMajorBtn.Location = new System.Drawing.Point(12, 12);
            this.dMajorBtn.Name = "dMajorBtn";
            this.dMajorBtn.Size = new System.Drawing.Size(156, 23);
            this.dMajorBtn.TabIndex = 0;
            this.dMajorBtn.Text = "D DUR";
            this.dMajorBtn.UseVisualStyleBackColor = true;
            this.dMajorBtn.Click += new System.EventHandler(this.DMajorBtn_Click);
            // 
            // cMajorBtn
            // 
            this.cMajorBtn.Location = new System.Drawing.Point(12, 53);
            this.cMajorBtn.Name = "cMajorBtn";
            this.cMajorBtn.Size = new System.Drawing.Size(156, 23);
            this.cMajorBtn.TabIndex = 1;
            this.cMajorBtn.Text = "C DUR";
            this.cMajorBtn.UseVisualStyleBackColor = true;
            this.cMajorBtn.Click += new System.EventHandler(this.CMajorBtn_Click);
            // 
            // aBluesBtn
            // 
            this.aBluesBtn.Location = new System.Drawing.Point(12, 93);
            this.aBluesBtn.Name = "aBluesBtn";
            this.aBluesBtn.Size = new System.Drawing.Size(156, 23);
            this.aBluesBtn.TabIndex = 2;
            this.aBluesBtn.Text = "A BLUES";
            this.aBluesBtn.UseVisualStyleBackColor = true;
            this.aBluesBtn.Click += new System.EventHandler(this.ABluesBtn_Click);
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(15, 207);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(96, 53);
            this.generateBtn.TabIndex = 3;
            this.generateBtn.Text = "GENERUJ";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wybrana skala:";
            // 
            // scaleLbl
            // 
            this.scaleLbl.AutoSize = true;
            this.scaleLbl.Location = new System.Drawing.Point(111, 149);
            this.scaleLbl.Name = "scaleLbl";
            this.scaleLbl.Size = new System.Drawing.Size(0, 13);
            this.scaleLbl.TabIndex = 5;
            this.scaleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scaleLbl.UseMnemonic = false;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(132, 207);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(98, 53);
            this.nextBtn.TabIndex = 6;
            this.nextBtn.Text = "NASTĘPNE 4";
            this.nextBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(249, 207);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(98, 53);
            this.BackBtn.TabIndex = 7;
            this.BackBtn.Text = "COFNIJ 4";
            this.BackBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click_1);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Lucida Console", 14F);
            this.richTextBox2.Location = new System.Drawing.Point(371, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(599, 150);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(191, 12);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(156, 23);
            this.b.TabIndex = 10;
            this.b.Text = "skala 4";
            this.b.UseVisualStyleBackColor = true;
            // 
            // bb
            // 
            this.bb.Location = new System.Drawing.Point(191, 53);
            this.bb.Name = "bb";
            this.bb.Size = new System.Drawing.Size(156, 23);
            this.bb.TabIndex = 11;
            this.bb.Text = "skala 5";
            this.bb.UseVisualStyleBackColor = true;
            // 
            // bbb
            // 
            this.bbb.Location = new System.Drawing.Point(191, 93);
            this.bbb.Name = "bbb";
            this.bbb.Size = new System.Drawing.Size(156, 23);
            this.bbb.TabIndex = 12;
            this.bbb.Text = "skala 6";
            this.bbb.UseVisualStyleBackColor = true;
            // 
            // min10chbx
            // 
            this.min10chbx.AutoSize = true;
            this.min10chbx.Location = new System.Drawing.Point(371, 226);
            this.min10chbx.Name = "min10chbx";
            this.min10chbx.Size = new System.Drawing.Size(58, 17);
            this.min10chbx.TabIndex = 14;
            this.min10chbx.Text = "Min 10";
            this.min10chbx.UseVisualStyleBackColor = true;
            this.min10chbx.CheckedChanged += new System.EventHandler(this.Min10chbx_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 297);
            this.Controls.Add(this.min10chbx);
            this.Controls.Add(this.bbb);
            this.Controls.Add(this.bb);
            this.Controls.Add(this.b);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.scaleLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.aBluesBtn);
            this.Controls.Add(this.cMajorBtn);
            this.Controls.Add(this.dMajorBtn);
            this.Name = "Form1";
            this.Text = "TabGen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dMajorBtn;
        private System.Windows.Forms.Button cMajorBtn;
        private System.Windows.Forms.Button aBluesBtn;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scaleLbl;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.Button bb;
        private System.Windows.Forms.Button bbb;
        private System.Windows.Forms.CheckBox min10chbx;
    }
}

