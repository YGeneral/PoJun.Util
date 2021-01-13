using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// 配置获取工具
    /// 创建人：杨江军
    /// 创建时间：2021/1/6/星期三 13:58:50
    /// </summary>
    public class ConfigurationManager
    {
        private static readonly object padlock = new object();

        /// <summary>
        /// 默认路径
        /// </summary>
        private static string _defaultPath = AppContext.BaseDirectory + "appsettings.json";

        /// <summary>
        /// 最终配置文件路径
        /// </summary>
        private static string _configPath = null;

        /// <summary>
        /// 配置节点关键字
        /// </summary>
        private static string _configSection = "AppSettings";

        /// <summary>
        /// 配置外连接的后缀
        /// </summary>
        private static string _configUrlPostfix = "Url";


        /// <summary>
        /// 配置外链关键词，例如：AppSettings.Url
        /// </summary>
        private static string _configUrlSection { get { return _configSection + "." + _configUrlPostfix; } }

        /// <summary>
        /// 
        /// </summary>
        static ConfigurationManager()
        {
            if (AppSettings == null)
            {
                lock (padlock)
                {
                    if (AppSettings == null)
                    {
                        ConfigFinder(_defaultPath);
                    }
                }
            }
        }

        /// <summary>
        /// 确定配置文件路径
        /// </summary>
        private static void ConfigFinder(string Path)
        {
            _configPath = Path;
            JObject config_json = new JObject();
            while (config_json != null)
            {
                config_json = null;
                FileInfo config_info = new FileInfo(_configPath);
                if (!config_info.Exists) break;

                config_json = LoadJsonFile(_configPath);
                if (config_json[_configUrlSection] != null)
                    _configPath = config_json[_configUrlSection].ToString();
                else break;
            }

            if (config_json == null || config_json[_configSection] == null) return;

            LoadConfiguration();
        }

        /// <summary>
        /// 读取配置文件内容
        /// </summary>
        private static void LoadConfiguration()
        {
            FileInfo config = new FileInfo(_configPath);
            var configColltion = new NameValueCollection();
            JObject config_object = LoadJsonFile(_configPath);
            if (config_object == null || !(config_object is JObject)) return;

            if (config_object[_configSection] != null)
            {
                foreach (JProperty prop in config_object[_configSection])
                {
                    configColltion[prop.Name] = prop.Value.ToString();
                }
            }

            AppSettings = configColltion;
        }

        /// <summary>
        /// 解析Json文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        private static JObject LoadJsonFile(string FilePath)
        {
            JObject config_object = null;
            try
            {
                StreamReader sr = new StreamReader(FilePath, Encoding.Default);
                config_object = JObject.Parse(sr.ReadToEnd());
                sr.Close();
            }
            catch { }
            return config_object;
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        public static NameValueCollection AppSettings { get; private set; } = null;
    }
}
