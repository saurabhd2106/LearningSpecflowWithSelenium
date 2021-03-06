using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Utils
{
    public class ExcelDriver
    {
        public static DataTable ReadDataFromExcel(string filename, string sheetname)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            _ = filename.Trim();

            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader;

            if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
            {
                excelReader = ExcelReaderFactory.CreateReader(stream);

            }
            else
            {
                throw new Exception("Invalid File Type");
            }

            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            DataTableCollection allTables = result.Tables;

            DataTable dataTable = allTables[sheetname];

            return dataTable;
        }
    }
}
