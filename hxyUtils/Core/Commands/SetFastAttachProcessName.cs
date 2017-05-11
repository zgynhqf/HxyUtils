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
    class SetFastAttachProcessName : FastAttachProcess
    {
        public SetFastAttachProcessName()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidSetFastAttachProcessNameCommand);
        }

        protected override void ExecuteCore()
        {
            var option = Package.GetDialogPage(typeof(HxyOptionGrid)) as HxyOptionGrid;
            var processName = option.FastAttachProcessName;

            var win = new SetFastAttachProcessNameWindow { FileName = processName };
            var res = win.ShowDialog();
            if (res == true)
            {
                option.FastAttachProcessName = win.FileName;
                option.SaveSettingsToStorage();

                base.ExecuteCore();
            }
        }
    }
}
