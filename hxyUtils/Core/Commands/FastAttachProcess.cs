/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20130415 17:52
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130415 17:52
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.OLE.Interop;

namespace hxyUtils.Commands
{
    /// <summary>
    /// http://www.cnblogs.com/sss/archive/2010/04/01/1702408.html
    /// </summary>
    class FastAttachProcess : Command
    {
        public FastAttachProcess()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidFastAttachProcessCommand);
        }

        protected override void ExecuteCore()
        {
            var option = Package.GetDialogPage(typeof(HxyOptionGrid)) as HxyOptionGrid;
            var processName = option.FastAttachProcessName;
            if (string.IsNullOrEmpty(processName))
            {
                MessageBox.Show("请在选项配置中配置好需要快速附加的进程路径。");
                return;
            }

            processName = processName.ToLower();
            var names = processName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var dte = base.DTE;
            var debugger = dte.Debugger as Debugger2;
            foreach (Transport trans in debugger.Transports)
            {
                if (trans.Name == "Default")
                {
                    var processes = debugger.GetProcesses(trans, Environment.MachineName);

                    int count = 0;
                    foreach (Process2 process in processes)
                    {
                        var pName = process.Name.ToLower();
                        if (names.Any(n => pName.Contains(n)))
                        {
                            process.Attach2();
                            count++;
                            //process.Attach2("Native");
                        }
                    }

                    if (count == 0)
                    {
                        var msg = string.Format("没有找到路径中包含 {0} 的进程。", option.FastAttachProcessName);
                        MessageBox.Show(msg, "hxy");
                    }
                    else if (count > 1)
                    {
                        var msg = string.Format("一共附加了 {0} 个进程。", count);
                        MessageBox.Show(msg, "hxy");
                    }

                    break;
                }
            }
        }
    }
}
