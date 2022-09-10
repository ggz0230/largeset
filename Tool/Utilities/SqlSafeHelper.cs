using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public class SqlSafeHelper
    {

        public bool Check(string sql)
        {

            string keywords = "/| response | group_concat | cmd | sysdate | xor | declare | db_name | char | and | or | truncate | asc | desc | drop | table | count | from | select | insert | update | delete | union | into | load_file | outfile | if | case | when | then | end | like |/";

            bool b = Regex.IsMatch(sql, keywords, RegexOptions.IgnoreCase);

            return b;
        }

    }
}
