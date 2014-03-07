using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Manager;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJ.DMES.PackageWorkstation.Test.Console
{
    class Program
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");

        static void Main(string[] args)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                //读取spring的配置文件
                IApplicationContext applicationContext = ContextRegistry.GetContext();
                //实例化一个IModelManager对象
                IModelManager modelManager =
                    (IModelManager)applicationContext.GetObject("ModelManager");
                //新建一个Model的实体，这里不需要建ID，ID会由底层分配一个Guid
                Model model = new Model()
                {
                    ModelName = "TestModel1",
                    Description = "Just for test"
                };
                //保存
                modelManager.Save(model);

            }
            catch (Exception ex)
            { 
            
            }
        }
    }
}
