using DevExpress.Xpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;


/***************************************************************************
*Class Name: HomeViewModel
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 13:53:25
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.UI.Wpf.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateToPackageCommand { get; private set; }
        public ICommand NavigateToTraceabilityCommand { get; private set; }
        public ICommand NaviagteToModelCommand { get; private set; }
        public ICommand NavigateToWICommand { get; private set; }
        public ICommand NavigateToCustomerCommand { get; private set; }
        public ICommand NavigateToStatisticCommand { get; private set; }
        public ICommand NavigateToConfigCommand { get; private set; }
        public ICommand NavigateToUserCommand { get; private set; }

        public HomeViewModel()
        {
            NavigateToPackageCommand = new DelegateCommand(OnNavigateToPackageCommandExecute);
            NavigateToTraceabilityCommand = new DelegateCommand(OnNavigateToTraceabilityCommandExecute);
            NaviagteToModelCommand = new DelegateCommand(OnNavigateToModelCommandExecute);
            NavigateToWICommand = new DelegateCommand(OnNavigateToWiCommandExecute);
            NavigateToCustomerCommand = new DelegateCommand(OnNavigateToCustomerCommandExecute);
            NavigateToStatisticCommand = new DelegateCommand(OnNavigateToStatisticCommandExecute);
            NavigateToConfigCommand = new DelegateCommand(OnNavigateToConfigCommandExecute);
            NavigateToUserCommand = new DelegateCommand(OnNavigateToUserCommandExecute);
        }

        void OnNavigateToPackageCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("PackageOperationView", null, this);
        }

        void OnNavigateToTraceabilityCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("TraceabilityView", null, this);
        }

        void OnNavigateToModelCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("ModelView", null, this);
        }

        void OnNavigateToWiCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("WorkInstructionView", null, this);
        }

        void OnNavigateToCustomerCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("CustomerView", null, this);
        }

        void OnNavigateToStatisticCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("StatisticView", null, this);
        }

        void OnNavigateToConfigCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("ConfigurationView", null, this);
        }

        void OnNavigateToUserCommandExecute()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("UserManagementView", null, this);
        }
    }
}
