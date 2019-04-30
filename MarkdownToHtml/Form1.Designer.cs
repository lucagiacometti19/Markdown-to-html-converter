namespace MarkdownToHtml
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pulisciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HtmlFormattatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxMarkdown = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxHtml = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.visualizzaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriToolStripMenuItem,
            this.salvaToolStripMenuItem,
            this.convertiToolStripMenuItem,
            this.pulisciToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Image = global::MarkdownToHtml.Properties.Resources.ASX_Open_blue_16x;
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.apriToolStripMenuItem.Text = "Apri file Markdown";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Image = global::MarkdownToHtml.Properties.Resources.Save_16x;
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.salvaToolStripMenuItem.Text = "Salva file HTML";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // convertiToolStripMenuItem
            // 
            this.convertiToolStripMenuItem.Image = global::MarkdownToHtml.Properties.Resources.Convert_16x;
            this.convertiToolStripMenuItem.Name = "convertiToolStripMenuItem";
            this.convertiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertiToolStripMenuItem.Text = "Converti";
            this.convertiToolStripMenuItem.Click += new System.EventHandler(this.convertiToolStripMenuItem_Click);
            // 
            // pulisciToolStripMenuItem
            // 
            this.pulisciToolStripMenuItem.Image = global::MarkdownToHtml.Properties.Resources.ClearWindowContent_16x;
            this.pulisciToolStripMenuItem.Name = "pulisciToolStripMenuItem";
            this.pulisciToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pulisciToolStripMenuItem.Text = "Pulisci";
            this.pulisciToolStripMenuItem.Click += new System.EventHandler(this.pulisciToolStripMenuItem_Click);
            // 
            // visualizzaToolStripMenuItem
            // 
            this.visualizzaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HtmlFormattatoToolStripMenuItem});
            this.visualizzaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.visualizzaToolStripMenuItem.Name = "visualizzaToolStripMenuItem";
            this.visualizzaToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.visualizzaToolStripMenuItem.Text = "Visualizza";
            // 
            // HtmlFormattatoToolStripMenuItem
            // 
            this.HtmlFormattatoToolStripMenuItem.Image = global::MarkdownToHtml.Properties.Resources.HTMLFile_16x;
            this.HtmlFormattatoToolStripMenuItem.Name = "HtmlFormattatoToolStripMenuItem";
            this.HtmlFormattatoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.HtmlFormattatoToolStripMenuItem.Text = "HTML";
            this.HtmlFormattatoToolStripMenuItem.Click += new System.EventHandler(this.hTMLFormattatoToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxMarkdown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxHtml);
            this.splitContainer1.Size = new System.Drawing.Size(691, 278);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(622, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Markdown";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxMarkdown
            // 
            this.richTextBoxMarkdown.BackColor = System.Drawing.Color.White;
            this.richTextBoxMarkdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMarkdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMarkdown.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxMarkdown.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxMarkdown.Name = "richTextBoxMarkdown";
            this.richTextBoxMarkdown.Size = new System.Drawing.Size(691, 138);
            this.richTextBoxMarkdown.TabIndex = 0;
            this.richTextBoxMarkdown.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(621, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "HTML";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxHtml
            // 
            this.richTextBoxHtml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBoxHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxHtml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxHtml.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxHtml.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxHtml.Name = "richTextBoxHtml";
            this.richTextBoxHtml.ReadOnly = true;
            this.richTextBoxHtml.Size = new System.Drawing.Size(691, 136);
            this.richTextBoxHtml.TabIndex = 3;
            this.richTextBoxHtml.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(691, 302);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Markdown to Html";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HtmlFormattatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertiToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBoxMarkdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem pulisciToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxHtml;
    }
}

