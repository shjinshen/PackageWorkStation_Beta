using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: SpringContext
*Description:Spring的初始化类，启动程序时需要调用，在使用时只需要调用Get()方法填入调用的类名
*Author: Jinshen
*Creation Time: 2014/3/10 10:50:05
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.UI.Wpf.Helpers
{
    public class SpringContext
    {
        private static bool isInit = false;

        public static bool IsInit
        {
            get
            {
                return isInit;
            }
        }

        private static IApplicationContext context;

        public static IApplicationContext Context
        {
            get
            {
                if (!isInit)
                {
                    Init();
                }
                return context;
            }
        }

        public static void Init()
        {
            context = ContextRegistry.GetContext();
            isInit = true;
        }

        public static object GetObject(string objectName)
        {
            if (!isInit) Init();
            return context.GetObject(objectName);
        }
    }
}
