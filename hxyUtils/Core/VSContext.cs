using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace hxyUtils
{
    public abstract class VSContext
    {
        protected internal hxyUtilsPackage Package { get; internal set; }

        protected internal IServiceProvider ServiceProvider
        {
            get { return this.Package; }
        }

        protected DTE DTE
        {
            get { return this.GetService(typeof(DTE)) as DTE; }
        }

        protected object GetService(Type type)
        {
            return this.ServiceProvider.GetService(type);
        }

        //protected void ShowMessageBox(string title, string content)
        //{
        //    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
        //    Guid clsid = Guid.Empty;
        //    int result;
        //    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
        //        0,
        //        ref clsid,
        //        title,
        //        content,
        //        //string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
        //        string.Empty,
        //        0,
        //        OLEMSGBUTTON.OLEMSGBUTTON_OK,
        //        OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
        //        OLEMSGICON.OLEMSGICON_INFO,
        //        0,        // false
        //        out result));
        //}
    }
}
