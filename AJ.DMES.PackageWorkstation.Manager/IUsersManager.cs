using AJ.DMES.PackageWorkstation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJ.DMES.PackageWorkstation.Manager
{
    public interface IUsersManager
    {
        object Save(Users entity);
        void SaveOrUpdate(Users entity);
        void Update(Users entity);
        Users Get(object id);
        void Delete(Users entity);
        IList<Users> FindAll();
        IList<Users> Find(string hql);
        IList<Users> FindSome(Users user);
    }
}
