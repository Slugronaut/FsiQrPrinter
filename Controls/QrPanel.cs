using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QRCoder;
using QRTest.Model;

namespace QRTest
{
    public partial class QrPanel : UserControl
    {
        public decimal PrintCopies { get => this.numericCopiesToPrint.Value; set => this.numericCopiesToPrint.Value = value; }
        public decimal QrQty { get => this.numericQrQty.Value; set => this.numericQrQty.Value = value; }
        public PictureBoxInterpolation Picture { get => this.pictureBox1; set => this.pictureBox1 = value; }
        public event EventHandler DeleteQrClicked;
        public bool DisableViewPropogate;

        public readonly QrModel Model;

        #region Drawing Data
        public Image DrawableImage { get => Picture.Image; }
        public string DrawableText1 { get => textBox1.Text; }
        public string DrawableText2 { get => textBox2.Text; }
        public string DrawableText3 { get => textBox3.Text; }
        #endregion

        /// <summary>
        /// Only for use with the designer.
        /// </summary>
        public QrPanel()
        {
            InitializeComponent();
        }

        public QrPanel(QrModel qrModel)
        {
            InitializeComponent();
            Model = qrModel;
            Picture.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            DisableViewPropogate = true;
            UpdateViewsWithModel(Form1.EccLevel);
            DisableViewPropogate = false;
        }

        /// <summary>
        /// Updates this panel's UI controls based on the current state of the QrModel.
        /// </summary>
        /// <param name="field"></param>
        public void UpdateViewsWithModel(QRCodeGenerator.ECCLevel eccLevel)
        {
            if (Model == null) return;

            var formatter = Model.QrField.Formatter;
            var field = Model.QrField;// formatter.FieldById(Model.FieldId);
            textBoxItemId.Text = Model.FieldId;

            //TODO: split the TextLinesFormat string, find each named textline and parse for the corresponding field value
            var variables = formatter.TextLinesFormat.Split(',').Select(x => x.Trim());

            foreach(var variable in variables)
            {
                var pair = variable.Split('=').Select(x => x.Trim()).ToArray();
                if (pair.Length != 3)
                    throw new Exception($"The textline formatting for {field.FieldId} is invalid.\n\n{formatter.TextLinesFormat}.");

                bool locked = pair[2] == "locked";
                string value = pair[1];

                if (value == "SerialNumber")
                    value = Model.SerialNumber;
                else if (value == "MM")
                    value = DateTime.Now.Month.ToString("00");
                else if (value == "YYYY")
                    value = DateTime.Now.Year.ToString("0000");
                else
                    value = field.GetFieldValue(pair[1]);


                if (pair[0].ToUpper() == "TEXT1")
                {
                    this.textBox1.Text = value;
                    if (locked) textBox1.ReadOnly = true;
                }
                else if (pair[0].ToUpper() == "TEXT2")
                {
                    this.textBox2.Text = value;
                    if (locked) textBox2.ReadOnly = true;
                }
                else if (pair[0].ToUpper() == "TEXT3")
                {
                    this.textBox3.Text = value;
                    if (locked) textBox3.ReadOnly = true;
                }
            }

            string payloadStr = Model.FormattedPayloadString;
            //TODO: Apply any additional formatting inserts to payloadStr here if needed
            GenerateQr(payloadStr, eccLevel);
        }

        /// <summary>
        /// Updates the internal QrModel based on the state of this panel's UI controls.
        /// </summary>
        public void UpdateModelWithViews()
        {
            if (Model == null) return;
            
            var formatter = Model.QrField.Formatter;
            var field = Model.QrField;// formatter.FieldById(Model.FieldId);

            //TODO: split the TextLinesFormat string, find each named textline and parse for the corresponding field value
            var variables = formatter.TextLinesFormat.Split(',').Select(x => x.Trim());

            foreach (var variable in variables)
            {
                var pair = variable.Split('=').Select(x => x.Trim()).ToArray();
                if (pair.Length != 3)
                    throw new Exception($"The textline formatting for {field.FieldId} is invalid.\n\n{formatter.TextLinesFormat}.");

                bool locked = pair[2] == "locked";
                string value = pair[1];

                //if serial number, get the new value from the model
                if(value == "SerialNumber")
                {
                    string newSerial = string.Empty;
                    if (pair[0].ToUpper() == "TEXT1")
                        newSerial = this.textBox1.Text;
                    else if (pair[0].ToUpper() == "TEXT2")
                        newSerial = this.textBox2.Text;
                    else if (pair[0].ToUpper() == "TEXT3")
                        newSerial = this.textBox3.Text;

                    /*
                    uint output = 1;
                    if (uint.TryParse(newSerial, out output))
                        if (output < 1) output = 1;
                        else output = 1;

                    Model.SerialNumber = output.ToString();
                    */
                    Model.SerialNumber = newSerial;
                    Model.Quantity = (uint)this.numericQrQty.Value;
                    
                }

                
            }

            //just in case this affects the qr image, we actually need a feedback to update the view as well
            DisableViewPropogate = true;
            UpdateViewsWithModel(Form1.EccLevel);
            DisableViewPropogate = false;
        }

        /// <summary>
        /// Helper for generating a qr image for a given payload string.
        /// </summary>
        /// <param name="qrText"></param>
        /// <param name="ppm"></param>
        /// <param name="ecc"></param>
        /// <returns></returns>
        public static Bitmap GenerateQRImage(string qrText, int ppm = 20, QRCodeGenerator.ECCLevel ecc = QRCodeGenerator.ECCLevel.Q)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="eccLevel"></param>
        void GenerateQr(string payload, QRCodeGenerator.ECCLevel eccLevel)
        {
            Picture.Image = GenerateQRImage(payload, 1, eccLevel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        void UpdateIfControlIsTagged(Object sender)
        {
            if (DisableViewPropogate || Model == null) return;
            UpdateModelWithViews();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteQrClicked?.Invoke(this, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateIfControlIsTagged(sender);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateIfControlIsTagged(sender);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateIfControlIsTagged(sender);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            UpdateIfControlIsTagged(sender);
        }
    }
}
