using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QRTest
{
    public class DataSet
    {
        public class DataPoint
        {
            public string Id;              //fast reference id - used as lookup into the dataset's list of datapoints
            public string Desc;            //description of the item
            public string InternalFullId;  //complete item id for internal use
            public string CustomerFullId;  //complete item id for customer
            public string MassKilos;       //mass of the item in kilos
        }

        public string DataSetId { get; private set; }
        public string DataFormatting { get; private set; } //used to format datapoint info into the payload string
        public List<DataPoint> Points = new List<DataPoint>();
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetId"></param>
        public DataSet(string filePath, string sheetId = "Sheet1")
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
                        this.DataFormatting = formatCell.Value as string;
                        rowCount++;
                        continue;
                    }

                    //all subsiquent rows are just data points
                    var idCell = cells[0];//row.GetCellByColumnName("Id");
                    var descCell = cells[1];
                    var internCell = cells[2];
                    var custCell = cells[3];
                    var massCell = cells[4];

                    DataPoint newPoint = new DataPoint()
                    {
                        Id = idCell.Value as string,
                        Desc = descCell.Value as string,
                        InternalFullId = internCell.Value as string,
                        CustomerFullId = custCell.Value as string,
                        MassKilos = massCell.Value as string,
                    };
                    Points.Add(newPoint);
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
                        //var result = reader.AsDataSet();
                        Dictionary<string, int> columnMap = new Dictionary<string, int>();
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
                                    catch(Exception e)
                                    {
                                        //eat it
                                    }
                                    if(!string.IsNullOrEmpty(s))
                                        columnMap[s] = i;
                                }
                                rowCount++;
                                continue;
                            }

                            int idCol = columnMap["Id"];
                            int descCol = columnMap["Desc"];
                            int iidCol = columnMap["Internal Id"];
                            int cidCol = columnMap["Customer Id"];
                            int wtCol = columnMap["Wt"];

                            if (rowCount == 1)
                            {
                                //meta data
                                var setIdCell = reader.GetString(idCol);
                                var formatCell = reader.GetString(descCol);

                                this.DataSetId = setIdCell;
                                this.DataFormatting = formatCell;
                                rowCount++;
                                continue;
                            }



                            string id;
                            string desc;
                            string iid;
                            string cid;
                            string wt;

                            try
                            {
                                id = reader.GetString(idCol);
                                desc = reader.GetString(descCol);
                                iid = reader.GetString(iidCol);
                                cid = reader.GetString(cidCol);
                                wt = reader.GetDouble(wtCol).ToString();
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                            DataPoint newPoint = new DataPoint()
                            {
                                Id = id,
                                Desc = desc,
                                InternalFullId = iid,
                                CustomerFullId = cid,
                                MassKilos = wt,
                            };

                            Points.Add(newPoint);
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
        /// <param name="id"></param>
        /// <returns></returns>
        public DataPoint DataById(string id)
        {
            foreach(var dp in Points)
            {
                if (dp.Id == id)
                    return dp;
            }

            return null;
        }

    }
}
