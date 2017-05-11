/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20130327 16:06
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130327 16:06
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EnvDTE;
using Microsoft.VisualStudio.OLE.Interop;

namespace hxyUtils.Commands
{
    class DropDependency : Command
    {
        public DropDependency()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidDropDependencyCommand);
        }

        protected override void OnQueryStatus()
        {
            this.MenuCommand.Enabled = this.DTE.SelectedItems.Count == 1;

            base.OnQueryStatus();
        }

        protected override void ExecuteCore()
        {
            var array = base.DTE.SelectedItems.OfType<SelectedItem>().ToArray();
            if (array.Length == 1)
            {
                ProjectItem projectItem = array[0].ProjectItem;
                if (projectItem.ProjectItems.Count > 0)
                {
                    MessageBox.Show("该项下面还有子项，请先移除所有子项。", "提示");
                }
                else
                {
                    var res = MessageBox.Show("是否需要把移除父子依赖成为独立的文件？\r\n", "移除父子依赖", MessageBoxButton.OKCancel);
                    if (res == MessageBoxResult.OK)
                    {
                        string text = projectItem.get_FileNames(0);
                        string tempFileName = Path.GetTempFileName();
                        File.Copy(text, tempFileName, true);
                        Project containingProject = projectItem.ContainingProject;
                        projectItem.Delete();
                        if (!File.Exists(text))
                        {
                            File.Copy(tempFileName, text, true);
                        }
                        containingProject.ProjectItems.AddFromFile(text);
                    }
                }
            }
        }
    }
}