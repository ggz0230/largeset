using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditCard
{
    public class Card
    {
        public string Name { get; set; }
        /// <summary>
        /// 总额度
        /// </summary>
        public decimal TotalQuota { get; set; }
        /// <summary>
        /// 已用额度
        /// </summary>
        public decimal UsedQuota { get; set; }
        /// <summary>
        /// 剩余
        /// </summary>
        public decimal SurplusQuota { get; set; }
        /// <summary>
        /// 账单日 每月几号
        /// </summary>
        public int StatementDate { get; set; }
    }
}
