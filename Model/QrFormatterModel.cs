using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QRTest.Model
{
    /// <summary>
    /// A table of id-keyed values that are used to generate QrModels from a single id.
    /// These values are imported from a spreadsheet and meant to be used as a quick lookup
    /// for all relevant data for a given project and module.
    /// </summary>
    public class QrFormatterModel
    {
        public string DataSetId { get; private set; }
        public string QrPayloadFormat { get; private set; } //used to format datapoint info into the qr payload string
        public string TextLinesFormat { get; private set; } //used to format data that goes into the textboxes next to the qr image
        public List<QrFormatterFieldModel> Fields = new List<QrFormatterFieldModel>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetId"></param>
        public QrFormatterModel(string filePath, string sheetId = "Sheet1")
        {
            ImportExcelDataReader(filePath, sheetId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetId"></param>
        public void ImportFastExcel(string filePath, string sheetId = "Sheet1")
        {
            var fileInfo = new System.IO.FileInfo(filePath);

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(fileInfo))
            {
                int rowCount = 0;
                var sheet = fastExcel.Read(sheetId);
                var rows = sheet.Rows;
                foreach (var row in rows)
                {
                    var cells = row.Cells.ToArray();

                    //the very first row is just the headers
                    if (rowCount == 0)
                    {
                        rowCount++;
                        continue;
                    }

                    //the second row contains just two datapoints: the set id and the formatting string
                    if (rowCount == 1)
                    {
                        var setIdCell = cells[0];
                        var formatCell = cells[1];

                        this.DataSetId = setIdCell.Value as string;
                        this.QrPayloadFormat = formatCell.Value as string;
                        rowCount++;
                        continue;
                    }

                    //all subsiquent rows are just data points
                    var idCell = cells[0];//row.GetCellByColumnName("Id");
                    var descCell = cells[1];
                    var internCell = cells[2];
                    var custCell = cells[3];
                    var massCell = cells[4];

                    /*
                    DataPoint newPoint = new DataPoint()
                    {
                        Id = idCell.Value as string,
                        Desc = descCell.Value as string,
                        InternalFullId = internCell.Value as string,
                        CustomerFullId = custCell.Value as string,
                        MassKilos = massCell.Value as string,
                    };
                    Points.Add(newPoint);
                    */
                    rowCount++;
                }
            }
        }

        /// <summary>
        /// Imports a spreadsheet containing all exported SAP materials list for a project.
        /// </summary>
        /// <param name="filePath"></param>
        public void ImportExcelDataReader(string filePath, string sheetId = "Sheet1")
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    //we are only going to read the first sheet
                    while (reader.Name != sheetId)
                        reader.NextResult();

                    if (reader.Name == sheetId)
                    {
                        Console.WriteLine("Valid materials sheet found. Importing material data now...");
                        List<string> headers = new List<string>(reader.FieldCount);
                        QrFormatterFieldModel template = null;
                        int rowCount = 0;
                        while (reader.Read())
                        {

                            if (rowCount == 0)
                            {
                                //this is just the header for column titles
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string s = string.Empty;
                                    try
                                    {
                                        s = reader.GetString(i);
                                    }
                                    catch (Exception e)
                                    {
                                        //eat it
                                    }
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        headers.Add(s);
                                    }
                                }
                                template = new QrFormatterFieldModel(this, headers.ToArray());
                                rowCount++;
                                continue;
                            }

                            if (rowCount == 1)
                            {
                                //meta data
                                this.DataSetId = reader.GetString(0);
                                this.QrPayloadFormat = reader.GetString(1);
                                this.TextLinesFormat = reader.GetString(2);
                                rowCount++;
                                continue;
                            }

                            //read column data for this row
                            QrFormatterFieldModel field = new QrFormatterFieldModel(template);
                            for (int i = 0; i < headers.Count; i++)
                                try
                                {
                                    field.SetFieldValue(headers[i], reader.GetString(i));
                                }
                                catch (Exception e1)
                                {
                                    try
                                    {
                                        field.SetFieldValue(headers[i], reader.GetDouble(i).ToString());
                                    }
                                    catch (Exception e2)
                                    {
                                        throw e2;
                                    }
                                }

                            Fields.Add(field);
                            rowCount++;
                        }
                        Console.WriteLine("... material sheet import complete.");
                    }
                    else
                    {
                        throw new Exception("No valid material spreadsheet could be found. Please be sure that all information is contained on a sheet entitled 'Sheet1' and that the following columns exist:\n\tComponent number\n\tDocument / Drawing\n\tObject description\n\tUn\n\tMatl Group");
                    }
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idValue"></param>
        /// <returns></returns>
        public QrFormatterFieldModel FieldById(string idValue)
        {
            foreach (var field in Fields)
            {
                if (field.FieldId == idValue)
                    return field;
            }

            return null;
        }
    }
}
