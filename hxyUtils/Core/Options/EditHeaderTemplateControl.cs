/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20130415 18:47
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130415 18:47
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hxyUtils
{
    public partial class EditHeaderTemplateControl : UserControl
    {
        public EditHeaderTemplateControl()
        {
            InitializeComponent();
        }

        internal FileHeaderTemplateOptionPage OptionsPage;

        public void Initialize()
        {
            textBox1.Text = OptionsPage.FileHeaderTemplate;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            OptionsPage.FileHeaderTemplate = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OptionsPage.FileHeaderTemplate = textBox1.Text;
        }
    }
}
