using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.entity
{
    /// <summary>
    /// 网站-地区 最近一次的监控记录
    /// </summary>
    //[Table("NewestSizeArea")]
    public class SizeArea
    {
        public string Id { get; set; }

        /// <summary>
        /// 网站id
        /// </summary>
        public string SizeId { get; set; }
        /// <summary>
        /// 地区id
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 监控时间
        /// </summary>
        public DateTime MonitorTime { get; set; }
        /// <summary>
        /// 响应时间 单位：毫秒
        /// </summary>
        public int ResponseTime { get; set; }

        /// <summary>
        /// 状态 1：正常  2：异常
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 是否最新  1：是     0：否
        /// </summary>
        public int IsNewest { get; set; }

        /// <summary>
        /// 出错原因
        /// </summary>
        public string ErrorMsg { get; set; }

    }
}
