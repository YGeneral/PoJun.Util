using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PoJun.Util.Helpers
{
    /// <summary>
	/// 执行CMD
	/// 创建人：杨江军
	/// 创建时间：2020/8/13/星期四 13:49:01
	/// </summary>
	public class RunCmd
    {
        private Process proc = null;
        /// <summary>
        /// 执行CMD
        /// </summary>
        public RunCmd()
        {
            proc = new Process();
        }

        /// <summary>
        /// 执行CMD命令
        /// </summary>
        /// <param name="cmd"></param>
        public void Exe(string cmd)
        {
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            // proc.OutputDataReceived += new DataReceivedEventHandler(sortProcess_OutputDataReceived);
            proc.Start();
            StreamWriter cmdWriter = proc.StandardInput;
            proc.BeginOutputReadLine();
            if (!System.String.IsNullOrEmpty(cmd))
            {
                cmdWriter.WriteLine(cmd);
            }
            cmdWriter.Close();
            proc.Close();
        }


        private void sortProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!System.String.IsNullOrEmpty(e.Data))
            {
                //this.BeginInvoke(new Action(() => { this.listBox1.Items.Add(e.Data); }));
            }
        }
    }
}
