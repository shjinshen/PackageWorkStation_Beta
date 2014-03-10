using AJ.DMES.PackageWorkstation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: ICustomerManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 10:00:20
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public interface ICustomerManager
    {
        object Save(Customer entity);
        void SaveOrUpdate(Customer entity);
        void Update(Customer entity);
        Customer Get(object id);
        void Delete(Customer entity);
        IList<Customer> Find(string hql);
    }
}
