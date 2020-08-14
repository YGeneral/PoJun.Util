using System.ComponentModel;

namespace PoJun.Util.Webs.Clients
{
    /// <summary>
    /// 内容类型
    /// </summary>
    public enum HttpContentType
    {
        /// <summary>
        /// application/x-www-form-urlencoded(FormUrlEncodedContent)
        /// </summary>
        [Description("application/x-www-form-urlencoded")]
        FormUrlEncoded,

        /// <summary>
        /// application/json(StringContent)
        /// </summary>
        [Description("application/json")]
        Json,

        /// <summary>
        /// multipart/form-data(MultipartFormDataContent)
        /// </summary>
        [Description("multipart/form-data")]
        FormData,

        /// <summary>
        /// binary(StreamContent)
        /// </summary>
        [Description("binary")]
        Binary,
    }
}
