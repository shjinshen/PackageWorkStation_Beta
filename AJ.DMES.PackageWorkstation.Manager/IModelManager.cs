using AJ.DMES.PackageWorkstation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: IModelManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/7 9:37:29
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public interface IModelManager
    {
        object Save(Model entity);
        void SaveOrUpdate(Model entity);
        void Update(Model entity);
        Model Get(object id);
        Model Get(string modelName);
        void Delete(Model entity);
        IList<Model> Find(string hql);
        IList<Domain.Model> QuerySomeModel(Domain.Model p_model);
         IList<Domain.Model> GetAllModels();
    }
}
