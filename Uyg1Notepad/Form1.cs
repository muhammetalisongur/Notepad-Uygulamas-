using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uyg1Notepad
{
    public partial class Form1 : Form
    {
        bool acikDosyaVarmi = false;
        bool degisiklikVarmi = false;
        string acikDosyaAdi = "Bos";

        public Form1()
        {
            InitializeComponent();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarmi == false && degisiklikVarmi == false) //durum 1
            {
                DosyaAcmaIslemleri();
            }
            else if (acikDosyaVarmi == true && degisiklikVarmi == false) //durum 2
                DosyaAcmaIslemleri();
            else if (acikDosyaVarmi == false && degisiklikVarmi == true) //durum3
            {
                DialogResult mbb = MessageBox.Show("Notepad", "Degisiklikler Kaydedilsin mi?", MessageBoxButtons.YesNoCancel);
                if (mbb == DialogResult.No)
                    DosyaAcmaIslemleri();
                else if (mbb == DialogResult.Yes)
                {
                    SaveFileDialog sd = new SaveFileDialog();
                    DialogResult sdb = sd.ShowDialog();
                    if (sdb == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                        DosyaAcmaIslemleri();
                    }
                }
            }
            else if (acikDosyaVarmi == true && degisiklikVarmi==true)//durum4
            {
                DialogResult mbb = MessageBox.Show("Notepad", "Degisiklikler Kaydedilsin mi?",MessageBoxButtons.YesNoCancel);

            }

        }
        public void DosyaAcmaIslemleri()
        {
            OpenFileDialog od = new OpenFileDialog();
            DialogResult basilan = od.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                richTextBox1.Clear();
                acikDosyaAdi = od.FileName;
                acikDosyaVarmi = true;
                richTextBox1.LoadFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                degisiklikVarmi = false;

            }
        }

        //
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            degisiklikVarmi = true;
        }

        private void hakkindaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapistirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void sozcukKaydirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sozcukKaydirToolStripMenuItem.Checked = !sozcukKaydirToolStripMenuItem.Checked;
            richTextBox1.WordWrap = sozcukKaydirToolStripMenuItem.Checked;
        }

        private void yaziTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fs = new FontDialog();
            if (fs.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fs.Font;
            }
        }

        private void durumCubuguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            durumCubuguToolStripMenuItem.Checked = !durumCubuguToolStripMenuItem.Checked;
            statusStrip1.Visible = durumCubuguToolStripMenuItem.Checked;
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
