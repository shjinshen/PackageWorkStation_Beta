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
        string m_hql;

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

        public IList<Customer> FuzzySearch(Customer p_entity)
        {
            m_hql = "FROM Customer as c WHERE 1=1 ";
            if (p_entity != null)
            {
                if (p_entity.CustomerCode != null)
                {
                    m_hql += "And c.CustomerCode like '%" + p_entity.CustomerCode + "%' ";
                }
                if (p_entity.CustomerName != null)
                {
                    m_hql += "And c.CustomerName like '%" + p_entity.CustomerName + "%' ";
                }
                if (p_entity.Country != null)
                {
                    m_hql += "And c.Country like '%" + p_entity.Country + "%' ";
                }
                if (p_entity.ShortName != null)
                {
                    m_hql += "And c.ShortName like '%" + p_entity.ShortName + "%' ";
                }
                if (p_entity.Address != null)
                {
                    m_hql += "And c.Address like '%" + p_entity.Address + "%' ";
                }
                if (p_entity.Phone != null)
                {
                    m_hql += "And c.Phone like '%" + p_entity.Phone + "%' ";
                }
                if (p_entity.WebSite != null)
                {
                    m_hql += "And c.WebSite like '%" + p_entity.WebSite + "%'";
                }
            }
            return CustomerRepository.Find(m_hql);
        }
    }
}
