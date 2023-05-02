namespace QRTest.Forms
{
    partial class PrintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericRightMargin = new System.Windows.Forms.NumericUpDown();
            this.numericBottomMargin = new System.Windows.Forms.NumericUpDown();
            this.numericLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.numericTopMargin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericBottomPadding = new System.Windows.Forms.NumericUpDown();
            this.numericRightPadding = new System.Windows.Forms.NumericUpDown();
            this.numericLeftPadding = new System.Windows.Forms.NumericUpDown();
            this.numericTopPadding = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericScale = new System.Windows.Forms.NumericUpDown();
            this.numericColumns = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopMargin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottomPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopPadding)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericRightMargin);
            this.groupBox1.Controls.Add(this.numericBottomMargin);
            this.groupBox1.Controls.Add(this.numericLeftMargin);
            this.groupBox1.Controls.Add(this.numericTopMargin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Margins (inches)";
            // 
            // numericRightMargin
            // 
            this.numericRightMargin.DecimalPlaces = 4;
            this.numericRightMargin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericRightMargin.Location = new System.Drawing.Point(161, 46);
            this.numericRightMargin.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericRightMargin.Name = "numericRightMargin";
            this.numericRightMargin.Size = new System.Drawing.Size(64, 20);
            this.numericRightMargin.TabIndex = 17;
            // 
            // numericBottomMargin
            // 
            this.numericBottomMargin.DecimalPlaces = 4;
            this.numericBottomMargin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericBottomMargin.Location = new System.Drawing.Point(161, 20);
            this.numericBottomMargin.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericBottomMargin.Name = "numericBottomMargin";
            this.numericBottomMargin.Size = new System.Drawing.Size(64, 20);
            this.numericBottomMargin.TabIndex = 16;
            this.numericBottomMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericLeftMargin
            // 
            this.numericLeftMargin.DecimalPlaces = 4;
            this.numericLeftMargin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericLeftMargin.Location = new System.Drawing.Point(47, 46);
            this.numericLeftMargin.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericLeftMargin.Name = "numericLeftMargin";
            this.numericLeftMargin.Size = new System.Drawing.Size(64, 20);
            this.numericLeftMargin.TabIndex = 15;
            // 
            // numericTopMargin
            // 
            this.numericTopMargin.DecimalPlaces = 4;
            this.numericTopMargin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTopMargin.Location = new System.Drawing.Point(47, 20);
            this.numericTopMargin.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericTopMargin.Name = "numericTopMargin";
            this.numericTopMargin.Size = new System.Drawing.Size(64, 20);
            this.numericTopMargin.TabIndex = 14;
            this.numericTopMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bottom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Top";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericBottomPadding);
            this.groupBox2.Controls.Add(this.numericRightPadding);
            this.groupBox2.Controls.Add(this.numericLeftPadding);
            this.groupBox2.Controls.Add(this.numericTopPadding);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(252, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 79);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Padding (inches)";
            // 
            // numericBottomPadding
            // 
            this.numericBottomPadding.DecimalPlaces = 4;
            this.numericBottomPadding.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericBottomPadding.Location = new System.Drawing.Point(159, 20);
            this.numericBottomPadding.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericBottomPadding.Name = "numericBottomPadding";
            this.numericBottomPadding.Size = new System.Drawing.Size(64, 20);
            this.numericBottomPadding.TabIndex = 21;
            this.numericBottomPadding.Value = new decimal(new int[] {
            125,
            0,
            0,
            196608});
            this.numericBottomPadding.ValueChanged += new System.EventHandler(this.numericBottomPadding_ValueChanged);
            // 
            // numericRightPadding
            // 
            this.numericRightPadding.DecimalPlaces = 4;
            this.numericRightPadding.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericRightPadding.Location = new System.Drawing.Point(159, 46);
            this.numericRightPadding.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericRightPadding.Name = "numericRightPadding";
            this.numericRightPadding.Size = new System.Drawing.Size(64, 20);
            this.numericRightPadding.TabIndex = 20;
            this.numericRightPadding.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericLeftPadding
            // 
            this.numericLeftPadding.DecimalPlaces = 4;
            this.numericLeftPadding.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericLeftPadding.Location = new System.Drawing.Point(47, 46);
            this.numericLeftPadding.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericLeftPadding.Name = "numericLeftPadding";
            this.numericLeftPadding.Size = new System.Drawing.Size(64, 20);
            this.numericLeftPadding.TabIndex = 19;
            this.numericLeftPadding.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericTopPadding
            // 
            this.numericTopPadding.DecimalPlaces = 4;
            this.numericTopPadding.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTopPadding.Location = new System.Drawing.Point(47, 20);
            this.numericTopPadding.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericTopPadding.Name = "numericTopPadding";
            this.numericTopPadding.Size = new System.Drawing.Size(64, 20);
            this.numericTopPadding.TabIndex = 18;
            this.numericTopPadding.Value = new decimal(new int[] {
            125,
            0,
            0,
            196608});
            this.numericTopPadding.ValueChanged += new System.EventHandler(this.numericTopPadding_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Right";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bottom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Left";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Top";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.numericFontSize);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.numericScale);
            this.groupBox3.Controls.Add(this.numericColumns);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 53);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Layout";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Font Size";
            // 
            // numericFontSize
            // 
            this.numericFontSize.DecimalPlaces = 1;
            this.numericFontSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericFontSize.Location = new System.Drawing.Point(287, 20);
            this.numericFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericFontSize.Name = "numericFontSize";
            this.numericFontSize.Size = new System.Drawing.Size(58, 20);
            this.numericFontSize.TabIndex = 15;
            this.numericFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericFontSize.ValueChanged += new System.EventHandler(this.numericFontSize_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(120, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Scale";
            // 
            // numericScale
            // 
            this.numericScale.DecimalPlaces = 4;
            this.numericScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericScale.Location = new System.Drawing.Point(161, 19);
            this.numericScale.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericScale.Name = "numericScale";
            this.numericScale.Size = new System.Drawing.Size(64, 20);
            this.numericScale.TabIndex = 13;
            this.numericScale.Value = new decimal(new int[] {
            16,
            0,
            0,
            65536});
            this.numericScale.ValueChanged += new System.EventHandler(this.numericScale_ValueChanged);
            // 
            // numericColumns
            // 
            this.numericColumns.Location = new System.Drawing.Point(59, 19);
            this.numericColumns.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColumns.Name = "numericColumns";
            this.numericColumns.Size = new System.Drawing.Size(52, 20);
            this.numericColumns.TabIndex = 12;
            this.numericColumns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericColumns.ValueChanged += new System.EventHandler(this.numericColumns_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Columns";
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printPreviewControl1.Location = new System.Drawing.Point(12, 156);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(474, 309);
            this.printPreviewControl1.TabIndex = 10;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(411, 116);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 11;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 477);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.printPreviewControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrintForm";
            this.Text = "Print Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottomMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopMargin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottomPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopPadding)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.NumericUpDown numericColumns;
        private System.Windows.Forms.NumericUpDown numericRightMargin;
        private System.Windows.Forms.NumericUpDown numericBottomMargin;
        private System.Windows.Forms.NumericUpDown numericLeftMargin;
        private System.Windows.Forms.NumericUpDown numericTopMargin;
        private System.Windows.Forms.NumericUpDown numericBottomPadding;
        private System.Windows.Forms.NumericUpDown numericRightPadding;
        private System.Windows.Forms.NumericUpDown numericLeftPadding;
        private System.Windows.Forms.NumericUpDown numericTopPadding;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericScale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericFontSize;
    }
}