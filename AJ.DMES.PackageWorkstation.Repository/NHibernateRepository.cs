using Spring.Data.NHibernate.Generic.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: NHibernateRepository
*Description:
*Author: Jinshen
*Creation Time: 2014/3/7 9:22:19
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Repository
{
    public class NHibernateRepository<T> : HibernateDaoSupport,IRepository<T>
    {

        public object Save(T entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public void Update(T entity)
        {
            this.HibernateTemplate.Update(entity);
        }

        public T Get(object id)
        {
            return this.HibernateTemplate.Get<T>(id);
        }

        public void Delete(T entity)
        {
            this.HibernateTemplate.Delete(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        public IList<T> Find(string hql)
        {
            return this.HibernateTemplate.Find<T>(hql);
        }
    }
}
