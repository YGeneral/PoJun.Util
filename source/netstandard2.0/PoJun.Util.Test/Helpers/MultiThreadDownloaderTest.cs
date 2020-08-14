using PoJun.Util.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PoJun.Util.Test.Helpers
{
    /// <summary>
	/// 多线程后台下载测试
	/// 创建人：杨江军
	/// 创建时间：2020/8/13/星期四 11:54:59
	/// </summary>
	public class MultiThreadDownloaderTest
    {
        /// <summary>
        /// 多线程后台下载测试
        /// </summary>
        [Fact]
        public void TestDownloader()
        {
            //var mtd = new MultiThreadDownloader("https://attachments-cdn.shimo.im/yXwC4kphjVQu06rH/KeyShot_Pro_7.3.37.7z", Environment.GetEnvironmentVariable("temp"), "E:\\Downloads\\KeyShot_Pro_7.3.37.7z", 8);
            //mtd.Configure(req =>
            //{
            //    req.Referer = "https://masuit.com";
            //    req.Headers.Add("Origin", "https://baidu.com");
            //});
            //mtd.TotalProgressChanged += (sender, e) =>
            //{
            //    var downloader = sender as MultiThreadDownloader;
            //    Console.WriteLine("下载进度：" + downloader.TotalProgress + "%");
            //    Console.WriteLine("下载速度：" + downloader.TotalSpeedInBytes / 1024 / 1024 + "MBps");
            //};
            //mtd.FileMergeProgressChanged += (sender, e) =>
            //{
            //    Console.WriteLine("下载完成");
            //};
            //mtd.Start();//开始下载

            Assert.True(true);
        }
    }
}
