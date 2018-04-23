using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraRichEdit;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.API.Native;

namespace CreateReportFromRichEdit {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            OpenDocumentAndShowReport();
        }

        void OpenDocumentAndShowReport() {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    if (openFileDialog1.OpenFile() != null) {
                        using (RichEditDocumentServer reds = new RichEditDocumentServer()) {
                            reds.LoadDocument(openFileDialog1.FileName);

                            using (XtraReport1 report = new XtraReport1()) {
                                report.RichText.Rtf = reds.RtfText;
                                report.ShowPreviewDialog();
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
    }
}
