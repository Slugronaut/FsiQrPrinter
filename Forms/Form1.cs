using QRCoder;
using QRTest.Forms;
using QRTest.Model;
using SAOT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QRTest
{
    /*
     * ALSTOM AVELIA FORMATTING
    * 00000606881-B-SN09-KR002_M_DR_130_G_001-04/2021-1
    * HS#-B-KR002_M_DR_XXX_G_001-MM/YYY-Weight Kilos
    * 
    */
    public partial class Form1 : Form
    {
        //Some singleton black magic! beware!!!
        private static Form1 Instance { get; set; }
        public static QRCodeGenerator.ECCLevel EccLevel { get => (QRCodeGenerator.ECCLevel)Instance.comboECCLevel.SelectedIndex; }
        List<QrPanel> QrPrintList = new List<QrPanel>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            Instance = this;
            InitializeComponent();
            this.payloadControl1.Copies = 3;

            foreach (var ecc in Enum.GetNames(typeof(QRCodeGenerator.ECCLevel)))
                comboECCLevel.Items.Add(ecc);

            comboECCLevel.SelectedItem = QRCodeGenerator.ECCLevel.Q.ToString();
            this.payloadControl1.ButtonGenerateClicked += OnGenerateQrClicked;

            Config.LoadConfig();
            ImportFormatterSpreadsheets();
        }

        /// <summary>
        /// 
        /// </summary>
        void ImportFormatterSpreadsheets()
        {
            string fileName = "";
            int setCount = int.Parse(Config.ReadConfigStr("DataSetCount"));
            try
            {
                for (int i = 0; i < setCount; i++)
                {
                    fileName = Config.ReadConfigStr("DataSet" + i);
                    var formatter = new QrFormatterModel(Path.Combine(Config.AppPath, fileName), "Sheet1");
                    payloadControl1.AddFormatter(formatter);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to read the file '{fileName}'.\n\n{e.Message}");
                Environment.Exit(1);
            }
        }

        void OnDeleteQrPanel(Object sender, EventArgs e)
        {
            var qrPanel = sender as QrPanel;
            qrPanel.DeleteQrClicked -= OnDeleteQrPanel;
            this.panel1.Controls.Remove(qrPanel);
            this.QrPrintList.Remove(qrPanel);
            qrPanel.Dispose();
        }

        private void OnGenerateQrClicked(object sender, EventArgs e)
        {
            var qrModel = payloadControl1.GenerateQrModel();
            var newQrPanel = new QrPanel(qrModel)
            {
                PrintCopies = this.payloadControl1.Copies,
            };
            newQrPanel.DeleteQrClicked += OnDeleteQrPanel;
            this.panel1.Controls.Add(newQrPanel);
            this.QrPrintList.Add(newQrPanel);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboECCLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void generateControl1_Load(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(QrPrintList == null || QrPrintList.Count < 1)
            {
                MessageBox.Show(this, "There are no QRs to print.");
                return;
            }
            using (var dialog = new PrintForm(QrPrintList.ToArray()))
                dialog.ShowDialog(this);
        }
    }
}
