﻿using AJ.DMES.PackageWorkstation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: IContainerManager
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 13:22:33
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Manager
{
    public interface IContainerManager
    {
        object Save(Container entity);
        void SaveOrUpdate(Container entity);
        void Update(Container entity);
        Container Get(object id);
        /// <summary>
        /// 根据sn号获取外箱
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        Container Get(string sn);
        void Delete(Container entity);
        IList<Container> Find(string hql);
        bool IsSNExist(string sn);
    }
}
