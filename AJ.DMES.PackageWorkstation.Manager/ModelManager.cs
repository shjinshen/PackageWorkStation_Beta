using AJ.DMES.PackageWorkstation.Domain;
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
             ModelRepository.SaveOrUpdate(entity);
        }

        public void Update(Domain.Model entity)
        {
            ModelRepository.Update(entity);
        }

        public Domain.Model Get(object id)
        {
            return ModelRepository.Get(id);
            
       }

        /// <summary>
        /// 根据Model的名称（DPN）获得Model对象
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public Model Get(string modelName)
        {
            string hql = string.Format("from Model where ModelName = '{0}'", modelName);
            return ModelRepository.Get(hql);
        }

        public void Delete(Domain.Model entity)
        {
            ModelRepository.Delete(entity);
        }

        public IList<Domain.Model> Find(string hql)
        {
            return ModelRepository.Find(hql);
        }

        public IList<Domain.Model> GetAllModels()
        {
             List<Domain.Model> lstModels= (List<Domain.Model>)Find("from Model");
               return lstModels;
          
        }

        public IList<Domain.Model> QuerySomeModel(Domain.Model p_model)
        {
            string hql = "from Model m  where 1=1 ";
            string where = "";
            if(!String.IsNullOrEmpty(p_model.CPN))
            {
                where +=string.Format( " and m.CPN like '%{0}%' ",p_model.CPN);
            }

            if(!string.IsNullOrEmpty(p_model.ModelName))
            {
             where+=string.Format("  and m.ModelName  like '%{0}%' ",p_model.ModelName);
            }

            if(p_model.Customer!=null)
            {
                where += string.Format(" and m.Customer.Id='{0}'",p_model.Customer.Id.ToString());
            }

            return Find(hql+where);
        }
    }
}
