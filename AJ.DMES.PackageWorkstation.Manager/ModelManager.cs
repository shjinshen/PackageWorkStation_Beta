﻿using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: ModelManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/7 14:03:28
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public class ModelManager : IModelManager
    {
        public IRepository<Model> ModelRepository { get; set; }

        public object Save(Domain.Model entity)
        {
            return ModelRepository.Save(entity);
        }

        public void SaveOrUpdate(Domain.Model entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Model entity)
        {
            throw new NotImplementedException();
        }

        public Domain.Model Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Model entity)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Model> Find(string hql)
        {
            throw new NotImplementedException();
        }
    }
}