/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20130415 18:39
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130415 18:39
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace hxyUtils
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("386395C3-DEC2-433C-88C8-98DA3DA1C37C")]
    public class FileHeaderTemplateOptionPage : DialogPage
    {
        public FileHeaderTemplateOptionPage()
        {
            this.FileHeaderTemplate = @"/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：$Today$
 * 说明：此文件只包含一个类，具体内容见类型注释。$end$
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 $Now$
 * 
*******************************************************/

";
        }

        [Category("hxy")]
        [DisplayName("文件头模板")]
        [Description("文件头模板")]
        public string FileHeaderTemplate { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                var page = new EditHeaderTemplateControl();
                page.OptionsPage = this;
                page.Initialize();
                return page;
            }
        }
    }
}
