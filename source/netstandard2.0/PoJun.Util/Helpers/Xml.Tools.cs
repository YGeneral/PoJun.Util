using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// Xml操作 - 工具
    /// </summary>
    public partial class Xml
    {
        /// <summary>
        /// 将Xml字符串转换为XDocument
        /// </summary>
        /// <param name="xml">Xml字符串</param>
        public static XDocument ToDocument(string xml)
        {
            return XDocument.Parse(xml);
        }

        /// <summary>
        /// 将Xml字符串转换为XElement列表
        /// </summary>
        /// <param name="xml">Xml字符串</param>
        public static List<XElement> ToElements(string xml)
        {
            var document = ToDocument(xml);
            if (document?.Root == null)
                return new List<XElement>();
            return document.Root.Elements().ToList();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="encoding">目前只支持utf8、ASCII、gb2312，且默认utf8</param>
        /// <returns></returns>
        public static string Serialize<T>(T obj, string encoding = "utf8")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            StringWriter writer;
            switch(encoding.ToLower())
            {                
                case "ascii":
                    writer = new StringASCIIWriter();
                    break;
                case "gb2312":
                    writer = new StringGB2312Writer();
                    break;
                case "utf8":
                default:
                    writer = new StringUTF8Writer();
                    break;
            }
            serializer.Serialize(writer, obj);
            string xml = writer.ToString();
            writer.Close();
            writer.Dispose();

            return xml;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);
            T result = (T)(serializer.Deserialize(reader));
            reader.Close();
            reader.Dispose();

            return result;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StringUTF8Writer : System.IO.StringWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StringASCIIWriter : System.IO.StringWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StringGB2312Writer : System.IO.StringWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.GetEncoding("GB2312"); }
        }
    }
}
