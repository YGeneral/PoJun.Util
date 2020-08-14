using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PoJun.Util.ModelValidation
{
    /// <summary>
	/// XSS攻击验证
	/// 创建人：杨江军
	/// 创建时间：2020/8/13/星期四 11:13:05
	/// </summary>
	public class XSSAttribute : ValidationAttribute
    {
        #region 初始化

        /// <summary>
        /// xss过滤
        /// </summary>
        private readonly static HtmlSanitizer sanitizer = new HtmlSanitizer();

        #endregion

        /// <summary>
        /// 参数验证
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Html = value as string;
            var html = sanitizer.Sanitize(Html);
            if (html != value.ToString())
                return new ValidationResult("参数中存在XSS攻击脚本，请检查录入参数！");

            return ValidationResult.Success;
        }
    }
}
