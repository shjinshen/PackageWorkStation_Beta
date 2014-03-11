using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: Model
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 15:15:47
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Domain
{
    public class Model : Entity
    {
        public virtual string ModelName { get; set; } //厂内产品物料号

        public virtual string Description { get; set; }//物料描述

        public virtual string CPN { get; set; }//客户提供的物料号

        public virtual Customer Customer { get; set; }//产品对应的客户

        public virtual string Reservation_1 { get; set; }

        public virtual string Reservation_2 { get; set; }

        public virtual string Reservation_3 { get; set; }

        public virtual string Reservation_4 { get; set; }

        public virtual string Reservation_5 { get; set; }
    }
}
