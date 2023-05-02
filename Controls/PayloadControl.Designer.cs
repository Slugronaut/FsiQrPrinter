namespace QRTest
{
    partial class PayloadControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboFormatterList = new System.Windows.Forms.ComboBox();
            this.textPayload = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboFormatterFieldIdList = new System.Windows.Forms.ComboBox();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.radioPreset = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboFormatterList);
            this.groupBox1.Controls.Add(this.textPayload);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboFormatterFieldIdList);
            this.groupBox1.Controls.Add(this.radioCustom);
            this.groupBox1.Controls.Add(this.radioPreset);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR Payload";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Project Format";
            // 
            // comboFormatterList
            // 
            this.comboFormatterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFormatterList.FormattingEnabled = true;
            this.comboFormatterList.Location = new System.Drawing.Point(202, 19);
            this.comboFormatterList.Name = "comboFormatterList";
            this.comboFormatterList.Size = new System.Drawing.Size(215, 21);
            this.comboFormatterList.TabIndex = 15;
            // 
            // textPayload
            // 
            this.textPayload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPayload.Location = new System.Drawing.Point(124, 84);
            this.textPayload.Multiline = true;
            this.textPayload.Name = "textPayload";
            this.textPayload.ReadOnly = true;
            this.textPayload.Size = new System.Drawing.Size(293, 70);
            this.textPayload.TabIndex = 14;
            this.textPayload.TextChanged += new System.EventHandler(this.textPayload_TextChanged_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(51, 94);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Copies";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(6, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboFormatterFieldIdList
            // 
            this.comboFormatterFieldIdList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFormatterFieldIdList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFormatterFieldIdList.FormattingEnabled = true;
            this.comboFormatterFieldIdList.Location = new System.Drawing.Point(124, 57);
            this.comboFormatterFieldIdList.Name = "comboFormatterFieldIdList";
            this.comboFormatterFieldIdList.Size = new System.Drawing.Size(293, 21);
            this.comboFormatterFieldIdList.TabIndex = 7;
            this.comboFormatterFieldIdList.SelectedIndexChanged += new System.EventHandler(this.comboPresets_SelectedIndexChanged);
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Location = new System.Drawing.Point(6, 76);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(101, 17);
            this.radioCustom.TabIndex = 6;
            this.radioCustom.Text = "Custom Payload";
            this.radioCustom.UseVisualStyleBackColor = true;
            // 
            // radioPreset
            // 
            this.radioPreset.AutoSize = true;
            this.radioPreset.Checked = true;
            this.radioPreset.Location = new System.Drawing.Point(6, 58);
            this.radioPreset.Name = "radioPreset";
            this.radioPreset.Size = new System.Drawing.Size(96, 17);
            this.radioPreset.TabIndex = 5;
            this.radioPreset.TabStop = true;
            this.radioPreset.Text = "Preset Payload";
            this.radioPreset.UseVisualStyleBackColor = true;
            this.radioPreset.CheckedChanged += new System.EventHandler(this.radioPreset_CheckedChanged);
            // 
            // PayloadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PayloadControl";
            this.Size = new System.Drawing.Size(429, 166);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textPayload;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboFormatterFieldIdList;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.RadioButton radioPreset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboFormatterList;
    }
}
