using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;

namespace hxyUtils
{
    public abstract class Command : VSContext
    {
        public CommandID CommandID { get; set; }

        private hxyMenuCommand _menuCommand;

        public MenuCommand MenuCommand
        {
            get
            {
                if (_menuCommand == null)
                {
                    _menuCommand = new hxyMenuCommand(this);
                    _menuCommand.BeforeQueryStatus += (o, e) => this.OnQueryStatus();
                }

                return _menuCommand;
            }
        }

        protected virtual void OnQueryStatus() { }

        protected abstract void ExecuteCore();

        internal void OnExecute(object sender, EventArgs e)
        {
            this.ExecuteCore();
        }

        internal void Initialize()
        {
            this.InitializeCore();
        }

        protected virtual void InitializeCore() { }
    }

    internal class hxyMenuCommand : OleMenuCommand
    {
        private Command _inner;

        public hxyMenuCommand(Command inner)
            : base(inner.OnExecute, inner.CommandID)
        {
            _inner = inner;
        }
    }
}
