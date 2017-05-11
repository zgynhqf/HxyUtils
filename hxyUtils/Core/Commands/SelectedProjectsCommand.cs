﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20130416
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130416 12:26
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace hxyUtils.Commands
{
    abstract class SelectedProjectsCommand : Command
    {
        protected override void OnQueryStatus()
        {
            this.MenuCommand.Enabled = base.DTE.SelectedItems.Count > 0;

            base.OnQueryStatus();
        }

        protected override void ExecuteCore()
        {
            var projects = new List<Project>();

            foreach (SelectedItem item in base.DTE.SelectedItems)
            {
                var project = item.Project;
                if (project == null)
                {
                    project = item.ProjectItem.ContainingProject;
                }

                if (!projects.Contains(project))
                {
                    projects.Add(project);
                }
            }

            this.ExecuteOnProject(projects);
        }

        protected abstract void ExecuteOnProject(IList<Project> projects);
    }
}
