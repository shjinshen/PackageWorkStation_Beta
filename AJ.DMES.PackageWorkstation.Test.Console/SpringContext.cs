using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: SpringContext
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 10:43:38
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Test.Console
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
