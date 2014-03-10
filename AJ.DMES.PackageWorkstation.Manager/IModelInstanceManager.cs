using AJ.DMES.PackageWorkstation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: IModelInstanceManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 14:48:28
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public interface IModelInstanceManager
    {
        object Save(ModelInstance entity);
        void SaveOrUpdate(ModelInstance entity);
        void Update(ModelInstance entity);
        ModelInstance Get(object id);
        void Delete(ModelInstance entity);
        IList<ModelInstance> Find(string hql);
    }
}
