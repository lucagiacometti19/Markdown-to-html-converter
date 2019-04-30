using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarkdownToHtml
{
    public partial class Form1 : Form
    {
        public Converter converter;
        public string markdownFormattedText;


        public Form1()
        {
            InitializeComponent();
            markdownFormattedText = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog save = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt", DefaultExt = "txt" })
                {
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, converter.Html);
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog { Filter = "Text Files (*.txt)|*.txt", DefaultExt = "txt" })
                {
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        markdownFormattedText = File.ReadAllText(open.FileName, Encoding.GetEncoding("iso-8859-1"));
                    }
                }
                richTextBoxMarkdown.Text = markdownFormattedText;
            }
            catch { }
        }

        private void hTMLFormattatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebBrowser form = new WebBrowser();
            form.Show(this);
        }

        private void convertiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                converter = new Converter(richTextBoxMarkdown.Text);
                converter.Convert();
                richTextBoxHtml.Text = converter.Html;
            }
            catch { }
        }

        private void pulisciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxMarkdown.Text = "";
                richTextBoxHtml.Text = "";
                markdownFormattedText = string.Empty;
                GC.Collect();
            }
            catch { }
        }
    }
}
