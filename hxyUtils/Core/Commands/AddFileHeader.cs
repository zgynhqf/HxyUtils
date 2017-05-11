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
    class AddFileHeader : Command
    {
        public AddFileHeader()
        {
            this.CommandID = new CommandID(GuidList.guidhxyUtilsCmdSet, PkgCmdIDList.cmdidAddFileHeaderCommand);
        }

        //protected override void InitializeCore()
        //{
        //    base.InitializeCore();

        //    //老是有问题，不如先注释了。
        //    //var documentEvents = base.DTE.Events.get_DocumentEvents(null);
        //    //documentEvents.DocumentSaved += document =>
        //    //{
        //    //    this.TryAddFileHeader(document, true);
        //    //};
        //}

        protected override void OnQueryStatus()
        {
            Document activeDocument = base.DTE.ActiveDocument;
            this.MenuCommand.Enabled = activeDocument != null;

            base.OnQueryStatus();
        }

        protected override void ExecuteCore()
        {
            Document activeDocument = base.DTE.ActiveDocument;
            if (activeDocument != null)
            {
                this.TryAddFileHeader(activeDocument, false);
            }
        }

        private void TryAddFileHeader(Document activeDoc, bool alert)
        {
            var textSelection = activeDoc.Selection as TextSelection;
            if (textSelection != null)
            {
                int absoluteCharOffset = textSelection.ActivePoint.AbsoluteCharOffset;
                textSelection.SelectAll();
                string text = textSelection.Text;
                textSelection.MoveToAbsoluteOffset(absoluteCharOffset, false);
                if (!text.Trim().StartsWith("/*") && alert)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("当前文档还没有添加文件头，是否立即添加文件头？", "hxyAddIn - 提示", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                string template = this.GetTemplate();
                textSelection.StartOfDocument(false);
                textSelection.Insert(template, 1);
                textSelection.StartOfDocument(false);
                textSelection.FindText("$end$", 0);
                textSelection.Delete(1);
            }
        }

        private string GetTemplate()
        {
            var grid = Package.GetDialogPage(typeof(FileHeaderTemplateOptionPage)) as FileHeaderTemplateOptionPage;
            var template = grid.FileHeaderTemplate;

            string timeValue = DateTime.Now.ToString("yyyyMMdd HH:mm");
            var todayValue = DateTime.Now.ToString("yyyyMMdd");
            var value = template.Replace("$Now$", timeValue).Replace("$Today$", todayValue);
            return value;
        }
    }
}
