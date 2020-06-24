using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PoJun.Util.QrCoder
{
    /// <summary>
    /// 容错级别
    /// </summary>
    [Description("容错级别")]
    public enum ErrorCorrectionLevel
    {
        /// <summary>
        /// 可以纠正最大7%的错误
        /// </summary>
        [Description("可以纠正最大7%的错误")]
        L,

        /// <summary>
        /// 可以纠正最大15%的错误
        /// </summary>
        [Description("可以纠正最大15%的错误")]
        M,

        /// <summary>
        /// 可以纠正最大25%的错误
        /// </summary>
        [Description("可以纠正最大25%的错误")]
        Q,

        /// <summary>
        /// 可以纠正最大30%的错误
        /// </summary>
        [Description("可以纠正最大30%的错误")]
        H
    }
}
