using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace DocxGeneratorForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateDocx(string fileName, int start, int end)
        {
            object oMissing = System.Reflection.Missing.Value;

            Word._Application app;
            Word._Document doc;
            app = new Word.Application();

            doc = app.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
            Word.Paragraph para;

            for (int i = start; i <= end; i++)
            {
                if (i > start)
                    doc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);

                para = doc.Content.Paragraphs.Add(ref oMissing);
                para.Range.Text = "2017年度部卫片" + i.ToString() + "号";
                para.Range.Font.Bold = 1;
                para.Range.Font.Size = 55;
                para.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                para.Range.InsertParagraphAfter();
            }

            doc.SaveAs2(fileName);
            app.Quit();
            this.lblMsg.Text = fileName;
        }

        private string GetFileName()
        {
            using (SaveFileDialog dlg = new SaveFileDialog() { Filter = "word文档|*.docx" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }
            return null;
        }

        private bool GetRange(out int start, out int end)
        {
            start = (int)this.numericUpDown1.Value;
            end = (int)this.numericUpDown2.Value;
            return start < end;
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            int start, end;
            this.btnGen.Enabled = false;
            try
            {
                if (!this.GetRange(out start, out end))
                    return;
                string fileName = this.GetFileName();
                if (string.IsNullOrWhiteSpace(fileName))
                    return;
                this.CreateDocx(fileName, start, end);
            }
            catch (Exception ex)
            {

                this.lblMsg.Text = ex.Message;
            }
            finally
            {
                this.btnGen.Enabled = true;
            }

        }
    }
}
