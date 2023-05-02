using System.Collections.Generic;

namespace QRTest.Model
{
    /// <summary>
    /// Represents a single entry in a QrFormatterModel table. This will
    /// contain all of the relevant information for creating a qr tag
    /// given a project and module id.
    /// </summary>
    public class QrFormatterFieldModel
    {
        public string FieldId { get => GetFieldValue("Id"); }
        public readonly QrFormatterModel Formatter;
        Dictionary<string, string> Ids = new Dictionary<string, string>();

        public QrFormatterFieldModel(QrFormatterFieldModel other)
        {
            Formatter = other.Formatter;
            foreach (var kv in other.Ids)
                Ids[kv.Key] = kv.Value;
        }

        public QrFormatterFieldModel(QrFormatterModel formatter, string[] fieldHeaders)
        {
            Formatter = formatter;
            foreach (var name in fieldHeaders)
                Ids[name] = string.Empty;
        }

        /// <summary>
        /// Given a column header id, returns the associated value for this field.
        /// </summary>
        /// <param name="colHeader"></param>
        /// <returns></returns>
        public string GetFieldValue(string colHeader)
        {
            return Ids[colHeader];
        }

        /// <summary>
        /// Sets the value for a given column header id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void SetFieldValue(string id, string value)
        {
            if (!Ids.ContainsKey(id))
                throw new KeyNotFoundException($"The key '{id}' does not exist in the dictionary.");
            Ids[id] = value;
        }

        /// <summary>
        /// Fills out the 'blanks' of a formatted string using this field's set of mapped values.
        /// This wil not fill all fields (such as serial or quantity values) but rather just the
        /// ones that are known to this object as well as the date.
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        public string FillFormattedString(string rawText)
        {
            foreach (var kv in Ids)
                rawText = rawText.Replace("{" + kv.Key + "}", kv.Value);

            return rawText;
        }
    }
}
