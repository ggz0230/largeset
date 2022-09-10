using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://info.paxsz.com/HR/Employee/PersonalFile.aspx?Source=HR确认&ID=6516";
            url = url.Replace("HR确认", "HR%C8%B7%C8%CF");
            //Server.UrlDecode
        }

        private static string FormatMoney(decimal? d)
        {
            if (d==null)
            {
                return "";
            }
            string str = d.Value.ToString("c").TrimStart('¥');
            if (str.EndsWith(".00"))
            {
                str = str.Substring(0, str.Length - 3);
            }
            return str;
        }

        protected static void CheckMaxLength(object model)
        {
            Type type1 = model.GetType();
            var fields = type1.GetProperties();
            foreach (PropertyInfo item in fields)
            {
                if (item.PropertyType.Name == "String")
                {
                    object[] attrubuteArray = item.GetCustomAttributes(typeof(MaxLengthAttribute), true);
                    if (attrubuteArray != null && attrubuteArray.Length > 0)
                    {
                        int length = ((MaxLengthAttribute)attrubuteArray[0]).Length;

                        string value = item.GetValue(model).ToString();
                        if (value.Length > length)
                        {
                            throw new Exception($"输入不符！{item.Name}字段字符长度过长，最多{length}个字符");
                        }
                    }
                }
            }
        }

    }

    public class LcdSampleModel
    {
        public int? Id { get; set; }
        /// <summary>
        ///尺寸
        /// </summary>
        [MaxLength(255)]
        public string Size { get; set; }

        /// <summary>
        ///长宽比
        /// </summary>
        [MaxLength(255)]
        public string AspectRatio { get; set; }

        /// <summary>
        ///玻璃尺寸
        /// </summary>
        public string GlassSize { get; set; }

        /// <summary>
        ///分辨率
        /// </summary>
        public string ResolutionRatio { get; set; }

        /// <summary>
        ///点间距
        /// </summary>
        public string PointSpacing { get; set; }

        /// <summary>
        ///显示类型/含制造工艺
        /// </summary>
        public string DisplayType { get; set; }

        /// <summary>
        ///驱动IC型号
        /// </summary>
        public string DriveICModel { get; set; }

        /// <summary>
        ///玻璃原厂料号
        /// </summary>
        public string GlassRawMaterialNo { get; set; }

        /// <summary>
        ///玻璃厂家
        /// </summary>
        public string GlassManufacturer { get; set; }

        /// <summary>
        ///测试结论：认证可用、生产可用、不适用
        /// </summary>
        public string TestConclusion { get; set; }

        /// <summary>
        ///测试文件id
        /// </summary>
        public int? DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentUrl { get; set; }


    }

}
