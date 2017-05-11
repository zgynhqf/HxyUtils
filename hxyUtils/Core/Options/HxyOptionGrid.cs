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
    [CLSCompliant(false), ComVisible(true)]
    public class HxyOptionGrid : DialogPage
    {
        //public HxyOptionGrid()
        //{
        //    this.FastAttachProcessName = "wpfclient.exe";
        //}

        [Category("hxy")]
        [DisplayName("快速附加进程名")]
        [Description("快速附加进程名或者路径。本字符串用于在进程全路径中搜索。")]
        public string FastAttachProcessName { get; set; }
    }
}
