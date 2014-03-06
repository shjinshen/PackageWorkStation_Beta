using System;
using System.Windows;
using DevExpress.Xpf.Core;

namespace AJ.DMES.PackageWorkstation.UI.Wpf.View
{
    public partial class WaitWindow : Window, ISplashScreen {
        public WaitWindow() {
            InitializeComponent();
        }
        public void Progress(double value) { }
        public void CloseSplashScreen() { Close(); }
        public void SetProgressState(bool isIndeterminate) { }
    }
}
