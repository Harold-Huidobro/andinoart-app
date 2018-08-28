using System;
using System.Collections.Generic;
using System.Text;

namespace Andinoart_app.Infrastructure
{
    using ViewModels;
    class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Contructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion

    }
}
