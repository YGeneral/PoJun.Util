using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PoJun.Util.QrCoder
{
    /// <summary>
    /// 二维码尺寸
    /// </summary>
    [Description("二维码尺寸")]
    public enum QrSize
    {
        /// <summary>
        /// 小
        /// </summary>
        [Description("小")]
        Small = 5,

        /// <summary>
        /// 中
        /// </summary>
        [Description("中")]
        Middle = 10,

        /// <summary>
        /// 大
        /// </summary>
        [Description("大")]
        Large = 20
    }
}
