using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = $"\\Upload\\cve\\{DateTime.Now.ToString("yyyyMMddHHmmssffff")}.xlsx";
            if (!Directory.Exists(fileName))
            {

                Directory.CreateDirectory(fileName);
            }


            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string filePath = "vulnerabilities_2020-11-30.xlsx";
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                DataSet result = null;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    result = reader.AsDataSet();
                }

                foreach (DataTable table in result.Tables)
                {
                    var title = table.TableName;
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        var item = table.Rows[i];
                        var No = item.ItemArray[1].ToString();
                        var DATE = item.ItemArray[2].ToString();
                        var CVSS = item.ItemArray[3].ToString();
                        var Description = item.ItemArray[4].ToString();
                        var References = item.ItemArray[5].ToString();
                        var Resolution = item.ItemArray[6].ToString();
                        var Status = item.ItemArray[7].ToString();
                        var Record = item.ItemArray[8].ToString();
                    }
                    foreach (DataRow item in table.Rows)
                    {
                        var c0 = item.ItemArray[0].ToString();
                        if (c0 == "#") continue;
                        var No = item.ItemArray[1].ToString();
                        var DATE = item.ItemArray[2].ToString();
                        var CVSS = item.ItemArray[3].ToString();
                        var Description = item.ItemArray[4].ToString();
                        var References = item.ItemArray[5].ToString();
                        var Resolution = item.ItemArray[6].ToString();
                        var Status = item.ItemArray[7].ToString();
                        var Record = item.ItemArray[8].ToString();

                    }

                }
            }

            Console.ReadKey();

        }

    }
}
