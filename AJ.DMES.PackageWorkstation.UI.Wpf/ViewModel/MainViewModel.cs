using DevExpress.Xpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;


/***************************************************************************
*Class Name: MainViewModel
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 13:24:43
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.UI.Wpf.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OnViewLoadedCommand { get; private set; }
        public MainViewModel()
        {
            OnViewLoadedCommand = new DelegateCommand(OnNavigateDetailsCommandExecute);
        }

        void OnNavigateDetailsCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("HomeView", null, this);
        }
    }
}
