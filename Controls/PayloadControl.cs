using QRCoder;
using QRTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QRTest
{
    public partial class PayloadControl : UserControl
    {

        public event EventHandler ComboSelectedIndexChanged;
        public event EventHandler TextBoxPayLoadTextChanged;
        public event EventHandler NumericValueChanged;
        public event EventHandler ButtonGenerateClicked;

        List<QrFormatterModel> Formatters = new List<QrFormatterModel>();

        public ComboBox FormatterCombo { get => this.comboFormatterList; }
        public ComboBox FormatterFieldCombo { get => this.comboFormatterFieldIdList; }
        public QrFormatterModel SelectedFormatterModel { get => Formatters[FormatterCombo.SelectedIndex]; }
        public QrFormatterFieldModel SelectedFormatterField { get => SelectedFormatterModel.FieldById(SelectedFormatterFieldId); }
        
        public decimal Copies { get => numericUpDown1.Value; set => numericUpDown1.Value = value; }
        public string FormattingStr { get => textPayload.Text; set => textPayload.Text = value; }
        public int SelectedFormatterFieldIndex { get => comboFormatterFieldIdList.SelectedIndex; set => comboFormatterFieldIdList.SelectedIndex = value; }
        public string SelectedFormatterFieldId { get => comboFormatterFieldIdList.Text; }
        public int SelectedFormatterIndex
        {
            get => FormatterCombo.SelectedIndex;
            set
            {
                FormatterCombo.SelectedIndex = value;
                OnSelectFormatter(null, null);
            }
        }
        public string SelectedFormatterId { get => FormatterCombo.Text; }


        public PayloadControl()
        {
            InitializeComponent();
            this.radioPreset.CheckedChanged += radioPreset_CheckedChanged;
            this.FormatterFieldCombo.Validating += OnValidating;
            this.FormatterCombo.SelectedIndexChanged += OnSelectFormatter;

        }

            

        /// <summary>
        /// Returns a new QrModel based on this controls selected parameters.
        /// </summary>
        /// <returns></returns>
        public QrModel GenerateQrModel()
        {
            return new QrModel(SelectedFormatterField);
        }

        void OnSelectFormatter(Object sender, EventArgs args)
        {
            int index = FormatterCombo.SelectedIndex;
            if (index < 0) return;
            var formatter = Formatters[index];
            FormatterFieldCombo.Items.AddRange(formatter.Fields.Select(x => x.FieldId).ToArray());
            FormatterFieldCombo.SelectedIndex = 0;
            FormattingStr = formatter.QrPayloadFormat;
        }

        /// <summary>
        /// Adds a new selectedable formatter to this control's available list.
        /// </summary>
        /// <param name="formatter"></param>
        public void AddFormatter(QrFormatterModel formatter)
        {
            Formatters.Add(formatter);
            FormatterCombo.Items.Add(formatter.DataSetId);
            if(FormatterCombo.Items.Count < 0 || FormatterCombo.Items.Count >= Formatters.Count)
                FormatterCombo.SelectedIndex = 0;
        }
        
        /// <summary>
        /// Ensures that any text typed into the box only matches something that exists within the drop-down list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnValidating(Object sender, CancelEventArgs e)
        {
            string currText = FormatterFieldCombo.Text;

            List<string> allowed = new List<string>();
            for(int i = 0; i < FormatterFieldCombo.Items.Count; i++)
            {
                var item = FormatterFieldCombo.Items[i];
                allowed.Add(FormatterFieldCombo.GetItemText(item));
            }
            if(!allowed.Contains(currText))
            {
                e.Cancel = true;
                MessageBox.Show(this, $"The value '{currText} is not a valid choice.");
                return;
            }
        }

        private void textPayload_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioPreset_CheckedChanged(object sender, EventArgs e)
        {
            var check = this.radioPreset;
            if (check != null)
            {
                textPayload.ReadOnly = check.Checked;
                comboFormatterFieldIdList.Enabled = check.Checked;
            }
        }

        private void comboPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboSelectedIndexChanged?.Invoke(sender, e);
        }

        private void textPayload_TextChanged_1(object sender, EventArgs e)
        {
            TextBoxPayLoadTextChanged?.Invoke(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericValueChanged?.Invoke(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonGenerateClicked?.Invoke(sender, e);
        }
    }
}
