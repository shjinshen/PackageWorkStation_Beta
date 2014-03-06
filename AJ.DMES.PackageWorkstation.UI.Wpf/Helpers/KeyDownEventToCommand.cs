using System;
using System.Windows.Input;
using DevExpress.Xpf.Mvvm.UI;

namespace AJ.DMES.PackageWorkstation.UI.Wpf.Helpers
{
    public class KeyDownEventToCommand : EventToCommand {
        public Key Key { get; set; }

        protected override void OnEvent(object eventArgs) {
            KeyEventArgs keyEventArgs = eventArgs as KeyEventArgs;
            if(keyEventArgs != null && keyEventArgs.Key == Key)
                base.OnEvent(eventArgs);
        }
    }
}
