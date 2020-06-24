using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// Class Name：【压缩解压类】
    /// Powered By：PoJun
    /// Create Date：2011-11-8
    /// </summary>
    public class ZipHelper
    {
        #region 压缩

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="outputDirectory">压缩文件输出目录【硬盘物理路径】</param>
        /// <param name="inputDirectory">待压缩的文件夹【硬盘物理路径】(最后不能带\或/)</param>
        /// <param name="zipName">压缩文件名称</param>
        /// <returns>压缩后的目录及文件名称</returns>
        public static string Zip(string outputDirectory, string inputDirectory, string zipName)
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            var _fileName = string.Format("{0}\\{1}", outputDirectory, zipName);
            FastZip fz = new FastZip();
            fz.CreateEmptyDirectories = true;
            fz.CreateZip(_fileName, inputDirectory, true, "");
            fz = null;
            return _fileName;

        }

        #endregion

        #region 解压文件

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="inputDirectory">待解压文件地址(硬盘物理路径)</param>
        /// <param name="outputDirectory">解压文件夹地址(硬盘物理路径)</param>
        public static bool UnZip(string inputDirectory, string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            ZipInputStream s = new ZipInputStream(System.IO.File.OpenRead(System.Web.HttpContext.Current.Server.MapPath(inputDirectory)));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(theEntry.Name);
                string fileName = Path.GetFileName(theEntry.Name);
                if (directoryName != System.String.Empty)
                {
                    Directory.CreateDirectory(outputDirectory + directoryName);
                }
                if (fileName != System.String.Empty)
                {
                    FileStream streamWriter = System.IO.File.Create(outputDirectory + theEntry.Name);
                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
            return true;
        }

        #endregion

    }
}
