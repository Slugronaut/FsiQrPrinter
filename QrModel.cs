using System;
using System.Drawing;

namespace QRTest.Model
{
    /// <summary>
    /// The state of a single instance of a QR and all of it's associated formatting and input values.
    /// </summary>
    public class QrModel
    {
        public readonly QrFormatterFieldModel QrField;
        public QrFormatterModel Formatter { get => QrField.Formatter; }
        public string FieldId { get => QrField.FieldId; }
        public string SerialNumber { get; set; }
        public uint Quantity { get; set; }
        public string FormattedPayloadString { get => FillFormattedString(Formatter.QrPayloadFormat); }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qrFormatterField"></param>
        /// <param name="defaultSerial"></param>
        /// <param name="defaultQty"></param>
        public QrModel(QrFormatterFieldModel qrFormatterField, string defaultSerial = "1", uint defaultQty = 1)
        {
            QrField = qrFormatterField;
            SerialNumber = defaultSerial;
            Quantity = defaultQty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        public string FillFormattedString(string rawText)
        {
            rawText = QrField.FillFormattedString(rawText);

            string monthMM = DateTime.Now.Month.ToString("00");
            string yearYYYY = DateTime.Now.Year.ToString("0000");
            rawText = rawText.Replace("{MM}", monthMM);
            rawText = rawText.Replace("{YYYY}", yearYYYY);

            rawText = rawText.Replace("{Qty}", Quantity.ToString());
            if (!string.IsNullOrEmpty(SerialNumber))
                rawText = rawText.Replace("{SerialNumber}", SerialNumber);

            return rawText;
        }
    }
}
