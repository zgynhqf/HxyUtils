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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EnvDTE;
using Microsoft.VisualStudio.OLE.Interop;

namespace hxyUtils.Commands
{
    class CreateDependency : Command
    {
        public CreateDependency()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidCreateDependencyCommand);
        }

        protected override void OnQueryStatus()
        {
            this.MenuCommand.Enabled = this.DTE.SelectedItems.Count == 2;

            base.OnQueryStatus();
        }

        protected override void ExecuteCore()
        {
            SelectedItem[] array = base.DTE.SelectedItems.OfType<SelectedItem>().ToArray();
            if (array.Length == 2)
            {
                ProjectItem projectItem = array[0].ProjectItem;
                ProjectItem projectItem2 = array[1].ProjectItem;
                string messageBoxText = string.Format("是否需要把 '{0}' 创建父子依赖，变为 '{1}' 的子文件?", projectItem.Name, projectItem2.Name);
                var messageBoxResult = MessageBox.Show(messageBoxText, "创建父子依赖", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    projectItem2.ProjectItems.AddFromFile(projectItem.get_FileNames(1));
                    projectItem2.ExpandView();
                }
            }
        }
    }
}
