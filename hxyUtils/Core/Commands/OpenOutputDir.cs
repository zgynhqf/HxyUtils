/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20130415 19:26
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130415 19:26
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
using System.Windows.Controls;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.OLE.Interop;

namespace hxyUtils.Commands
{
    /// <summary>
    /// 打开 Debug 文件夹
    /// </summary>
    class OpenOutputDir : SelectedProjectsCommand
    {
        public OpenOutputDir()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidOpenDebugDirCommand);
        }

        protected override void ExecuteOnProject(IList<Project> projects)
        {
            foreach (var project in projects)
            {
                //https://social.msdn.microsoft.com/Forums/vstudio/zh-CN/03d9d23f-e633-4a27-9b77-9029735cfa8d/how-to-get-the-right-output-path-from-envdteproject-by-code-if-show-advanced-build?forum=vsx
                string fullPath = project.Properties.Item("FullPath").Value.ToString();
                string outputPath = project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();
                string outputDir = Path.Combine(fullPath, outputPath);

                //var path = project.FullName;
                //var outputDir = Path.Combine(Path.GetDirectoryName(path), "bin\\Debug\\");
                while (true)
                {
                    if (Directory.Exists(outputDir)) break;
                    outputDir = Path.GetDirectoryName(outputDir);
                }
                System.Diagnostics.Process.Start(outputDir);
            }
        }
    }
}
