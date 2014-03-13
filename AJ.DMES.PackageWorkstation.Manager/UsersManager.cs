using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJ.DMES.PackageWorkstation.Manager
{
    public class UsersManager : IUsersManager
    {
        public IRepository<Users> UsersRepository { get; set; }

        public object Save(Domain.Users entity)
        {
            return UsersRepository.Save(entity);
        }

        public void SaveOrUpdate(Domain.Users entity)
        {
            UsersRepository.SaveOrUpdate(entity);
        }

        public void Update(Domain.Users entity)
        {
            UsersRepository.Update(entity);
        }

        public Domain.Users Get(object id)
        {
            return UsersRepository.Get(id);
        }

        public void Delete(Domain.Users entity)
        {
            UsersRepository.Delete(entity);
        }

        public IList<Users> FindAll()
        {
            return UsersRepository.Find("FROM Users");
        }
        
        public IList<Users> Find(string hql)
        {
            return UsersRepository.Find(hql);
        }
        
        public IList<Users> FindSome(Users user)
        {
            string hql = "FROM Users u  WHERE 1=1 ";
            string where = "";
            if (user != null)
            {
                if (!String.IsNullOrEmpty(user.UserName))
                {
                    where += string.Format(" and u.UserName like '%{0}%' ", user.UserName);
                }

                if (!string.IsNullOrEmpty(user.RealName))
                {
                    where += string.Format("  and u.RealName  like '%{0}%' ", user.RealName);
                }

                if (!string.IsNullOrEmpty(user.Gender))
                {
                    where += string.Format("  and u.Gender  like '%{0}%' ", user.Gender);
                }

                if (!string.IsNullOrEmpty(user.Age))
                {
                    where += string.Format("  and u.Age  like '%{0}%' ", user.Age);
                }

                if (!string.IsNullOrEmpty(user.Phone))
                {
                    where += string.Format("  and u.Phone  like '%{0}%' ", user.Phone);
                }
            }
            return Find(hql + where);
        }
    }
}
