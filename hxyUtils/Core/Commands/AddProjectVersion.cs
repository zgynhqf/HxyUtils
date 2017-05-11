/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20130416
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130416 12:24
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
    class AddProjectVersion : SelectedProjectsCommand
    {
        public AddProjectVersion()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidAddProjectVersionCommand);
        }

        protected override void ExecuteOnProject(IList<Project> projects)
        {
            foreach (var project in projects)
            {
                var ver = project.Properties.Item("AssemblyVersion");
                var fileVer = project.Properties.Item("AssemblyFileVersion");

                AddBuildVersion(ver);
                AddBuildVersion(fileVer);
            }

            //project.Save();
            MessageBox.Show("版本号自增完成。");
        }

        private void AddBuildVersion(Property propery)
        {
            var value = propery.Value.ToString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                var ver = new Version(value);
                ver = new Version(ver.Major, ver.Minor, ver.Build + 1, ver.Revision);
                propery.Value = ver.ToString();
            }
        }
    }
}