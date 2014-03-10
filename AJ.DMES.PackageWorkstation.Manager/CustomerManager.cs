using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: CustomerManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 9:59:57
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public class CustomerManager : ICustomerManager
    {
        public IRepository<Customer> CustomerRepository { get; set; }

        public object Save(Domain.Customer entity)
        {
            return CustomerRepository.Save(entity);
        }

        public void SaveOrUpdate(Domain.Customer entity)
        {
            CustomerRepository.SaveOrUpdate(entity);
        }

        public void Update(Domain.Customer entity)
        {
            CustomerRepository.Update(entity);
        }

        public Domain.Customer Get(object id)
        {
            return CustomerRepository.Get(id);
        }

        public void Delete(Domain.Customer entity)
        {
            CustomerRepository.Delete(entity);
        }

        public IList<Domain.Customer> Find(string hql)
        {
            return CustomerRepository.Find(hql);
        }
    }
}
