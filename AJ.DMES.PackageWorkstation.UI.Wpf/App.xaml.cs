using AJ.DMES.PackageWorkstation.UI.Wpf.Helpers;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;

namespace AJ.DMES.PackageWorkstation.UI.Wpf
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Start(() => base.OnStartup(e));
        }
        public static void Start(Action baseStart)
        {
            LoadPlugins();
            ThemeManager.ApplicationThemeName = Theme.MetropolisDark.Name;
            baseStart();
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(200));
            SetCultureInfo();
            //初始化Spring
            SpringContext.Init();
        }
        #region LoadPlugins
        static void LoadPlugins()
        {
            foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "DevExpress.RealtorWorld.Xpf.Plugins.*.exe"))
            {
                Assembly plugin = Assembly.LoadFrom(file);
                if (plugin == null) continue;
                Type entry = plugin.GetType("Global.Program");
                if (entry == null) continue;
                MethodInfo start = entry.GetMethod("Start", BindingFlags.Static | BindingFlags.Public, null, new Type[] { }, null);
                if (start == null) continue;
                start.Invoke(null, new object[] { });
            }
        }
        #endregion
        static void SetCultureInfo()
        {
            CultureInfo demoCI = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            demoCI.NumberFormat.CurrencySymbol = "$";
            Thread.CurrentThread.CurrentCulture = demoCI;
            CultureInfo demoUI = (CultureInfo)Thread.CurrentThread.CurrentUICulture.Clone();
            demoUI.NumberFormat.CurrencySymbol = "$";
            Thread.CurrentThread.CurrentUICulture = demoUI;
        }
    }
}
