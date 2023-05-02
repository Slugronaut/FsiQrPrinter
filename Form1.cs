using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRTest
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> ShipmentTables = new Dictionary<string, string>();
        Dictionary<string, ModInfo> AveliaStdShipment = new Dictionary<string, ModInfo>();

        class ModInfo
        {
            public string ModNumber;
            public string HS;
            public string FullKelox;
            public string Desc;
            public double Wt;
        }

        public Form1()
        {
            InitializeComponent();

            foreach (var ecc in Enum.GetNames(typeof(QRCodeGenerator.ECCLevel)))
                comboECCLevel.Items.Add(ecc);

            comboECCLevel.SelectedItem = QRCodeGenerator.ECCLevel.Q.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        void ReadTable(string fileName)
        {

        }

        private void CreateTag(string tableId, string itemId)
        {
            /*
            //string payload = GenrateAlstomPayload(tableId, itemId);
            pictureBox1.Image = GenerateQRImage(payload, 1, (QRCodeGenerator.ECCLevel)(comboECCLevel.SelectedIndex));// (int)scale);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="auxData"></param>
        /// <returns></returns>
        QrPanel GenerateQRPanel(string payload, QRCodeGenerator.ECCLevel eccLevel, string auxData)
        {
            var panel = new QrPanel();
            panel.SuspendLayout();

            panel.DescLabel = "Description";
            panel.SnLabel = "Serial No.";
            panel.IdLabel = "Item ID";
            panel.Picture.Image = GenerateQRImage(payload, 1, eccLevel);

            panel.ResumeLayout();
            return panel;
        }

        
        string GenerateAlstomPayload(string tableId, string itemId, int serialNumber)
        {
            return null;
            /*
             * 00000606881-B-SN09-KR002_M_DR_130_G_001-04/2021-1
             * HS#-B-KR002_M_DR_XXX_G_001-MM/YYY-Weight Kilos
             * 
             */
            //string table = ShipmentTable.TryGetValue(tableId)
            //string output = $"00000606881-B-SN{serialNumber}-KR002_M_DR_{itemId}_G_001-04/2021-1";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newQrPanel = GenerateQRPanel("Test", (QRCodeGenerator.ECCLevel)this.comboECCLevel.SelectedIndex, "");
            this.panel1.Controls.Add(newQrPanel);
        }

        public string GenerateQRCode(string qrText, int ppm = 20, QRCodeGenerator.ECCLevel ecc = QRCodeGenerator.ECCLevel.Q)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(qrText, ecc);
            PngByteQRCode pngByteQRCode = new PngByteQRCode(qRCodeData);
            byte[] qrCodeBytes = pngByteQRCode.GetGraphic(ppm);
            string qrCodeString = Convert.ToBase64String(qrCodeBytes);
            return qrCodeString;
        }

        public Bitmap GenerateQRImage(string qrText, int ppm = 20, QRCodeGenerator.ECCLevel ecc = QRCodeGenerator.ECCLevel.Q)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(qrText, ecc);
            PngByteQRCode pngByteQRCode = new PngByteQRCode(qRCodeData);
            byte[] qrCodeBytes = pngByteQRCode.GetGraphic(ppm);
            Bitmap bm;
            using (var ms = new MemoryStream(qrCodeBytes))
            {
                bm = new Bitmap(ms);
            }
            return bm;
        }
    }
}
