using QRTest.Model;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QRTest.Forms
{
    public partial class PrintForm : Form
    {
        float xppi = 100;
        QrPanel[] Qrs;
        int Columns { get => (int)this.numericColumns.Value; }
        float LeftMargin { get => (float)this.numericRightMargin.Value * xppi; }
        float RightMargin { get => (float)this.numericLeftMargin.Value * xppi; }

        Graphics Canvas;

        public PrintForm(QrPanel[] qrs)
        {
            Qrs = qrs;
            InitializeComponent();
            printDocument1.PrintPage += HandlePrint;
            Canvas = printPreviewControl1.CreateGraphics();
            DrawAllQrs(Canvas);
        }

        void HandlePrint(object sender, PrintPageEventArgs e)
        {
            DrawAllQrs(e.Graphics);
        }

        void DrawAllQrs(Graphics canvas)
        {
            canvas.Clear(Color.White);
            int x = 0;
            int y = 0;
            foreach (var qr in Qrs)
            {
                for (int i = 0; i < qr.PrintCopies; i++)
                {
                    DrawQr(qr, canvas, x, y);
                    x++;
                    if (x >= Columns)
                    {
                        x = 0;
                        y++;
                    }
                }
            }
            printPreviewControl1.Document = printDocument1;
        }

        void DrawQr(QrPanel qrPanel, Graphics canvas, int column, int row)
        {
            float pageWidth = 820;
            float pageHeight = 1056;
            float rowGutter = ((float)numericBottomPadding.Value + (float)numericTopPadding.Value) * xppi;
            float rowHeight = 64;

            float ePageWidth = pageWidth - LeftMargin - RightMargin;
            float colWidth = ePageWidth / Columns;

            float scale = (float)numericScale.Value;
            float imageWidth = qrPanel.DrawableImage.Width * scale;
            float imageHeight = qrPanel.DrawableImage.Height * scale;
            int xPos = (int)LeftMargin +
                       (int)Math.Round(column * colWidth);

            int yPos = (int)Math.Round(row * (rowHeight + rowGutter));
            canvas.DrawImage(qrPanel.DrawableImage, new Rectangle(xPos, yPos, (int)imageWidth, (int)imageHeight));

            xPos += (int)imageWidth + 6;
            Font printFont = new Font("Calibri", (float)numericFontSize.Value);

            float frac = imageHeight / 3.5f;

            yPos += 6;
            canvas.DrawString(qrPanel.DrawableText1, printFont, Brushes.Black, new Point(xPos, yPos));

            //HACK ALERT: hardcoded 'SN' characters here!!
            yPos += (int)frac;
            canvas.DrawString("SN"+qrPanel.DrawableText2, printFont, Brushes.Black, new Point(xPos, yPos));

            yPos += (int)frac;
            canvas.DrawString(qrPanel.DrawableText3, printFont, Brushes.Black, new Point(xPos, yPos));
        }

        private void buttonPrint_Click(object sender, System.EventArgs e)
        {
            var dialog = this.printDialog1;
            dialog.ShowNetwork = true;
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var printSettings = this.printDocument1.PrinterSettings;
                printDocument1.Print();
            }
        }

        private void numericFontSize_ValueChanged(object sender, EventArgs e)
        {
            DrawAllQrs(Canvas);
        }

        private void numericScale_ValueChanged(object sender, EventArgs e)
        {
            DrawAllQrs(Canvas);
        }

        private void numericColumns_ValueChanged(object sender, EventArgs e)
        {
            DrawAllQrs(Canvas);
        }

        private void numericBottomPadding_ValueChanged(object sender, EventArgs e)
        {
            DrawAllQrs(Canvas);
        }

        private void numericTopPadding_ValueChanged(object sender, EventArgs e)
        {
            DrawAllQrs(Canvas);
        }
    }
}
