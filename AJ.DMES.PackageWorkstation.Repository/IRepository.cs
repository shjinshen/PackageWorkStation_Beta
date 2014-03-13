using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: IRepository
*Description:
*Author: Jinshen
*Creation Time: 2014/3/7 9:19:59
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Repository
{
    public interface IRepository<T>
    {
        object Save(T entity);
        void SaveOrUpdate(T entity);
        void Update(T entity);
        T Get(object id);
        T Get(string hql);
        void Delete(T entity);
        IList<T> Find(string hql);
    }
}
