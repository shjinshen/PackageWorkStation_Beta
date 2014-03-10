using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: ModelInstanceManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 14:49:37
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public class ModelInstanceManager : IModelInstanceManager
    {

        public IRepository<ModelInstance> ModelInstanceRepository { get; set; }

        public object Save(Domain.ModelInstance entity)
        {
            return ModelInstanceRepository.Save(entity);
        }

        public void SaveOrUpdate(Domain.ModelInstance entity)
        {
            ModelInstanceRepository.SaveOrUpdate(entity);
        }

        public void Update(Domain.ModelInstance entity)
        {
            ModelInstanceRepository.Update(entity);
        }

        public Domain.ModelInstance Get(object id)
        {
            return ModelInstanceRepository.Get(id);
        }

        public void Delete(Domain.ModelInstance entity)
        {
            ModelInstanceRepository.Delete(entity);
        }

        public IList<Domain.ModelInstance> Find(string hql)
        {
            return ModelInstanceRepository.Find(hql);
        }
    }
}
