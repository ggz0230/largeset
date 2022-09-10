using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Encrypt.EncryptByAES("123456", "12345678900000001234567890000000");
            Console.WriteLine(str);


            var dd = Encrypt.DecryptByAES("87b00a7fc59ff0966c00718bc9973531", "12345678900000001234567890000000");
            Console.WriteLine(dd);

            Console.ReadKey();
        }


        private static string GetSNwhere(string str)
        {
            var arr = str.Split(",");
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
            {

                var st = item.Split("-");
                if (st.Count() == 1)
                {
                    sb.Append($" fsn = '{st[0]}' or ");
                }
                else
                {
                    sb.Append($" ( fsn>='{st[0]}' and fsn<='{st[1]}' ) or ");
                }
            }
            string sql = sb.ToString();
            return $"({sql.Substring(0, sql.Length - 3)})";
        }


        /// <summary>
        /// 合并连号
        /// </summary>
        /// <param name="strs">需要合并的字符串集合(字符串可以包含字母，但是后缀必须是数字)</param>
        /// <param name="connector">连接符 - , </param>
        /// <returns></returns>
        public static string MergeSerialNumber(List<string> strs, string connector)
        {
            if (strs == null || strs.Count == 0) return "";
            if (strs.Count == 1) return strs[0];
            string first = strs[0];
            int notintindex = -1;//字母的最后一个索引
            string qianzui = "";//包含字母的前缀
            for (int i = first.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(first[i].ToString(), out _))
                {

                }
                else
                {
                    notintindex = i;
                    break;
                }
            }
            if (notintindex != -1)
            {
                qianzui = first.Substring(0, notintindex + 1);
                strs = strs.Select(q => q.Substring(notintindex + 1)).ToList();
            }
            return MergeSerialNumber(strs, connector, qianzui);
        }

        /// <summary>
        /// 合并连号
        /// </summary>
        /// <param name="strs">可转换为long的字符串集合</param>
        /// <param name="connector">连接符号</param>
        /// <param name="qianzui">前缀（包含非数字的）</param>
        /// <returns></returns>
        public static string MergeSerialNumber(List<string> strs, string connector, string qianzui)
        {
            List<long> list = list = strs.Select(q => long.Parse("1" + q)).OrderBy(q => q).ToList();//防止前面为0 加前缀哨兵1

            long start = list[0];
            long end = start;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < list.Count; i++)
            {
                if (end + 1 == list[i])
                {
                    end = list[i];
                    if (i == list.Count - 1)
                    {
                        //最后一个
                        sb.Append($",{qianzui}{start.ToString().Substring(1)}{connector}{qianzui}{end.ToString().Substring(1)}");
                    }
                }
                else
                {
                    sb.Append(",");
                    if (start == end)
                    {
                        sb.Append(qianzui);
                        sb.Append(end.ToString().Substring(1));//减前缀哨兵1
                    }
                    else
                    {
                        sb.Append(qianzui);
                        sb.Append(start.ToString().Substring(1));
                        sb.Append(connector);
                        sb.Append(qianzui);
                        sb.Append(end.ToString().Substring(1));
                    }
                    start = list[i];
                    end = list[i];
                    if (i == list.Count - 1)
                    {
                        //最后一个
                        sb.Append($",{end.ToString().Substring(1)}");
                    }
                }
            }
            return sb.ToString().Substring(1);
        }

        /// <summary>
        /// 拆分连号（比如输入0821033922-0821033924 支持包含非数字的但后缀必须是数字，输出集合0821033922、0821033923、0821033924）
        /// </summary>
        /// <param name="str">0821033925   0821033922-0821033923</param>
        /// <returns></returns>
        public static List<string> SpiitSerialNumber(string str, string connector)
        {
            var res = new List<string>();
            if (string.IsNullOrWhiteSpace(str)) return res;
            if (str.Contains(connector))
            {
                var arr = str.Split(connector);
                string first = arr[0];
                int notintindex = -1;//字母的最后一个索引
                string qianzui = "";//包含字母的前缀
                for (int i = first.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(first[i].ToString(), out _))
                    {

                    }
                    else
                    {
                        notintindex = i;
                        break;
                    }
                }
                long start = 0, end = 0;
                if (notintindex != -1)
                {
                    qianzui = first.Substring(0, notintindex + 1);
                    start = long.Parse("1" + arr[0].Substring(notintindex + 1));
                    end = long.Parse("1" + arr[1].Substring(notintindex + 1));
                }
                else
                {
                    start = long.Parse("1" + arr[0]);
                    end = long.Parse("1" + arr[1]);
                }
                return SpiitSerialNumber(start, end, qianzui);
            }
            else
            {
                res.Add(str);
            }
            return res;
        }

        /// <summary>
        /// 拆分连号
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="qianzui">前缀</param>
        /// <returns></returns>
        private static List<string> SpiitSerialNumber(long start, long end, string qianzui)
        {
            var res = new List<string>();

            for (long i = start; i <= end; i++)
            {
                res.Add(qianzui + i.ToString().Substring(1));//减前缀哨兵1
            }

            return res;
        }


        public static bool CheckSql(string str)
        {
            return Regex.IsMatch(str.ToLower(), "/response|group_concat|cmd|sysdate|xor|declare|db_name|char| and| or|truncate| asc| desc|drop |table|count|from|select|insert|update|delete|union|into|load_file|outfile/");
        }

        public static List<string> GetNos(string no)
        {
            //DN-5842到DN-5851
            List<string> res = new List<string>();
            if (no.IndexOf('到') < -1)
            {
                res.Add(no);
            }
            else
            {
                string[] strs = no.Split('到');
                int s = strs[0].LastIndexOf('-') + 1;
                string qianzui = strs[0].Substring(0, s);
                int start = int.Parse(strs[0].Substring(s));

                int e = strs[1].LastIndexOf('-') + 1;
                int end = int.Parse(strs[1].Substring(e));
                for (int i = start; i <= end; i++)
                {
                    res.Add(qianzui + i.ToString());
                }
            }
            return res;
        }

        public static List<int> GetIds(string strIds)
        {
            if (string.IsNullOrWhiteSpace(strIds)) return new List<int>();
            return strIds.Split(",").Select(q => int.Parse(q)).ToList();
        }

        public static string GetIds(List<string> ids)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ids)
            {
                sb.Append("'");
                sb.Append(item);
                sb.Append("'");
                sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }

        public static string GetNo(string no)
        {
            string qianzui = DateTime.Now.ToString("yyMMdd");
            if (!string.IsNullOrWhiteSpace(no) && no.StartsWith(qianzui))
            {
                return qianzui + PrefixPatch0((int.Parse(no.Substring(6, 3)) + 1).ToString(), 3);
            }
            else
            {
                return qianzui + "001";
            }
        }

        public static string PrefixPatch0(string str, int nums)
        {
            while (str.Length < nums)
            {
                str = "0" + str;
            }
            return str;
        }

    }

    public class MyTest
    {
        public string No { get; set; }
    }

    public class MyClass
    {
        public DateTime GetWeekStartTime()
        {
            DateTime dt = DateTime.Now;
            int dayOfWeek = -1 * (int)dt.Date.DayOfWeek;
            //Sunday = 0,Monday = 1,Tuesday = 2,Wednesday = 3,Thursday = 4,Friday = 5,Saturday = 6,

            DateTime weekStartTime = dt.AddDays(dayOfWeek + 1);//取本周一
            if (dayOfWeek == 0) //如果今天是周日，则开始时间是上周一
            {
                weekStartTime = weekStartTime.AddDays(-7);
            }

            return weekStartTime.Date;
        }

    }

}
