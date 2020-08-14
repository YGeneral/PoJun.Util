using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace PoJun.Util.ModelValidation
{
    /// <summary>
	/// 密码强度检查
	/// 创建人：杨江军
	/// 创建时间：2020/8/13/星期四 13:12:17
	/// </summary>
	public class PasswordStrengthCheckAttribute : ValidationAttribute
    {
        /// <summary>
        /// 参数验证
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pwd = value as string;

            if (pwd.Length <= 6)
                return new ValidationResult("密码过短，至少需要6个字符！");

            // 必须包含数字 必须包含小写或大写字母 必须包含特殊符号 至少6个字符，最多30个字符
            var regex = new Regex(@"(?=.*[0-9])(?=.*[a-zA-Z])(?=([\x21-\x7e]+)[^a-zA-Z0-9]).{6,30}", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            if (!regex.Match(pwd).Success)
                return new ValidationResult("密码强度值不够，密码必须包含数字，必须包含小写或大写字母，必须包含至少一个特殊符号，至少6个字符，最多30个字符！");

            return ValidationResult.Success;
        }
    }
}
