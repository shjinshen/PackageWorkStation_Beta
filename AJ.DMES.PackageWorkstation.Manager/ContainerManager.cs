using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: ContainerManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 13:25:44
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public class ContainerManager : IContainerManager
    {
        public IRepository<Container> ContainerRepository { get; set; }

        public object Save(Domain.Container entity)
        {
            return ContainerRepository.Save(entity);
        }

        public void SaveOrUpdate(Domain.Container entity)
        {
            ContainerRepository.SaveOrUpdate(entity);
        }

        public void Update(Domain.Container entity)
        {
            ContainerRepository.Update(entity);
        }

        public Domain.Container Get(object id)
        {
            return ContainerRepository.Get(id);
        }

        public void Delete(Domain.Container entity)
        {
            ContainerRepository.Delete(entity);
        }

        public IList<Domain.Container> Find(string hql)
        {
            return ContainerRepository.Find(hql);
        }

        /// <summary>
        /// 获取数据库中是否存在已经封箱的SN号
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public bool IsSNExist(string sn)
        {
            string hql = string.Format("from Container where ContainerSN='{0}' and ContainerStatus=2", sn);
            return ContainerRepository.Get(hql) != null;
        }

        public Container Get(string sn)
        {
            string hql = string.Format("from Container where ContainerSN='{0}'", sn);
            return ContainerRepository.Get(hql);
        }
    }
}
