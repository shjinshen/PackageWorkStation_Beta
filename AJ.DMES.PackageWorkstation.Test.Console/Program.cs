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
                IApplicationContext applicationContext = ContextRegistry.GetContext();
                IModelManager modelManager =
                    (IModelManager)applicationContext.GetObject("ModelManager");
                Model model = new Model()
                {
                    ModelName = "Test",
                    Description = "ssssss"
                };

                modelManager.Save(model);
            }
            catch (Exception ex)
            { 
            
            }
        }
    }
}
